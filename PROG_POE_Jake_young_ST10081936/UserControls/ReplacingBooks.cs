using PROG_POE_Jake_young_ST10081936.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using DeweyDecimalLibrary;


namespace PROG_POE_Jake_young_ST10081936
{
    public partial class ReplacingBooks : UserControl
    {
       
        //list of picture boxes that hold the game life statuses
        private List<PictureBox> lifeIndicatorList = new List<PictureBox>();

        //new game manager object
        GameManager playerSession;

        //new shelf content object
        ShelfContent gameShelf;


        public ReplacingBooks()
        {
            InitializeComponent();

            //call method to prime the game to be started
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

            //set the game manager
            playerSession = new GameManager(lifeIndicatorList, playerClock, this); //input the list of lives, game timer clock, and the parent control
            
            //set the shelf content
            gameShelf = new ShelfContent(bookshelf, playerSession); //input the control to hold the books and slots, and the game manager object

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
            GameTimer.Text = playerSession.GameTimerHandler(); //call method to update the in-game timer
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


    }

}

