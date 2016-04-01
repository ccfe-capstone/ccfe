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
        public GSDWindow()
        {
            InitializeComponent();
            setTrackBarTextBoxLocationAndText();
        }

        private void altitudeTrackBar_Scroll(object sender, EventArgs e)
        {
            setTrackBarTextBoxLocationAndText();
        }

        private void setTrackBarTextBoxLocationAndText()
        {
            altitudeTrackBarValueTextBox.Text = altitudeTrackBar.Value.ToString();
            altitudeTrackBarValueTextBox.Location = determineCoordsOfAltitudeTrackBar();
        }

        //needed to move the trackbarLabel with the trackbar as it scrolls horizontally
        private Point determineCoordsOfAltitudeTrackBar()
        {
            int yValue;
            yValue = altitudeTrackBar.Location.Y + 375;
            return new Point(altitudeTrackBarValueTextBox.Location.X, yValue - (int)(altitudeTrackBar.Value * .745));
        }

        private void altitudeTrackBarValueTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void altitudeTrackBarValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
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
            e.Handled = !(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar));
        }
    }
}
