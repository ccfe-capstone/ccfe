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
        #region variables
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
        #endregion

        #region constructors
        public CCFE_Configuration()
        {
            propertyList = new List<CCFE_ConfigurationProperty>();
        }
        #endregion

        #region public methods
        public void addProperty(CCFE_ConfigurationProperty property)
        {
            propertyList.Add(property);
        }
        #endregion
    }
}
