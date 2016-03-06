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
    public class CCFE_FileIOTests
    {
        [TestMethod()]
        public void writeFileTest()
        {
            //ARRANGE
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "CCFE_writeFileTest.txt";
            //delete test file if one exists
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            string fileData = "writeFile Data";

            //ACT
            CCFE_FileIO.writeFile(filePath, fileData);

            //ASSERT
            //check if file was written
            Assert.IsTrue(System.IO.File.Exists(filePath));
            //check if file was written correctly
            Assert.IsTrue(fileData.Equals(System.IO.File.ReadAllText(filePath)));

            //CLEANUP
            System.IO.File.Delete(filePath);
        }

        [TestMethod()]
        public void readFileTest()
        {
            //ARRANGE
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "CCFE_readFileTest.txt";
            string fileData = "readFile Data";
            System.IO.File.WriteAllText(filePath, fileData);

            //ACT
            string result = CCFE_FileIO.readFile(filePath);

            //ASSERT
            //check if file was read correctly
            Assert.IsTrue(result.Equals(fileData));

            //CLEANUP
            System.IO.File.Delete(filePath);
        }
    }
}