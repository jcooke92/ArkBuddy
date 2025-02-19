﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using System.Threading;
using System.Reflection.Emit;
using System.Diagnostics;
using IniParser.Model;
using IniParser;
using System.IO;
using Serilog.Events;
using Serilog.Core;
using System.IO.Compression;

namespace ArkBuddy
{
    public partial class Form1: Form
    {
        public const string ARK_PROCESS_NAME = "ArkAscendedServer";
        public const string ARK_SERVER_EXE_PATH = "ShooterGame\\Binaries\\Win64\\ArkAscendedServer.exe";
        public const string STEAM_CMD_EXE = "steamcmd.exe";
        public const string STEAMD_CMD_PROCESS_NAME = "steamcmd";
        public const string RCON_PROCESS_NAME = "mcrcon";
        public const string ARK_CONFIG_PATH = "ShooterGame\\Saved\\Config\\WindowsServer";
        public const string ARK_SAVE_PATH = "ShooterGame\\Saved";
        public const int MAX_BACKUPS_TO_KEEP = 50;
        public static volatile bool autoStartUpdateEnabled = false;
        public static volatile bool autoBackupEnabled = false;
        public Color GOOD_COLOUR = Color.ForestGreen;
        public Color BAD_COLOUR = Color.Crimson;
        public Thread autoStartUpdateThread = null;

        public IniData serverConfigData = null;
        public const string INI_SERVER_SECTION = "ServerConfig";
        public const string INI_SERVER_NAME = "SessionName";
        public const string INI_SERVER_PASSWORD = "ServerPassword";
        public const string INI_SERVER_MAP = "Map";
        public const string INI_MODS_LIST = "Mods";
        public const string INI_BATTLEYE = "Battleye";
        public const string INI_SERVER_PORT = "Port";
        public const string INI_QUERY_PORT = "QueryPort";
        public const string INI_RCON_PORT = "RCONPort";
        public const string INI_RCON_PASSWORD = "RCONPassword";

        public const string SAVE_SETTINGS_INI = ".\\ArkBuddySettings.ini";
        public const string INI_SETTINGS = "Settings";

        public Form1()
        {
            InitializeComponent();
        }

        public void initializeLog()
        {
            string logName = $"logs/ark_buddy_log_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            Log.Logger = new LoggerConfiguration().WriteTo.Console()
            .WriteTo.File(logName)
            .WriteTo.Sink(new RichTextBoxSink(richTextBoxOutputLog))
            .CreateLogger();
            Log.Information("Log initialized");
        }

        public bool IsProcessRunning(string processName)
        {
            Log.Debug($"Checking if {processName} is running");
            var processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }

        public void monitorServerProcess()
        {
            while(true)
            {
                try
                {
                    Thread.Sleep(1_000);
                    labelServerProcess.Invoke((Action)(() =>
                    {
                        var serverRunning = IsProcessRunning(ARK_PROCESS_NAME);
                        labelServerProcess.Text = serverRunning ? "Running" : "Not running";
                        labelServerProcess.ForeColor = serverRunning ? GOOD_COLOUR : BAD_COLOUR;
                    }));
                }
                catch(Exception ex)
                {
                    Log.Error($"Exception during check server status: {ex.StackTrace}");
                }
            }
        }

        public bool isOnlyWhiteSpace(string filePath)
        {
            if (!File.Exists(filePath)) return false;
            string content = File.ReadAllText(filePath);
            return string.IsNullOrWhiteSpace(content);
        }

        public bool loadSettings()
        {
            Log.Information($"Loading settings from {SAVE_SETTINGS_INI}");
            var success = false;
            try
            {
                var parser = new FileIniDataParser();
                IniData settings = new IniData();
                if (File.Exists(SAVE_SETTINGS_INI))
                {
                    try
                    {
                        settings = parser.ReadFile(SAVE_SETTINGS_INI);
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Exception during settings INI read - INI file may be corrupted: {ex.StackTrace}");
                    }
                }

                foreach (Control control in tableLayoutPanelFilePaths.Controls)
                {
                    if (control is TextBox)
                    {
                        try
                        {
                            control.Text = settings[INI_SETTINGS][control.Name];
                        }
                        catch(Exception innerex)
                        {
                            Log.Error($"Exception reading : {innerex.StackTrace}");
                        }
                    }
                }

                success = true;
            }
            catch (Exception ex)
            {
                Log.Error($"Exception settings INI load: {ex.StackTrace}");
            }

            if (!success)
            {
                Log.Error($"Failed to load settings from {SAVE_SETTINGS_INI}");
            }

            return success;
        }

