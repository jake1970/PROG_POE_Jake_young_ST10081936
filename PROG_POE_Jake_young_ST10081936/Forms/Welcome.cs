using PROG_POE_Jake_young_ST10081936.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG_POE_Jake_young_ST10081936
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();

            //set icon
            this.Icon = Resources.Dewy_Trainer;

            //disable maximise button
            this.MaximizeBox = false;

            //disable minimise button
            this.MinimizeBox = false;
        }
    }
}
