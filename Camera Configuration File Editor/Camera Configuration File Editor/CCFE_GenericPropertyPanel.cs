using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Camera_Configuration_File_Editor
{
    public class CCFE_GenericPropertyPanel : Panel
    {
        #region variables
        Label propertyLabel;
        TextBox propertyTextBox;
        #endregion

        #region constructors
        public CCFE_GenericPropertyPanel(Point location, string propertyName, string defaultValue)
        {
            Location = location;
            AutoSize = true;

            propertyLabel = new Label();
            propertyLabel.Text = propertyName;
            propertyLabel.Location = new Point(3, 9);
            this.Controls.Add(propertyLabel);

            propertyTextBox = new TextBox();
            propertyTextBox.Text = defaultValue;
            propertyTextBox.Location = new Point(propertyLabel.Location.X + propertyLabel.Size.Width + 3, 8);
            this.Controls.Add(propertyTextBox);
        }
        #endregion

        #region public methods
        public string getPropertyName()
        {
            return propertyLabel.Text;
        }

        public string getPropertyValue()
        {
            return propertyTextBox.Text;
        }
        #endregion
    }
}
