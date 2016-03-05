using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_Configuration_File_Editor
{
    class CCFE_FileHandler
    {
        //Constants
        const string PROPERTY_TRIGGERMODE = "TriggerMode";
        const string PROPERTY_OVERLAPPERCENT = "OverlapPercent";
        const string PROPERTY_KNOWNHALALTITUDEUNITS = "KnownHalAltitudeUnits";
        const string PROPERTY_KNOWNHALALTITUDE = "KnownHalAltitude";
        const string PROPERTY_TIME = "Time";
        const string PROPERTY_DISTANCE = "Distance";
        const string PROPERTY_WAITFORGPSFIX = "WaitForGPSFix";
        const string PROPERTY_VERSION = "Version";

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
        //End of Constants

        public string fileLocation;

        public CCFE_FileHandler(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        public void save(CCFE_Configuration configuration)
        {
            string configurationFileText;

            configurationFileText = "[UserSettings]\n";

            foreach (CCFE_ConfigurationProperty property in configuration.propertyList)
            {
                configurationFileText = configurationFileText + appendProperty(property);
            }

            CCFE_FileIO.writeFile(fileLocation, configurationFileText);
        }

        public List<CCFE_ConfigurationProperty> parse()
        {
            return new List<CCFE_ConfigurationProperty>(); //TODO
        }

        string appendProperty(CCFE_ConfigurationProperty property)
        {
            string appendText = "";

            if (property.name.Equals(PROPERTY_TRIGGERMODE))
            {
                appendText = COMMENTS_TRIGGERMODE;
                appendText = appendText + property.value + "=" + property.value + "\n";
            }
            else if (property.name.Equals(PROPERTY_OVERLAPPERCENT))
            {
                appendText = COMMENTS_OVERLAPPERCENT;
                appendText = appendText + property.value + "=" + property.value + "\n";
            }
            else if (property.name.Equals(PROPERTY_KNOWNHALALTITUDEUNITS))
            {
                appendText = COMMENTS_KNOWNHALALTITUDEUNITS;
                appendText = appendText + property.value + "=" + property.value + "\n";
            }
            else if (property.name.Equals(PROPERTY_KNOWNHALALTITUDE))
            {
                appendText = COMMENTS_KNOWNHALALTITUDE;
                appendText = appendText + property.value + "=" + property.value + "\n";
            }
            else if (property.name.Equals(PROPERTY_TIME))
            {
                appendText = COMMENTS_TIME;
                appendText = appendText + property.value + "=" + property.value + "\n";
            }
            else if (property.name.Equals(PROPERTY_DISTANCE))
            {
                appendText = COMMENTS_DISTANCE;
                appendText = appendText + property.value + "=" + property.value + "\n";
            }
            else if (property.name.Equals(PROPERTY_WAITFORGPSFIX))
            {
                appendText = COMMENTS_WAITFORGPSFIX;
                appendText = appendText + property.value + "=" + property.value + "\n";
            }
            else if (property.name.Equals(PROPERTY_VERSION))
            {
                appendText = COMMENTS_VERSION;
                appendText = appendText + property.value + "=" + property.value + "\n";
            }

            return appendText;
        }
    }
}
