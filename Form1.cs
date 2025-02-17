using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ArkBuddy
{
    public partial class Form1: Form
    {
        public const string ARK_PROCESS_NAME = "ArkAscendedServer";
        public static volatile bool autoStartUpdateEnabled = false;
        public Color GOOD_COLOUR = Color.ForestGreen;
        public Color BAD_COLOUR = Color.Crimson;
        public Thread autoStartUpdateThread = null;
        public IniData serverConfigData = null;
        public const string INI_SERVER_SECTION = "ServerConfig";
        public const string INI_SERVER_NAME = "ServerName";
        public const string INI_SERVER_PASSWORD = "ServerPassword";
        public const string INI_SERVER_MAP = "ServerMap";
        public const string INI_MODS_LIST = "ModsList";
        public const string INI_BATTLEYE = "Battleye";
        public const string INI_SERVER_PORT = "ServerPort";
        public const string INI_QUERY_PORT = "QueryPort";
        public const string INI_RCON_PORT = "RCONPort";
        public const string INI_RCON_PASSWORD = "RCONPassword";

        public Form1()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("ark_buddy_log-.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            Log.Information("Log initialized");
            InitializeComponent();
            labelRunningCommand.Visible = false;
            Thread serverStatusThread = new Thread(() => { monitorServerProcess(); }){ IsBackground = true };
            serverStatusThread.Start();
        }
        public bool IsProcessRunning(string processName)
        {
            Log.Information($"Checking if {processName} is running");
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

        public void startServer()
        {

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
                    process.StartInfo.FileName = $"{rconExePath}\\mcrcon.exe";
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
                    process.StartInfo.FileName = $"{rconExePath}\\mcrcon.exe";
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
                    Log.Error($"Exception save+exit server: {ex.StackTrace}");
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
        }

        private void buttonMcRconFolderSelect_Click(object sender, EventArgs e)
        { 
            var selectedFolder = selectFolder("Select RCON folder");
            textBoxRconFolder.Text = string.IsNullOrWhiteSpace(selectedFolder) ? "None": selectedFolder;

        }

        private void buttonSteamCmdFolderSelect_Click(object sender, EventArgs e)
        {
            var selectedFolder = selectFolder("Select steamcmd folder");
            textBoxSteamCmdFolder.Text = string.IsNullOrWhiteSpace(selectedFolder) ? "None" : selectedFolder;


        }

        private void buttonBackupFolderSelect_Click(object sender, EventArgs e)
        {
            var selectedFolder = selectFolder("Select backup folder");
            textBoxBackupFolder.Text = string.IsNullOrWhiteSpace(selectedFolder) ? "None" : selectedFolder;

        }

        private void buttonServerConfigINISelect_Click(object sender, EventArgs e)
        {
            var selectedFile = selectFile("INI files (*.ini)|*.ini|All files (*.*)|*.*");
            textBoxServerConfigINI.Text = string.IsNullOrWhiteSpace(selectedFile) ? "None" : selectedFile;
            var success = readServerConfigIni();
            if(!success) 
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
    }
}