        public bool loadServerConfig()
        {
            var serverConfigPath = textBoxServerConfigINI.Text;
            Log.Information($"Loading server config from {serverConfigPath}");
            var success = false;
            try
            {
                var parser = new FileIniDataParser();
                serverConfigData = new IniData();
                if (File.Exists(serverConfigPath))
                {
                    try
                    {
                        serverConfigData = parser.ReadFile(serverConfigPath);
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Exception during server config INI read - INI file may be corrupted: {ex.StackTrace}");
                    }
                }

                success = true;
            }
            catch (Exception ex)
            {
                Log.Error($"Exception server config INI load: {ex.StackTrace}");
            }

            if (!success)
            {
                Log.Error($"Failed to load server config from {serverConfigPath}");
            }

            return success;
        }

        public bool saveSettings()
        {
            var success = false;
            try
            {
                var parser = new FileIniDataParser();
                IniData settings = new IniData();
                if(File.Exists(SAVE_SETTINGS_INI))
                {
                    try
                    {
                        settings = parser.ReadFile(SAVE_SETTINGS_INI);
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Exception during settings INI read - INI file may be corrupted: {ex.StackTrace}");
                    }
                }

                foreach (Control control in tableLayoutPanelFilePaths.Controls)
                {
                    if(control is TextBox)
                    {
                        if(!string.IsNullOrWhiteSpace(control.Text) && control.Text != "None")
                        {
                            settings[INI_SETTINGS][control.Name] = control.Text;
                        }
                    }
                }

                parser.WriteFile(SAVE_SETTINGS_INI, settings);
                success = true;
            }
            catch (Exception ex)
            {
                Log.Error($"Exception during settings INI save: {ex.StackTrace}");
            }

            if(!success)
            {
                Log.Error($"Failed to save settings to {SAVE_SETTINGS_INI}");
            }

            return success;
        }

        public bool readServerConfigIni()
        {
            var success = false;
            try
            {
                var parser = new FileIniDataParser();
                string filePath = null;
                textBoxServerConfigINI.Invoke((Action)(() =>
                {
                    filePath = textBoxServerConfigINI.Text;
                }));
                serverConfigData = parser.ReadFile(filePath);
                success = serverConfigData != null && !string.IsNullOrWhiteSpace(serverConfigData.ToString());
            }
            catch(Exception ex)
            {
                Log.Error($"Exception server config INI read: {ex.StackTrace}");
            }
            return success;
        }

        public bool startServer()
        {
            /*
             * start C:\Users\vr\Desktop\arkie2\ShooterGame\Binaries\Win64\ArkAscendedServer.exe Svartalfheim_WP?listen?SessionName=gnomez?ServerPassword=statwhore?Port=7777?QueryPort=27015? 
             * -NoBattlEye -mods=962796,940003,928597,929800,933099,928548,931047,929868,937546,928621,928506,932225,935408,929420,933301,929347
             */
            Log.Information("Starting server...");
            var delimiter = "?";
            var serverFolder = textBoxServerFolder.Text;
            disableAllComponents();
            var success = false;
            var task = Task.Run(() =>
            {
                try
                {
                    Log.Information("Constructing START SERVER command");
                    var battleye = bool.Parse(serverConfigData[INI_SERVER_SECTION][INI_BATTLEYE]);
                    var modsList = serverConfigData[INI_SERVER_SECTION][INI_MODS_LIST];
                    var settings = new List<string>()
                    {
                        serverConfigData[INI_SERVER_SECTION][INI_SERVER_MAP],
                        "listen",
                        $"{INI_SERVER_NAME}={serverConfigData[INI_SERVER_SECTION][INI_SERVER_NAME]}",
                        $"{INI_SERVER_PASSWORD}={serverConfigData[INI_SERVER_SECTION][INI_SERVER_PASSWORD]}",
                        $"{INI_SERVER_PORT}={serverConfigData[INI_SERVER_SECTION][INI_SERVER_PORT]}",
                        $"{INI_QUERY_PORT}={serverConfigData[INI_SERVER_SECTION][INI_QUERY_PORT]}",
                    };
                    var port = serverConfigData[INI_SERVER_SECTION][INI_RCON_PORT];
                    var password = serverConfigData[INI_SERVER_SECTION][INI_RCON_PASSWORD];
                    using(var process = new Process())
                    {
                        process.StartInfo.FileName = Path.Combine(serverFolder, ARK_SERVER_EXE_PATH);
                        process.StartInfo.Arguments = $"";
                        foreach (var s in settings)
                        {
                            process.StartInfo.Arguments += $"{s}{delimiter}";
                        }
                        process.StartInfo.Arguments = battleye ? process.StartInfo.Arguments : $" {process.StartInfo.Arguments} -NoBattleye";
                        if (!string.IsNullOrWhiteSpace(modsList)) { process.StartInfo.Arguments += $" -mods={modsList}"; }
                        process.StartInfo.UseShellExecute = true;
                        process.StartInfo.CreateNoWindow = false;
                        process.Start();
                    }

                    Stopwatch processTimer = Stopwatch.StartNew();
                    while (!IsProcessRunning(ARK_PROCESS_NAME) && processTimer.Elapsed.TotalSeconds < 15)
                    {
                        Thread.Sleep(500);
                    }

                    if (IsProcessRunning(ARK_PROCESS_NAME))
                    {
                        Log.Information($"{ARK_PROCESS_NAME} is running :)");
                        success = true;
                    }
                    else
                    {
                        Log.Error($"{ARK_PROCESS_NAME} is NOT running :(");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"Exception start server: {ex.StackTrace}");
                }
            });

            Stopwatch timer = Stopwatch.StartNew();
            while (!task.IsCompleted && timer.Elapsed.TotalSeconds < 60)
            {
                Application.DoEvents();
            }
            enableAllComponents();

            return success;
        }

