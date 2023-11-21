namespace PROG_POE_Jake_young_ST10081936
{
    partial class FindCallNumbers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindCallNumbers));
            this.playerClock = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lives3 = new System.Windows.Forms.PictureBox();
            this.lives2 = new System.Windows.Forms.PictureBox();
            this.lives1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GameTimer = new System.Windows.Forms.Label();
            this.bookshelf = new System.Windows.Forms.Panel();
            this.pnlCurrentQuestion = new System.Windows.Forms.Panel();
            this.pnlSlot = new System.Windows.Forms.Panel();
            this.pnlAnswer1 = new System.Windows.Forms.Panel();
            this.pnlAnswer2 = new System.Windows.Forms.Panel();
            this.pnlAnswer3 = new System.Windows.Forms.Panel();
            this.pnlAnswer4 = new System.Windows.Forms.Panel();
            this.resetButton = new System.Windows.Forms.PictureBox();
            this.submitButton = new System.Windows.Forms.PictureBox();
            this.indicateBlanks = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lives3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lives2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lives1)).BeginInit();
            this.panel1.SuspendLayout();
            this.bookshelf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resetButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.submitButton)).BeginInit();
            this.SuspendLayout();
            // 
            // playerClock
            // 
            this.playerClock.Interval = 1000;
            this.playerClock.Tick += new System.EventHandler(this.playerClock_Tick_1);
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
            this.panel2.Location = new System.Drawing.Point(718, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 148);
            this.panel2.TabIndex = 21;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.GameTimer);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(161, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 233);
            this.panel1.TabIndex = 20;
            // 
            // GameTimer
            // 
            this.GameTimer.AutoSize = true;
            this.GameTimer.BackColor = System.Drawing.Color.Transparent;
            this.GameTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameTimer.ForeColor = System.Drawing.Color.White;
            this.GameTimer.Location = new System.Drawing.Point(82, 59);
            this.GameTimer.Name = "GameTimer";
            this.GameTimer.Size = new System.Drawing.Size(311, 118);
            this.GameTimer.TabIndex = 4;
            this.GameTimer.Text = "00:00";
            // 
            // bookshelf
            // 
            this.bookshelf.BackColor = System.Drawing.Color.Transparent;
            this.bookshelf.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bookshelf.BackgroundImage")));
            this.bookshelf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bookshelf.Controls.Add(this.pnlCurrentQuestion);
            this.bookshelf.Controls.Add(this.pnlSlot);
            this.bookshelf.Controls.Add(this.pnlAnswer1);
            this.bookshelf.Controls.Add(this.pnlAnswer2);
            this.bookshelf.Controls.Add(this.pnlAnswer3);
            this.bookshelf.Controls.Add(this.pnlAnswer4);
            this.bookshelf.ForeColor = System.Drawing.Color.Transparent;
            this.bookshelf.Location = new System.Drawing.Point(75, 317);
            this.bookshelf.Name = "bookshelf";
            this.bookshelf.Size = new System.Drawing.Size(2149, 1504);
            this.bookshelf.TabIndex = 32;
            // 
            // pnlCurrentQuestion
            // 
            this.pnlCurrentQuestion.BackColor = System.Drawing.Color.Transparent;
            this.pnlCurrentQuestion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlCurrentQuestion.BackgroundImage")));
            this.pnlCurrentQuestion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCurrentQuestion.ForeColor = System.Drawing.Color.Transparent;
            this.pnlCurrentQuestion.Location = new System.Drawing.Point(257, 474);
            this.pnlCurrentQuestion.Name = "pnlCurrentQuestion";
            this.pnlCurrentQuestion.Size = new System.Drawing.Size(610, 148);
            this.pnlCurrentQuestion.TabIndex = 38;
            // 
            // pnlSlot
            // 
            this.pnlSlot.BackColor = System.Drawing.Color.Transparent;
            this.pnlSlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlSlot.ForeColor = System.Drawing.Color.Transparent;
            this.pnlSlot.Location = new System.Drawing.Point(257, 1117);
            this.pnlSlot.Name = "pnlSlot";
            this.pnlSlot.Size = new System.Drawing.Size(610, 148);
            this.pnlSlot.TabIndex = 36;
            // 
            // pnlAnswer1
            // 
            this.pnlAnswer1.BackColor = System.Drawing.Color.Transparent;
            this.pnlAnswer1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAnswer1.BackgroundImage")));
            this.pnlAnswer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlAnswer1.ForeColor = System.Drawing.Color.Transparent;
            this.pnlAnswer1.Location = new System.Drawing.Point(1330, 702);
            this.pnlAnswer1.Name = "pnlAnswer1";
            this.pnlAnswer1.Size = new System.Drawing.Size(610, 148);
            this.pnlAnswer1.TabIndex = 35;
            // 
            // pnlAnswer2
            // 
            this.pnlAnswer2.BackColor = System.Drawing.Color.Transparent;
            this.pnlAnswer2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAnswer2.BackgroundImage")));
            this.pnlAnswer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlAnswer2.ForeColor = System.Drawing.Color.Transparent;
            this.pnlAnswer2.Location = new System.Drawing.Point(1330, 840);
            this.pnlAnswer2.Name = "pnlAnswer2";
            this.pnlAnswer2.Size = new System.Drawing.Size(610, 148);
            this.pnlAnswer2.TabIndex = 34;
            // 
            // pnlAnswer3
            // 
            this.pnlAnswer3.BackColor = System.Drawing.Color.Transparent;
            this.pnlAnswer3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAnswer3.BackgroundImage")));
            this.pnlAnswer3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlAnswer3.ForeColor = System.Drawing.Color.Transparent;
            this.pnlAnswer3.Location = new System.Drawing.Point(1330, 978);
            this.pnlAnswer3.Name = "pnlAnswer3";
            this.pnlAnswer3.Size = new System.Drawing.Size(610, 148);
            this.pnlAnswer3.TabIndex = 33;
            // 
            // pnlAnswer4
            // 
            this.pnlAnswer4.BackColor = System.Drawing.Color.Transparent;
            this.pnlAnswer4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAnswer4.BackgroundImage")));
            this.pnlAnswer4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlAnswer4.ForeColor = System.Drawing.Color.Transparent;
            this.pnlAnswer4.Location = new System.Drawing.Point(1330, 1117);
            this.pnlAnswer4.Name = "pnlAnswer4";
            this.pnlAnswer4.Size = new System.Drawing.Size(610, 148);
            this.pnlAnswer4.TabIndex = 32;
            // 
            // resetButton
            // 
            this.resetButton.Image = ((System.Drawing.Image)(resources.GetObject("resetButton.Image")));
            this.resetButton.Location = new System.Drawing.Point(1739, 60);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(202, 202);
            this.resetButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resetButton.TabIndex = 34;
            this.resetButton.TabStop = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Image = ((System.Drawing.Image)(resources.GetObject("submitButton.Image")));
            this.submitButton.Location = new System.Drawing.Point(2022, 60);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(202, 202);
            this.submitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.submitButton.TabIndex = 33;
            this.submitButton.TabStop = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // indicateBlanks
            // 
            this.indicateBlanks.Interval = 350;
            this.indicateBlanks.Tick += new System.EventHandler(this.indicateBlanks_Tick);
            // 
            // FindCallNumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bookshelf);
            this.Name = "FindCallNumbers";
            this.Size = new System.Drawing.Size(2299, 1776);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lives3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lives2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lives1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.bookshelf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resetButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.submitButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox lives3;
        private System.Windows.Forms.PictureBox lives2;
        private System.Windows.Forms.PictureBox lives1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label GameTimer;
        private System.Windows.Forms.Timer playerClock;
        private System.Windows.Forms.Panel bookshelf;
        private System.Windows.Forms.Panel pnlCurrentQuestion;
        private System.Windows.Forms.Panel pnlSlot;
        private System.Windows.Forms.Panel pnlAnswer1;
        private System.Windows.Forms.Panel pnlAnswer2;
        private System.Windows.Forms.Panel pnlAnswer3;
        private System.Windows.Forms.Panel pnlAnswer4;
        private System.Windows.Forms.PictureBox resetButton;
        private System.Windows.Forms.PictureBox submitButton;
        private System.Windows.Forms.Timer indicateBlanks;
    }
}
