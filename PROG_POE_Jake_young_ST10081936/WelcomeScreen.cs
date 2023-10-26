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
    public partial class WelcomeScreen : UserControl
    {
        public WelcomeScreen()
        {
            InitializeComponent();
            
            InitialiseMenu();
           
        }

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to set the navigation of the menu options
        /// </summary>
        private void InitialiseMenu()
        {
            //part one  (sort books) navigation components
            panel6.Click += new EventHandler(StartPartOne_Click);
            label5.Click += new EventHandler(StartPartOne_Click);

            //part two  (identify areas) navigation components
            panel4.Click += new EventHandler(StartPartTwo_Click);
            label3.Click += new EventHandler(StartPartTwo_Click);

            //set the sound effect for mouse enter "hover"
            panel6.MouseEnter += new EventHandler(Option_MouseEnter);
            label5.MouseEnter += new EventHandler(Option_MouseEnter);
        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Enter POE Part 1 - Order Books
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartPartOne_Click(object sender, EventArgs e)
        {
            //new sound manager object
            SoundManager soundEffect = new SoundManager();

            //call method to play sound effect
            soundEffect.PlaySound("ButtonClick");

            //show part one "order books"
            Form1 partOne = new Form1(1);
            partOne.Show();
        }
        //------------------------------------------------------------------------------------------------------------------

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Enter POE Part 2 - Identify Areas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartPartTwo_Click(object sender, EventArgs e)
        {
            //new sound manager object
            SoundManager soundEffect = new SoundManager();

            //call method to play sound effect
            soundEffect.PlaySound("ButtonClick");

            //show part two "identify  areas"
            Form1 partTwo = new Form1(2);
            partTwo.Show();
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// sound effects on mouse enter of menu options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Option_MouseEnter(object sender, EventArgs e)
        {
            //new sound manager object
            SoundManager soundEffect = new SoundManager();

            //call method to play sound effect
            soundEffect.PlaySound("ButtonHover");
        }
        //------------------------------------------------------------------------------------------------------------------

    }
}
