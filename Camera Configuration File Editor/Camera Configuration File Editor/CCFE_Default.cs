using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;

namespace Camera_Configuration_File_Editor
{
    public class CCFE_Default
    {
        public const string programVersion = "0.3.0";

        public static readonly ReadOnlyCollection<string> hardVersions =
            new ReadOnlyCollection<string>(new[]
                {
                    "1.0"
                }
            );

        public static List<CCFE_ConfigurationProperty> getDefaultProperties(string configurationVersion)
        {
            List<CCFE_ConfigurationProperty> propertyList = new List<CCFE_ConfigurationProperty>();

            //check if default config file exists
            string fileLocation = AppDomain.CurrentDomain.BaseDirectory + "/config/" + configurationVersion + ".txt";
            if (File.Exists(fileLocation))
            {
                CCFE_FileHandler fileHandler = new CCFE_FileHandler(fileLocation);
                propertyList = fileHandler.parse();
            }
            else //use hardcoded values
            {
                if (configurationVersion.Equals("1.0"))
                {
                    propertyList.Add(new CCFE_ConfigurationProperty("TriggerMode", "5"));
                    propertyList.Add(new CCFE_ConfigurationProperty("OverlapPercent", "75"));
                    propertyList.Add(new CCFE_ConfigurationProperty("KnownHalAltitudeUnits", "feet"));
                    propertyList.Add(new CCFE_ConfigurationProperty("KnownHalAltitude", "400"));
                    propertyList.Add(new CCFE_ConfigurationProperty("Time", "3.8"));
                    propertyList.Add(new CCFE_ConfigurationProperty("Distance", "10"));
                    propertyList.Add(new CCFE_ConfigurationProperty("WaitForGpsFix", "yes"));
                    propertyList.Add(new CCFE_ConfigurationProperty("Version", configurationVersion));
                }
                else
                {
                    propertyList.Add(new CCFE_ConfigurationProperty("TriggerMode", "5"));
                    propertyList.Add(new CCFE_ConfigurationProperty("OverlapPercent", "75"));
                    propertyList.Add(new CCFE_ConfigurationProperty("KnownHalAltitudeUnits", "feet"));
                    propertyList.Add(new CCFE_ConfigurationProperty("KnownHalAltitude", "400"));
                    propertyList.Add(new CCFE_ConfigurationProperty("Time", "3.8"));
                    propertyList.Add(new CCFE_ConfigurationProperty("Distance", "10"));
                    propertyList.Add(new CCFE_ConfigurationProperty("WaitForGpsFix", "yes"));
                    propertyList.Add(new CCFE_ConfigurationProperty("Version", configurationVersion));
                }
            }

            return propertyList;
        }
        public static CCFE_Configuration getDefaultConfiguration(string configurationVersion)
        {
            return new CCFE_Configuration(getDefaultProperties(configurationVersion));
        }

        public static List<string> getVersions()
        {
            List<string> versionList;
            //check if config folder exists
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/config";
            if (Directory.Exists(filePath))
            {
                versionList = new List<string>();
                //check for config files
                var possibleFiles = Directory.EnumerateFiles(filePath);
                string configPattern = "[0-9]+.[0-9]+.txt";
                foreach (string fileLocation in possibleFiles)
                {
                    string fileName = Path.GetFileName(fileLocation);
                    if(System.Text.RegularExpressions.Regex.IsMatch(fileName, configPattern))
                    {
                        versionList.Add(Path.GetFileNameWithoutExtension(fileLocation));
                    }
                }

                //check if hardcoded versions should be added
                foreach(string hardVersion in hardVersions)
                {
                    if(versionList.TrueForAll(x => !x.Equals(hardVersion)))
                    {
                        versionList.Add(hardVersion);
                    }
                }
            }
            else //no config files found, only return hardcoded versions
            {
                versionList = new List<string>(hardVersions);
            }

            return versionList;
        }

