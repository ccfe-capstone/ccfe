namespace Camera_Configuration_File_Editor
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
            this.altitudeTitleLabel = new System.Windows.Forms.Label();
            this.altitudeTextBox = new System.Windows.Forms.TextBox();
            this.cameraResComboBox = new System.Windows.Forms.ComboBox();
            this.camerResLabel = new System.Windows.Forms.Label();
            this.fieldofviewLabel = new System.Windows.Forms.Label();
            this.fieldofviewTextBox = new System.Windows.Forms.TextBox();
            this.pictureBoxModel = new System.Windows.Forms.PictureBox();
            this.altitudeUnitLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.altitudeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxModel)).BeginInit();
            this.SuspendLayout();
            // 
            // altitudeTrackBar
            // 
            this.altitudeTrackBar.Location = new System.Drawing.Point(15, 25);
            this.altitudeTrackBar.Maximum = 500;
            this.altitudeTrackBar.Name = "altitudeTrackBar";
            this.altitudeTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.altitudeTrackBar.Size = new System.Drawing.Size(45, 410);
            this.altitudeTrackBar.TabIndex = 0;
            this.altitudeTrackBar.Scroll += new System.EventHandler(this.altitudeTrackBar_Scroll);
            this.altitudeTrackBar.ValueChanged += new System.EventHandler(this.altitudeTrackBar_ValueChanged);
            // 
            // altitudeTitleLabel
            // 
            this.altitudeTitleLabel.AutoSize = true;
            this.altitudeTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.altitudeTitleLabel.Name = "altitudeTitleLabel";
            this.altitudeTitleLabel.Size = new System.Drawing.Size(42, 13);
            this.altitudeTitleLabel.TabIndex = 1;
            this.altitudeTitleLabel.Text = "Altitude";
            // 
            // altitudeTextBox
            // 
            this.altitudeTextBox.Location = new System.Drawing.Point(47, 258);
            this.altitudeTextBox.Name = "altitudeTextBox";
            this.altitudeTextBox.Size = new System.Drawing.Size(34, 20);
            this.altitudeTextBox.TabIndex = 2;
            this.altitudeTextBox.Text = "0";
            this.altitudeTextBox.TextChanged += new System.EventHandler(this.altitudeTrackBarValueTextBox_TextChanged);
            this.altitudeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.altitudeTrackBarValueTextBox_KeyPress);
            // 
            // cameraResComboBox
            // 
            this.cameraResComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraResComboBox.FormattingEnabled = true;
            this.cameraResComboBox.Items.AddRange(new object[] {
            "1248 x 950",
            "3808 x 2754"});
            this.cameraResComboBox.Location = new System.Drawing.Point(561, 32);
            this.cameraResComboBox.Name = "cameraResComboBox";
            this.cameraResComboBox.Size = new System.Drawing.Size(121, 21);
            this.cameraResComboBox.TabIndex = 3;
            this.cameraResComboBox.SelectedIndexChanged += new System.EventHandler(this.cameraResComboBox_SelectedIndexChanged);
            // 
            // camerResLabel
            // 
            this.camerResLabel.AutoSize = true;
            this.camerResLabel.Location = new System.Drawing.Point(573, 16);
            this.camerResLabel.Name = "camerResLabel";
            this.camerResLabel.Size = new System.Drawing.Size(96, 13);
            this.camerResLabel.TabIndex = 4;
            this.camerResLabel.Text = "Camera Resolution";
            // 
            // fieldofviewLabel
            // 
            this.fieldofviewLabel.AutoSize = true;
            this.fieldofviewLabel.Location = new System.Drawing.Point(599, 75);
            this.fieldofviewLabel.Name = "fieldofviewLabel";
            this.fieldofviewLabel.Size = new System.Drawing.Size(67, 13);
            this.fieldofviewLabel.TabIndex = 5;
            this.fieldofviewLabel.Text = "Field of View";
            // 
            // fieldofviewTextBox
            // 
            this.fieldofviewTextBox.Location = new System.Drawing.Point(582, 91);
            this.fieldofviewTextBox.Name = "fieldofviewTextBox";
            this.fieldofviewTextBox.Size = new System.Drawing.Size(100, 20);
            this.fieldofviewTextBox.TabIndex = 6;
            this.fieldofviewTextBox.Text = "5";
            this.fieldofviewTextBox.TextChanged += new System.EventHandler(this.fieldofviewTextBox_TextChanged);
            this.fieldofviewTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fieldofviewTextBox_KeyPress);
            // 
            // pictureBoxModel
            // 
            this.pictureBoxModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxModel.Location = new System.Drawing.Point(107, 25);
            this.pictureBoxModel.Name = "pictureBoxModel";
            this.pictureBoxModel.Size = new System.Drawing.Size(276, 410);
            this.pictureBoxModel.TabIndex = 7;
            this.pictureBoxModel.TabStop = false;
            this.pictureBoxModel.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxModel_Paint);
            // 
            // altitudeUnitLabel
            // 
            this.altitudeUnitLabel.AutoSize = true;
            this.altitudeUnitLabel.Location = new System.Drawing.Point(87, 261);
            this.altitudeUnitLabel.Name = "altitudeUnitLabel";
            this.altitudeUnitLabel.Size = new System.Drawing.Size(13, 13);
            this.altitudeUnitLabel.TabIndex = 8;
            this.altitudeUnitLabel.Text = "ft";
            // 
            // GSDWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 835);
            this.Controls.Add(this.altitudeUnitLabel);
            this.Controls.Add(this.pictureBoxModel);
            this.Controls.Add(this.fieldofviewTextBox);
            this.Controls.Add(this.fieldofviewLabel);
            this.Controls.Add(this.camerResLabel);
            this.Controls.Add(this.cameraResComboBox);
            this.Controls.Add(this.altitudeTextBox);
            this.Controls.Add(this.altitudeTitleLabel);
            this.Controls.Add(this.altitudeTrackBar);
            this.Name = "GSDWindow";
            this.Text = "GSDWindow";
            ((System.ComponentModel.ISupportInitialize)(this.altitudeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxModel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar altitudeTrackBar;
        private System.Windows.Forms.Label altitudeTitleLabel;
        private System.Windows.Forms.TextBox altitudeTextBox;
        private System.Windows.Forms.ComboBox cameraResComboBox;
        private System.Windows.Forms.Label camerResLabel;
        private System.Windows.Forms.Label fieldofviewLabel;
        private System.Windows.Forms.TextBox fieldofviewTextBox;
        private System.Windows.Forms.PictureBox pictureBoxModel;
        private System.Windows.Forms.Label altitudeUnitLabel;
    }
}