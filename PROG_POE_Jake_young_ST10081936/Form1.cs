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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //set icon
            this.Icon = Resources.Dewy_Trainer;

            //disable maximise button
            this.MaximizeBox = false;

            //disable minimise button
            this.MinimizeBox = false;
        }

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to disable control stuttering when moving
        /// </summary>
        //source - https://stackoverflow.com/a/14282467
        protected override CreateParams CreateParams
        {
            
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
            
        }
        //------------------------------------------------------------------------------------------------------------------

    }
}
