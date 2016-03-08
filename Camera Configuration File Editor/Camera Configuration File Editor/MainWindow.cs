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
    public partial class MainWindow : Form
    {
        CCFE_Configuration configuration;
        CCFE_FileHandler fileHandler;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileHandler = new CCFE_FileHandler(openFileDialog.FileName);
                configuration = new CCFE_Configuration(fileHandler.parse());
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)triggerModeComboBox.SelectedItem == "Time (for systems without GPS only)")
            {
                overlapPanel.Enabled = false;
                knownHalAltPanel.Enabled = false;
                triggerPeriodPanel.Enabled = true;
                triggerDistancePanel.Enabled = false;
                waitForGpsFixPanel.Enabled = false;
            }
            else if ((string)triggerModeComboBox.SelectedItem == "Network")
            {
                overlapPanel.Enabled = false;
                knownHalAltPanel.Enabled = false;
                triggerPeriodPanel.Enabled = false;
                triggerDistancePanel.Enabled = false;
                waitForGpsFixPanel.Enabled = false;
            }
            else if ((string)triggerModeComboBox.SelectedItem == "MAVlink")
            {
                overlapPanel.Enabled = false;
                knownHalAltPanel.Enabled = false;
                triggerPeriodPanel.Enabled = false;
                triggerDistancePanel.Enabled = false;
                waitForGpsFixPanel.Enabled = false;
            }
            else if ((string)triggerModeComboBox.SelectedItem == "GPS Distance")
            {
                overlapPanel.Enabled = false;
                knownHalAltPanel.Enabled = false;
                triggerPeriodPanel.Enabled = false;
                triggerDistancePanel.Enabled = true;
                waitForGpsFixPanel.Enabled = true;
            }
            else if ((string)triggerModeComboBox.SelectedItem == "GPS Time")
            {
                overlapPanel.Enabled = false;
                knownHalAltPanel.Enabled = false;
                triggerPeriodPanel.Enabled = true;
                triggerDistancePanel.Enabled = false;
                waitForGpsFixPanel.Enabled = true;
            }
            else if ((string)triggerModeComboBox.SelectedItem == "GPS Overlap - Auto Detect Altitude")
            {
                overlapPanel.Enabled = true;
                knownHalAltPanel.Enabled = false;
                triggerPeriodPanel.Enabled = false;
                triggerDistancePanel.Enabled = false;
                waitForGpsFixPanel.Enabled = true;
            }
            else if ((string)triggerModeComboBox.SelectedItem == "GPS Overlap - Known Altitude")
            {
                overlapPanel.Enabled = true;
                knownHalAltPanel.Enabled = true;
                triggerPeriodPanel.Enabled = false;
                triggerDistancePanel.Enabled = false;
                waitForGpsFixPanel.Enabled = true;
            }
            else
            {
                overlapPanel.Enabled = true;
                knownHalAltPanel.Enabled = true;
                triggerPeriodPanel.Enabled = true;
                triggerDistancePanel.Enabled = true;
                waitForGpsFixPanel.Enabled = true;
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            overlapTrackBarValueLabel.Text = overlapTrackBar.Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void knownHalAltitudeValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void triggerDistanceValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void knownHalAltitudeUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void overlapPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saveConfigurationButton_Click(object sender, EventArgs e)
        {

        }
    }
}
