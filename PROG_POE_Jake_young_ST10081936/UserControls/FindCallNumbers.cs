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
    public partial class FindCallNumbers : UserControl
    {

        //list of picture boxes that hold the game life statuses
        private List<PictureBox> lifeIndicatorList = new List<PictureBox>();

        //list of panels that hold the potential answers to the main question
        private List<Panel> potentialAnswers = new List<Panel>();

        //new game manager object
        GameManager playerSession;

        //new shelf content object
        ShelfContentFindCallNumbers gameShelf;

        public FindCallNumbers()
        {
            InitializeComponent();


            //call method to instantiate the third game
            InstantiateGame();

        }

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to call all functions associated with the start of a new game
        /// </summary>
        private void InstantiateGame()
        {
            //add the picture boxes that contain the life gifs to the list
            lifeIndicatorList.Add(lives1);
            lifeIndicatorList.Add(lives2);
            lifeIndicatorList.Add(lives3);


            //add the panels that contain the possible answers
            potentialAnswers.Add(pnlAnswer4);
            potentialAnswers.Add(pnlAnswer3);
            potentialAnswers.Add(pnlAnswer2);
            potentialAnswers.Add(pnlAnswer1);
            

            //set the game manager
            playerSession = new GameManager(lifeIndicatorList, playerClock, this); //input the list of lives, game timer clock, and the parent control

            //set the shelf content
            gameShelf = new ShelfContentFindCallNumbers(playerSession, potentialAnswers, pnlCurrentQuestion, pnlSlot); //input the control to hold the books, slots and answer options, the game manager object, and the game mode boolean


            //method to populate shelf with game data
            gameShelf.InitialSetup();


            //call method to start the game
            playerSession.StartGame();
        }
        //------------------------------------------------------------------------------------------------------------------




        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Update Game Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playerClock_Tick_1(object sender, EventArgs e)
        {
            //set in-game timer
            GameTimer.Text = playerSession.GameTimerHandler(); //call method to update the in-game timer
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            //call method to reset the book back to its original postion and out of the slot
            gameShelf.ResetPanel();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            //call method to check the book answer against the question
            gameShelf.EvaluateAnswer(indicateBlanks);
        }

        private void indicateBlanks_Tick(object sender, EventArgs e)
        {
            //call method to indicate the empty slots
            gameShelf.BlankSlotTicker(indicateBlanks); //input the timer that controls the blinking
        }
        //------------------------------------------------------------------------------------------------------------------

    }
}
