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
        
 
        public Form1(short gameSelector)
        {
            InitializeComponent();

            //set icon
            this.Icon = Resources.Dewy_Trainer;

            //disable maximise button
            this.MaximizeBox = false;

            //disable minimise button
            this.MinimizeBox = false;

            //call method to display the selected game
            Selectgame(gameSelector);
        }


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to select the game to play
        /// </summary>
        /// <param name="gameSelector"></param>
        /// source - https://stackoverflow.com/a/14282467
        public void Selectgame (short gameSelector)
        {

          switch(gameSelector)
            {
                case 1:
                    {
                        //call method to load the first/default game (replacing books/part one)
                        GlobalGameData.GenerateGameOne(this); //pass current form

                    }
                    break;
                case 2:
                    {
                        //call method to load the second game
                        GlobalGameData.GenerateGameTwo(this, true); //pass current form and game mode (true)

                    }
                    break;
                case 3:
                        //call method to load the third game (find call numbers/part three)
                        GlobalGameData.GenerateGameThree(this); //pass current form
                    break;
                default:
                    {
                        //call method to load the first/default game (replacing books/part one)
                        GlobalGameData.GenerateGameOne(this); //pass current form
                    }
                    break;
            }
         

        }
        //------------------------------------------------------------------------------------------------------------------



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
