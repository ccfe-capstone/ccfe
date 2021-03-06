﻿namespace Camera_Configuration_File_Editor
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.gSDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TriggerModeGroupBox = new System.Windows.Forms.GroupBox();
            this.triggerModeComboBox = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TriggerOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.triggerOptionsPanel = new System.Windows.Forms.Panel();
            this.triggerDistancePanel = new System.Windows.Forms.Panel();
            this.triggerDistanceUnit = new System.Windows.Forms.Label();
            this.triggerDistanceLabel = new System.Windows.Forms.Label();
            this.triggerDistanceValue = new System.Windows.Forms.TextBox();
            this.overlapPanel = new System.Windows.Forms.Panel();
            this.overlapTrackBarValueLabel = new System.Windows.Forms.Label();
            this.overlapLabel = new System.Windows.Forms.Label();
            this.overlapTrackBarMinLabel = new System.Windows.Forms.Label();
            this.overlapTrackBarMaxLabel = new System.Windows.Forms.Label();
            this.overlapTrackBar = new System.Windows.Forms.TrackBar();
            this.waitForGpsFixPanel = new System.Windows.Forms.Panel();
            this.waitForGpsFixValue = new System.Windows.Forms.CheckBox();
            this.triggerPeriodPanel = new System.Windows.Forms.Panel();
            this.triggerPeriodLabel = new System.Windows.Forms.Label();
            this.triggerPeriodUnit = new System.Windows.Forms.Label();
            this.triggerPeriodValue = new System.Windows.Forms.TextBox();
            this.knownHalAltPanel = new System.Windows.Forms.Panel();
            this.knownHalLabel = new System.Windows.Forms.Label();
            this.knownHalAltitudeValue = new System.Windows.Forms.TextBox();
            this.knownHalAltitudeUnit = new System.Windows.Forms.ComboBox();
            this.saveConfigurationButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.TriggerModeGroupBox.SuspendLayout();
            this.TriggerOptionsGroupBox.SuspendLayout();
            this.triggerOptionsPanel.SuspendLayout();
            this.triggerDistancePanel.SuspendLayout();
            this.overlapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overlapTrackBar)).BeginInit();
            this.waitForGpsFixPanel.SuspendLayout();
            this.triggerPeriodPanel.SuspendLayout();
            this.knownHalAltPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.verToolStripMenuItem,
            this.gSDToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(553, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadDefaultsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // loadDefaultsToolStripMenuItem
            // 
            this.loadDefaultsToolStripMenuItem.Name = "loadDefaultsToolStripMenuItem";
            this.loadDefaultsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadDefaultsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.loadDefaultsToolStripMenuItem.Text = "Load Defaults";
            this.loadDefaultsToolStripMenuItem.Click += new System.EventHandler(this.loadDefaultsToolStripMenuItem_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.verToolStripMenuItem.Text = "Version";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(152, 23);
            this.versionToolStripMenuItem.SelectedIndexChanged += new System.EventHandler(this.versionToolStripMenuItem_SelectedIndexChanged);
            // 
            // gSDToolStripMenuItem
            // 
            this.gSDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchCalculatorToolStripMenuItem});
            this.gSDToolStripMenuItem.Name = "gSDToolStripMenuItem";
            this.gSDToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.gSDToolStripMenuItem.Text = "GSD";
            // 
            // launchCalculatorToolStripMenuItem
            // 
            this.launchCalculatorToolStripMenuItem.Name = "launchCalculatorToolStripMenuItem";
            this.launchCalculatorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.launchCalculatorToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.launchCalculatorToolStripMenuItem.Text = "Launch Calculator";
            this.launchCalculatorToolStripMenuItem.Click += new System.EventHandler(this.launchCalculatorToolStripMenuItem_Click);
            // 
            // TriggerModeGroupBox
            // 
            this.TriggerModeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TriggerModeGroupBox.Controls.Add(this.triggerModeComboBox);
            this.TriggerModeGroupBox.Location = new System.Drawing.Point(13, 28);
            this.TriggerModeGroupBox.Name = "TriggerModeGroupBox";
            this.TriggerModeGroupBox.Size = new System.Drawing.Size(528, 58);
            this.TriggerModeGroupBox.TabIndex = 4;
            this.TriggerModeGroupBox.TabStop = false;
            this.TriggerModeGroupBox.Text = "Trigger Mode";
            // 
            // triggerModeComboBox
            // 
            this.triggerModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.triggerModeComboBox.FormattingEnabled = true;
            this.triggerModeComboBox.Items.AddRange(new object[] {
            "Time (for systems without GPS only)",
            "Network",
            "MAVlink",
            "GPS Distance",
            "GPS Time",
            "GPS Overlap - Auto Detect Altitude",
            "GPS Overlap - Known Altitude"});
            this.triggerModeComboBox.Location = new System.Drawing.Point(43, 19);
            this.triggerModeComboBox.Name = "triggerModeComboBox";
            this.triggerModeComboBox.Size = new System.Drawing.Size(197, 21);
            this.triggerModeComboBox.TabIndex = 0;
            this.triggerModeComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.Filter = "Configuration Files|*.txt|All Files|*.*";
            this.openFileDialog.InitialDirectory = "C:\\";
            this.openFileDialog.Title = "Open Configuration File";
            // 
            // TriggerOptionsGroupBox
            // 
            this.TriggerOptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TriggerOptionsGroupBox.Controls.Add(this.triggerOptionsPanel);
            this.TriggerOptionsGroupBox.Location = new System.Drawing.Point(13, 92);
            this.TriggerOptionsGroupBox.Name = "TriggerOptionsGroupBox";
            this.TriggerOptionsGroupBox.Size = new System.Drawing.Size(528, 252);
            this.TriggerOptionsGroupBox.TabIndex = 5;
            this.TriggerOptionsGroupBox.TabStop = false;
            this.TriggerOptionsGroupBox.Text = "Trigger Options";
            // 
            // triggerOptionsPanel
            // 
            this.triggerOptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.triggerOptionsPanel.AutoScroll = true;
            this.triggerOptionsPanel.Controls.Add(this.triggerDistancePanel);
            this.triggerOptionsPanel.Controls.Add(this.overlapPanel);
            this.triggerOptionsPanel.Controls.Add(this.waitForGpsFixPanel);
            this.triggerOptionsPanel.Controls.Add(this.triggerPeriodPanel);
            this.triggerOptionsPanel.Controls.Add(this.knownHalAltPanel);
            this.triggerOptionsPanel.Location = new System.Drawing.Point(6, 19);
            this.triggerOptionsPanel.Name = "triggerOptionsPanel";
            this.triggerOptionsPanel.Size = new System.Drawing.Size(516, 227);
            this.triggerOptionsPanel.TabIndex = 9;
            // 
            // triggerDistancePanel
            // 
            this.triggerDistancePanel.AutoSize = true;
            this.triggerDistancePanel.Controls.Add(this.triggerDistanceUnit);
            this.triggerDistancePanel.Controls.Add(this.triggerDistanceLabel);
            this.triggerDistancePanel.Controls.Add(this.triggerDistanceValue);
            this.triggerDistancePanel.Location = new System.Drawing.Point(3, 186);
            this.triggerDistancePanel.Name = "triggerDistancePanel";
            this.triggerDistancePanel.Size = new System.Drawing.Size(216, 37);
            this.triggerDistancePanel.TabIndex = 8;
            // 
            // triggerDistanceUnit
            // 
            this.triggerDistanceUnit.AutoSize = true;
            this.triggerDistanceUnit.Location = new System.Drawing.Point(167, 11);
            this.triggerDistanceUnit.Name = "triggerDistanceUnit";
            this.triggerDistanceUnit.Size = new System.Drawing.Size(38, 13);
            this.triggerDistanceUnit.TabIndex = 8;
            this.triggerDistanceUnit.Text = "meters";
            // 
            // triggerDistanceLabel
            // 
            this.triggerDistanceLabel.AutoSize = true;
            this.triggerDistanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.triggerDistanceLabel.Location = new System.Drawing.Point(3, 9);
            this.triggerDistanceLabel.Name = "triggerDistanceLabel";
            this.triggerDistanceLabel.Size = new System.Drawing.Size(100, 15);
            this.triggerDistanceLabel.TabIndex = 4;
            this.triggerDistanceLabel.Text = "Trigger Distance:";
            // 
            // triggerDistanceValue
            // 
            this.triggerDistanceValue.Location = new System.Drawing.Point(109, 8);
            this.triggerDistanceValue.Name = "triggerDistanceValue";
            this.triggerDistanceValue.Size = new System.Drawing.Size(52, 20);
            this.triggerDistanceValue.TabIndex = 6;
            this.triggerDistanceValue.TextChanged += new System.EventHandler(this.triggerDistanceValue_TextChanged);
            // 
            // overlapPanel
            // 
            this.overlapPanel.Controls.Add(this.overlapTrackBarValueLabel);
            this.overlapPanel.Controls.Add(this.overlapLabel);
            this.overlapPanel.Controls.Add(this.overlapTrackBarMinLabel);
            this.overlapPanel.Controls.Add(this.overlapTrackBarMaxLabel);
            this.overlapPanel.Controls.Add(this.overlapTrackBar);
            this.overlapPanel.Location = new System.Drawing.Point(3, 3);
            this.overlapPanel.Name = "overlapPanel";
            this.overlapPanel.Size = new System.Drawing.Size(468, 56);
            this.overlapPanel.TabIndex = 5;
            // 
            // overlapTrackBarValueLabel
            // 
            this.overlapTrackBarValueLabel.AutoSize = true;
            this.overlapTrackBarValueLabel.Location = new System.Drawing.Point(101, 35);
            this.overlapTrackBarValueLabel.Name = "overlapTrackBarValueLabel";
            this.overlapTrackBarValueLabel.Size = new System.Drawing.Size(21, 13);
            this.overlapTrackBarValueLabel.TabIndex = 4;
            this.overlapTrackBarValueLabel.Text = "0%";
            // 
            // overlapLabel
            // 
            this.overlapLabel.AutoSize = true;
            this.overlapLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overlapLabel.Location = new System.Drawing.Point(3, 9);
            this.overlapLabel.Name = "overlapLabel";
            this.overlapLabel.Size = new System.Drawing.Size(66, 15);
            this.overlapLabel.TabIndex = 1;
            this.overlapLabel.Text = "Overlap %:";
            // 
            // overlapTrackBarMinLabel
            // 
            this.overlapTrackBarMinLabel.AutoSize = true;
            this.overlapTrackBarMinLabel.Location = new System.Drawing.Point(75, 11);
            this.overlapTrackBarMinLabel.Name = "overlapTrackBarMinLabel";
            this.overlapTrackBarMinLabel.Size = new System.Drawing.Size(21, 13);
            this.overlapTrackBarMinLabel.TabIndex = 2;
            this.overlapTrackBarMinLabel.Text = "0%";
            // 
            // overlapTrackBarMaxLabel
            // 
            this.overlapTrackBarMaxLabel.AutoSize = true;
            this.overlapTrackBarMaxLabel.Location = new System.Drawing.Point(427, 11);
            this.overlapTrackBarMaxLabel.Name = "overlapTrackBarMaxLabel";
            this.overlapTrackBarMaxLabel.Size = new System.Drawing.Size(33, 13);
            this.overlapTrackBarMaxLabel.TabIndex = 3;
            this.overlapTrackBarMaxLabel.Text = "100%";
            // 
            // overlapTrackBar
            // 
            this.overlapTrackBar.Location = new System.Drawing.Point(94, 9);
            this.overlapTrackBar.Maximum = 100;
            this.overlapTrackBar.Name = "overlapTrackBar";
            this.overlapTrackBar.Size = new System.Drawing.Size(327, 45);
            this.overlapTrackBar.TabIndex = 0;
            this.overlapTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // waitForGpsFixPanel
            // 
            this.waitForGpsFixPanel.Controls.Add(this.waitForGpsFixValue);
            this.waitForGpsFixPanel.Location = new System.Drawing.Point(3, 63);
            this.waitForGpsFixPanel.Name = "waitForGpsFixPanel";
            this.waitForGpsFixPanel.Size = new System.Drawing.Size(134, 25);
            this.waitForGpsFixPanel.TabIndex = 7;
            // 
            // waitForGpsFixValue
            // 
            this.waitForGpsFixValue.AutoSize = true;
            this.waitForGpsFixValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitForGpsFixValue.Location = new System.Drawing.Point(6, 3);
            this.waitForGpsFixValue.Name = "waitForGpsFixValue";
            this.waitForGpsFixValue.Size = new System.Drawing.Size(118, 19);
            this.waitForGpsFixValue.TabIndex = 4;
            this.waitForGpsFixValue.Text = "Wait For GPS Fix";
            this.waitForGpsFixValue.UseVisualStyleBackColor = true;
            // 
            // triggerPeriodPanel
            // 
            this.triggerPeriodPanel.Controls.Add(this.triggerPeriodLabel);
            this.triggerPeriodPanel.Controls.Add(this.triggerPeriodUnit);
            this.triggerPeriodPanel.Controls.Add(this.triggerPeriodValue);
            this.triggerPeriodPanel.Location = new System.Drawing.Point(3, 143);
            this.triggerPeriodPanel.Name = "triggerPeriodPanel";
            this.triggerPeriodPanel.Size = new System.Drawing.Size(204, 37);
            this.triggerPeriodPanel.TabIndex = 7;
            // 
            // triggerPeriodLabel
            // 
            this.triggerPeriodLabel.AutoSize = true;
            this.triggerPeriodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.triggerPeriodLabel.Location = new System.Drawing.Point(3, 9);
            this.triggerPeriodLabel.Name = "triggerPeriodLabel";
            this.triggerPeriodLabel.Size = new System.Drawing.Size(88, 15);
            this.triggerPeriodLabel.TabIndex = 3;
            this.triggerPeriodLabel.Text = "Trigger Period:";
            // 
            // triggerPeriodUnit
            // 
            this.triggerPeriodUnit.AutoSize = true;
            this.triggerPeriodUnit.Location = new System.Drawing.Point(152, 11);
            this.triggerPeriodUnit.Name = "triggerPeriodUnit";
            this.triggerPeriodUnit.Size = new System.Drawing.Size(47, 13);
            this.triggerPeriodUnit.TabIndex = 7;
            this.triggerPeriodUnit.Text = "seconds";
            // 
            // triggerPeriodValue
            // 
            this.triggerPeriodValue.Location = new System.Drawing.Point(94, 8);
            this.triggerPeriodValue.Name = "triggerPeriodValue";
            this.triggerPeriodValue.Size = new System.Drawing.Size(52, 20);
            this.triggerPeriodValue.TabIndex = 5;
            // 
            // knownHalAltPanel
            // 
            this.knownHalAltPanel.Controls.Add(this.knownHalLabel);
            this.knownHalAltPanel.Controls.Add(this.knownHalAltitudeValue);
            this.knownHalAltPanel.Controls.Add(this.knownHalAltitudeUnit);
            this.knownHalAltPanel.Location = new System.Drawing.Point(3, 94);
            this.knownHalAltPanel.Name = "knownHalAltPanel";
            this.knownHalAltPanel.Size = new System.Drawing.Size(242, 43);
            this.knownHalAltPanel.TabIndex = 6;
            // 
            // knownHalLabel
            // 
            this.knownHalLabel.AutoSize = true;
            this.knownHalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knownHalLabel.Location = new System.Drawing.Point(3, 16);
            this.knownHalLabel.Name = "knownHalLabel";
            this.knownHalLabel.Size = new System.Drawing.Size(113, 15);
            this.knownHalLabel.TabIndex = 0;
            this.knownHalLabel.Text = "Known Hal Altitude:";
            // 
            // knownHalAltitudeValue
            // 
            this.knownHalAltitudeValue.Location = new System.Drawing.Point(122, 16);
            this.knownHalAltitudeValue.Name = "knownHalAltitudeValue";
            this.knownHalAltitudeValue.Size = new System.Drawing.Size(43, 20);
            this.knownHalAltitudeValue.TabIndex = 1;
            this.knownHalAltitudeValue.TextChanged += new System.EventHandler(this.knownHalAltitudeValue_TextChanged);
            // 
            // knownHalAltitudeUnit
            // 
            this.knownHalAltitudeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.knownHalAltitudeUnit.FormattingEnabled = true;
            this.knownHalAltitudeUnit.Items.AddRange(new object[] {
            "feet",
            "meters"});
            this.knownHalAltitudeUnit.Location = new System.Drawing.Point(171, 16);
            this.knownHalAltitudeUnit.Name = "knownHalAltitudeUnit";
            this.knownHalAltitudeUnit.Size = new System.Drawing.Size(63, 21);
            this.knownHalAltitudeUnit.TabIndex = 2;
            this.knownHalAltitudeUnit.SelectedIndexChanged += new System.EventHandler(this.knownHalAltitudeUnit_SelectedIndexChanged);
            // 
            // saveConfigurationButton
            // 
            this.saveConfigurationButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveConfigurationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveConfigurationButton.Location = new System.Drawing.Point(227, 350);
            this.saveConfigurationButton.MaximumSize = new System.Drawing.Size(96, 34);
            this.saveConfigurationButton.Name = "saveConfigurationButton";
            this.saveConfigurationButton.Size = new System.Drawing.Size(96, 34);
            this.saveConfigurationButton.TabIndex = 6;
            this.saveConfigurationButton.Text = "Save";
            this.saveConfigurationButton.UseVisualStyleBackColor = true;
            this.saveConfigurationButton.Click += new System.EventHandler(this.saveConfigurationButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.FileName = "UserSettings";
            this.saveFileDialog.Filter = "Configuration Files|*.txt|All Files|*.*";
            this.saveFileDialog.Title = "Save Configuration File";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 391);
            this.Controls.Add(this.saveConfigurationButton);
            this.Controls.Add(this.TriggerOptionsGroupBox);
            this.Controls.Add(this.TriggerModeGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(569, 430);
            this.Name = "MainWindow";
            this.Text = "Camera Configuration File Editor";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TriggerModeGroupBox.ResumeLayout(false);
            this.TriggerOptionsGroupBox.ResumeLayout(false);
            this.triggerOptionsPanel.ResumeLayout(false);
            this.triggerOptionsPanel.PerformLayout();
            this.triggerDistancePanel.ResumeLayout(false);
            this.triggerDistancePanel.PerformLayout();
            this.overlapPanel.ResumeLayout(false);
            this.overlapPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overlapTrackBar)).EndInit();
            this.waitForGpsFixPanel.ResumeLayout(false);
            this.waitForGpsFixPanel.PerformLayout();
            this.triggerPeriodPanel.ResumeLayout(false);
            this.triggerPeriodPanel.PerformLayout();
            this.knownHalAltPanel.ResumeLayout(false);
            this.knownHalAltPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDefaultsToolStripMenuItem;
        private System.Windows.Forms.GroupBox TriggerModeGroupBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem gSDToolStripMenuItem;
        private System.Windows.Forms.ComboBox triggerModeComboBox;
        private System.Windows.Forms.GroupBox TriggerOptionsGroupBox;
        private System.Windows.Forms.TrackBar overlapTrackBar;
        private System.Windows.Forms.Label overlapTrackBarMaxLabel;
        private System.Windows.Forms.Label overlapTrackBarMinLabel;
        private System.Windows.Forms.Label overlapLabel;
        private System.Windows.Forms.CheckBox waitForGpsFixValue;
        private System.Windows.Forms.Panel overlapPanel;
        private System.Windows.Forms.ComboBox knownHalAltitudeUnit;
        private System.Windows.Forms.TextBox knownHalAltitudeValue;
        private System.Windows.Forms.Label knownHalLabel;
        private System.Windows.Forms.TextBox triggerDistanceValue;
        private System.Windows.Forms.TextBox triggerPeriodValue;
        private System.Windows.Forms.Label triggerDistanceLabel;
        private System.Windows.Forms.Label triggerPeriodLabel;
        private System.Windows.Forms.Label triggerDistanceUnit;
        private System.Windows.Forms.Label triggerPeriodUnit;
        private System.Windows.Forms.Panel triggerPeriodPanel;
        private System.Windows.Forms.Panel waitForGpsFixPanel;
        private System.Windows.Forms.Panel knownHalAltPanel;
        private System.Windows.Forms.Panel triggerDistancePanel;
        private System.Windows.Forms.Button saveConfigurationButton;
        private System.Windows.Forms.Label overlapTrackBarValueLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox versionToolStripMenuItem;
        private System.Windows.Forms.Panel triggerOptionsPanel;
        private System.Windows.Forms.ToolStripMenuItem launchCalculatorToolStripMenuItem;
    }
}

