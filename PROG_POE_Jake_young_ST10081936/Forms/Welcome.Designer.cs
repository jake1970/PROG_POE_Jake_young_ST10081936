namespace PROG_POE_Jake_young_ST10081936
{
    partial class Welcome
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
            this.welcomeScreen1 = new PROG_POE_Jake_young_ST10081936.WelcomeScreen();
            this.SuspendLayout();
            // 
            // welcomeScreen1
            // 
            this.welcomeScreen1.BackColor = System.Drawing.Color.Black;
            this.welcomeScreen1.Location = new System.Drawing.Point(1, 0);
            this.welcomeScreen1.Name = "welcomeScreen1";
            this.welcomeScreen1.Size = new System.Drawing.Size(1691, 1354);
            this.welcomeScreen1.TabIndex = 0;
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1690, 1341);
            this.Controls.Add(this.welcomeScreen1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.ResumeLayout(false);

        }

        #endregion

        private WelcomeScreen welcomeScreen1;
    }
}