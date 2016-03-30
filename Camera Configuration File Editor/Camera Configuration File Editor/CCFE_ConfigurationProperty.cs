using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_Configuration_File_Editor
{
    public class CCFE_ConfigurationProperty
    {
        #region constructors
        public CCFE_ConfigurationProperty(string name, string value)
        {
            Name = String.Copy(name);
            Value = String.Copy(value);
        }
        #endregion

        #region variables
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
        #endregion
    }
}
