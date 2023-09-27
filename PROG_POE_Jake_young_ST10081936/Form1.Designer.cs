namespace PROG_POE_Jake_young_ST10081936
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.replacingBooks1 = new PROG_POE_Jake_young_ST10081936.ReplacingBooks();
            this.SuspendLayout();
            // 
            // replacingBooks1
            // 
            this.replacingBooks1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.replacingBooks1.BackColor = System.Drawing.Color.Black;
            this.replacingBooks1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.replacingBooks1.Location = new System.Drawing.Point(0, 0);
            this.replacingBooks1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.replacingBooks1.Name = "replacingBooks1";
            this.replacingBooks1.Size = new System.Drawing.Size(1088, 945);
            this.replacingBooks1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1088, 945);
            this.Controls.Add(this.replacingBooks1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "Form1";
            this.Text = "Sort Books";
            this.ResumeLayout(false);

        }

        #endregion

        private ReplacingBooks replacingBooks1;
    }
}

