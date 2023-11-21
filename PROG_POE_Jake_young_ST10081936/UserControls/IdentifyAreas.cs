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
    public partial class IdentifyAreas : UserControl
    {

        //list of picture boxes that hold the game life statuses
        private List<PictureBox> lifeIndicatorList = new List<PictureBox>();

        //new game manager object
        GameManager playerSession;

        //new shelf content object
        ShelfContentIdentifyAreas gameShelf;

        //controls game mode from using the call numbers or the descriptions as the questions
        private bool useCallNumbers = false;

        //game mode getter and setter
        public bool UseCallNumbers { get => useCallNumbers; set => useCallNumbers = value; }


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="useCallNumbers"></param>
        public IdentifyAreas(bool useCallNumbers)
        {
            InitializeComponent();
            this.UseCallNumbers = useCallNumbers;

            //call method to instantiate the second game
            InstantiateGame();
           
        }
        //------------------------------------------------------------------------------------------------------------------

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


  


            //set the game manager
            playerSession = new GameManager(lifeIndicatorList, playerClock, this); //input the list of lives, game timer clock, and the parent control

            //set the shelf content
            gameShelf = new ShelfContentIdentifyAreas(bookshelf, playerSession, UseCallNumbers); //input the control to hold the books, slots and answer options, the game manager object, and the game mode boolean

            //call method to populate the shelf with books and slots
            gameShelf.PopulateShelf();

            //call method to start the game
            playerSession.StartGame();
        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer to control the blinking indicators of empty slots when a user attempts to submit without adding all books to the top shelf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void indicateBlanks_Tick(object sender, EventArgs e)
        {
            //call method to indicate the empty slots
            gameShelf.BlankSlotTicker(indicateBlanks); //input the timer that controls the blinking
        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Update Game Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playerClock_Tick(object sender, EventArgs e)
        {
            //set in-game timer
            GameTimer1.Text = playerSession.GameTimerHandler(); //call method to update the in-game timer
        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Submit Book Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            //call method to check the order of books submited
            gameShelf.EvaluatePlacement(indicateBlanks); //input the timer that controls the blinking
        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Reset Book Position Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetButton_Click(object sender, EventArgs e)
        {

            //call method to reset the books positions
            gameShelf.ResetBooks();
            
        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Change the questions from call numbers to descriptions and vice versa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void questionSwapButton_Click(object sender, EventArgs e)
        {

            try
            {

                //call method to load the second game
                GlobalGameData.GenerateGameTwo(this.Parent, !useCallNumbers); //pass the current mode as inverted

                //remove the active instance of game two
                this.Parent.Controls.Remove(this);
            }
            catch(Exception ex) 
            {
                var inform = MessageBox.Show("Game mode failed to swap", "Error");
            }

        }
        //------------------------------------------------------------------------------------------------------------------

    }
}
