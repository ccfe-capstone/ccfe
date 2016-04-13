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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GSDWindow));
            this.altitudeTrackBar = new System.Windows.Forms.TrackBar();
            this.altitudeTitleLabel = new System.Windows.Forms.Label();
            this.camResComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBoxModel = new System.Windows.Forms.PictureBox();
            this.altitudeUnitLabel = new System.Windows.Forms.Label();
            this.cameraParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.fovGroupBox = new System.Windows.Forms.GroupBox();
            this.fovVTrackBar = new System.Windows.Forms.TrackBar();
            this.fovHTrackBar = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.fovVNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fovHNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.camResGroupBox = new System.Windows.Forms.GroupBox();
            this.camResYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.camResXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.altitudeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.outputPictureInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gsdYLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gsdXLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gsdUnitComboBox = new System.Windows.Forms.ComboBox();
            this.groundCoverageGroupBox = new System.Windows.Forms.GroupBox();
            this.coverageUnitComboBox = new System.Windows.Forms.ComboBox();
            this.coverageLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.altitudeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxModel)).BeginInit();
            this.cameraParametersGroupBox.SuspendLayout();
            this.fovGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fovVTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovHTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovVNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovHNumericUpDown)).BeginInit();
            this.camResGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camResYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camResXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.altitudeNumericUpDown)).BeginInit();
            this.outputPictureInfoGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groundCoverageGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // altitudeTrackBar
            // 
            this.altitudeTrackBar.Location = new System.Drawing.Point(12, 25);
            this.altitudeTrackBar.Maximum = 500;
            this.altitudeTrackBar.Name = "altitudeTrackBar";
            this.altitudeTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.altitudeTrackBar.Size = new System.Drawing.Size(45, 169);
            this.altitudeTrackBar.TabIndex = 0;
            this.altitudeTrackBar.Value = 200;
            this.altitudeTrackBar.ValueChanged += new System.EventHandler(this.altitudeTrackBar_ValueChanged);
            // 
            // altitudeTitleLabel
            // 
            this.altitudeTitleLabel.AutoSize = true;
            this.altitudeTitleLabel.Location = new System.Drawing.Point(9, 9);
            this.altitudeTitleLabel.Name = "altitudeTitleLabel";
            this.altitudeTitleLabel.Size = new System.Drawing.Size(42, 13);
            this.altitudeTitleLabel.TabIndex = 1;
            this.altitudeTitleLabel.Text = "Altitude";
            // 
            // camResComboBox
            // 
            this.camResComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.camResComboBox.FormattingEnabled = true;
            this.camResComboBox.Items.AddRange(new object[] {
            "1248 x 950 - 1.2 MP",
            "3808 x 2754 - 10.5 MP",
            "Custom"});
            this.camResComboBox.Location = new System.Drawing.Point(6, 19);
            this.camResComboBox.Name = "camResComboBox";
            this.camResComboBox.Size = new System.Drawing.Size(131, 21);
            this.camResComboBox.TabIndex = 3;
            this.camResComboBox.SelectedIndexChanged += new System.EventHandler(this.cameraResComboBox_SelectedIndexChanged);
            // 
            // pictureBoxModel
            // 
            this.pictureBoxModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxModel.Location = new System.Drawing.Point(131, 25);
            this.pictureBoxModel.Name = "pictureBoxModel";
            this.pictureBoxModel.Size = new System.Drawing.Size(276, 444);
            this.pictureBoxModel.TabIndex = 7;
            this.pictureBoxModel.TabStop = false;
            this.pictureBoxModel.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxModel_Paint);
            // 
            // altitudeUnitLabel
            // 
            this.altitudeUnitLabel.AutoSize = true;
            this.altitudeUnitLabel.Location = new System.Drawing.Point(112, 108);
            this.altitudeUnitLabel.Name = "altitudeUnitLabel";
            this.altitudeUnitLabel.Size = new System.Drawing.Size(13, 13);
            this.altitudeUnitLabel.TabIndex = 8;
            this.altitudeUnitLabel.Text = "ft";
            // 
            // cameraParametersGroupBox
            // 
            this.cameraParametersGroupBox.Controls.Add(this.fovGroupBox);
            this.cameraParametersGroupBox.Controls.Add(this.camResGroupBox);
            this.cameraParametersGroupBox.Location = new System.Drawing.Point(413, 9);
            this.cameraParametersGroupBox.Name = "cameraParametersGroupBox";
            this.cameraParametersGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cameraParametersGroupBox.Size = new System.Drawing.Size(341, 130);
            this.cameraParametersGroupBox.TabIndex = 9;
            this.cameraParametersGroupBox.TabStop = false;
            this.cameraParametersGroupBox.Text = "Camera Parameters";
            // 
            // fovGroupBox
            // 
            this.fovGroupBox.Controls.Add(this.fovVTrackBar);
            this.fovGroupBox.Controls.Add(this.fovHTrackBar);
            this.fovGroupBox.Controls.Add(this.label9);
            this.fovGroupBox.Controls.Add(this.fovVNumericUpDown);
            this.fovGroupBox.Controls.Add(this.label8);
            this.fovGroupBox.Controls.Add(this.label6);
            this.fovGroupBox.Controls.Add(this.fovHNumericUpDown);
            this.fovGroupBox.Controls.Add(this.label3);
            this.fovGroupBox.Location = new System.Drawing.Point(6, 75);
            this.fovGroupBox.Name = "fovGroupBox";
            this.fovGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fovGroupBox.Size = new System.Drawing.Size(329, 47);
            this.fovGroupBox.TabIndex = 12;
            this.fovGroupBox.TabStop = false;
            this.fovGroupBox.Text = "Field of View";
            // 
            // fovVTrackBar
            // 
            this.fovVTrackBar.Location = new System.Drawing.Point(147, 47);
            this.fovVTrackBar.Name = "fovVTrackBar";
            this.fovVTrackBar.Size = new System.Drawing.Size(109, 45);
            this.fovVTrackBar.TabIndex = 14;
            this.fovVTrackBar.ValueChanged += new System.EventHandler(this.fovVTrackBar_ValueChanged);
            // 
            // fovHTrackBar
            // 
            this.fovHTrackBar.Location = new System.Drawing.Point(9, 47);
            this.fovHTrackBar.Name = "fovHTrackBar";
            this.fovHTrackBar.Size = new System.Drawing.Size(109, 45);
            this.fovHTrackBar.TabIndex = 13;
            this.fovHTrackBar.ValueChanged += new System.EventHandler(this.fovHTrackBar_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(250, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "°";
            // 
            // fovVNumericUpDown
            // 
            this.fovVNumericUpDown.Location = new System.Drawing.Point(195, 21);
            this.fovVNumericUpDown.Name = "fovVNumericUpDown";
            this.fovVNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.fovVNumericUpDown.TabIndex = 11;
            this.fovVNumericUpDown.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.fovVNumericUpDown.Value = new decimal(new int[] {
            44,
            0,
            0,
            0});
            this.fovVNumericUpDown.ValueChanged += new System.EventHandler(this.fovVNumericUpDown_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(144, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Vertical:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Horizontal:";
            // 
            // fovHNumericUpDown
            // 
            this.fovHNumericUpDown.Location = new System.Drawing.Point(69, 21);
            this.fovHNumericUpDown.Name = "fovHNumericUpDown";
            this.fovHNumericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.fovHNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.fovHNumericUpDown.TabIndex = 8;
            this.fovHNumericUpDown.Value = new decimal(new int[] {
            58,
            0,
            0,
            0});
            this.fovHNumericUpDown.ValueChanged += new System.EventHandler(this.fovHNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(124, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "°";
            // 
            // camResGroupBox
            // 
            this.camResGroupBox.Controls.Add(this.camResYNumericUpDown);
            this.camResGroupBox.Controls.Add(this.camResXNumericUpDown);
            this.camResGroupBox.Controls.Add(this.label2);
            this.camResGroupBox.Controls.Add(this.camResComboBox);
            this.camResGroupBox.Controls.Add(this.label1);
            this.camResGroupBox.Location = new System.Drawing.Point(6, 19);
            this.camResGroupBox.Name = "camResGroupBox";
            this.camResGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.camResGroupBox.Size = new System.Drawing.Size(329, 50);
            this.camResGroupBox.TabIndex = 11;
            this.camResGroupBox.TabStop = false;
            this.camResGroupBox.Text = "Camera Resolution";
            // 
            // camResYNumericUpDown
            // 
            this.camResYNumericUpDown.Location = new System.Drawing.Point(258, 19);
            this.camResYNumericUpDown.Name = "camResYNumericUpDown";
            this.camResYNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.camResYNumericUpDown.TabIndex = 12;
            this.camResYNumericUpDown.ValueChanged += new System.EventHandler(this.camResYNumericUpDown_ValueChanged);
            // 
            // camResXNumericUpDown
            // 
            this.camResXNumericUpDown.Location = new System.Drawing.Point(170, 19);
            this.camResXNumericUpDown.Name = "camResXNumericUpDown";
            this.camResXNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.camResXNumericUpDown.TabIndex = 11;
            this.camResXNumericUpDown.ValueChanged += new System.EventHandler(this.camResXNumericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(148, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "or";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "x";
            // 
            // altitudeNumericUpDown
            // 
            this.altitudeNumericUpDown.Location = new System.Drawing.Point(53, 106);
            this.altitudeNumericUpDown.Name = "altitudeNumericUpDown";
            this.altitudeNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.altitudeNumericUpDown.TabIndex = 10;
            this.altitudeNumericUpDown.ThousandsSeparator = true;
            this.altitudeNumericUpDown.ValueChanged += new System.EventHandler(this.altitudeNumericUpDown_ValueChanged);
            // 
            // outputPictureInfoGroupBox
            // 
            this.outputPictureInfoGroupBox.Controls.Add(this.groupBox1);
            this.outputPictureInfoGroupBox.Controls.Add(this.groundCoverageGroupBox);
            this.outputPictureInfoGroupBox.Location = new System.Drawing.Point(413, 190);
            this.outputPictureInfoGroupBox.Name = "outputPictureInfoGroupBox";
            this.outputPictureInfoGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.outputPictureInfoGroupBox.Size = new System.Drawing.Size(341, 323);
            this.outputPictureInfoGroupBox.TabIndex = 11;
            this.outputPictureInfoGroupBox.TabStop = false;
            this.outputPictureInfoGroupBox.Text = "Output Picture Information";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gsdYLabel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.gsdXLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.gsdUnitComboBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(329, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ground Sample Distance (GSD)";
            // 
            // gsdYLabel
            // 
            this.gsdYLabel.AutoSize = true;
            this.gsdYLabel.Location = new System.Drawing.Point(112, 22);
            this.gsdYLabel.Name = "gsdYLabel";
            this.gsdYLabel.Size = new System.Drawing.Size(35, 13);
            this.gsdYLabel.TabIndex = 4;
            this.gsdYLabel.Text = "YYYY";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(95, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "x";
            // 
            // gsdXLabel
            // 
            this.gsdXLabel.AutoSize = true;
            this.gsdXLabel.Location = new System.Drawing.Point(54, 22);
            this.gsdXLabel.Name = "gsdXLabel";
            this.gsdXLabel.Size = new System.Drawing.Size(35, 13);
            this.gsdXLabel.TabIndex = 2;
            this.gsdXLabel.Text = "XXXX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "GSD = ";
            // 
            // gsdUnitComboBox
            // 
            this.gsdUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gsdUnitComboBox.FormattingEnabled = true;
            this.gsdUnitComboBox.Items.AddRange(new object[] {
            "inches",
            "centimeters"});
            this.gsdUnitComboBox.Location = new System.Drawing.Point(203, 19);
            this.gsdUnitComboBox.Name = "gsdUnitComboBox";
            this.gsdUnitComboBox.Size = new System.Drawing.Size(80, 21);
            this.gsdUnitComboBox.TabIndex = 0;
            this.gsdUnitComboBox.SelectedIndexChanged += new System.EventHandler(this.gsdUnitComboBox_SelectedIndexChanged);
            // 
            // groundCoverageGroupBox
            // 
            this.groundCoverageGroupBox.Controls.Add(this.coverageUnitComboBox);
            this.groundCoverageGroupBox.Controls.Add(this.coverageLabel);
            this.groundCoverageGroupBox.Controls.Add(this.label4);
            this.groundCoverageGroupBox.Location = new System.Drawing.Point(6, 19);
            this.groundCoverageGroupBox.Name = "groundCoverageGroupBox";
            this.groundCoverageGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groundCoverageGroupBox.Size = new System.Drawing.Size(329, 43);
            this.groundCoverageGroupBox.TabIndex = 0;
            this.groundCoverageGroupBox.TabStop = false;
            this.groundCoverageGroupBox.Text = "Ground Coverage";
            // 
            // coverageUnitComboBox
            // 
            this.coverageUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coverageUnitComboBox.FormattingEnabled = true;
            this.coverageUnitComboBox.Items.AddRange(new object[] {
            "square feet",
            "square yards",
            "square miles",
            "acres",
            "hectares",
            "square meters",
            "square kilometers"});
            this.coverageUnitComboBox.Location = new System.Drawing.Point(134, 13);
            this.coverageUnitComboBox.Name = "coverageUnitComboBox";
            this.coverageUnitComboBox.Size = new System.Drawing.Size(108, 21);
            this.coverageUnitComboBox.TabIndex = 2;
            this.coverageUnitComboBox.SelectedIndexChanged += new System.EventHandler(this.coverageUnitComboBox_SelectedIndexChanged);
            // 
            // coverageLabel
            // 
            this.coverageLabel.AutoSize = true;
            this.coverageLabel.Location = new System.Drawing.Point(93, 16);
            this.coverageLabel.Name = "coverageLabel";
            this.coverageLabel.Size = new System.Drawing.Size(35, 13);
            this.coverageLabel.TabIndex = 1;
            this.coverageLabel.Text = "XXXX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Coverage Area =";
            // 
            // GSDWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 481);
            this.Controls.Add(this.outputPictureInfoGroupBox);
            this.Controls.Add(this.altitudeNumericUpDown);
            this.Controls.Add(this.cameraParametersGroupBox);
            this.Controls.Add(this.altitudeUnitLabel);
            this.Controls.Add(this.pictureBoxModel);
            this.Controls.Add(this.altitudeTitleLabel);
            this.Controls.Add(this.altitudeTrackBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GSDWindow";
            this.Text = "GSDWindow";
            ((System.ComponentModel.ISupportInitialize)(this.altitudeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxModel)).EndInit();
            this.cameraParametersGroupBox.ResumeLayout(false);
            this.fovGroupBox.ResumeLayout(false);
            this.fovGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fovVTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovHTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovVNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fovHNumericUpDown)).EndInit();
            this.camResGroupBox.ResumeLayout(false);
            this.camResGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camResYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camResXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.altitudeNumericUpDown)).EndInit();
            this.outputPictureInfoGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groundCoverageGroupBox.ResumeLayout(false);
            this.groundCoverageGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar altitudeTrackBar;
        private System.Windows.Forms.Label altitudeTitleLabel;
        private System.Windows.Forms.ComboBox camResComboBox;
        private System.Windows.Forms.PictureBox pictureBoxModel;
        private System.Windows.Forms.Label altitudeUnitLabel;
        private System.Windows.Forms.GroupBox cameraParametersGroupBox;
        private System.Windows.Forms.GroupBox fovGroupBox;
        private System.Windows.Forms.NumericUpDown fovHNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox camResGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown altitudeNumericUpDown;
        private System.Windows.Forms.NumericUpDown camResYNumericUpDown;
        private System.Windows.Forms.NumericUpDown camResXNumericUpDown;
        private System.Windows.Forms.GroupBox outputPictureInfoGroupBox;
        private System.Windows.Forms.GroupBox groundCoverageGroupBox;
        private System.Windows.Forms.ComboBox coverageUnitComboBox;
        private System.Windows.Forms.Label coverageLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox gsdUnitComboBox;
        private System.Windows.Forms.Label gsdXLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label gsdYLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown fovVNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar fovVTrackBar;
        private System.Windows.Forms.TrackBar fovHTrackBar;
    }
}