        public bool updateServer()
        {
            Log.Information("Updating server...");
            disableAllComponents();
            var serverFolder = textBoxServerFolder.Text;
            var steamCmdFolder = textBoxSteamCmdFolder.Text;
            var success = false;
            var task = Task.Run(() =>
            {
                try
                {
                    Log.Information("Constructing UPDATE SERVER command");
                    var process = new Process();
                    process.StartInfo.FileName = Path.Combine(steamCmdFolder, STEAM_CMD_EXE);
                    process.StartInfo.Arguments = $"+force_install_dir \"{serverFolder}\" +login anonymous +app_update 2430930 +quit";
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.CreateNoWindow = false;
                    process.Start();

                    Stopwatch internaltimer = Stopwatch.StartNew();
                    while (IsProcessRunning(STEAMD_CMD_PROCESS_NAME) && internaltimer.Elapsed.TotalSeconds < 300)
                    {
                        Thread.Sleep(1_000);
                    }

                    bool finishedInTime = process.WaitForExit(1_000);

                    if (finishedInTime && process.ExitCode == 0)
                    {
                        Log.Information($"Server update successful");
                        success = true;
                    }
                    else
                    {
                        Log.Error($"Server update timed out");
                        if (!process.HasExited)
                            process.Kill();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"Exception start server: {ex.StackTrace}");
                }
            });

            Stopwatch timer = Stopwatch.StartNew();
            while (!task.IsCompleted && timer.Elapsed.TotalSeconds < 310)
            {
                Application.DoEvents();
            }
            enableAllComponents();

            return success;
        }

        public void setComponentsEnabled(Control parent, bool enabled=true)
        {
            foreach (Control control in parent.Controls)
            {
                if(ReferenceEquals(control, labelRunningCommand)) { continue; }
                control.Enabled = enabled;
                if (control.HasChildren)
                {
                    setComponentsEnabled(control, enabled); // Recursively handle nested controls
                }
            }
        }

        public void disableAllComponents()
        {
            setComponentsEnabled(this, false);
            labelRunningCommand.Visible = true;
        }

        public void enableAllComponents()
        {
            setComponentsEnabled(this, true);
            labelRunningCommand.Visible = false;
        }

        public bool openFile(string filePath)
        {
            Log.Information($"Opening {filePath}...");
            disableAllComponents();
            var success = false;
            var task = Task.Run(() =>
            {
                try
                {
                    Log.Information($"Constructing command for opening {filePath}");
                    var process = new Process();
                    process.StartInfo.FileName = filePath;
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.CreateNoWindow = false;
                    process.Start();
                    success = true;
                }
                catch (Exception ex)
                {
                    Log.Error($"Exception opening {filePath}: {ex.StackTrace}");
                }
            });

            Stopwatch timer = Stopwatch.StartNew();
            while (!task.IsCompleted && timer.Elapsed.TotalSeconds < 15)
            {
                Application.DoEvents();
            }
            enableAllComponents();

            return success;
        }

