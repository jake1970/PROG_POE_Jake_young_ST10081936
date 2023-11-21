using PROG_POE_Jake_young_ST10081936.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PROG_POE_Jake_young_ST10081936
{
    internal class GameManager
    {
        
        //list to hold the picture boxes that contain the life status
        private List<PictureBox> lifeList = new List<PictureBox>();

        //list to record picture boxes with lives that have been lost
        private List<PictureBox> lifeListLost = new List<PictureBox>();
        
        //the amount of lives at the end of the game
        private int endLifeCount = 0;

        //time at the start of a game
        private DateTime startTime = new DateTime();

        //the time that the game is taking
        private TimeSpan gameTime = new TimeSpan();


        //the maximum length a game can take
        private const int gameTimeLimitMinutes = 3;

        //seconds in a minute
        private const int secondsPerMinute = 60;

        //timer to handle the game time
        private Timer playerClock = new Timer();

        //the control where dynamic components must be created
        private Control parentControl; //used to create the game over screen

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="lifeList"></param>
        /// <param name="playerClock"></param>
        /// <param name="parentControl"></param>
        public GameManager(List<PictureBox> lifeList, Timer playerClock, Control parentControl)
        {
            this.lifeList = lifeList;
            this.playerClock = playerClock;
            this.parentControl = parentControl;
        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to end the game
        /// </summary>
        /// <param name="win"></param>
        public void EndGame(bool win)
        {
            //stop the game timer
            playerClock.Stop();

            //new dynamic component from the UserFeedback user control
            UserFeedback userPopup = new UserFeedback();

            //pass the win status of the game
            userPopup.GameOutcome = win;
               
            //pass the users score
            userPopup.UserScore = GenerateScore(); //call the method to calculate the users score

            //pass the game time taken
            userPopup.GameTime = GlobalGameData.GameTime;

            //set the dynamic components parent
            userPopup.Parent = parentControl.Parent;

            //set the position on the form of the dynamic component
            userPopup.Location = parentControl.Location;

            //set the padding for the dynamic component
            //the padding eliminates the bottom and right side border
            userPopup.Margin = new Padding(0);

            //set the size of the dynamic component
            userPopup.Size = parentControl.Size;

            //set the position on the form of the dynamic component
            userPopup.Location = parentControl.Location;

            //increase layer order of dynamic component
            userPopup.BringToFront();

           

           
         


        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to generate the players score
        /// </summary>
        /// <returns></returns>
        private double GenerateScore()
        {

            //value to multiple the users score with
            int scoreMultiplier = 0;

            //convert the amount of lives left into the score multiplier
            switch (endLifeCount)
            {
                case 0:
                    //if no lives were lost
                    scoreMultiplier = 3;
                    break;
                case 3:
                    //if 1 life was lost
                    scoreMultiplier = 2;
                    break;
                case 2:
                    //if 2 lives were lost
                    scoreMultiplier = 1;
                    break;
            }

            //calculate the users score
            //the players score
            double playerScore = 0;

            try 
            {
                //score formula: playerLivesLeft x (gameTimeInSeconds - gameTimeTaken)
                playerScore = scoreMultiplier * ((gameTimeLimitMinutes * secondsPerMinute) - Math.Round(gameTime.TotalSeconds));
            }
            catch(Exception ex)
            {
                var inform = MessageBox.Show("Score could not be calculated", "Error");
            }
           

            return playerScore;

        }
        //------------------------------------------------------------------------------------------------------------------

        
        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to remove one of the users "lifes" (chances) if they enter the wrong order
        /// </summary>
        public void SubtractLife()
        {

            //new gif list manager object to handle the animations of the life indicator gifs
            GifListManager handleLifeGifs = new GifListManager(lifeList, lifeListLost);

            //get the remaining lives
            var remainingLives = from life in lifeList where !lifeListLost.Contains(life) select life;

            //get the lives that have been already used
            var lostLives = from life in lifeList where life.Enabled == true && lifeListLost.Contains(life) == false select life;


            try
            {

                //loop through the lives that have been used
                foreach (PictureBox life in lostLives)
                {
                    //if a life is lost while another life is busy doing its animation
                    //call method to manually end its animation
                    handleLifeGifs.ManualHandle(life);  //call method to manually invalidate the life
                }
            
            }
            catch (Exception ex)
            {
                var inform = MessageBox.Show("Life status could not be displayed", "Error");
            }


            //check for remaining lives
            if (remainingLives.Any())
            {

                try
                { 
                //record the amounnt of lives remaining
                //call method to animate and invalidate a remaining life
                endLifeCount = handleLifeGifs.animateItem(remainingLives.ToList());
                }
                catch (Exception ex)
                {
                    var inform = MessageBox.Show("Life status could not be displayed", "Error");
                }


                //new sound manager object
                SoundManager soundEffect = new SoundManager();

                //call method to play sound effect
                soundEffect.PlaySound("WrongAnswer");
            }


            //check if there are still valid lives left
            if (endLifeCount <= 1)
            {
                //end game as a loss
                EndGame(false);
            }

        }
        //------------------------------------------------------------------------------------------------------------------
        

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to start the game sequence
        /// </summary>
        public void StartGame()
        {
            //set the current time
            startTime = DateTime.Now;

            //start game clock
            playerClock.Start();

        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Update Game Timer
        /// </summary>
        /// <returns></returns>
        public string GameTimerHandler()
        {
            

            //calculate the time that the game has taken so far
            gameTime = DateTime.Now - startTime;

            //source - https://stackoverflow.com/a/37730718
            //format the game time taken as seconds and minutes
            string currentGameTime = string.Format("{0:mm\\:ss}", gameTime);

            //record the game time taken as global data
            GlobalGameData.GameTime = currentGameTime;


            //check if the games time taken is over the maximum amount
            if (Math.Round(gameTime.TotalSeconds) >= (gameTimeLimitMinutes * secondsPerMinute))
            {
                //end game as a loss
                EndGame(false);
            }


            return currentGameTime;
        }
        //------------------------------------------------------------------------------------------------------------------



    }
}
