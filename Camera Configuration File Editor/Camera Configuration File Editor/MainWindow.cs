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
            newConfiguration("1.0");
            loadConfiguration(configuration);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileHandler = null;
            newConfiguration("1.0");
            loadConfiguration(configuration);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileSearch();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkSave())
            {
                saveConfiguration();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileHandler = new CCFE_FileHandler(saveFileDialog.FileName);
                if (checkSave())
                {
                    saveConfiguration();
                }
            }
        }

        private void loadDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: support different versions
            newConfiguration("1.0");
            loadConfiguration(configuration);
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
            setTrackBarLabelLocationAndText();
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
            if(checkSave())
            {
                saveConfiguration();
            }
        }

        private void overlapTrackBarValueLabel_Click(object sender, EventArgs e)
        {

        }

        private void setTrackBarLabelLocationAndText()
        {
            overlapTrackBarValueLabel.Text = overlapTrackBar.Value.ToString() + "%";
            overlapTrackBarValueLabel.Location = determineCoordsOfOverlapTrackBar();
        }

        //needed to move the trackbarLabel with the trackbar as it scrolls horizontally
        private Point determineCoordsOfOverlapTrackBar()
        {
            int xValue;
            if (overlapTrackBar.Value < 10)
            {
                xValue = (overlapTrackBar.Location.X + 7);
            }
            else if (overlapTrackBar.Value >= 10 && overlapTrackBar.Value < 100)
            {
                xValue = (overlapTrackBar.Location.X + 4);
            }
            else
            {
                xValue = overlapTrackBar.Location.X + 1;
            }
            return new Point(xValue + (overlapTrackBar.Value * 3), overlapTrackBarValueLabel.Location.Y);
        }

        private void saveConfiguration()
        {
            //sanitize inputs (remove separators, etc)
            double knownHalAltitude;
            double triggerPeriod;
            double triggerDistance;

            Double.TryParse(knownHalAltitudeValue.Text, out knownHalAltitude);
            Double.TryParse(triggerPeriodValue.Text, out triggerPeriod);
            Double.TryParse(triggerDistanceValue.Text, out triggerDistance);

            configuration.setValue(CCFE_Configuration.PROPERTY_KNOWNHALALTITUDE, knownHalAltitude.ToString());
            configuration.setValue(CCFE_Configuration.PROPERTY_TIME, triggerPeriod.ToString());
            configuration.setValue(CCFE_Configuration.PROPERTY_DISTANCE, triggerDistance.ToString());
            configuration.setValue(CCFE_Configuration.PROPERTY_TRIGGERMODE, triggerModeComboBox.SelectedIndex.ToString());
            configuration.setValue(CCFE_Configuration.PROPERTY_OVERLAPPERCENT, overlapTrackBar.Value.ToString());
            configuration.setValue(CCFE_Configuration.PROPERTY_KNOWNHALALTITUDEUNITS, knownHalAltitudeUnit.Text);
            configuration.setValue(CCFE_Configuration.PROPERTY_WAITFORGPSFIX, waitForGpsFixValue.Checked ? "yes" : "no");

            fileHandler.save(configuration);
            MessageBox.Show("Configuration saved successfully!");
        }

        //checks to see if either of the filehandler or configuration objects have been created
        //meaning a new file has been made or a file location was set
        public bool checkSave()
        {
            //sanitize inputs to eliminate possible blanks
            double knownHalAltitude;
            double triggerPeriod;
            double triggerDistance;
            bool kHA;
            bool tP;
            bool tD;

            kHA = Double.TryParse(knownHalAltitudeValue.Text, out knownHalAltitude);
            tP = Double.TryParse(triggerPeriodValue.Text, out triggerPeriod);
            tD = Double.TryParse(triggerDistanceValue.Text, out triggerDistance);

            if (!kHA || !tP || !tD)
            {
                String message = "The following settings were left blank:\n\n";
                if (!kHA)
                {
                    message += "Known Hal Altitude\n";
                }
                if (!tP)
                {
                    message += "Trigger Period\n";
                }
                if (!tD)
                {
                    message += "Trigger Distance\n";
                }
                message += "\nProceed with these values set to 0?";
                if (MessageBox.Show(message, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                {
                    return false;
                }
                else
                {
                    if (!kHA)
                    {
                        knownHalAltitudeValue.Text = "0";
                    }
                    if (!tP)
                    {
                        triggerPeriodValue.Text = "0";
                    }
                    if (!tD)
                    {
                        triggerDistanceValue.Text = "0";
                    }
                }
            }

            if (configuration == null || fileHandler == null)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileHandler = new CCFE_FileHandler(saveFileDialog.FileName);
                    //TODO: create configuration using actual selected version
                    //this is fine for now
                    configuration = new CCFE_Configuration("1.0");
                }
                //they canceled or input something wrong
                else
                {
                    return false;
                }
            }
            return true;
        }

        //allows the user to select the settings and begins the parsing
        public void fileSearch()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileHandler = new CCFE_FileHandler(openFileDialog.FileName);
                configuration = new CCFE_Configuration(fileHandler.parse());

                loadConfiguration(configuration);
            }
        }

        public void newConfiguration(string version)
        {
            configuration = new CCFE_Configuration(version);
            loadConfiguration(configuration);
        }

        public void loadConfiguration(CCFE_Configuration config)
        {
            triggerModeComboBox.SelectedIndex = Convert.ToInt32(config.getValue(CCFE_Configuration.PROPERTY_TRIGGERMODE));
            overlapTrackBar.Value = Convert.ToInt32(config.getValue(CCFE_Configuration.PROPERTY_OVERLAPPERCENT));
            waitForGpsFixValue.Checked = (bool)config.getValue(CCFE_Configuration.PROPERTY_WAITFORGPSFIX).Equals("yes");
            knownHalAltitudeValue.Text = config.getValue(CCFE_Configuration.PROPERTY_KNOWNHALALTITUDE);

            //sets the known hal altitude unit
            if (config.getValue(CCFE_Configuration.PROPERTY_KNOWNHALALTITUDEUNITS).Equals("feet"))
            {
                //feet
                knownHalAltitudeUnit.SelectedIndex = 0;
            }
            else
            {
                //meters
                knownHalAltitudeUnit.SelectedIndex = 1;
            }
            triggerPeriodValue.Text = config.getValue(CCFE_Configuration.PROPERTY_TIME);
            triggerDistanceValue.Text = config.getValue(CCFE_Configuration.PROPERTY_DISTANCE);

            //needed to move the trackbar label to its spot under the trackbar
            setTrackBarLabelLocationAndText();
        }
    }
}