        public bool openGameUserSettingsINI()
        {
            string gameUserSettingsPath = Path.Combine(textBoxServerFolder.Text, ARK_CONFIG_PATH, "GameUserSettings.ini");
            return openFile(gameUserSettingsPath);
        }

        public bool openGameINI()
        {
            string gameUserSettingsPath = Path.Combine(textBoxServerFolder.Text, ARK_CONFIG_PATH, "Game.ini");
            return openFile(gameUserSettingsPath);
        }

        public bool openRconConnect()
        {
            Log.Information("Saving+exiting server...");
            disableAllComponents();
            string rconExePath = textBoxRconFolder.Text;
            var success = false;
            var task = Task.Run(() =>
            {
                try
                {
                    Log.Information("Constructing RCON command for server SAVE");
                    var port = serverConfigData[INI_SERVER_SECTION][INI_RCON_PORT];
                    var password = serverConfigData[INI_SERVER_SECTION][INI_RCON_PASSWORD];
                    var process = new Process();
                    process.StartInfo.FileName = Path.Combine(rconExePath, "mcrcon.exe");
                    process.StartInfo.Arguments = $"-H localhost -P {port} -p {password}";
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.CreateNoWindow = false;
                    process.Start();

                    // Wait for RCON to open+connect - it will exit if connection fails
                    Thread.Sleep(10_000);

                    if (IsProcessRunning(RCON_PROCESS_NAME))
                    {
                        Log.Information($"{RCON_PROCESS_NAME} is running :)");
                        success = true;
                    }
                    else
                    {
                        Log.Error($"{RCON_PROCESS_NAME} is NOT running :(");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"Exception during RCON open+connect: {ex.StackTrace}");
                }
            });

            Stopwatch timer = Stopwatch.StartNew();
            while (!task.IsCompleted && timer.Elapsed.TotalSeconds < 15)
            {
                Application.DoEvents();
            }
            enableAllComponents();

            return success;
        }

        public bool saveExit()
        {
            Log.Information("Saving+exiting server...");
            disableAllComponents();
            string rconExePath = textBoxRconFolder.Text;
            var success = false;
            var task = Task.Run(() =>
            {
                try
                {
                    Log.Information("Constructing RCON command for server SAVE");
                    var port = serverConfigData[INI_SERVER_SECTION][INI_RCON_PORT];
                    var password = serverConfigData[INI_SERVER_SECTION][INI_RCON_PASSWORD];
                    var process = new Process();
                    process.StartInfo.FileName = Path.Combine(rconExePath, "mcrcon.exe");
                    process.StartInfo.Arguments = $"-H localhost -P {port} -p {password} SaveWorld";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    bool finishedInTime = process.WaitForExit(30_000);

                    if (finishedInTime && process.ExitCode == 0)
                    {
                        Log.Information($"Server save successful");
                    }
                    else
                    {
                        Log.Error($"Server save timed out");
                        if (!process.HasExited)
                            process.Kill();
                        Log.Debug($"Server save output: {output}");
                        Log.Debug($"Server save error: {error}");
                        return;
                    }

                    Log.Information("Constructing RCON command for server EXIT");
                    port = serverConfigData[INI_SERVER_SECTION][INI_RCON_PORT];
                    password = serverConfigData[INI_SERVER_SECTION][INI_RCON_PASSWORD];
                    process = new Process();
                    process.StartInfo.FileName = Path.Combine(rconExePath, "mcrcon.exe");
                    process.StartInfo.Arguments = $"-H localhost -P {port} -p {password} DoExit";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    output = process.StandardOutput.ReadToEnd();
                    error = process.StandardError.ReadToEnd();
                    finishedInTime = process.WaitForExit(30_000);

                    if (finishedInTime && process.ExitCode == 0)
                    {
                        Log.Information($"Server exit command successful");
                    }
                    else
                    {
                        Log.Error($"Server exit command timed out");
                        if (!process.HasExited)
                            process.Kill();
                        Log.Debug($"Server exit output: {output}");
                        Log.Debug($"Server exit error: {error}");
                    }

                    Stopwatch processTimer = Stopwatch.StartNew();
                    while (IsProcessRunning(ARK_PROCESS_NAME) && processTimer.Elapsed.TotalSeconds < 15)
                    {
                        Thread.Sleep(500);
                    }

                    if (IsProcessRunning(ARK_PROCESS_NAME))
                    {
                        Log.Error($"{ARK_PROCESS_NAME} still running :(");
                    }
                    else
                    {
                        Log.Information($"{ARK_PROCESS_NAME} is NOT running :)");
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"Exception during save+exit server: {ex.StackTrace}");
                }
            });

            Stopwatch timer = Stopwatch.StartNew();
            while (!task.IsCompleted && timer.Elapsed.TotalSeconds < 60)
            {
                Application.DoEvents();
            }
            enableAllComponents();

            return success;
        }