        public static List<CCFE_ConfigurationProperty> getCommentPropertyPairs(string configurationVersion)
        {
            List<CCFE_ConfigurationProperty> propertyList = new List<CCFE_ConfigurationProperty>();

            //check if default config file exists
            string fileLocation = AppDomain.CurrentDomain.BaseDirectory + "/config/" + configurationVersion + ".txt";
            if (File.Exists(fileLocation))
            {
                CCFE_FileHandler fileHandler = new CCFE_FileHandler(fileLocation);
                propertyList = fileHandler.parseComments();
            }
            else //use hardcoded values
            {
                if (configurationVersion.Equals("1.0"))
                {
                    string property = "TriggerMode";
                    string comment =
                        "# TriggerMode\n" +
                        "# 0: Time (for systems without GPS only)\n" +
                        "# 1: Network\n" +
                        "# 2: MAVlink\n" +
                        "# 3: GPS Distance\n" +
                        "# 4: GPS Time\n" +
                        "# 5: GPS Overlap - Auto Detect Altitude\n" +
                        "# 6: GPS Overlap - Known Altitude\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "OverlapPercent";
                    comment =
                        "\n" +
                        "# --------- GPS Overlap Trigger Options ---------\n" +
                        "# Only used when TriggerMode is 5 or 6 (GPS Overlap - Auto Detect OR Known Altitude)\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "KnownHalAltitudeUnits";
                    comment =
                        "\n" +
                        "# Only used when TriggerMode is 6 (GPS Overlap - Known Altitude)\n" +
                        "# KnownAltitudeUnits options: feet, meters\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "KnownHalAltitude";
                    comment =
                        "";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "Time";
                    comment =
                        "\n" +
                        "# --------- Time Trigger Options ---------\n" +
                        "# Only used when TriggerMode is 0 or 4 (Time)\n" +
                        "# Time in seconds\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "Distance";
                    comment =
                        "\n" +
                        "# --------- GPS Distance Trigger Options ---------\n" +
                        "# Only used when TriggerMode is 3 (Distance)\n" +
                        "# Distance in meters\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "WaitForGpsFix";
                    comment =
                        "\n" +
                        "# --------- General GPS Options -------------------\n" +
                        "# Only used when TriggerMode is 3,4,5,6\n" +
                        "# Options: yes, no\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "Version";
                    comment =
                        "\n" +
                        "# Indicates version of this file, to know what fields are available\n" +
                        "# Minor number increments when new fields are added\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));
                }
                else //default to 1.0
                {
                    string property = "TriggerMode";
                    string comment =
                        "# TriggerMode\n" +
                        "# 0: Time (for systems without GPS only)\n" +
                        "# 1: Network\n" +
                        "# 2: MAVlink\n" +
                        "# 3: GPS Distance\n" +
                        "# 4: GPS Time\n" +
                        "# 5: GPS Overlap - Auto Detect Altitude\n" +
                        "# 6: GPS Overlap - Known Altitude\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "OverlapPercent";
                    comment =
                        "\n" +
                        "# --------- GPS Overlap Trigger Options ---------\n" +
                        "# Only used when TriggerMode is 5 or 6 (GPS Overlap - Auto Detect OR Known Altitude)\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "KnownHalAltitudeUnits";
                    comment =
                        "\n" +
                        "# Only used when TriggerMode is 6 (GPS Overlap - Known Altitude)\n" +
                        "# KnownAltitudeUnits options: feet, meters\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "KnownHalAltitude";
                    comment =
                        "";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "Time";
                    comment =
                        "\n" +
                        "# --------- Time Trigger Options ---------\n" +
                        "# Only used when TriggerMode is 0 or 4 (Time)\n" +
                        "# Time in seconds\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "Distance";
                    comment =
                        "\n" +
                        "# --------- GPS Distance Trigger Options ---------\n" +
                        "# Only used when TriggerMode is 3 (Distance)\n" +
                        "# Distance in meters\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "WaitForGpsFix";
                    comment =
                        "\n" +
                        "# --------- General GPS Options -------------------\n" +
                        "# Only used when TriggerMode is 3,4,5,6\n" +
                        "# Options: yes, no\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));

                    property = "Version";
                    comment =
                        "\n" +
                        "# Indicates version of this file, to know what fields are available\n" +
                        "# Minor number increments when new fields are added\n";
                    propertyList.Add(new CCFE_ConfigurationProperty(property, comment));
                }
            }

            return propertyList;
        }
    }
}
