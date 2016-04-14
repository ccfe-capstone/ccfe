using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Camera_Configuration_File_Editor
{
    public class CCFE_FileHandler
    {
        #region property constants
        enum STATES
        {
            VERSION,
            COMMENTS
        };
        #endregion

        #region variables
        private string fileLocation;

        public string FileLocation
        {
            get
            {
                return fileLocation;
            }

            set
            {
                fileLocation = value;
            }
        }
        #endregion

        #region constructors
        public CCFE_FileHandler(string fileLocation)
        {
            FileLocation = String.Copy(fileLocation);
        }
        #endregion

        #region public methods
        public void save(CCFE_Configuration configuration)
        {
            string configurationFileText;

            configurationFileText = "[UserSettings]\n";
            configurationFileText += "# CCFE v" + CCFE_Default.programVersion + " - " + DateTime.Now.ToString(CultureInfo.CurrentCulture) + "\n";

            List<CCFE_ConfigurationProperty> configurationComments = CCFE_Default.getCommentPropertyPairs(configuration.getValue("Version"));

            foreach (CCFE_ConfigurationProperty property in configuration.PropertyList)
            {
                configurationFileText = configurationFileText + appendProperty(property, configurationComments);
            }

            System.IO.File.WriteAllText(FileLocation, configurationFileText);
        }

        public List<CCFE_ConfigurationProperty> parse()
        {
            List<CCFE_ConfigurationProperty> propertyList = new List<CCFE_ConfigurationProperty>();

            //read in file data as string
            string fileText = System.IO.File.ReadAllText(FileLocation);

            //create StringReader to parse string
            System.IO.StringReader stringReader = new System.IO.StringReader(fileText);

            string line;
            string propertyPattern = "^([A-Z])([A-z])+=\\S+";
            string[] propertyValues;
            while ((line = stringReader.ReadLine()) != null)
            {
                //check if line is a property using regex
                if (System.Text.RegularExpressions.Regex.IsMatch(line, propertyPattern))
                {
                    //break string into 'name' and 'value' parts
                    propertyValues = line.Split('=');
                    propertyList.Add(new CCFE_ConfigurationProperty(propertyValues[0], propertyValues[1]));
                }
            }
            stringReader.Close();

            return propertyList;
        }

        public List<CCFE_ConfigurationProperty> parseComments()
        {
            List<CCFE_ConfigurationProperty> propertyList = new List<CCFE_ConfigurationProperty>();

            STATES state = STATES.VERSION;

            //read in file data as string
            string fileText = System.IO.File.ReadAllText(FileLocation);

            //create StringReader to parse string
            System.IO.StringReader stringReader = new System.IO.StringReader(fileText);

            string line;
            string commentPattern = "^#.+";
            string propertyPattern = "^([A-Z])([A-z])+=\\S+";
            string[] propertyValues;

            string commentValue = string.Empty;

            while ((line = stringReader.ReadLine()) != null)
            {
                if (line.Equals(string.Empty))
                {
                    if(state == STATES.COMMENTS)
                    {
                        commentValue += "\n";
                    }
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(line, commentPattern))
                {
                    if (state == STATES.VERSION)
                    {
                        state = STATES.COMMENTS;
                    }
                    else if (state == STATES.COMMENTS)
                    {
                        if (commentValue.Equals(string.Empty) || commentValue.Equals("\n"))
                        {
                            commentValue += line;
                        }
                        else
                        {
                            commentValue += "\n" + line;
                        }
                    }
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(line, propertyPattern))
                {
                    if (state == STATES.COMMENTS)
                    {
                        //break property into 'name' and 'value' parts
                        propertyValues = line.Split('=');
                        if (!(commentValue.Equals(string.Empty) || commentValue.Equals("\n")))
                        {
                            commentValue = commentValue + "\n";
                        }
                        propertyList.Add(new CCFE_ConfigurationProperty(propertyValues[0], commentValue));
                        commentValue = "";
                    }
                }
            }
            stringReader.Close();

            return propertyList;
        }
        #endregion

        #region private methods
        private string appendProperty(CCFE_ConfigurationProperty property, List<CCFE_ConfigurationProperty> configurationComments)
        {
            string appendText = "";

            CCFE_ConfigurationProperty comment = configurationComments.Find(x => x.Name.Equals(property.Name));
            appendText = comment.Value + property.Name + "=" + property.Value + "\n";

            return appendText;
        }
        #endregion
    }
}
