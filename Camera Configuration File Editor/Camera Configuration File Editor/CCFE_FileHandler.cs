using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_Configuration_File_Editor
{
    public class CCFE_FileHandler
    {
        #region property constants
        const string PROPERTY_TRIGGERMODE = "TriggerMode";
        const string PROPERTY_OVERLAPPERCENT = "OverlapPercent";
        const string PROPERTY_KNOWNHALALTITUDEUNITS = "KnownHalAltitudeUnits";
        const string PROPERTY_KNOWNHALALTITUDE = "KnownHalAltitude";
        const string PROPERTY_TIME = "Time";
        const string PROPERTY_DISTANCE = "Distance";
        const string PROPERTY_WAITFORGPSFIX = "WaitForGpsFix";
        const string PROPERTY_VERSION = "Version";
        #endregion
        #region property comment constants
        const string COMMENTS_TRIGGERMODE = 
            "# TriggerMode\n" +
            "# 0: Time (for systems without GPS only)\n" +
            "# 1: Network\n" +
            "# 2: MAVlink\n" +
            "# 3: GPS Distance\n" +
            "# 4: GPS Time\n" +
            "# 5: GPS Overlap - Auto Detect Altitude\n" +
            "# 6: GPS Overlap - Known Altitude\n";
        const string COMMENTS_OVERLAPPERCENT = 
            "# --------- GPS Overlap Trigger Options ---------\n" +
            "# Only used when TriggerMode is 5 or 6 (GPS Overlap - Auto Detect OR Known Altitude)\n";
        const string COMMENTS_KNOWNHALALTITUDEUNITS =
            "# Only used when TriggerMode is 6 (GPS Overlap - Known Altitude)\n" +
            "# KnownAltudeUnits options: feet, meters\n";
        const string COMMENTS_KNOWNHALALTITUDE =
            "";
        const string COMMENTS_TIME =
            "# --------- Time Trigger Options ---------\n" +
            "# Only used when TriggerMode is 0 or 4 (Time)\n" +
            "# Time in seconds\n";
        const string COMMENTS_DISTANCE =
            "# --------- GPS Distance Trigger Options ---------\n" +
            "# Only used when TriggerMode is 3 (Distance)\n" +
            "# Distance in meters\n";
        const string COMMENTS_WAITFORGPSFIX =
            "# --------- General GPS Options -------------------\n" +
            "# Only used when TriggerMode is 3,4,5,6\n" +
            "# Options: yes, no\n";
        const string COMMENTS_VERSION =
            "# Indicates version of this file, to know what fields are available\n" +
            "# Minor number increments when new fields are added\n";
        #endregion

        #region variables
        private string fileLocation;

        public string FileLocation
        {
            get
            {
                return fileLocation;
            }

            set
            {
                fileLocation = value;
            }
        }
        #endregion

        #region constructors
        public CCFE_FileHandler(string fileLocation)
        {
            this.FileLocation = fileLocation;
        }
        #endregion

        #region public methods
        public void save(CCFE_Configuration configuration)
        {
            string configurationFileText;

            configurationFileText = "[UserSettings]\n";

            foreach (CCFE_ConfigurationProperty property in configuration.PropertyList)
            {
                configurationFileText = configurationFileText + appendProperty(property);
            }

            CCFE_FileIO.writeFile(FileLocation, configurationFileText);
        }

        public List<CCFE_ConfigurationProperty> parse()
        {
            List<CCFE_ConfigurationProperty> propertyList = new List<CCFE_ConfigurationProperty>();

            //read in file data as string
            string fileText = CCFE_FileIO.readFile(FileLocation);

            //create StringReader to parse string
            System.IO.StringReader stringReader = new System.IO.StringReader(fileText);

            string line;
            string propertyPattern = "^([A-Z])([A-z])+=\\S+";
            string[] propertyValues;
            while ((line = stringReader.ReadLine()) != null)
            {
                //check if line is a property using regex
                if (System.Text.RegularExpressions.Regex.IsMatch(line, propertyPattern))
                {
                    //break string into 'name' and 'value' parts
                    propertyValues = line.Split('=');
                    propertyList.Add(new CCFE_ConfigurationProperty(propertyValues[0], propertyValues[1]));
                }
            }
            stringReader.Close();

            return propertyList;
        }
        #endregion

        #region private methods
        private string appendProperty(CCFE_ConfigurationProperty property)
        {
            string appendText = "";

            if (property.Name.Equals(PROPERTY_TRIGGERMODE))
            {
                appendText = COMMENTS_TRIGGERMODE;
                appendText = appendText + property.Name + "=" + property.Value + "\n";
            }
            else if (property.Name.Equals(PROPERTY_OVERLAPPERCENT))
            {
                appendText = "\n" + COMMENTS_OVERLAPPERCENT;
                appendText = appendText + property.Name + "=" + property.Value + "\n";
            }
            else if (property.Name.Equals(PROPERTY_KNOWNHALALTITUDEUNITS))
            {
                appendText = "\n" + COMMENTS_KNOWNHALALTITUDEUNITS;
                appendText = appendText + property.Name + "=" + property.Value + "\n";
            }
            else if (property.Name.Equals(PROPERTY_KNOWNHALALTITUDE))
            {
                appendText = COMMENTS_KNOWNHALALTITUDE;
                appendText = appendText + property.Name + "=" + property.Value + "\n";
            }
            else if (property.Name.Equals(PROPERTY_TIME))
            {
                appendText = "\n" + COMMENTS_TIME;
                appendText = appendText + property.Name + "=" + property.Value + "\n";
            }
            else if (property.Name.Equals(PROPERTY_DISTANCE))
            {
                appendText = "\n" + COMMENTS_DISTANCE;
                appendText = appendText + property.Name + "=" + property.Value + "\n";
            }
            else if (property.Name.Equals(PROPERTY_WAITFORGPSFIX))
            {
                appendText = "\n" + COMMENTS_WAITFORGPSFIX;
                appendText = appendText + property.Name + "=" + property.Value + "\n";
            }
            else if (property.Name.Equals(PROPERTY_VERSION))
            {
                appendText = "\n" + COMMENTS_VERSION;
                appendText = appendText + property.Name + "=" + property.Value + "\n";
            }

            return appendText;
        }
        #endregion
    }
}
