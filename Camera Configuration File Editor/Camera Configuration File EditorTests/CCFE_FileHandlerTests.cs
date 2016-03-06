using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camera_Configuration_File_Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_Configuration_File_Editor.Tests
{
    [TestClass()]
    public class CCFE_FileHandlerTests
    {
        #region constants
        const int UserSettingsPropertyCount = 8;
        const string UserSettingsTestData =
            "[UserSettings]\n" +
            "# TriggerMode\n" +
            "# 0: Time (for systems without GPS only)\n" +
            "# 1: Network\n" +
            "# 2: MAVlink\n" +
            "# 3: GPS Distance\n" +
            "# 4: GPS Time\n" +
            "# 5: GPS Overlap - Auto Detect Altitude\n" +
            "# 6: GPS Overlap - Known Altitude\n" +
            "TriggerMode=5\n" +
            "\n" +
            "# --------- GPS Overlap Trigger Options ---------\n" +
            "# Only used when TriggerMode is 5 or 6 (GPS Overlap - Auto Detect OR Known Altitude)\n" +
            "OverlapPercent=75\n" +
            "\n" +
            "# Only used when TriggerMode is 6 (GPS Overlap - Known Altitude)\n" +
            "# KnownAltudeUnits options: feet, meters\n" +
            "KnownHalAltitudeUnits=feet\n" +
            "KnownHalAltitude=400\n" +
            "\n" +
            "# --------- Time Trigger Options ---------\n" +
            "# Only used when TriggerMode is 0 or 4 (Time)\n" +
            "# Time in seconds\n" +
            "Time=3.8\n" +
            "\n" +
            "# --------- GPS Distance Trigger Options ---------\n" +
            "# Only used when TriggerMode is 3 (Distance)\n" +
            "# Distance in meters\n" +
            "Distance=10\n" +
            "\n" +
            "# --------- General GPS Options -------------------\n" +
            "# Only used when TriggerMode is 3,4,5,6\n" +
            "# Options: yes, no\n" +
            "WaitForGpsFix=yes\n" +
            "\n" +
            "# Indicates version of this file, to know what fields are available\n" +
            "# Minor number increments when new fields are added\n" +
            "Version=1.0\n";
        #endregion

        [TestMethod()]
        public void CCFE_FileHandlerTest()
        {
            //ARRANGE
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "/" + "UserSettings.txt";
            CCFE_FileHandler fileHandler = new CCFE_FileHandler(filePath);

            //ACT


            //ASSERT
            Assert.IsTrue(fileHandler.FileLocation.Equals(filePath));
        }

        [TestMethod()]
        public void saveTest()
        {
            //ARRANGE
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "/" + "UserSettings.txt";
            //delete test file if one exists
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            CCFE_FileHandler fileHandler = new CCFE_FileHandler(filePath);

            CCFE_Configuration configuration = new CCFE_Configuration();
            configuration.PropertyList.Add(new CCFE_ConfigurationProperty("TriggerMode", "5"));
            configuration.PropertyList.Add(new CCFE_ConfigurationProperty("OverlapPercent", "75"));
            configuration.PropertyList.Add(new CCFE_ConfigurationProperty("KnownHalAltitudeUnits", "feet"));
            configuration.PropertyList.Add(new CCFE_ConfigurationProperty("KnownHalAltitude", "400"));
            configuration.PropertyList.Add(new CCFE_ConfigurationProperty("Time", "3.8"));
            configuration.PropertyList.Add(new CCFE_ConfigurationProperty("Distance", "10"));
            configuration.PropertyList.Add(new CCFE_ConfigurationProperty("WaitForGpsFix", "yes"));
            configuration.PropertyList.Add(new CCFE_ConfigurationProperty("Version", "1.0"));

            //ACT
            fileHandler.save(configuration);

            //ASSERT
            //check if file was created
            Assert.IsTrue(System.IO.File.Exists(filePath));
            //check if file was saved with correct data
            Assert.IsTrue(System.IO.File.ReadAllText(filePath).Equals(UserSettingsTestData));

            //CLEANUP
            System.IO.File.Delete(filePath);
        }

        [TestMethod()]
        public void parseTest()
        {
            //ARRANGE
            CCFE_Configuration configuration = new CCFE_Configuration();

            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "/" + "UserSettings.txt";
            //delete test file if one exists
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            CCFE_FileHandler fileHandler = new CCFE_FileHandler(filePath);

            //make test file
            System.IO.File.WriteAllText(filePath, UserSettingsTestData);

            //ACT
            configuration.PropertyList = fileHandler.parse();

            //ASSERT
            //check if all properties are there
            Assert.IsTrue(configuration.PropertyList.Count == UserSettingsPropertyCount);
            //check if all properties have correct values
            for (int i = 0; i < configuration.PropertyList.Count; i++)
            {
                switch (configuration.PropertyList[i].Name)
                {
                    case "TriggerMode":
                        Assert.IsTrue(configuration.PropertyList[i].Value.Equals("5"));
                        break;
                    case "OverlapPercent":
                        Assert.IsTrue(configuration.PropertyList[i].Value.Equals("75"));
                        break;
                    case "KnownHalAltitudeUnits":
                        Assert.IsTrue(configuration.PropertyList[i].Value.Equals("feet"));
                        break;
                    case "KnownHalAltitude":
                        Assert.IsTrue(configuration.PropertyList[i].Value.Equals("400"));
                        break;
                    case "Time":
                        Assert.IsTrue(configuration.PropertyList[i].Value.Equals("3.8"));
                        break;
                    case "Distance":
                        Assert.IsTrue(configuration.PropertyList[i].Value.Equals("10"));
                        break;
                    case "WaitForGpsFix":
                        Assert.IsTrue(configuration.PropertyList[i].Value.Equals("yes"));
                        break;
                    case "Version":
                        Assert.IsTrue(configuration.PropertyList[i].Value.Equals("1.0"));
                        break;
                    default:
                        //unknown property, can't check
                        break;
                }
            }

            //CLEANUP
            System.IO.File.Delete(filePath);
        }
    }
}