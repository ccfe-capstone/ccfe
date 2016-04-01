﻿using System;
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
    }
}