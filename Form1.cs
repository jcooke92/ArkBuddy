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
        public const string INI_SERVER_NAME = "ServerName";
        public const string INI_SERVER_PASSWORD = "ServerPassword";
        public const string INI_SERVER_MAP = "ServerMap";
        public const string INI_MODS_LIST = "ModsList";
        public const string INI_BATTLEYE = "Battleye";
        public const string INI_SERVER_PORT = "ServerPort";
        public const string INI_QUERY_PORT = "QueryPort";

        public Form1()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("ark_buddy_log-.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            Log.Information("Log initialized");
            InitializeComponent();
            Thread serverStatusThread = new Thread(() => { monitorServerProcess(); }){ IsBackground = true };
            serverStatusThread.Start();
        }
        public bool IsProcessRunning(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }

        public void monitorServerProcess()
        {
            while(true)
            {
                try
                {
                    Thread.Sleep(500);
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

        public void saveExit()
        {
            var task = Task.Run(() =>
            {
                string rconExePath = null;
                textBoxRconFolder.Invoke((Action)(() =>
                {
                    rconExePath = textBoxRconFolder.Text;
                }));



            });
            task.Wait();
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
                labelAutoStartUpdate.Invoke((Action)(() =>
                {
                    buttonToggleAutoStartUpdate.Enabled = false;
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
                }));
            }
            catch(Exception ex)
            {
                Log.Error($"Exception during toggle auto start+update: {ex.StackTrace}");
            }
            finally
            {
                buttonToggleAutoStartUpdate.Invoke((Action)(() =>
                {
                    buttonToggleAutoStartUpdate.Enabled = true;
                }));
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
    }
}
