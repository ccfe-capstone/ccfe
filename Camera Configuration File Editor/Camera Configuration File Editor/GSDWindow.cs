using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camera_Configuration_File_Editor
{
    public partial class GSDWindow : Form
    {
        #region constants
        private const int MAX_DRONE_ALTITUDE = 500;
        private const int MIN_DRONE_ALTITUDE = 0;
        private const int MAX_FOV = 90;
        private const int MIN_FOV = 0;
        private const int MAX_CAMERA_RESOLUTION = 15360; //used 16K digital cinema
        private const int MIN_CAMERA_RESOLUTION = 0;
        private const int MAX_SKY_ALTITUDE = MAX_DRONE_ALTITUDE + 100;

        private const int ACTUAL_FIELD_WIDTH = 360;
        private const int ACTUAL_FIELD_HEIGHT = 120;

        private const int MODEL_DRONE_HEIGHT = 30;
        #endregion

        #region runtime constants
        readonly int MAX_COVERAGE_FEET = (int)(2 * MAX_DRONE_ALTITUDE * Math.Tan((MAX_FOV / 2.0) * Math.PI / 180.0));
        #endregion

        #region variables
        int MAX_COVERAGE;

        Image droneImage = Properties.Resources.drone;
        Image fieldImage = Properties.Resources.field;
        Image skyImage = Properties.Resources.sky;

        double groundSampleDistanceX, groundSampleDistanceY;
        double groundCoverage;

        double scaleFactor;
        #endregion

        public GSDWindow()
        {
            InitializeComponent();

            scaleFactor = (double)pictureBoxModel.ClientSize.Width / MAX_COVERAGE_FEET;
            MAX_COVERAGE = (int)(scaleFactor * MAX_COVERAGE_FEET);

            pictureBoxModel.ClientSize = new Size(pictureBoxModel.ClientSize.Width, (int)(scaleFactor * (MAX_SKY_ALTITUDE + MAX_COVERAGE_FEET)));

            //resize components to match picturebox
            outputPictureInfoGroupBox.Height = pictureBoxModel.Location.Y + pictureBoxModel.Size.Height - outputPictureInfoGroupBox.Location.Y;

            //resize form to fit to picturebox
            ClientSize = new Size(ClientSize.Width, pictureBoxModel.Location.Y + pictureBoxModel.Height + 2*pictureBoxModel.Margin.Bottom);

            //set max and min form size to current size
            MinimumSize = new Size(Width, Height);
            MaximumSize = new Size(Width, Height);

            //initialize combo boxes
            coverageUnitComboBox.SelectedIndex = 0;
            gsdUnitComboBox.SelectedIndex = 0;

            //set max and min
            altitudeNumericUpDown.Maximum = MAX_DRONE_ALTITUDE;
            altitudeNumericUpDown.Minimum = MIN_DRONE_ALTITUDE;

            //set max and min
            fovNumericUpDown.Maximum = MAX_FOV;
            fovNumericUpDown.Minimum = MIN_FOV;

            //set max and min
            camResXNumericUpDown.Maximum = MAX_CAMERA_RESOLUTION;
            camResXNumericUpDown.Minimum = MIN_CAMERA_RESOLUTION;
            camResYNumericUpDown.Maximum = MAX_CAMERA_RESOLUTION;
            camResYNumericUpDown.Minimum = MIN_CAMERA_RESOLUTION;
            camResComboBox.SelectedIndex = 0;

            //set max and min, height, and starting value
            altitudeTrackBar.Height = (int)(pictureBoxModel.ClientSize.Height - MAX_COVERAGE);
            altitudeTrackBar.Maximum = MAX_DRONE_ALTITUDE;
            altitudeTrackBar.Minimum = MIN_DRONE_ALTITUDE;
            altitudeTrackBar.Value = altitudeTrackBar.Minimum;
            followTrackBar();

            updateGSD();
        }

        private void followTrackBar()
        {
            moveWithTrackBar(altitudeNumericUpDown);
            moveWithTrackBar(altitudeUnitLabel);
        }

        //moves control with the trackbar as it scrolls vertically
        private void moveWithTrackBar(Control control)
        {
            int trackBarFF = 10;
            int trackBarBottom = altitudeTrackBar.Location.Y + altitudeTrackBar.Size.Height - trackBarFF;
            int trackBarTop = altitudeTrackBar.Location.Y + trackBarFF;
            control.Location = new Point(control.Location.X, trackBarBottom - (int)(((trackBarBottom - trackBarTop) / (double)MAX_DRONE_ALTITUDE) * altitudeTrackBar.Value) - (control.Height / 2));
        }

        private Size getCameraResolution()
        {
            int x = (int)camResXNumericUpDown.Value;
            int y = (int)camResYNumericUpDown.Value;
            return new Size(x, y);
        }

        private void updateGSD()
        {
            groundCoverage = 2 * altitudeTrackBar.Value * Math.Tan(((double)fovNumericUpDown.Value / 2) * (Math.PI / 180.0));
            Size cameraResolution = getCameraResolution();
            groundSampleDistanceX = groundCoverage / cameraResolution.Width;
            groundSampleDistanceY = groundCoverage / cameraResolution.Height;

            updatePictureInformation();

            //update model on screen
            pictureBoxModel.Invalidate();
        }

        private void updatePictureInformation()
        {
            //coverage
            //calculate in square feet
            double coverageArea = Math.Pow(groundCoverage, 2);

            if (coverageUnitComboBox.Text.Equals("square yards"))
            {
                coverageArea = coverageArea / 9.0;
            }
            else if (coverageUnitComboBox.Text.Equals("square miles"))
            {
                coverageArea = coverageArea / (2.78784 * Math.Pow(10, 7));
            }
            else if (coverageUnitComboBox.Text.Equals("acres"))
            {
                coverageArea = coverageArea / 43560.0;
            }
            else if (coverageUnitComboBox.Text.Equals("hectares"))
            {
                coverageArea = coverageArea / 107639.1;
            }
            else if (coverageUnitComboBox.Text.Equals("square meters"))
            {
                coverageArea = coverageArea / 10.764;
            }
            else if (coverageUnitComboBox.Text.Equals("square kilometers"))
            {
                coverageArea = coverageArea / 10764000.0;
            }
            
            if (coverageArea <= 0.0001 && coverageArea != 0) //coverage area is very small, we should use exponents to display it
            {
                coverageLabel.Text = string.Format("{0:#,0.000e-0}", coverageArea);
            }
            else
            {
                coverageLabel.Text = string.Format("{0:#,0.###}", coverageArea);
            }
            coverageUnitComboBox.Location = new Point(coverageLabel.Location.X + coverageLabel.Size.Width + coverageLabel.Margin.Right, coverageUnitComboBox.Location.Y);

            //gsd
            //calculate in inches by default
            double convertedGSDX = groundSampleDistanceX * 12.0;
            double convertedGSDY = groundSampleDistanceY * 12.0;

            if (gsdUnitComboBox.Text.Equals("centimeters"))
            {
                convertedGSDX = groundSampleDistanceX * 30.48;
                convertedGSDY = groundSampleDistanceY * 30.48;
            }
            gsdXLabel.Text = string.Format("{0:#,0.###}", convertedGSDX);
            gsdYLabel.Text = string.Format("{0:#,0.###}", convertedGSDY);
        }

        private void pictureBoxModel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //draw outside
            int pictureBoxMidX = pictureBoxModel.ClientSize.Width / 2;

            int outsideWidth = pictureBoxModel.ClientSize.Width - 1;
            int outsideHeight = outsideWidth;
            Size outsideSize = new Size(outsideWidth, outsideHeight);

            int outsideX = 0;
            int outsideY = pictureBoxModel.ClientSize.Height - outsideHeight - 1;
            Point outsideLocation = new Point(outsideX, outsideY);

            Rectangle outsideRect = new Rectangle(outsideLocation, outsideSize);

            Brush outsideBrush = new SolidBrush(Color.ForestGreen);

            g.FillRectangle(outsideBrush, outsideRect);

            //draw field
            int fieldWidth = (int)(ACTUAL_FIELD_WIDTH * ((double)outsideWidth / MAX_COVERAGE_FEET));
            int fieldHeight = (int)(fieldWidth * ((double)ACTUAL_FIELD_HEIGHT / ACTUAL_FIELD_WIDTH));
            Size fieldSize = new Size(fieldWidth, fieldHeight);

            int outsideMidY = outsideY + outsideHeight / 2;
            int fieldX = pictureBoxMidX - fieldWidth / 2;
            int fieldY = outsideMidY - fieldHeight / 2;
            Point fieldLocation = new Point(fieldX, fieldY);

            Rectangle fieldRect = new Rectangle(fieldLocation, fieldSize);

            g.DrawImage(fieldImage, fieldRect);

            //draw sky
            int skyWidth = outsideWidth;
            int skyHeight = outsideY;
            Size skySize = new Size(skyWidth, skyHeight);

            int skyX = outsideX;
            int skyY = 0;
            Point skyLocation = new Point(skyX, skyY);

            Rectangle skyRect = new Rectangle(skyLocation, skySize);

            int skySrcX = 0;
            int skySrcY = skyImage.Height - skyHeight;

            g.DrawImage(skyImage, skyRect, skySrcX, skySrcY, skyWidth, skyHeight, GraphicsUnit.Pixel);

            //draw coverage
            int coverageWidth = Math.Min((int)(groundCoverage * scaleFactor), outsideWidth - 1);
            int coverageHeight = Math.Min((int)(groundCoverage * scaleFactor), outsideHeight - 1);
            Size coverageSize = new Size(coverageWidth, coverageHeight);

            int fieldMixX = fieldLocation.X + fieldSize.Width / 2;
            int fieldMidY = fieldLocation.Y + fieldSize.Height / 2;
            int coverageX = fieldMixX - (coverageSize.Width / 2);
            int coverageY = fieldMidY - (coverageSize.Height / 2);
            Point coverageLocation = new Point(coverageX, coverageY);

            Rectangle coverageRect = new Rectangle(coverageLocation, coverageSize);

            Pen coveragePen = new Pen(Color.Red);
            g.DrawRectangle(coveragePen, coverageRect);

            //draw drone
            int droneAltitude = altitudeTrackBar.Value;

            int droneHeight = MODEL_DRONE_HEIGHT;
            int droneWidth = ((droneImage.Width / droneImage.Height) * droneHeight);
            Size droneSize = new Size(droneWidth, droneHeight);

            int droneX = pictureBoxMidX - (droneWidth / 2);
            double skyScaleY = (double)skyHeight / (MAX_SKY_ALTITUDE);
            int droneY = outsideY - droneHeight - (int)(droneAltitude * skyScaleY);
            Point droneLocation = new Point(droneX, droneY);

            Rectangle droneRect = new Rectangle(droneLocation, droneSize);

            g.DrawImage(droneImage, droneRect);

            //draw FOV lines
            int droneMidX = droneLocation.X + droneSize.Width / 2;
            Point fovTopPoint = new Point(droneMidX, droneLocation.Y + droneSize.Height);

            int fovBottomY = outsideY;
            int fovBottomWidth = coverageWidth / 2;

            Point fovLeftPoint = new Point(droneMidX - fovBottomWidth, fovBottomY);
            Point fovRightPoint = new Point(droneMidX + fovBottomWidth, fovBottomY);

            Pen fovPen = new Pen(Color.Red);
            g.DrawLine(fovPen, fovTopPoint, fovLeftPoint);
            g.DrawLine(fovPen, fovTopPoint, fovRightPoint);
            g.DrawLine(fovPen, fovLeftPoint, fovRightPoint);
        }

        private void altitudeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            altitudeNumericUpDown.Value = altitudeTrackBar.Value;
            followTrackBar();
            updateGSD();
        }

        private void altitudeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            altitudeTrackBar.Value = (int)altitudeNumericUpDown.Value;
        }

        private void fovNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            updateGSD();
        }

        private void cameraResComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!camResComboBox.Text.Equals("Custom"))
            {
                string[] resolution = camResComboBox.Text.Split(); //1248 x 950 - 1.2MP
                camResXNumericUpDown.Value = Convert.ToInt32(resolution[0]);
                camResYNumericUpDown.Value = Convert.ToInt32(resolution[2]);
            }
        }

        private void coverageUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePictureInformation();
        }

        private void gsdUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePictureInformation();
        }

        private void camResXNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            camResCustomCheck();
            updateGSD();
        }

        private void camResYNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            camResCustomCheck();
            updateGSD();
        }

        //depending on what is in the camera resolution x and y, the combo box may be changed to custom
        private void camResCustomCheck()
        {
            for (int i = 0; i < camResComboBox.Items.Count - 1; i++)
            {
                string[] resolution = camResComboBox.Items[i].ToString().Split();
                if ((camResXNumericUpDown.Value == Convert.ToDecimal(resolution[0])) && (camResYNumericUpDown.Value == Convert.ToDecimal(resolution[2])))
                {
                    camResComboBox.SelectedIndex = camResComboBox.FindString(camResComboBox.Items[i].ToString());
                    return;
                }
                else
                {
                    camResComboBox.SelectedIndex = camResComboBox.FindString("Custom");
                }
            }
        }
    }
}
