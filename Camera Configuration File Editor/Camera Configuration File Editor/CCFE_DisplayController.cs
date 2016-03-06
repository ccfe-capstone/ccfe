using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_Configuration_File_Editor
{
    public class CCFE_DisplayController
    {
        CCFE_Configuration configuration;

        public CCFE_Configuration Configuration
        {
            get
            {
                return configuration;
            }

            set
            {
                configuration = value;
            }
        }

        public void setupDisplay()
        {

        }
    }
}
