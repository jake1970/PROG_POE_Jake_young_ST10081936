using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG_POE_Jake_young_ST10081936
{
    internal class CustomLabel : Label
    {

        //custom class for custom labels

        //the new text color of the custom label when disabled
        private Color disabledTextColor = Color.White;


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Override method for on paint to change the text color when the label is disabled
        /// </summary>
        /// <param name="e"></param>
        /// source - https://stackoverflow.com/a/6002751
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!this.Enabled)
            {
                using (Brush brush = new SolidBrush(disabledTextColor))
                {
                    e.Graphics.DrawString(this.Text, this.Font, brush, this.ClientRectangle);
                }
               
            }
            else
            {
                base.OnPaint(e); // Use the default paint behavior when enabled
            }
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to format the label to appear centered on the spine of the book
        /// </summary>
        /// <param name="labelParent"></param>
        public void FormatLabel(Panel labelParent)
        {
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.AutoSize = true;
            this.Width = labelParent.Width;
            this.MaximumSize = new Size(labelParent.Width - 12, 0);
            this.MinimumSize = new Size(labelParent.Width - 12, 0);
            this.Left = 4;
            this.Top = ((labelParent.Height - this.Height) / 2) + 4;
        }
        //------------------------------------------------------------------------------------------------------------------


    }
}
