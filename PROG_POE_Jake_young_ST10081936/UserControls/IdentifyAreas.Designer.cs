namespace PROG_POE_Jake_young_ST10081936
{
    partial class IdentifyAreas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IdentifyAreas));
            this.playerClock = new System.Windows.Forms.Timer(this.components);
            this.indicateBlanks = new System.Windows.Forms.Timer(this.components);
            this.resetButton = new System.Windows.Forms.PictureBox();
            this.submitButton = new System.Windows.Forms.PictureBox();
            this.GameTimer1 = new System.Windows.Forms.Label();
            this.bookshelf = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lives3 = new System.Windows.Forms.PictureBox();
            this.lives2 = new System.Windows.Forms.PictureBox();
            this.lives1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.questionSwapButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.resetButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.submitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookshelf)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lives3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lives2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lives1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionSwapButton)).BeginInit();
            this.SuspendLayout();
            // 
            // playerClock
            // 
            this.playerClock.Interval = 1000;
            this.playerClock.Tick += new System.EventHandler(this.playerClock_Tick);
            // 
            // indicateBlanks
            // 
            this.indicateBlanks.Interval = 350;
            this.indicateBlanks.Tick += new System.EventHandler(this.indicateBlanks_Tick);
            // 
            // resetButton
            // 
            this.resetButton.Image = ((System.Drawing.Image)(resources.GetObject("resetButton.Image")));
            this.resetButton.Location = new System.Drawing.Point(1739, 54);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(202, 202);
            this.resetButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resetButton.TabIndex = 22;
            this.resetButton.TabStop = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Image = ((System.Drawing.Image)(resources.GetObject("submitButton.Image")));
            this.submitButton.Location = new System.Drawing.Point(2022, 54);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(202, 202);
            this.submitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.submitButton.TabIndex = 21;
            this.submitButton.TabStop = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // GameTimer1
            // 
            this.GameTimer1.AutoSize = true;
            this.GameTimer1.BackColor = System.Drawing.Color.Transparent;
            this.GameTimer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameTimer1.ForeColor = System.Drawing.Color.White;
            this.GameTimer1.Location = new System.Drawing.Point(37, 39);
            this.GameTimer1.Name = "GameTimer1";
            this.GameTimer1.Size = new System.Drawing.Size(263, 101);
            this.GameTimer1.TabIndex = 4;
            this.GameTimer1.Text = "00:00";
            // 
            // bookshelf
            // 
            this.bookshelf.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bookshelf.BackgroundImage")));
            this.bookshelf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bookshelf.Location = new System.Drawing.Point(80, 306);
            this.bookshelf.Name = "bookshelf";
            this.bookshelf.Size = new System.Drawing.Size(2149, 1504);
            this.bookshelf.TabIndex = 6;
            this.bookshelf.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.lives3);
            this.panel2.Controls.Add(this.lives2);
            this.panel2.Controls.Add(this.lives1);
            this.panel2.ForeColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(163, 731);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 148);
            this.panel2.TabIndex = 25;
            // 
            // lives3
            // 
            this.lives3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lives3.Enabled = false;
            this.lives3.Image = ((System.Drawing.Image)(resources.GetObject("lives3.Image")));
            this.lives3.ImageLocation = "";
            this.lives3.InitialImage = null;
            this.lives3.Location = new System.Drawing.Point(388, 2);
            this.lives3.Name = "lives3";
            this.lives3.Size = new System.Drawing.Size(144, 157);
            this.lives3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lives3.TabIndex = 15;
            this.lives3.TabStop = false;
            // 
            // lives2
            // 
            this.lives2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lives2.Enabled = false;
            this.lives2.Image = ((System.Drawing.Image)(resources.GetObject("lives2.Image")));
            this.lives2.ImageLocation = "";
            this.lives2.InitialImage = null;
            this.lives2.Location = new System.Drawing.Point(220, 2);
            this.lives2.Name = "lives2";
            this.lives2.Size = new System.Drawing.Size(144, 157);
            this.lives2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lives2.TabIndex = 14;
            this.lives2.TabStop = false;
            // 
            // lives1
            // 
            this.lives1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lives1.Enabled = false;
            this.lives1.Image = ((System.Drawing.Image)(resources.GetObject("lives1.Image")));
            this.lives1.ImageLocation = "";
            this.lives1.InitialImage = null;
            this.lives1.Location = new System.Drawing.Point(52, 2);
            this.lives1.Name = "lives1";
            this.lives1.Size = new System.Drawing.Size(144, 157);
            this.lives1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lives1.TabIndex = 13;
            this.lives1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.GameTimer1);
            this.panel3.ForeColor = System.Drawing.Color.Transparent;
            this.panel3.Location = new System.Drawing.Point(209, 563);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 177);
            this.panel3.TabIndex = 26;
            // 
            // questionSwapButton
            // 
            this.questionSwapButton.Image = ((System.Drawing.Image)(resources.GetObject("questionSwapButton.Image")));
            this.questionSwapButton.Location = new System.Drawing.Point(80, 54);
            this.questionSwapButton.Name = "questionSwapButton";
            this.questionSwapButton.Size = new System.Drawing.Size(202, 202);
            this.questionSwapButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.questionSwapButton.TabIndex = 27;
            this.questionSwapButton.TabStop = false;
            this.questionSwapButton.Click += new System.EventHandler(this.questionSwapButton_Click);
            // 
            // IdentifyAreas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.questionSwapButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.bookshelf);
            this.Name = "IdentifyAreas";
            this.Size = new System.Drawing.Size(2299, 1776);
            ((System.ComponentModel.ISupportInitialize)(this.resetButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.submitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookshelf)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lives3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lives2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lives1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionSwapButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bookshelf;
        private System.Windows.Forms.Label GameTimer1;
        private System.Windows.Forms.PictureBox resetButton;
        private System.Windows.Forms.PictureBox submitButton;
        private System.Windows.Forms.Timer playerClock;
        private System.Windows.Forms.Timer indicateBlanks;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox lives3;
        private System.Windows.Forms.PictureBox lives2;
        private System.Windows.Forms.PictureBox lives1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox questionSwapButton;
    }
}
