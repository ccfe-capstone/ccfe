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
            AutoSize = true;
            Location = location;
            Width = 1;
            Height = 1;

            propertyLabel = new Label();
            propertyLabel.Name = propertyName + "Label";
            propertyLabel.Text = propertyName + ":";
            propertyLabel.Location = new Point(3, 9);
            propertyLabel.AutoSize = true;
            Controls.Add(propertyLabel);

            propertyTextBox = new TextBox();
            propertyLabel.Name = propertyName + "TextBox";
            propertyTextBox.Text = defaultValue;
            propertyTextBox.Location = new Point(propertyLabel.Location.X + propertyLabel.Size.Width + 3, 8);
            Controls.Add(propertyTextBox);
        }
        #endregion

        #region public methods
        public string getPropertyName()
        {
            return propertyLabel.Text.TrimEnd(':');
        }

        public string getPropertyValue()
        {
            return propertyTextBox.Text;
        }
        #endregion
    }
}
