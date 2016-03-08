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
        #region constants
        const string NOVALUE = "";
        #endregion

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

        public CCFE_Configuration(List<CCFE_ConfigurationProperty> propertyList)
        {
            PropertyList = propertyList;
        }

        public CCFE_Configuration(string configurationVersion)
        {
            if (configurationVersion.Equals("1.0"))
            {
                //TODO: create properties with default values for configuration version
                propertyList.Add(new CCFE_ConfigurationProperty("TriggerMode", "5"));
                propertyList.Add(new CCFE_ConfigurationProperty("OverlapPercent", "75"));
                propertyList.Add(new CCFE_ConfigurationProperty("KnownHalAltitudeUnits", "feet"));
                propertyList.Add(new CCFE_ConfigurationProperty("KnownHalAltitude", "400"));
                propertyList.Add(new CCFE_ConfigurationProperty("Time", "3.8"));
                propertyList.Add(new CCFE_ConfigurationProperty("Distance", "10"));
                propertyList.Add(new CCFE_ConfigurationProperty("WaitForGpsFix", "yes"));
                propertyList.Add(new CCFE_ConfigurationProperty("Version", configurationVersion));
            }
        }
        #endregion

        #region public methods
        public void addProperty(CCFE_ConfigurationProperty property)
        {
            propertyList.Add(property);
        }

        public string getValue(string propertyName)
        {
            foreach (CCFE_ConfigurationProperty property in propertyList)
            {
                if (property.Name.Equals(propertyName))
                {
                    return property.Value;
                }
            }

            //we didn't find anything
            return NOVALUE;
        }

        public void setValue(string propertyName, string value)
        {
            foreach (CCFE_ConfigurationProperty property in propertyList)
            {
                if (property.Name.Equals(propertyName))
                {
                    property.Value = value;
                    return;
                }
            }
        }
        #endregion
    }
}