        public void autoStartUpdate()
        {
            while(autoStartUpdateEnabled)
            {

            }
        }

        public void startAutoStartUpdate()
        {
            autoStartUpdateThread = new Thread(() => { autoStartUpdate(); }) { IsBackground = true };
            autoStartUpdateThread.Start();
        }

        public void stopAutoStartUpdate()
        {
            autoStartUpdateEnabled = false;
            if(autoStartUpdateThread != null && autoStartUpdateThread.IsAlive)
            {
                if(!autoStartUpdateThread.Join(5000))
                {
                    Log.Error("Exceeded timeout while waiting for AutoStartUpdate thread to complete");
                }
            }
        }

        public void toggleAutoStartUpdate()
        {
            try
            {
                disableAllComponents();
                var enable = labelAutoStartUpdate.Text.Contains("Disabled");
                if (enable) 
                {
                    labelAutoStartUpdate.Text = "Enabled";
                    labelAutoStartUpdate.ForeColor = GOOD_COLOUR;
                    autoStartUpdate(); 
                } 
                else 
                {
                    labelAutoStartUpdate.Text = "Disabled";
                    labelAutoStartUpdate.ForeColor = BAD_COLOUR;
                    stopAutoStartUpdate();
                }
            }
            catch(Exception ex)
            {
                Log.Error($"Exception during toggle auto start+update: {ex.StackTrace}");
            }
            finally
            {
                enableAllComponents();
            }
        }

        public static void CreateZipArchive(string sourceDir, string destDirectory)
        {
            string zipFileName = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.zip";
            string zipFilePath = Path.Combine(destDirectory, zipFileName);
            using (var zip = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
            {
                foreach (string file in Directory.GetFiles(sourceDir))
                {
                    try
                    {
                        using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
                        }
                    }
                    catch (IOException)
                    {
                        Log.Error($"Skipping file in use: {file}");
                    }
                }
            }
        }

        public static void CleanupOldArchives(string destDir, int maxArchives)
        {
            var zipFiles = Directory.GetFiles(destDir, "*.zip")
                                    .Select(f => new FileInfo(f))
                                    .OrderByDescending(f => f.CreationTime)
                                    .ToList();

            if (zipFiles.Count > maxArchives)
            {
                foreach (var file in zipFiles.Skip(maxArchives))
                {
                    try
                    {
                        File.Delete(file.FullName);
                        Log.Debug($"Deleted old archive: {file.Name}");
                    }
                    catch (Exception ex)
                    {
                       Log.Error($"Failed to delete {file.Name}: {ex.Message}");
                    }
                }
            }
        }

        public bool backupServer()
        {
            Log.Information("Backing up server...");
            disableAllComponents();
            var success = false;
            var sourceDir = Path.Combine(textBoxServerFolder.Text, ARK_SAVE_PATH);
            var destDir = textBoxBackupFolder.Text;
            var task = Task.Run(() =>
            {
                try
                {
                    CreateZipArchive(sourceDir, destDir);
                    CleanupOldArchives(destDir, MAX_BACKUPS_TO_KEEP);
                    success = true;
                }
                catch (Exception ex)
                {
                    Log.Error($"Exception during backup server: {ex.StackTrace}");
                }
            });

            Stopwatch timer = Stopwatch.StartNew();
            while (!task.IsCompleted && timer.Elapsed.TotalSeconds < 60)
            {
                Application.DoEvents();
            }
            enableAllComponents();

            return success;
        }

        public void toggleAutoBackup()
        {

        }

        public string selectFolder(string description="Select folder")
        {
            string folderPath = null;
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = description;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the folder path
                    folderPath = folderDialog.SelectedPath;
                    Log.Information($"Selected folder: {folderPath}");
                }
            }

