using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG_POE_Jake_young_ST10081936
{
    public partial class UserFeedback : UserControl
    {

      

        //if the game was a win or loss
        private bool gameOutcome = false;

        //the players score
        private double userScore = 0;

        //the time it took for the game to end
        private string gameTime = "00:00";

       
      
        public UserFeedback()
        {
            InitializeComponent();

        }


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// On end of game display the results and round data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserFeedback_Load(object sender, EventArgs e)
        {
            
            if (gameOutcome == true)
            {
                lblOutcome.Text = "You Win";

                //new sound manager object
                SoundManager soundEffect = new SoundManager();

                //call method to play sound effect
                soundEffect.PlaySound("GameWin");

            }
            else
            {
                lblOutcome.Text = "You Lose";

                //new sound manager object
                SoundManager soundEffect = new SoundManager();

                //call method to play sound effect
                soundEffect.PlaySound("GameLose");
            }

            lblScore.Text = "Score: " + UserScore.ToString();
            lblTime.Text = "Time: " + gameTime;
            
        }
        //------------------------------------------------------------------------------------------------------------------


        public double UserScore { get => userScore; set => userScore = value; }
        public bool GameOutcome { get => gameOutcome; set => gameOutcome = value; }
        public string GameTime { get => gameTime; set => gameTime = value; }




        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Close the sorting game form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //source - https://stackoverflow.com/a/13528048
        private void backButton_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }
        //------------------------------------------------------------------------------------------------------------------



        private void playAgain()
        {

            var currentGameModifier = true;
                

                foreach (var gameInstance in this.Parent.Controls)
                {
              

                if ((gameInstance is IdentifyAreas))
                {
                    currentGameModifier = (gameInstance as IdentifyAreas).UseCallNumbers;
                   
                }

                if (!(gameInstance is UserFeedback))
                    {
                        this.Parent.Controls.Remove((Control)gameInstance);
                       
                    }
                }


                switch (this.Parent.Text)
                {
                    case "Sort Books":
                        {

                        GlobalGameData.GenerateGameOne(this.Parent);
                        
                        }
                        break;
                    case "Identify Areas":
                        {
                        
                        GlobalGameData.GenerateGameTwo(this.Parent, !currentGameModifier);

                        }
                        break;
                    default:
                        {
                            var inform = MessageBox.Show("Error", "Unable to replay game please select it from the menu");
                        }
                        break;
                }



                this.Parent.Controls.Remove(this);


            
        }

        private void lblPlayAgain_Click(object sender, EventArgs e)
        {
            playAgain();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            playAgain();
        }
    }
}
