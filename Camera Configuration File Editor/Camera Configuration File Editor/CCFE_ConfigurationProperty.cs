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
            this.Name = name;
            this.Value = value;
        }

        private string name;
        private string value;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }
    }
}
