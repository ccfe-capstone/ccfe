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

        public const string PROPERTY_TRIGGERMODE = "TriggerMode";
        public const string PROPERTY_OVERLAPPERCENT = "OverlapPercent";
        public const string PROPERTY_KNOWNHALALTITUDEUNITS = "KnownHalAltitudeUnits";
        public const string PROPERTY_KNOWNHALALTITUDE = "KnownHalAltitude";
        public const string PROPERTY_TIME = "Time";
        public const string PROPERTY_DISTANCE = "Distance";
        public const string PROPERTY_WAITFORGPSFIX = "WaitForGpsFix";
        public const string PROPERTY_VERSION = "Version";
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
            PropertyList = new List<CCFE_ConfigurationProperty>();
            foreach (CCFE_ConfigurationProperty property in propertyList)
            {
                PropertyList.Add(new CCFE_ConfigurationProperty(property.Name, property.Value));
            }
        }

        public CCFE_Configuration(string configurationVersion)
        {
            PropertyList = new List<CCFE_ConfigurationProperty>();
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
            if (PropertyList.Exists(x => x.Name.Equals(property.Name)))
            {
                //property already exists
            }
            else
            {
                propertyList.Add(new CCFE_ConfigurationProperty(property.Name, property.Value));
            }
        }

        public string getValue(string propertyName)
        {
            CCFE_ConfigurationProperty property = propertyList.Find(x => x.Name.Equals(propertyName));

            if(property != null)
            {
                return property.Value;
            }
            else
            {
                //we didn't find anything
                return NOVALUE;
            }
        }

        public void setValue(string propertyName, string value)
        {
            propertyList.Find(x => x.Name.Equals(propertyName)).Value = value;
        }
        #endregion
    }
}
