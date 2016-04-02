﻿namespace Camera_Configuration_File_Editor
{
    partial class GSDWindow
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
            this.altitudeTrackBar = new System.Windows.Forms.TrackBar();
            this.altitudeLabel = new System.Windows.Forms.Label();
            this.altitudeTrackBarValueTextBox = new System.Windows.Forms.TextBox();
            this.cameraResComboBox = new System.Windows.Forms.ComboBox();
            this.camerResLabel = new System.Windows.Forms.Label();
            this.fieldofviewLabel = new System.Windows.Forms.Label();
            this.fieldofviewTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.altitudeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // altitudeTrackBar
            // 
            this.altitudeTrackBar.Location = new System.Drawing.Point(12, 85);
            this.altitudeTrackBar.Maximum = 500;
            this.altitudeTrackBar.Name = "altitudeTrackBar";
            this.altitudeTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.altitudeTrackBar.Size = new System.Drawing.Size(45, 502);
            this.altitudeTrackBar.TabIndex = 0;
            this.altitudeTrackBar.Scroll += new System.EventHandler(this.altitudeTrackBar_Scroll);
            this.altitudeTrackBar.ValueChanged += new System.EventHandler(this.altitudeTrackBar_ValueChanged);
            // 
            // altitudeLabel
            // 
            this.altitudeLabel.AutoSize = true;
            this.altitudeLabel.Location = new System.Drawing.Point(15, 69);
            this.altitudeLabel.Name = "altitudeLabel";
            this.altitudeLabel.Size = new System.Drawing.Size(69, 13);
            this.altitudeLabel.TabIndex = 1;
            this.altitudeLabel.Text = "Altitude (feet)";
            // 
            // altitudeTrackBarValueTextBox
            // 
            this.altitudeTrackBarValueTextBox.Location = new System.Drawing.Point(50, 276);
            this.altitudeTrackBarValueTextBox.Name = "altitudeTrackBarValueTextBox";
            this.altitudeTrackBarValueTextBox.Size = new System.Drawing.Size(34, 20);
            this.altitudeTrackBarValueTextBox.TabIndex = 2;
            this.altitudeTrackBarValueTextBox.Text = "0";
            this.altitudeTrackBarValueTextBox.TextChanged += new System.EventHandler(this.altitudeTrackBarValueTextBox_TextChanged);
            this.altitudeTrackBarValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.altitudeTrackBarValueTextBox_KeyPress);
            // 
            // cameraResComboBox
            // 
            this.cameraResComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraResComboBox.FormattingEnabled = true;
            this.cameraResComboBox.Items.AddRange(new object[] {
            "1248 x 950",
            "3808 x 2754"});
            this.cameraResComboBox.Location = new System.Drawing.Point(1017, 26);
            this.cameraResComboBox.Name = "cameraResComboBox";
            this.cameraResComboBox.Size = new System.Drawing.Size(121, 21);
            this.cameraResComboBox.TabIndex = 3;
            this.cameraResComboBox.SelectedIndexChanged += new System.EventHandler(this.cameraResComboBox_SelectedIndexChanged);
            // 
            // camerResLabel
            // 
            this.camerResLabel.AutoSize = true;
            this.camerResLabel.Location = new System.Drawing.Point(1029, 10);
            this.camerResLabel.Name = "camerResLabel";
            this.camerResLabel.Size = new System.Drawing.Size(96, 13);
            this.camerResLabel.TabIndex = 4;
            this.camerResLabel.Text = "Camera Resolution";
            // 
            // fieldofviewLabel
            // 
            this.fieldofviewLabel.AutoSize = true;
            this.fieldofviewLabel.Location = new System.Drawing.Point(1055, 69);
            this.fieldofviewLabel.Name = "fieldofviewLabel";
            this.fieldofviewLabel.Size = new System.Drawing.Size(67, 13);
            this.fieldofviewLabel.TabIndex = 5;
            this.fieldofviewLabel.Text = "Field of View";
            // 
            // fieldofviewTextBox
            // 
            this.fieldofviewTextBox.Location = new System.Drawing.Point(1038, 85);
            this.fieldofviewTextBox.Name = "fieldofviewTextBox";
            this.fieldofviewTextBox.Size = new System.Drawing.Size(100, 20);
            this.fieldofviewTextBox.TabIndex = 6;
            this.fieldofviewTextBox.Text = "5";
            this.fieldofviewTextBox.TextChanged += new System.EventHandler(this.fieldofviewTextBox_TextChanged);
            this.fieldofviewTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fieldofviewTextBox_KeyPress);
            // 
            // GSDWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 835);
            this.Controls.Add(this.fieldofviewTextBox);
            this.Controls.Add(this.fieldofviewLabel);
            this.Controls.Add(this.camerResLabel);
            this.Controls.Add(this.cameraResComboBox);
            this.Controls.Add(this.altitudeTrackBarValueTextBox);
            this.Controls.Add(this.altitudeLabel);
            this.Controls.Add(this.altitudeTrackBar);
            this.DoubleBuffered = true;
            this.Name = "GSDWindow";
            this.Text = "GSDWindow";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GSDWindow_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.altitudeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar altitudeTrackBar;
        private System.Windows.Forms.Label altitudeLabel;
        private System.Windows.Forms.TextBox altitudeTrackBarValueTextBox;
        private System.Windows.Forms.ComboBox cameraResComboBox;
        private System.Windows.Forms.Label camerResLabel;
        private System.Windows.Forms.Label fieldofviewLabel;
        private System.Windows.Forms.TextBox fieldofviewTextBox;
    }
}