using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG_POE_Jake_young_ST10081936
{
    static class GlobalGameData
    {
        //global game data

        //time that the game has taken
        private static string gameTime = "00:00";

        //the size of the user controls
        private static readonly Size gameSize = new Size((int)(2299 / 3.15), (int)(1776 / 2.8));

        //game time getter and setter
        public static string GameTime { get => gameTime; set => gameTime = value; }

        


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to create the first game "Sort books"
        /// </summary>
        /// <param name="parentValue"></param>
        public static void GenerateGameOne(Control parentValue)
        {

            //new dynamic component from the ReplacingBooks user control
            ReplacingBooks gameOne = new ReplacingBooks();

            //call method to format the game user control
            FormatControl(parentValue, gameOne);

            //set the forms text to the first game
            parentValue.Text = "Sort Books";
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to create the second game "Identify Areas"
        /// </summary>
        /// <param name="parentValue"></param>
        /// <param name="gameMode"></param>
        public static void GenerateGameTwo(Control parentValue, bool gameMode)
        {

            //new dynamic component from the IdentifyAreas user control
            IdentifyAreas gameTwo = new IdentifyAreas(gameMode);

            //call method to format the game user control
            FormatControl(parentValue, gameTwo);

            //set the forms text to the second game
            parentValue.Text = "Identify Areas";
        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to format the selected game to fit and scale to the screen
        /// </summary>
        /// <param name="parentValue"></param>
        /// <param name="givenGame"></param>
        public static void FormatControl(Control parentValue, Control givenGame)
        {


            //set the dynamic components parent
            givenGame.Parent = parentValue;

            //set the size of the dynamic component
            givenGame.Size = gameSize; //gameSize;

            //set the padding for the dynamic component
            //the padding eliminates the bottom and right side border
            givenGame.Margin = new Padding(0);

            //increase layer order of dynamic component
            givenGame.BringToFront();

        }
        //------------------------------------------------------------------------------------------------------------------



    }
}
