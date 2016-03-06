using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_Configuration_File_Editor
{
    public class CCFE_Configuration
    {
        public CCFE_Configuration()
        {
            propertyList = new List<CCFE_ConfigurationProperty>();
        }

        private List<CCFE_ConfigurationProperty> propertyList;

        public List<CCFE_ConfigurationProperty> PropertyList
        {
            get
            {
                return propertyList;
            }

            set
            {
                propertyList = value;
            }
        }

        public void addProperty(CCFE_ConfigurationProperty property)
        {
            propertyList.Add(property);
        }
    }
}
