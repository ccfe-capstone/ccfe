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
    public class CCFE_ConfigurationTests
    {
        [TestMethod()]
        public void CCFE_ConfigurationTest()
        {
            //ARRANGE

            //ACT
            CCFE_Configuration config = new CCFE_Configuration();

            //ASSERT
            Assert.IsNotNull(config);
            Assert.IsNotNull(config.PropertyList);
        }

        [TestMethod()]
        public void CCFE_ConfigurationTest_PropertyList()
        {
            //ARRANGE
            List<CCFE_ConfigurationProperty> propertyList = new List<CCFE_ConfigurationProperty>();
            propertyList.Add(new CCFE_ConfigurationProperty("TriggerMode", "5"));
            propertyList.Add(new CCFE_ConfigurationProperty("OverlapPercent", "75"));
            propertyList.Add(new CCFE_ConfigurationProperty("KnownHalAltitudeUnits", "feet"));
            propertyList.Add(new CCFE_ConfigurationProperty("KnownHalAltitude", "400"));
            propertyList.Add(new CCFE_ConfigurationProperty("Time", "3.8"));
            propertyList.Add(new CCFE_ConfigurationProperty("Distance", "10"));
            propertyList.Add(new CCFE_ConfigurationProperty("WaitForGpsFix", "yes"));
            propertyList.Add(new CCFE_ConfigurationProperty("Version", "1.0"));

            //ACT
            CCFE_Configuration config = new CCFE_Configuration(propertyList);

            //will cause assert to fail if shallow copy
            foreach (CCFE_ConfigurationProperty property in propertyList)
            {
                if (property.Name.Equals("TriggerMode"))
                {
                    property.Value = "0";
                    break;
                }
            }

            //ASSERT
            Assert.IsNotNull(config);
            Assert.IsNotNull(config.PropertyList);
            Assert.IsTrue(config.getValue("TriggerMode").Equals("5"));
            Assert.IsTrue(config.getValue("OverlapPercent").Equals("75"));
            Assert.IsTrue(config.getValue("KnownHalAltitudeUnits").Equals("feet"));
            Assert.IsTrue(config.getValue("KnownHalAltitude").Equals("400"));
            Assert.IsTrue(config.getValue("Time").Equals("3.8"));
            Assert.IsTrue(config.getValue("Distance").Equals("10"));
            Assert.IsTrue(config.getValue("WaitForGpsFix").Equals("yes"));
            Assert.IsTrue(config.getValue("Version").Equals("1.0"));
        }

        [TestMethod()]
        public void CCFE_ConfigurationTest_SpecificVersion()
        {
            //ARRANGE

            //ACT
            CCFE_Configuration config = new CCFE_Configuration("1.0");

            //ASSERT
            Assert.IsNotNull(config);
            Assert.IsNotNull(config.PropertyList);
            Assert.IsTrue(config.getValue("TriggerMode").Equals("5"));
            Assert.IsTrue(config.getValue("OverlapPercent").Equals("75"));
            Assert.IsTrue(config.getValue("KnownHalAltitudeUnits").Equals("feet"));
            Assert.IsTrue(config.getValue("KnownHalAltitude").Equals("400"));
            Assert.IsTrue(config.getValue("Time").Equals("3.8"));
            Assert.IsTrue(config.getValue("Distance").Equals("10"));
            Assert.IsTrue(config.getValue("WaitForGpsFix").Equals("yes"));
            Assert.IsTrue(config.getValue("Version").Equals("1.0"));
        }

        [TestMethod()]
        public void addPropertyTest()
        {
            //ARRANGE
            CCFE_Configuration config = new CCFE_Configuration();

            //ACT
            config.addProperty(new CCFE_ConfigurationProperty("TestProperty", "TestValue"));
            //try to add duplicate
            config.addProperty(new CCFE_ConfigurationProperty("TestProperty", "TestValue"));
            config.addProperty(new CCFE_ConfigurationProperty("TestProperty", "AnotherTestValue"));

            //ASSERT
            Assert.IsTrue(config.PropertyList.Count == 1);
            Assert.IsTrue(config.PropertyList.Exists(x => (x.Name.Equals("TestProperty") && x.Value.Equals("TestValue"))));
        }

        [TestMethod()]
        public void getValueTest()
        {
            //ARRANGE
            CCFE_Configuration config = new CCFE_Configuration();
            config.PropertyList.Add(new CCFE_ConfigurationProperty("TestProperty1", "TestValue1"));
            config.PropertyList.Add(new CCFE_ConfigurationProperty("TestProperty2", "TestValue2"));

            //ACT
            string result = config.getValue("TestProperty1");

            //ASSERT
            Assert.IsTrue(result.Equals("TestValue1"));
            Assert.IsFalse(result.Equals("TestValue2"));
        }

        [TestMethod()]
        public void setValueTest()
        {
            //ARRANGE
            CCFE_Configuration config = new CCFE_Configuration();
            config.PropertyList.Add(new CCFE_ConfigurationProperty("TestProperty1", "TestValue1"));
            config.PropertyList.Add(new CCFE_ConfigurationProperty("TestProperty2", "TestValue2"));

            //ACT
            config.setValue("TestProperty1", "NewValue");

            //ASSERT
            Assert.IsTrue(config.PropertyList.Exists(x => (x.Name.Equals("TestProperty1") && x.Value.Equals("NewValue"))));
            Assert.IsTrue(config.PropertyList.Exists(x => (x.Name.Equals("TestProperty2") && x.Value.Equals("TestValue2"))));
        }
    }
}