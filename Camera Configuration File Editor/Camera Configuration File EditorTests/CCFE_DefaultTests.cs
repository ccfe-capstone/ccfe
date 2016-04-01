using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camera_Configuration_File_Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Camera_Configuration_File_Editor.Tests
{
    [TestClass()]
    public class CCFE_DefaultTests
    {
        #region constants
        const int hardcodedVersionCount = 1;
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
            "TriggerMode=1\n" +
            "\n" +
            "# --------- GPS Overlap Trigger Options ---------\n" +
            "# Only used when TriggerMode is 5 or 6 (GPS Overlap - Auto Detect OR Known Altitude)\n" +
            "OverlapPercent=50\n" +
            "\n" +
            "# Only used when TriggerMode is 6 (GPS Overlap - Known Altitude)\n" +
            "# KnownAltudeUnits options: feet, meters\n" +
            "KnownHalAltitudeUnits=meters\n" +
            "KnownHalAltitude=200\n" +
            "\n" +
            "# --------- Time Trigger Options ---------\n" +
            "# Only used when TriggerMode is 0 or 4 (Time)\n" +
            "# Time in seconds\n" +
            "Time=4.2\n" +
            "\n" +
            "# --------- GPS Distance Trigger Options ---------\n" +
            "# Only used when TriggerMode is 3 (Distance)\n" +
            "# Distance in meters\n" +
            "Distance=5\n" +
            "\n" +
            "# --------- General GPS Options -------------------\n" +
            "# Only used when TriggerMode is 3,4,5,6\n" +
            "# Options: yes, no\n" +
            "WaitForGpsFix=no\n" +
            "\n" +
            "# Indicates version of this file, to know what fields are available\n" +
            "# Minor number increments when new fields are added\n" +
            "Version=1.0\n";
        #endregion

        [TestMethod()]
        public void getDefaultPropertiesTest_NoConfigFileExists()
        {
            //ARRANGE
            List<CCFE_ConfigurationProperty> propertyList;
            //delete test file if one exists
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/config";
            if (File.Exists(filePath + "1.0.txt"))
            {
                File.Delete(filePath + "/1.0.txt");
            }

            //ACT
            propertyList = CCFE_Default.getDefaultProperties("1.0");

            //ASSERT
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("TriggerMode") && x.Value.Equals("5"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("OverlapPercent") && x.Value.Equals("75"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("KnownHalAltitudeUnits") && x.Value.Equals("feet"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("KnownHalAltitude") && x.Value.Equals("400"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("Time") && x.Value.Equals("3.8"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("Distance") && x.Value.Equals("10"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("WaitForGpsFix") && x.Value.Equals("yes"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("Version") && x.Value.Equals("1.0"))));
        }

        [TestMethod()]
        public void getDefaultPropertiesTest_ConfigFileExists()
        {
            //ARRANGE
            List<CCFE_ConfigurationProperty> propertyList;
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/config";
            Directory.CreateDirectory(filePath);
            File.WriteAllText(filePath + "/1.0.txt", UserSettingsTestData);

            //ACT
            propertyList = CCFE_Default.getDefaultProperties("1.0");

            //ASSERT
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("TriggerMode") && x.Value.Equals("1"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("OverlapPercent") && x.Value.Equals("50"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("KnownHalAltitudeUnits") && x.Value.Equals("meters"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("KnownHalAltitude") && x.Value.Equals("200"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("Time") && x.Value.Equals("4.2"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("Distance") && x.Value.Equals("5"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("WaitForGpsFix") && x.Value.Equals("no"))));
            Assert.IsTrue(propertyList.Exists(x => (x.Name.Equals("Version") && x.Value.Equals("1.0"))));

            //CLEANUP
            File.Delete(filePath + "/1.0.txt");
        }

        [TestMethod()]
        public void getDefaultConfigurationTest_NoConfigFileExists()
        {
            //ARRANGE
            CCFE_Configuration configuration;
            //delete test file if one exists
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/config";
            if (File.Exists(filePath + "1.0.txt"))
            {
                File.Delete(filePath + "/1.0.txt");
            }

            //ACT
            configuration = CCFE_Default.getDefaultConfiguration("1.0");

            //ASSERT
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("TriggerMode") && x.Value.Equals("5"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("OverlapPercent") && x.Value.Equals("75"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("KnownHalAltitudeUnits") && x.Value.Equals("feet"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("KnownHalAltitude") && x.Value.Equals("400"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("Time") && x.Value.Equals("3.8"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("Distance") && x.Value.Equals("10"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("WaitForGpsFix") && x.Value.Equals("yes"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("Version") && x.Value.Equals("1.0"))));
        }

        [TestMethod()]
        public void getDefaultConfigurationTest_ConfigFileExists()
        {
            //ARRANGE
            CCFE_Configuration configuration;
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/config";
            Directory.CreateDirectory(filePath);
            File.WriteAllText(filePath + "/1.0.txt", UserSettingsTestData);

            //ACT
            configuration = CCFE_Default.getDefaultConfiguration("1.0");

            //ASSERT
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("TriggerMode") && x.Value.Equals("1"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("OverlapPercent") && x.Value.Equals("50"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("KnownHalAltitudeUnits") && x.Value.Equals("meters"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("KnownHalAltitude") && x.Value.Equals("200"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("Time") && x.Value.Equals("4.2"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("Distance") && x.Value.Equals("5"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("WaitForGpsFix") && x.Value.Equals("no"))));
            Assert.IsTrue(configuration.PropertyList.Exists(x => (x.Name.Equals("Version") && x.Value.Equals("1.0"))));

            //CLEANUP
            File.Delete(filePath + "/1.0.txt");
        }

        [TestMethod()]
        public void getVersionsTest_NoConfigFolder()
        {
            //ARRANGE
            List<string> versionList;
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/config";
            //delete test folder if one exists
            if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath, true);
            }

            //ACT
            versionList = CCFE_Default.getVersions();

            //ASSERT
            Assert.IsTrue(versionList.Count == hardcodedVersionCount);
            foreach(string hardVersion in CCFE_Default.hardVersions)
            {
                Assert.IsTrue(versionList.Exists(x => x.Equals(hardVersion)));
            }
        }
        
        [TestMethod()]
        public void getVersionsTest_NoConfigs()
        {
            //ARRANGE
            List<string> versionList;
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/config";
            Directory.CreateDirectory(filePath);

            //ACT
            versionList = CCFE_Default.getVersions();

            //ASSERT
            Assert.IsTrue(versionList.Count == hardcodedVersionCount);
            foreach (string hardVersion in CCFE_Default.hardVersions)
            {
                Assert.IsTrue(versionList.Exists(x => x.Equals(hardVersion)));
            }
        }
        
        [TestMethod()]
        public void getVersionsTest_SomeConfigsMissing()
        {
            //ARRANGE
            List<string> versionList;
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "/config";
            //delete test folder (and files) if exists
            if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath, true);
            }
            Directory.CreateDirectory(filePath);
            File.WriteAllText(filePath + "/9000.1.txt", UserSettingsTestData);

            //ACT
            versionList = CCFE_Default.getVersions();

            //ASSERT
            Assert.IsTrue(versionList.Count == hardcodedVersionCount + 1);
            foreach (string hardVersion in CCFE_Default.hardVersions)
            {
                Assert.IsTrue(versionList.Exists(x => x.Equals(hardVersion)));
            }
            Assert.IsTrue(versionList.Exists(x => x.Equals("9000.1")));

            //CLEANUP
            File.Delete(filePath + "/9000.1.txt");
        }
        
    }
}