            return folderPath;
        }

        public string selectFile(string filter= "Text files (*.txt)|*.txt|All files (*.*)|*.*")
        {
            string filePath = null;
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = @"C:\";
                fileDialog.Filter = filter;
                fileDialog.Multiselect = false;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = fileDialog.FileName;
                    Log.Information($"Selected file: {filePath}");
                }
            }
            return filePath;
        }

        private void buttonServerFolderSelect_Click(object sender, EventArgs e)
        {
            var selectedFolder = selectFolder("Select server folder");
            textBoxServerFolder.Text = string.IsNullOrWhiteSpace(selectedFolder) ? "None" : selectedFolder;
            saveSettings();
        }

        private void buttonMcRconFolderSelect_Click(object sender, EventArgs e)
        { 
            var selectedFolder = selectFolder("Select RCON folder");
            textBoxRconFolder.Text = string.IsNullOrWhiteSpace(selectedFolder) ? "None": selectedFolder;
            saveSettings();

        }

        private void buttonSteamCmdFolderSelect_Click(object sender, EventArgs e)
        {
            var selectedFolder = selectFolder("Select steamcmd folder");
            textBoxSteamCmdFolder.Text = string.IsNullOrWhiteSpace(selectedFolder) ? "None" : selectedFolder;
            saveSettings();
        }

        private void buttonBackupFolderSelect_Click(object sender, EventArgs e)
        {
            var selectedFolder = selectFolder("Select backup folder");
            textBoxBackupFolder.Text = string.IsNullOrWhiteSpace(selectedFolder) ? "None" : selectedFolder;
            saveSettings();
        }

        private void buttonServerConfigINISelect_Click(object sender, EventArgs e)
        {
            var selectedFile = selectFile("INI files (*.ini)|*.ini|All files (*.*)|*.*");
            textBoxServerConfigINI.Text = string.IsNullOrWhiteSpace(selectedFile) ? "None" : selectedFile;
            var success = readServerConfigIni();
            if(success) 
            {
                saveSettings();
            }
            else
            {
                textBoxServerConfigINI.Text = "None";
                MessageBox.Show("Error parsing server config INI", "INI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonToggleAutoStartUpdate_Click(object sender, EventArgs e)
        {

        }

        private void buttonToggleAutoBackup_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaveExit_Click(object sender, EventArgs e)
        {
            var success = saveExit();
            if (!success)
            {
                MessageBox.Show("Error saving+exit server", "Save+exit error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initializeLog();
            labelRunningCommand.Visible = false;
            Thread serverStatusThread = new Thread(() => { monitorServerProcess(); }) { IsBackground = true };
            serverStatusThread.Start();
            loadSettings();
            loadServerConfig();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Log.CloseAndFlush();
            base.OnFormClosed(e);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            var success = startServer();
            if(!success)
            {
                MessageBox.Show("Error starting server", "Start server error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdateServer_Click(object sender, EventArgs e)
        {
            var success = updateServer();
            if(!success)
            {
                MessageBox.Show("Error updating server", "Update server error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOpenRcon_Click(object sender, EventArgs e)
        {
            var success = openRconConnect();
            if (!success)
            {
                MessageBox.Show("Error connecting+opening RCON", "RCON open+connect error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOpenGameUserSettingsINI_Click(object sender, EventArgs e)
        {
            var success = openGameUserSettingsINI();
            if (!success)
            {
                MessageBox.Show("Error opening GameUserSettingsINI", "GameUserSettingsINI open error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOpenGameINI_Click(object sender, EventArgs e)
        {
            var success = openGameINI();
            if (!success)
            {
                MessageBox.Show("Error opening GameINI", "GameINI open error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBackupServer_Click(object sender, EventArgs e)
        {
            var success = backupServer();
            if (!success)
            {
                MessageBox.Show("Error backing up server", "Server backup error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class RichTextBoxSink : ILogEventSink
    {
        public RichTextBox richTextBox;
        public RichTextBoxSink(RichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;
        }
        public void Emit(LogEvent logEvent)
        {
            richTextBox.Invoke(new Action(() => WriteToRichTextBox(logEvent)));
        }

        public void WriteToRichTextBox(LogEvent logEvent)
        {
            if (logEvent.Level > LogEventLevel.Debug)
            {
                richTextBox.AppendText($"{logEvent.Timestamp:HH:mm:ss} [{logEvent.Level}] {logEvent.RenderMessage()}{Environment.NewLine}");
                richTextBox.ScrollToCaret();
            }
        }
    }
}
