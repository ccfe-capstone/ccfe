using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_Configuration_File_Editor
{
    public class CCFE_ConfigurationProperty
    {
        public CCFE_ConfigurationProperty(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public string name;
        public string value;
    }
}
