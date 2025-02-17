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

namespace ArkBuddy
{
    public partial class Form1: Form
    {
        const string ARK_PROCESS_NAME = "ArkAscendedServer";
        Color GOOD_COLOUR = Color.ForestGreen;
        Color BAD_COLOUR = Color.Crimson;

        public Form1()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("ark_buddy_log-.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            Log.Information("Log initialized");
            InitializeComponent();
            ThreadPool.QueueUserWorkItem(_ => monitorServerProcess());
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
        }
    }
}
