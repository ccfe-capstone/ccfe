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
        private const int ACTUAL_FIELD_WIDTH = 360;
        private const int ACTUAL_FIELD_HEIGHT = 120;

        Image droneImage = Properties.Resources.drone;
        Image fieldImage = Properties.Resources.football_field;
        Image skyImage = Properties.Resources.sky;

        double groundSampleDistanceX, groundSampleDistanceY;
        double groundCoverage;

        public GSDWindow()
        {
            InitializeComponent();
            setTrackBarTextBoxLocationAndText();
            cameraResComboBox.SelectedIndex = 0;
        }

        private void altitudeTrackBar_Scroll(object sender, EventArgs e)
        {
            altitudeTrackBarValueTextBox.Text = altitudeTrackBar.Value.ToString();
            setTrackBarTextBoxLocationAndText();
            updateGSD();
        }

        private void altitudeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            setTrackBarTextBoxLocationAndText();
            updateGSD();
        }

        private void setTrackBarTextBoxLocationAndText()
        {
            altitudeTrackBarValueTextBox.Location = determineCoordsOfAltitudeTrackBar();
        }

        //needed to move the textbox with the trackbar as it scrolls vertically
        private Point determineCoordsOfAltitudeTrackBar()
        {
            int trackBarFF = 20;
            int trackBarBottom = altitudeTrackBar.Location.Y + altitudeTrackBar.Size.Height - trackBarFF;
            int trackBarTop = altitudeTrackBar.Location.Y + trackBarFF;
            return new Point(altitudeTrackBarValueTextBox.Location.X, trackBarBottom - (int)(((trackBarBottom - trackBarTop) / 485.0)*altitudeTrackBar.Value) - 5);
        }

        private void altitudeTrackBarValueTextBox_TextChanged(object sender, EventArgs e)
        {
            sanitizeTextBox(altitudeTrackBarValueTextBox, 0, 500);
            altitudeTrackBar.Value = Convert.ToInt32(altitudeTrackBarValueTextBox.Text);
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
            Refresh();
        }

        private void GSDWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //draw field
            int midWindowX = Size.Width / 2;

            int fieldHeight = 200;
            int fieldWidth = ((fieldImage.Width / fieldImage.Height) * fieldHeight);
            double fieldScaleX = fieldWidth / ACTUAL_FIELD_WIDTH;
            double fieldScaleY = fieldHeight / ACTUAL_FIELD_HEIGHT;
            Size fieldSize = new Size(fieldWidth, fieldHeight);

            int fieldX = midWindowX - (fieldWidth / 2);
            int fieldY = altitudeTrackBar.Location.Y + altitudeTrackBar.Size.Height;
            Point fieldLocation = new Point(fieldX, fieldY);

            Rectangle fieldRect = new Rectangle(fieldLocation, fieldSize);

            g.DrawImage(fieldImage, fieldRect);

            //draw sky
            int skyWidth = fieldWidth;
            int skyHeight = fieldY;
            Size skySize = new Size(skyWidth, skyHeight);

            int skyX = fieldX;
            int skyY = 0;
            Point skyLocation = new Point(skyX, skyY);

            Rectangle skyRect = new Rectangle(skyLocation, skySize);

            int skySrcX = 0;
            int skySrcY = skyImage.Height - skyHeight;

            g.DrawImage(skyImage, skyRect, skySrcX, skySrcY, skyWidth, skyHeight, GraphicsUnit.Pixel);

            //draw coverage
            int coverageWidth = Math.Min((int)(groundCoverage * fieldScaleX), fieldWidth);
            int coverageHeight = Math.Min((int)(groundCoverage * fieldScaleY), fieldHeight);
            Size coverageSize = new Size(coverageWidth, coverageHeight);

            int fieldMidY = fieldLocation.Y + fieldSize.Height / 2;
            int coverageX = midWindowX - (coverageSize.Width / 2);
            int coverageY = fieldMidY - (coverageSize.Height / 2);
            Point coverageLocation = new Point(coverageX, coverageY);

            Rectangle coverageRect = new Rectangle(coverageLocation, coverageSize);

            Pen coveragePen = new Pen(Color.Red);
            g.DrawRectangle(coveragePen, coverageRect);

            //draw drone
            int droneAltitude = altitudeTrackBar.Value;

            int droneHeight = 100;
            int droneWidth = ((droneImage.Width / droneImage.Height) * droneHeight);
            Size droneSize = new Size(droneWidth, droneHeight);

            int droneX = midWindowX - (droneWidth / 2);
            int droneY = fieldY - droneHeight - (int)(droneAltitude * fieldScaleY);
            Point droneLocation = new Point(droneX, droneY);

            Rectangle droneRect = new Rectangle(droneLocation, droneSize);

            g.DrawImage(droneImage, droneRect);

            //draw FOV lines
            int droneMidX = droneLocation.X + droneSize.Width / 2;
            Point fovTopPoint = new Point(droneMidX, droneLocation.Y + droneSize.Height);

            int fovBottomY = altitudeTrackBar.Location.Y + altitudeTrackBar.Size.Height;
            double fovHalfRadians = (Convert.ToDouble(fieldofviewTextBox.Text)/2)*(Math.PI/180.0);
            double fovBottomLeg = (int)(Math.Tan(fovHalfRadians) * (fovBottomY - fovTopPoint.Y));
            int fovBottomWidth = Math.Min((int)(fovBottomLeg * fieldScaleX), fieldWidth / 2);

            Point fovLeftPoint = new Point(droneMidX - fovBottomWidth, fovBottomY);
            Point fovRightPoint = new Point(droneMidX + fovBottomWidth, fovBottomY);

            Pen fovPen = new Pen(Color.Red);
            g.DrawLine(fovPen, fovTopPoint, fovLeftPoint);
            g.DrawLine(fovPen, fovTopPoint, fovRightPoint);
            g.DrawLine(fovPen, fovLeftPoint, fovRightPoint);
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
            sanitizeTextBox(fieldofviewTextBox, 0, 90);
            updateGSD();
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
