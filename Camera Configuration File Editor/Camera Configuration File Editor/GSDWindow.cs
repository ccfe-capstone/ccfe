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
            cameraResComboBox.SelectedIndex = 0;

            scaleFactor = (double)pictureBoxModel.ClientSize.Width / MAX_COVERAGE_FEET;
            MAX_COVERAGE = (int)(scaleFactor * MAX_COVERAGE_FEET);
            pictureBoxModel.ClientSize = new Size(pictureBoxModel.ClientSize.Width, (int)(scaleFactor * (MAX_SKY_ALTITUDE + MAX_COVERAGE_FEET)));
            altitudeTrackBar.Height = (int)(pictureBoxModel.ClientSize.Height - MAX_COVERAGE);

            altitudeTrackBar.Maximum = MAX_DRONE_ALTITUDE;
            altitudeTrackBar.Minimum = MIN_DRONE_ALTITUDE;
            altitudeTrackBar.Value = altitudeTrackBar.Minimum;
            followTrackBar();
        }

        private void altitudeTrackBar_Scroll(object sender, EventArgs e)
        {
            altitudeTextBox.Text = altitudeTrackBar.Value.ToString();
            followTrackBar();
            updateGSD();
        }

        private void altitudeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            followTrackBar();
            updateGSD();
        }

        private void followTrackBar()
        {
            moveWithTrackBar(altitudeTextBox);
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

        private void altitudeTrackBarValueTextBox_TextChanged(object sender, EventArgs e)
        {
            sanitizeTextBox(altitudeTextBox, MIN_DRONE_ALTITUDE, MAX_DRONE_ALTITUDE);
            altitudeTrackBar.Value = Convert.ToInt32(altitudeTextBox.Text);
        }

        private void altitudeTrackBarValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar));
        }

        private Size getCameraResolution()
        {
            string[] sizes = cameraResComboBox.Text.Split('x');
            int x = Convert.ToInt32(sizes[0]);
            int y = Convert.ToInt32(sizes[1]);
            return new Size(x, y);
        }

        private void updateGSD()
        {
            groundCoverage = 2 * altitudeTrackBar.Value * Math.Tan((Convert.ToDouble(fieldofviewTextBox.Text) / 2) * (Math.PI / 180.0));
            groundSampleDistanceX = groundCoverage / getCameraResolution().Width;
            groundSampleDistanceY = groundCoverage / getCameraResolution().Height;

            //update model on screen
            pictureBoxModel.Invalidate();
        }

        private void fieldofviewTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar));
        }

        private void cameraResComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateGSD();
        }

        private void fieldofviewTextBox_TextChanged(object sender, EventArgs e)
        {
            sanitizeTextBox(fieldofviewTextBox, MIN_FOV, MAX_FOV);
            updateGSD();
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

        private void sanitizeTextBox(TextBox textbox, int min, int max)
        {
            if (string.IsNullOrEmpty(textbox.Text) || (Convert.ToInt32(textbox.Text) <= min))
            {
                textbox.Text = min.ToString();
            }
            else if (Convert.ToInt32(textbox.Text) >= max)
            {
                textbox.Text = max.ToString();
            }
            else
            {
                textbox.Text = Convert.ToInt32(textbox.Text).ToString();
            }
        }
    }
}
