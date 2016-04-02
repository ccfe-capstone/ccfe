﻿using System;
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
            if (string.IsNullOrEmpty(altitudeTrackBarValueTextBox.Text) || (Convert.ToInt32(altitudeTrackBarValueTextBox.Text) <= 0))
            {
                altitudeTrackBarValueTextBox.Text = "0";
            }
            else if (Convert.ToInt32(altitudeTrackBarValueTextBox.Text) >= 500)
            {
                altitudeTrackBarValueTextBox.Text = "500";
            }
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
            Size fieldSize = new Size(fieldWidth, fieldHeight);

            int fieldX = midWindowX - (fieldWidth / 2);
            int fieldY = altitudeTrackBar.Location.Y + altitudeTrackBar.Size.Height;
            Point fieldLocation = new Point(fieldX, fieldY);

            Rectangle fieldRect = new Rectangle(fieldLocation, fieldSize);

            g.DrawImage(fieldImage, fieldRect);

            //draw coverage
            double coverageScaleX = fieldWidth / ACTUAL_FIELD_WIDTH;
            double coverageScaleY = fieldHeight / ACTUAL_FIELD_HEIGHT;

            int coverageWidth = Math.Min((int)(groundCoverage * coverageScaleX), fieldWidth);
            int coverageHeight = Math.Min((int)(groundCoverage * coverageScaleY), fieldHeight);
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
            int droneY = fieldY - droneHeight - (int)(droneAltitude * coverageScaleY);
            Point droneLocation = new Point(droneX, droneY);

            Rectangle droneRect = new Rectangle(droneLocation, droneSize);

            g.DrawImage(droneImage, droneRect);

            //draw FOV lines
            int droneMidX = droneLocation.X + droneSize.Width / 2;
            Point fovTopPoint = new Point(droneMidX, droneLocation.Y + droneSize.Height);

            int fovBottomY = altitudeTrackBar.Location.Y + altitudeTrackBar.Size.Height;
            double fovHalfRadians = (Convert.ToDouble(fieldofviewTextBox.Text)/2)*(Math.PI/180.0);
            double fovBottomLeg = (int)(Math.Tan(fovHalfRadians) * (fovBottomY - fovTopPoint.Y));
            int fovBottomWidth = Math.Min((int)(fovBottomLeg * coverageScaleX), fieldWidth / 2);

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
            if (string.IsNullOrEmpty(fieldofviewTextBox.Text) || (Convert.ToInt32(fieldofviewTextBox.Text) <= 0))
            {
                fieldofviewTextBox.Text = "0";
            }
            else if (Convert.ToInt32(fieldofviewTextBox.Text) >= 90)
            {
                fieldofviewTextBox.Text = "90";
            }
            updateGSD();
        }
    }
}
