using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Camera_Configuration_File_Editor
{
    class CCFE_FileIO
    {
        public static void writeFile(string fileLocation, string configurationFileText)
        {
            File.WriteAllText(fileLocation, configurationFileText);
        }
        public static string readFile(string fileLocation)
        {
            return File.ReadAllText(fileLocation);
        }
    }
}
