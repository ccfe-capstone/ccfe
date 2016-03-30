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
    public class CCFE_ConfigurationPropertyTests
    {
        [TestMethod()]
        public void CCFE_ConfigurationPropertyTest()
        {
            //ARRANGE
            string name = "TestProperty";
            string value = "TestValue";

            //ACT
            CCFE_ConfigurationProperty property = new CCFE_ConfigurationProperty(name, value);
            //check deep copy
            value = "AlternateValue";

            //ASSERT
            Assert.IsTrue(property.Name.Equals("TestProperty"));
            Assert.IsTrue(property.Value.Equals("TestValue"));
        }
    }
}