namespace ArkBuddy
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxServerFolder = new System.Windows.Forms.TextBox();
            this.textBoxRconFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSteamCmdFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonUpdateServer = new System.Windows.Forms.Button();
            this.buttonSaveExit = new System.Windows.Forms.Button();
            this.buttonBackupServer = new System.Windows.Forms.Button();
            this.textBoxBackupFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonOpenRcon = new System.Windows.Forms.Button();
            this.buttonOpenGameUserSettingsINI = new System.Windows.Forms.Button();
            this.buttonOpenGameINI = new System.Windows.Forms.Button();
            this.richTextBoxOutputLog = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonServerFolderSelect = new System.Windows.Forms.Button();
            this.buttonSteamCmdFolderSelect = new System.Windows.Forms.Button();
            this.buttonToggleAutoStartUpdate = new System.Windows.Forms.Button();
            this.buttonToggleAutoBackup = new System.Windows.Forms.Button();
            this.labelAutoStartUpdate = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelServerProcess = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelAutoBackup = new System.Windows.Forms.Label();
            this.tableLayoutPanelFilePaths = new System.Windows.Forms.TableLayoutPanel();
            this.buttonServerConfigINISelect = new System.Windows.Forms.Button();
            this.textBoxServerConfigINI = new System.Windows.Forms.TextBox();
            this.buttonBackupFolderSelect = new System.Windows.Forms.Button();
            this.buttonMcRconFolderSelect = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelRunningCommand = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelFilePaths.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Folder";
            // 
            // textBoxServerFolder
            // 
            this.textBoxServerFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxServerFolder.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServerFolder.Location = new System.Drawing.Point(263, 18);
            this.textBoxServerFolder.Name = "textBoxServerFolder";
            this.textBoxServerFolder.Size = new System.Drawing.Size(420, 35);
            this.textBoxServerFolder.TabIndex = 1;
            this.textBoxServerFolder.Text = "None";
            // 
            // textBoxRconFolder
            // 
            this.textBoxRconFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxRconFolder.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRconFolder.Location = new System.Drawing.Point(263, 90);
            this.textBoxRconFolder.Name = "textBoxRconFolder";
            this.textBoxRconFolder.Size = new System.Drawing.Size(420, 35);
            this.textBoxRconFolder.TabIndex = 3;
            this.textBoxRconFolder.Text = "None";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "mcrcon Folder";
            // 
            // textBoxSteamCmdFolder
            // 
            this.textBoxSteamCmdFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxSteamCmdFolder.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSteamCmdFolder.Location = new System.Drawing.Point(263, 162);
            this.textBoxSteamCmdFolder.Name = "textBoxSteamCmdFolder";
            this.textBoxSteamCmdFolder.Size = new System.Drawing.Size(420, 35);
            this.textBoxSteamCmdFolder.TabIndex = 5;
            this.textBoxSteamCmdFolder.Text = "None";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "steamcmd Folder";
            // 
            // buttonUpdateServer
            // 
            this.buttonUpdateServer.AutoSize = true;
            this.buttonUpdateServer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonUpdateServer.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateServer.Location = new System.Drawing.Point(10, 10);
            this.buttonUpdateServer.Margin = new System.Windows.Forms.Padding(10);
            this.buttonUpdateServer.Name = "buttonUpdateServer";
            this.buttonUpdateServer.Padding = new System.Windows.Forms.Padding(10);
            this.buttonUpdateServer.Size = new System.Drawing.Size(340, 70);
            this.buttonUpdateServer.TabIndex = 7;
            this.buttonUpdateServer.Text = "Install/Update Server";
            this.buttonUpdateServer.UseVisualStyleBackColor = true;
            // 
            // buttonSaveExit
            // 
            this.buttonSaveExit.AutoSize = true;
            this.buttonSaveExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSaveExit.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveExit.Location = new System.Drawing.Point(875, 10);
            this.buttonSaveExit.Margin = new System.Windows.Forms.Padding(10);
            this.buttonSaveExit.Name = "buttonSaveExit";
            this.buttonSaveExit.Padding = new System.Windows.Forms.Padding(10);
            this.buttonSaveExit.Size = new System.Drawing.Size(279, 70);
            this.buttonSaveExit.TabIndex = 8;
            this.buttonSaveExit.Text = "Save Server+Exit";
            this.buttonSaveExit.UseVisualStyleBackColor = true;
            this.buttonSaveExit.Click += new System.EventHandler(this.buttonSaveExit_Click);
            // 
            // buttonBackupServer
            // 
            this.buttonBackupServer.AutoSize = true;
            this.buttonBackupServer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBackupServer.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackupServer.Location = new System.Drawing.Point(600, 10);
            this.buttonBackupServer.Margin = new System.Windows.Forms.Padding(10);
            this.buttonBackupServer.Name = "buttonBackupServer";
            this.buttonBackupServer.Padding = new System.Windows.Forms.Padding(10);
            this.buttonBackupServer.Size = new System.Drawing.Size(255, 70);
            this.buttonBackupServer.TabIndex = 9;
            this.buttonBackupServer.Text = "Back-up Server";
            this.buttonBackupServer.UseVisualStyleBackColor = true;
            // 
            // textBoxBackupFolder
            // 
            this.textBoxBackupFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxBackupFolder.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBackupFolder.Location = new System.Drawing.Point(263, 234);
            this.textBoxBackupFolder.Name = "textBoxBackupFolder";
            this.textBoxBackupFolder.Size = new System.Drawing.Size(420, 35);
            this.textBoxBackupFolder.TabIndex = 11;
            this.textBoxBackupFolder.Text = "None";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 40);
            this.label4.TabIndex = 10;
            this.label4.Text = "Backup Folder";
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.AutoSize = true;
            this.buttonStartServer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonStartServer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonStartServer.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartServer.Location = new System.Drawing.Point(370, 10);
            this.buttonStartServer.Margin = new System.Windows.Forms.Padding(10);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Padding = new System.Windows.Forms.Padding(10);
            this.buttonStartServer.Size = new System.Drawing.Size(210, 70);
            this.buttonStartServer.TabIndex = 6;
            this.buttonStartServer.Text = "Start Server";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonUpdateServer);
            this.flowLayoutPanel1.Controls.Add(this.buttonStartServer);
            this.flowLayoutPanel1.Controls.Add(this.buttonBackupServer);
            this.flowLayoutPanel1.Controls.Add(this.buttonSaveExit);
            this.flowLayoutPanel1.Controls.Add(this.buttonOpenRcon);
            this.flowLayoutPanel1.Controls.Add(this.buttonOpenGameUserSettingsINI);
            this.flowLayoutPanel1.Controls.Add(this.buttonOpenGameINI);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 429);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1195, 197);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // buttonOpenRcon
            // 
            this.buttonOpenRcon.AutoSize = true;
            this.buttonOpenRcon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenRcon.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenRcon.Location = new System.Drawing.Point(10, 100);
            this.buttonOpenRcon.Margin = new System.Windows.Forms.Padding(10);
            this.buttonOpenRcon.Name = "buttonOpenRcon";
            this.buttonOpenRcon.Padding = new System.Windows.Forms.Padding(10);
            this.buttonOpenRcon.Size = new System.Drawing.Size(345, 70);
            this.buttonOpenRcon.TabIndex = 10;
            this.buttonOpenRcon.Text = "RCON Open+Connect";
            this.buttonOpenRcon.UseVisualStyleBackColor = true;
            // 
            // buttonOpenGameUserSettingsINI
            // 
            this.buttonOpenGameUserSettingsINI.AutoSize = true;
            this.buttonOpenGameUserSettingsINI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenGameUserSettingsINI.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenGameUserSettingsINI.Location = new System.Drawing.Point(375, 100);
            this.buttonOpenGameUserSettingsINI.Margin = new System.Windows.Forms.Padding(10);
            this.buttonOpenGameUserSettingsINI.Name = "buttonOpenGameUserSettingsINI";
            this.buttonOpenGameUserSettingsINI.Padding = new System.Windows.Forms.Padding(10);
            this.buttonOpenGameUserSettingsINI.Size = new System.Drawing.Size(424, 70);
            this.buttonOpenGameUserSettingsINI.TabIndex = 12;
            this.buttonOpenGameUserSettingsINI.Text = "Open GameUserSettings.ini";
            this.buttonOpenGameUserSettingsINI.UseVisualStyleBackColor = true;
            // 
            // buttonOpenGameINI
            // 
            this.buttonOpenGameINI.AutoSize = true;
            this.buttonOpenGameINI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenGameINI.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenGameINI.Location = new System.Drawing.Point(819, 100);
            this.buttonOpenGameINI.Margin = new System.Windows.Forms.Padding(10);
            this.buttonOpenGameINI.Name = "buttonOpenGameINI";
            this.buttonOpenGameINI.Padding = new System.Windows.Forms.Padding(10);
            this.buttonOpenGameINI.Size = new System.Drawing.Size(251, 70);
            this.buttonOpenGameINI.TabIndex = 13;
            this.buttonOpenGameINI.Text = "Open Game.ini";
            this.buttonOpenGameINI.UseVisualStyleBackColor = true;
            // 
            // richTextBoxOutputLog
            // 
            this.richTextBoxOutputLog.Location = new System.Drawing.Point(10, 694);
            this.richTextBoxOutputLog.Name = "richTextBoxOutputLog";
            this.richTextBoxOutputLog.Size = new System.Drawing.Size(1478, 258);
            this.richTextBoxOutputLog.TabIndex = 13;
            this.richTextBoxOutputLog.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 648);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 40);
            this.label5.TabIndex = 14;
            this.label5.Text = "Output Log";
            // 
            // buttonServerFolderSelect
            // 
            this.buttonServerFolderSelect.AutoSize = true;
            this.buttonServerFolderSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonServerFolderSelect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonServerFolderSelect.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonServerFolderSelect.Location = new System.Drawing.Point(696, 10);
            this.buttonServerFolderSelect.Margin = new System.Windows.Forms.Padding(10);
            this.buttonServerFolderSelect.Name = "buttonServerFolderSelect";
            this.buttonServerFolderSelect.Padding = new System.Windows.Forms.Padding(5);
            this.buttonServerFolderSelect.Size = new System.Drawing.Size(98, 52);
            this.buttonServerFolderSelect.TabIndex = 15;
            this.buttonServerFolderSelect.Text = "Select";
            this.buttonServerFolderSelect.UseVisualStyleBackColor = true;
            this.buttonServerFolderSelect.Click += new System.EventHandler(this.buttonServerFolderSelect_Click);
            // 
            // buttonSteamCmdFolderSelect
            // 
            this.buttonSteamCmdFolderSelect.AutoSize = true;
            this.buttonSteamCmdFolderSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSteamCmdFolderSelect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonSteamCmdFolderSelect.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSteamCmdFolderSelect.Location = new System.Drawing.Point(696, 154);
            this.buttonSteamCmdFolderSelect.Margin = new System.Windows.Forms.Padding(10);
            this.buttonSteamCmdFolderSelect.Name = "buttonSteamCmdFolderSelect";
            this.buttonSteamCmdFolderSelect.Padding = new System.Windows.Forms.Padding(5);
            this.buttonSteamCmdFolderSelect.Size = new System.Drawing.Size(98, 52);
            this.buttonSteamCmdFolderSelect.TabIndex = 16;
            this.buttonSteamCmdFolderSelect.Text = "Select";
            this.buttonSteamCmdFolderSelect.UseVisualStyleBackColor = true;
            this.buttonSteamCmdFolderSelect.Click += new System.EventHandler(this.buttonSteamCmdFolderSelect_Click);
            // 
            // buttonToggleAutoStartUpdate
            // 
            this.buttonToggleAutoStartUpdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonToggleAutoStartUpdate.AutoSize = true;
            this.buttonToggleAutoStartUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonToggleAutoStartUpdate.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToggleAutoStartUpdate.Location = new System.Drawing.Point(11, 124);
            this.buttonToggleAutoStartUpdate.Margin = new System.Windows.Forms.Padding(10);
            this.buttonToggleAutoStartUpdate.Name = "buttonToggleAutoStartUpdate";
            this.buttonToggleAutoStartUpdate.Padding = new System.Windows.Forms.Padding(10);
            this.buttonToggleAutoStartUpdate.Size = new System.Drawing.Size(380, 70);
            this.buttonToggleAutoStartUpdate.TabIndex = 20;
            this.buttonToggleAutoStartUpdate.Text = "Toggle AutoStartUpdate";
            this.buttonToggleAutoStartUpdate.UseVisualStyleBackColor = true;
            this.buttonToggleAutoStartUpdate.Click += new System.EventHandler(this.buttonToggleAutoStartUpdate_Click);
            // 
            // buttonToggleAutoBackup
            // 
            this.buttonToggleAutoBackup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonToggleAutoBackup.AutoSize = true;
            this.buttonToggleAutoBackup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonToggleAutoBackup.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToggleAutoBackup.Location = new System.Drawing.Point(11, 231);
            this.buttonToggleAutoBackup.Margin = new System.Windows.Forms.Padding(10);
            this.buttonToggleAutoBackup.Name = "buttonToggleAutoBackup";
            this.buttonToggleAutoBackup.Padding = new System.Windows.Forms.Padding(10);
            this.buttonToggleAutoBackup.Size = new System.Drawing.Size(315, 70);
            this.buttonToggleAutoBackup.TabIndex = 21;
            this.buttonToggleAutoBackup.Text = "Toggle AutoBackup";
            this.buttonToggleAutoBackup.UseVisualStyleBackColor = true;
            this.buttonToggleAutoBackup.Click += new System.EventHandler(this.buttonToggleAutoBackup_Click);
            // 
            // labelAutoStartUpdate
            // 
            this.labelAutoStartUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAutoStartUpdate.AutoSize = true;
            this.labelAutoStartUpdate.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutoStartUpdate.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelAutoStartUpdate.Location = new System.Drawing.Point(461, 139);
            this.labelAutoStartUpdate.Name = "labelAutoStartUpdate";
            this.labelAutoStartUpdate.Size = new System.Drawing.Size(126, 40);
            this.labelAutoStartUpdate.TabIndex = 21;
            this.labelAutoStartUpdate.Text = "Enabled";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.labelServerProcess, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonToggleAutoBackup, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelAutoBackup, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelAutoStartUpdate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonToggleAutoStartUpdate, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(870, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(618, 321);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // labelServerProcess
            // 
            this.labelServerProcess.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelServerProcess.AutoSize = true;
            this.labelServerProcess.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerProcess.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelServerProcess.Location = new System.Drawing.Point(457, 33);
            this.labelServerProcess.Name = "labelServerProcess";
            this.labelServerProcess.Size = new System.Drawing.Size(134, 40);
            this.labelServerProcess.TabIndex = 23;
            this.labelServerProcess.Text = "Running";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(218, 40);
            this.label9.TabIndex = 24;
            this.label9.Text = "Server Process";
            // 
            // labelAutoBackup
            // 
            this.labelAutoBackup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAutoBackup.AutoSize = true;
            this.labelAutoBackup.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutoBackup.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelAutoBackup.Location = new System.Drawing.Point(461, 246);
            this.labelAutoBackup.Name = "labelAutoBackup";
            this.labelAutoBackup.Size = new System.Drawing.Size(126, 40);
            this.labelAutoBackup.TabIndex = 22;
            this.labelAutoBackup.Text = "Enabled";
            // 
            // tableLayoutPanelFilePaths
            // 
            this.tableLayoutPanelFilePaths.AutoSize = true;
            this.tableLayoutPanelFilePaths.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelFilePaths.ColumnCount = 3;
            this.tableLayoutPanelFilePaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFilePaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFilePaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelFilePaths.Controls.Add(this.buttonServerConfigINISelect, 2, 4);
            this.tableLayoutPanelFilePaths.Controls.Add(this.textBoxServerConfigINI, 1, 4);
            this.tableLayoutPanelFilePaths.Controls.Add(this.buttonBackupFolderSelect, 2, 3);
            this.tableLayoutPanelFilePaths.Controls.Add(this.buttonMcRconFolderSelect, 2, 1);
            this.tableLayoutPanelFilePaths.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelFilePaths.Controls.Add(this.textBoxServerFolder, 1, 0);
            this.tableLayoutPanelFilePaths.Controls.Add(this.buttonSteamCmdFolderSelect, 2, 2);
            this.tableLayoutPanelFilePaths.Controls.Add(this.buttonServerFolderSelect, 2, 0);
            this.tableLayoutPanelFilePaths.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanelFilePaths.Controls.Add(this.textBoxBackupFolder, 1, 3);
            this.tableLayoutPanelFilePaths.Controls.Add(this.textBoxRconFolder, 1, 1);
            this.tableLayoutPanelFilePaths.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanelFilePaths.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanelFilePaths.Controls.Add(this.textBoxSteamCmdFolder, 1, 2);
            this.tableLayoutPanelFilePaths.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanelFilePaths.Location = new System.Drawing.Point(10, 15);
            this.tableLayoutPanelFilePaths.Name = "tableLayoutPanelFilePaths";
            this.tableLayoutPanelFilePaths.RowCount = 5;
            this.tableLayoutPanelFilePaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFilePaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFilePaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFilePaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFilePaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelFilePaths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelFilePaths.Size = new System.Drawing.Size(804, 360);
            this.tableLayoutPanelFilePaths.TabIndex = 23;
            // 
            // buttonServerConfigINISelect
            // 
            this.buttonServerConfigINISelect.AutoSize = true;
            this.buttonServerConfigINISelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonServerConfigINISelect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonServerConfigINISelect.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonServerConfigINISelect.Location = new System.Drawing.Point(696, 298);
            this.buttonServerConfigINISelect.Margin = new System.Windows.Forms.Padding(10);
            this.buttonServerConfigINISelect.Name = "buttonServerConfigINISelect";
            this.buttonServerConfigINISelect.Padding = new System.Windows.Forms.Padding(5);
            this.buttonServerConfigINISelect.Size = new System.Drawing.Size(98, 52);
            this.buttonServerConfigINISelect.TabIndex = 21;
            this.buttonServerConfigINISelect.Text = "Select";
            this.buttonServerConfigINISelect.UseVisualStyleBackColor = true;
            this.buttonServerConfigINISelect.Click += new System.EventHandler(this.buttonServerConfigINISelect_Click);
            // 
            // textBoxServerConfigINI
            // 
            this.textBoxServerConfigINI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxServerConfigINI.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServerConfigINI.Location = new System.Drawing.Point(263, 306);
            this.textBoxServerConfigINI.Name = "textBoxServerConfigINI";
            this.textBoxServerConfigINI.Size = new System.Drawing.Size(420, 35);
            this.textBoxServerConfigINI.TabIndex = 20;
            this.textBoxServerConfigINI.Text = "None";
            // 
            // buttonBackupFolderSelect
            // 
            this.buttonBackupFolderSelect.AutoSize = true;
            this.buttonBackupFolderSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBackupFolderSelect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonBackupFolderSelect.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackupFolderSelect.Location = new System.Drawing.Point(696, 226);
            this.buttonBackupFolderSelect.Margin = new System.Windows.Forms.Padding(10);
            this.buttonBackupFolderSelect.Name = "buttonBackupFolderSelect";
            this.buttonBackupFolderSelect.Padding = new System.Windows.Forms.Padding(5);
            this.buttonBackupFolderSelect.Size = new System.Drawing.Size(98, 52);
            this.buttonBackupFolderSelect.TabIndex = 18;
            this.buttonBackupFolderSelect.Text = "Select";
            this.buttonBackupFolderSelect.UseVisualStyleBackColor = true;
            this.buttonBackupFolderSelect.Click += new System.EventHandler(this.buttonBackupFolderSelect_Click);
            // 
            // buttonMcRconFolderSelect
            // 
            this.buttonMcRconFolderSelect.AutoSize = true;
            this.buttonMcRconFolderSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonMcRconFolderSelect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonMcRconFolderSelect.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMcRconFolderSelect.Location = new System.Drawing.Point(696, 82);
            this.buttonMcRconFolderSelect.Margin = new System.Windows.Forms.Padding(10);
            this.buttonMcRconFolderSelect.Name = "buttonMcRconFolderSelect";
            this.buttonMcRconFolderSelect.Padding = new System.Windows.Forms.Padding(5);
            this.buttonMcRconFolderSelect.Size = new System.Drawing.Size(98, 52);
            this.buttonMcRconFolderSelect.TabIndex = 17;
            this.buttonMcRconFolderSelect.Text = "Select";
            this.buttonMcRconFolderSelect.UseVisualStyleBackColor = true;
            this.buttonMcRconFolderSelect.Click += new System.EventHandler(this.buttonMcRconFolderSelect_Click);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 304);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(254, 40);
            this.label10.TabIndex = 19;
            this.label10.Text = "Server Config INI";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(12, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1469, 5);
            this.label6.TabIndex = 24;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(16, 643);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1469, 5);
            this.label7.TabIndex = 25;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(846, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(5, 370);
            this.label8.TabIndex = 26;
            this.label8.Text = "label8";
            // 
            // labelRunningCommand
            // 
            this.labelRunningCommand.AutoSize = true;
            this.labelRunningCommand.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRunningCommand.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelRunningCommand.Location = new System.Drawing.Point(487, 359);
            this.labelRunningCommand.Name = "labelRunningCommand";
            this.labelRunningCommand.Size = new System.Drawing.Size(618, 86);
            this.labelRunningCommand.TabIndex = 27;
            this.labelRunningCommand.Text = "Running command...";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(1256, 410);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(5, 220);
            this.label11.TabIndex = 28;
            this.label11.Text = "label11";
            // 
            // buttonExit
            // 
            this.buttonExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(1302, 429);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(10);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Padding = new System.Windows.Forms.Padding(10);
            this.buttonExit.Size = new System.Drawing.Size(159, 197);
            this.buttonExit.TabIndex = 14;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 983);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelRunningCommand);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tableLayoutPanelFilePaths);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBoxOutputLog);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ArkBuddy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanelFilePaths.ResumeLayout(false);
            this.tableLayoutPanelFilePaths.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxServerFolder;
        private System.Windows.Forms.TextBox textBoxRconFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSteamCmdFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonUpdateServer;
        private System.Windows.Forms.Button buttonSaveExit;
        private System.Windows.Forms.Button buttonBackupServer;
        private System.Windows.Forms.TextBox textBoxBackupFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonOpenRcon;
        private System.Windows.Forms.Button buttonOpenGameUserSettingsINI;
        private System.Windows.Forms.Button buttonOpenGameINI;
        private System.Windows.Forms.RichTextBox richTextBoxOutputLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonServerFolderSelect;
        private System.Windows.Forms.Button buttonSteamCmdFolderSelect;
        private System.Windows.Forms.Button buttonToggleAutoStartUpdate;
        private System.Windows.Forms.Button buttonToggleAutoBackup;
        private System.Windows.Forms.Label labelAutoStartUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelAutoBackup;
        private System.Windows.Forms.Label labelServerProcess;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFilePaths;
        private System.Windows.Forms.Button buttonBackupFolderSelect;
        private System.Windows.Forms.Button buttonMcRconFolderSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonServerConfigINISelect;
        private System.Windows.Forms.TextBox textBoxServerConfigINI;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelRunningCommand;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonExit;
    }
}

