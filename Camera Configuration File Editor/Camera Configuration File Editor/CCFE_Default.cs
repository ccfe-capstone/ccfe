using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Camera_Configuration_File_Editor
{
    public class CCFE_Default
    {
        public static List<CCFE_ConfigurationProperty> getDefaultProperties(string configurationVersion)
        {
            List<CCFE_ConfigurationProperty> propertyList = new List<CCFE_ConfigurationProperty>();

            //check if default config file exists
            string fileLocation = System.AppDomain.CurrentDomain.BaseDirectory + "/config/" + configurationVersion + ".txt";
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
    }
}
