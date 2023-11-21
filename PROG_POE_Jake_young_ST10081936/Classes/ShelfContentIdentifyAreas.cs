using DeweyDecimalLibrary;
using PROG_POE_Jake_young_ST10081936.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PROG_POE_Jake_young_ST10081936
{


    internal class ShelfContentIdentifyAreas
    {

        
        //dictionary to hold the dewey call numbers and their descriptions
        IDictionary<string, string> callNumbers = new Dictionary<string, string>()
                {
            {"000", "Computer Science, Information, & General Works"},
            {"100", "Philosophy & Psychology"},
            {"200", "Religion"},
            {"300", "Social Sciences"},
            {"400", "Language"},
            {"500", "Science"},
            {"600", "Technology"},
            {"700", "Arts & Recreation"},
            {"800", "Literature"},
            {"900", "History & Geography"}
                };


        //list to hold the book data
        private List<Book> bookList = new List<Book>();

        //list to hold the slot data
        private List<Slot> slotList = new List<Slot>();

        //location of current book
        private Point currentBookPosition = new Point();

        //the size of dynamically generated panels
        private readonly Size panelSize = new Size(180, 46);

        //size of book panels when being moved
        private readonly Size enlargedBookSize = new Size(190, 56);

        //font of dewey decimal label 
        private readonly Font normalDewyLabel = new Font("Microsoft Sans Serif", 8);

        //font of dewey decimal label when the book panel is being moved
        private readonly Font enlargedDewyLabel = new Font("Microsoft Sans Serif", 9);

        //left (X) position of the book slots
        private const int bookSlottedLeft = 254;

        //left (X) position of the books
        private const int bookUnslottedLeft = 34;

        //left (X) position of the answer options
        private const int answerOptionsLeft = bookSlottedLeft + 230;

        //the starting position (Top/Y) of the first book
        private const int bookTopStart = 305;

        //the starting position (Top/Y) of the first slot
        private const int slotTopStart = 20;

        //response to display when an invalid submission of book order is made
        private const string invalidSubmissionResponse = "Please match each question with the correct answer";

        //how many times the empty slot indicator has run
        private int slotBlinkCounter = 0;

        //semi transparent empty slot indicator color
        private readonly Color darkOverlay = Color.FromArgb(70, Color.Black);

        //the control where the dynamic panels (books, slots and answer options) are generated
        private Control bookshelf = new Control();

        //the game manager object that is controlling the current game
        private GameManager gameManager;

        //list to hold labels where answer options are displayed
        private List<CustomLabel> answerOptions = new List<CustomLabel>();

        //the layer order of the current book being moved
        private int zIndex = 0;

        //boolean to control if the questions display the call numbers or descriptions
        private bool useCallNumbers;



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="bookshelf"></param>
        /// <param name="gameManager"></param>
        /// <param name="useCallNumbers"></param>
        public ShelfContentIdentifyAreas(Control bookshelf, GameManager gameManager, bool useCallNumbers)
        {
            this.bookshelf = bookshelf;
            this.gameManager = gameManager;
            this.useCallNumbers = useCallNumbers;

        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to populate the shelf
        /// </summary>
        public void PopulateShelf()
        {
            //method to set the list of call numbers and descriptions that will be shown to the user
            ModifyDeweyDictionary();

            //method to populate a list of the book data
            GenerateBookData();

            //method to populate a list of the slot data
            GenerateSlotData();

            //method to create the dynamic book panels using the list of book data
            CreateSlots();

            //method to create the dynamic slot panels using the list of slot data
            CreateBooks();

            //method to display the answer options text to the books (questions)
            populateAnswerOptions();
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to create the books answer options panels
        /// </summary>
        /// <param name="answerOptionLocation"></param>
        private void CreateBookAnswerOption(Point answerOptionLocation)
        {


            //create new panel for the answer option
            Panel newAnswerOption = new Panel();

            //set the panel size
            newAnswerOption.Size = panelSize;

            //set the left (X) value for the answer option
            answerOptionLocation.X = answerOptionsLeft;

            //assign the answer option a location on the end (right most) shelf
            newAnswerOption.Location = answerOptionLocation;

            //assign the answer option image
            newAnswerOption.BackgroundImage = Resources.grey_book_side;

            //set the answer option image sizing behaviour
            newAnswerOption.BackgroundImageLayout = ImageLayout.Stretch;

            //set the answer options panel to be transparent
            newAnswerOption.BackColor = Color.Transparent;

            //add the answer option to the shelf
            bookshelf.Controls.Add(newAnswerOption);

            //manually set the parent to the shelf
            newAnswerOption.Parent = this.bookshelf;


            //new answer option label to display text
            CustomLabel dewyLabel = new CustomLabel();

            //set the label font
            dewyLabel.Font = normalDewyLabel;

            //set the label font color
            dewyLabel.ForeColor = Color.White;

            //set the label to be contained inside the book
            dewyLabel.Parent = newAnswerOption;

            //disable the label to ensure its events are not observed
            dewyLabel.Enabled = false;

            //add the answer option text to the answer option
            newAnswerOption.Controls.Add(dewyLabel);

            //add the newly made label to the list of answer option labels
            answerOptions.Add(dewyLabel);

        }

        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to populate the list of possible answers with text values
        /// </summary>
        private void populateAnswerOptions()
        {

            //randomise the order of answer option labels
            var shuffled = answerOptions.OrderBy(x => Guid.NewGuid()).ToList(); //source - https://stackoverflow.com/a/4262134

            try
            {

                //loop the amount of call numbers that remain in the dictionary
                for (int i = 0; i < callNumbers.Count; i++)
                {

                    //if the game is in call number question mode
                    if (useCallNumbers == true)
                    {
                        //set the answer options to be the descriptions of the dewey values
                        shuffled[i].Text = callNumbers.ElementAt(i).Value.ToString();
                    }
                    else
                    {
                        //if the game is not in call number question mode
                        //set the answer options to be the dewey values of the descriptions
                        shuffled[i].Text = callNumbers.ElementAt(i).Key.ToString();
                    }


                    //format the labels text to appear centered on the spine of the book
                    shuffled[i].FormatLabel(shuffled[i].Parent as Panel);


                }
            }
            catch (Exception ex)
            {
                var inform = MessageBox.Show("Book Answer Options cannot be generated", "Error");
            }

        }

        //------------------------------------------------------------------------------------------------------------------


        

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to reset all book positions
        /// </summary>
        public void ResetBooks()
        {

            //get all books that are currently in the middle shelf
            var books = from panels in bookshelf.Controls.OfType<Panel>() where panels.Left == bookSlottedLeft && panels.HasChildren == true select panels;


            //loop through middle shelf books
            foreach (Control book in books)
            {
                //get the books corresponding original location from the book list
                var booksExpanded = from avaliableBooks in bookList where book.Controls.OfType<CustomLabel>().First().Text == avaliableBooks.bookDewy select avaliableBooks;

                //set the books location to its initial value
                book.Location = booksExpanded.First().bookPosition;
            }

            //get all slots
            var slots = from panels in bookshelf.Controls.OfType<Panel>() where panels.HasChildren == false && panels.Visible == false select panels;

            //loop through all slots
            foreach (Control slot in slots)
            {
                //make slot visible
                slot.Visible = true;
            }

            //new sound manager object
            SoundManager soundEffect = new SoundManager();

            //call method to play sound effect
            soundEffect.PlaySound("BookDrop");

        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to check if all books are put into slots
        /// </summary>
        /// <returns></returns>
        private bool AllBooksSubmitted()
        {

            //find all books that are on the left most shelf (not in a slot)
            var unslottedBooks = from books in bookshelf.Controls.OfType<Panel>() where books.Left == bookUnslottedLeft && books.Controls.Count < 2 select books;



            //if there are any books that are not in slots
            if (unslottedBooks.Any()) //source - https://stackoverflow.com/a/3259925
            {

                //if all books are not in slots
                return false;
            }
            else
            {
                //if all books are in slots
                return true;
            }




        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to evaluate the users order of books
        /// </summary>
        /// <param name="indicateBlanks"></param>
        public void EvaluatePlacement(System.Windows.Forms.Timer indicateBlanks)
        {

            //new sound manager object
            SoundManager soundEffect = new SoundManager();

            //call method to play sound effect
            soundEffect.PlaySound("BookClick");

            //check if all books are in the middle shelf and in a slot
            if (AllBooksSubmitted() == true)
            {

                //all slotted books
                var bookPanels = (from book in bookshelf.Controls.OfType<Panel>() where book.Left == bookSlottedLeft && book.HasChildren == true select book).OrderBy(book => int.Parse(book.Name));

                //the associated dictionary value from the key
                var result = "";

                //how many answers are correct
                var matches = 0;

                //loop through slotted books
                foreach (var submittedBook in bookPanels)
                {
                    //the question being answered
                    var correspondingQuestion = (from question in bookshelf.Controls.OfType<Panel>() where question.Left == answerOptionsLeft && question.Top == submittedBook.Top && question.HasChildren == true select question);

                    //if theres a question that is being answered
                    if (correspondingQuestion.Count() >= 1)
                    {
                        //the text of the question
                        var questionText = correspondingQuestion.First().Controls.OfType<CustomLabel>().First().Text;

                        //the text of the attempted answer
                        var answerText = submittedBook.Controls.OfType<CustomLabel>().First().Text;

                        //if the game is in call number question mode
                        if (useCallNumbers == true)
                        {
                            //try get the corresponding value of the answer
                            if (callNumbers.TryGetValue(answerText, out result))
                            {

                                //if the corresponding value is a match
                                if (result == questionText)
                                {
                                    //increment the amount of matching answers
                                    matches++;
                                }

                            }
                        }
                         else
                        {
                            //if the game is not in call number question mode

                            //try get the corresponding value of the question
                            if (callNumbers.TryGetValue(questionText, out result))
                            {

                                //if the corresponding value is a match
                                if (result == answerText)
                                {
                                    //increment the amount of matching answers
                                    matches++;
                                }

                            }
                        }
                    }
                }

               

                //if the amount of correct answers is equal to the amount of books (answers to do) shown to the user
                if (matches == bookList.Count)
                {
                    //if the order is correct
                    //call game ending method as a win
                    gameManager.EndGame(true);
                }
                else
                {
                    //if the order is incorrect
                    //inform the user
                    var informUser = MessageBox.Show(invalidSubmissionResponse, "Incorrect Answers");

                    //call method to remove a life
                    gameManager.SubtractLife();
                }

            }
            else
            {
                //if not all books are in a slot

                //start timer to indicate the unfilled slots
                indicateBlanks.Start();

                //inform the user
                var informUser = MessageBox.Show(invalidSubmissionResponse, "Not all books in slots");
            }


        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to format the dewey dictionary with the desired amount of possible answers
        /// </summary>
        private void ModifyDeweyDictionary()
        {

            //random value object
            Random randomPart = new Random();
        
            //randomise the dictionary order
            callNumbers = callNumbers.OrderBy(x => randomPart.Next()).ToDictionary(item => item.Key, item => item.Value); //source - https://csharpindeep.wordpress.com/2013/08/10/c-snippet-shuffling-a-dictionary-beginner/

            //loop to remove the extra entries that wont be used in this series of questions
            for (var i = 0; i < 3; i++)
            {
                //remove the last entry (has been randomised)
                callNumbers.Remove(callNumbers.Last());
            }

        }
        //------------------------------------------------------------------------------------------------------------------




        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to create the book data
        /// </summary>
        private void GenerateBookData()
        {

            //list to hold the book texture selection index
            List<int> textureHolder = new List<int>() { 1, 2, 3, 4 };

            //randomise the book texture selection list
            var shuffled = textureHolder.OrderBy(x => Guid.NewGuid()).ToList(); //source - https://stackoverflow.com/a/4262134


            //the starting left position for the book panel
            var bookTop = bookTopStart;

            //random value object
            Random rand = new Random();

       

            //loop through the index of the amount of books with answers that will be shown to the user
            for (int i = 0; i < 4; i++)
            {

                //create a new book object from the structure
                Book newBook = new Book();

                //if the game is in call number question mode
                if (useCallNumbers == true)
                {
                    //set the book answer to be the dewey value
                    newBook.bookDewy = callNumbers.ElementAt(i).Key.ToString();
                }
                else
                {
                    //if the game is not in call number question mode

                    //set the book answer to be the dewey description
                    newBook.bookDewy = callNumbers.ElementAt(i).Value.ToString();
                }


                //record book position in the shelf
                newBook.bookPosition = new Point(bookUnslottedLeft, bookTop);


                //increase book spacing
                bookTop += 40;

                //assign the book image from the texture list
                newBook.bookImage = newBook.GetHorizontalBookImage(shuffled[i]);

                //add the book data to the book list
                bookList.Add(newBook);
            }

        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to create the slot data
        /// </summary>
        private void GenerateSlotData()
        {

            //the current slot number
            var currentSlot = 0;

            //the starting left position for the slot panel
            var bookTop = slotTopStart;

            //loop through the call numbers to generate a slot for each answer option
            foreach (var i in callNumbers)
            {

                //create a new slot object from the structure
                Slot newSlot = new Slot();

                //set the slots number to an incremented value
                newSlot.slotNumber = ++currentSlot;

                //record slot position in the shelf
                newSlot.slotPosition = new Point(bookSlottedLeft, bookTop);

                //increase slot spacing
                bookTop += 68;

                //add the slot data to the slot list
                slotList.Add(newSlot);
            }

        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to create the slots where the books are placed
        /// </summary>
        private void CreateSlots()
        {

            //loop through all sots in the list of slots
            foreach (Slot i in slotList)
            {

                //create the new panel for the slot
                Panel newSlot = new Panel();

                //set the panel size
                newSlot.Size = panelSize;

                //set the book panels background to be transparent
                newSlot.BackColor = Color.Transparent;

                //set the slot panels name to its slot number in the shelf
                newSlot.Name = i.slotNumber.ToString();

                //assign the slot panel a location on the bottom shelf
                newSlot.Location = i.slotPosition;

                //add the slot to the shelf
                bookshelf.Controls.Add(newSlot);

                //create the option answer
                CreateBookAnswerOption(i.slotPosition);

            }


        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to create the books that will be placed in the slots
        /// </summary>
        private void CreateBooks()
        {

            //loop through all books in the list of books
            foreach (Book i in bookList)
            {
                //create new panel for the book
                Panel newBook = new Panel();

                //set the panel size
                newBook.Size = panelSize;

                //assign mouse clicks to book
                //book placement
                newBook.MouseUp += new MouseEventHandler(bookPanel_MouseUp);
                //book movement
                newBook.MouseDown += new MouseEventHandler(bookPanel_MouseDown);

                //set the book panel to be draggable
                ControlExtension.Draggable(newBook, true);

                //assign the book panel a location on the left most shelf
                newBook.Location = i.bookPosition;

                //assign the book image
                newBook.BackgroundImage = i.bookImage;

                //set the book image sizing behaviour
                newBook.BackgroundImageLayout = ImageLayout.Stretch;

                //set the book panels background to be transparent
                newBook.BackColor = Color.Transparent;

                //add the book to the shelf
                bookshelf.Controls.Add(newBook);



                //generate dewey decimal labels
                //create the label from a custom label class
                CustomLabel dewyLabel = new CustomLabel();

                //set the label font
                dewyLabel.Font = normalDewyLabel;

                //set the label font color
                dewyLabel.ForeColor = Color.White;

                //set the dewey decimal value to the labels text
                dewyLabel.Text = i.bookDewy;

                //set the label to be contained inside the book
                dewyLabel.Parent = newBook;

                //disable the label to prevent the events from being registered when the user attempts to drag the book panel and clicks on the label
                dewyLabel.Enabled = false;

                //call method on custom label to format its position to appeat on the spine of the book
                dewyLabel.FormatLabel(newBook);

                //add the label to the book answer
                newBook.Controls.Add(dewyLabel);

            }

        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method that determines the placement of the book when being moved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bookPanel_MouseUp(object sender, MouseEventArgs e)
        {


            //find all slot panels that are open
            var openSlots = from slot in bookshelf.Controls.OfType<Panel>() where slot.HasChildren == false select slot;

            //loop through all open slots
            foreach (var slot in openSlots)
            {
                //set the open slots color to transparent
                slot.BackColor = Color.Transparent;
            }


            //get the current panel - https://stackoverflow.com/a/2681968
            Control thisPanel = (Control)sender;


            //if the book is enlarged
            if (thisPanel.Size == enlargedBookSize)
            {
                //reset the books size
                thisPanel.Size = panelSize;

                try
                {
                    //reset the label size
                    thisPanel.Controls.OfType<CustomLabel>().First().Font = normalDewyLabel;
                }
                catch (Exception ex)
                {
                    var inform = MessageBox.Show("Book text cannot be scaled down", "Error");
                }

            }


            //if the book enters a slot
            var matches = false;


            //find the open slots that are touching the book being moved
            var slotsToHandle = from slot in bookshelf.Controls.OfType<Panel>() where slot.HasChildren == false && thisPanel.Bounds.IntersectsWith(slot.Bounds) && slot.Visible == true select slot;


            //loop through the open slots that the book is touching
            foreach (var slot in slotsToHandle)
            {
                //set the book location to the location of the slot
                thisPanel.Left = slot.Left;
                thisPanel.Top = slot.Top;

                //make the slot invisible
                slot.Visible = false;

                //set the books current slot to its name property
                thisPanel.Name = slot.Name;

                //the book is in a slot
                matches = true;

                //new sound manager object
                SoundManager soundEffect = new SoundManager();

                //call method to play sound effect
                soundEffect.PlaySound("BookDrop");
            }

            //if the book is not touching a new slot
            if (matches == false)
            {
                    try
                    {
                        //get the dewy decimal text value from the current books child label
                        var dewyLabel = thisPanel.Controls.OfType<CustomLabel>().First().Text;

                        //find the current books data in the list of book data, if the dewy decimal matches a book in the list
                        var matchingBook = from book in bookList where book.bookDewy == dewyLabel select book;

                        //set the current books location to its original point on the left most shelf
                        thisPanel.Location = matchingBook.First().bookPosition;

                    }
                    catch (Exception ex)
                    {
                        var inform = MessageBox.Show("Book could not return to bottom shelf", "Error");
                    }

            }

            //reset the books layer (z index) position to appear "stacked" with the other books
            bookshelf.Controls.SetChildIndex(thisPanel, zIndex);

        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method that record the book position when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bookPanel_MouseDown(object sender, MouseEventArgs e)
        {


            //find all slot panels that are open    
            var openSlots = from slot in bookshelf.Controls.OfType<Panel>() where slot.HasChildren == false select slot; //&& slot.Visible == true

            //loop through all open slots
            foreach (var slot in openSlots)
            {
                //set the open slots color to be a dark overlay
                slot.BackColor = darkOverlay;
            }


            //new sound manager object
            SoundManager soundEffect = new SoundManager();

            //call method to play sound effect
            soundEffect.PlaySound("BookClick");

            //get the current panel - https://stackoverflow.com/a/2681968
            Control thisPanel = (Control)sender;

            //record the books current layer value (z index)
            zIndex = thisPanel.TabIndex;

            //bring the book panel to the front
            thisPanel.BringToFront();


            //if the book is normal sized
            if (thisPanel.Size == panelSize)
            {
                //reset the books size
                thisPanel.Size = enlargedBookSize;

                try
                {

                    //reset the label size
                    thisPanel.Controls.OfType<CustomLabel>().First().Font = enlargedDewyLabel;
                }
                catch (Exception ex)
                {
                    var inform = MessageBox.Show("Book text cannot be scaled up", "Error");
                }
            }

            //record the books current position
            currentBookPosition.X = thisPanel.Left;
            currentBookPosition.Y = thisPanel.Top;
            

            //if book is currently in a slot
            if (currentBookPosition.X != bookUnslottedLeft && currentBookPosition.X != answerOptionsLeft)
            {

                //get the slot that the (this) book is currently in
                var populatedSlots = from slot in bookshelf.Controls.OfType<Panel>() where slot.HasChildren == false && slot.Visible == false && slot.Top == currentBookPosition.Y select slot;

                foreach (var slot in populatedSlots)
                {
                    //make the slot visible (unlocks the slot which allows a new book to be placed into it)
                    slot.Visible = true;
                 
                }

            }

        }

        //------------------------------------------------------------------------------------------------------------------

       
    

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Control the blinking indicators of empty slots when a user attempts to submit without adding all books to the top shelf
        /// </summary>
        /// <param name="indicateBlanks"></param>
        public void BlankSlotTicker(System.Windows.Forms.Timer indicateBlanks)
        {
            //find all slots that do not contain books
            var emptySlots = from panels in bookshelf.Controls.OfType<Panel>() where panels.Visible == true && panels.HasChildren == false select panels;

            //loop through the empty slots
            foreach (var emptySlot in emptySlots)
            {
                //if a slot is being indicaed
                if (emptySlot.BackColor == darkOverlay) //ShelfContent.DarkOverlay
                {
                    //set the slots color to be transparent (not indicated)
                    emptySlot.BackColor = Color.Transparent;
                }
                else
                {
                    //set the slots color to be semi transparent (indicated)
                    emptySlot.BackColor = darkOverlay; //ShelfContent.DarkOverlay


                    //new sound manager object
                    SoundManager soundEffect = new SoundManager();

                    //call method to play sound effect
                    soundEffect.PlaySound("ButtonHover");

                }
            }



            //increment the amount of slot indication runs
            slotBlinkCounter = slotBlinkCounter + 1;

            //if the indication has run fully
            if (slotBlinkCounter == 4) //full indication is 4 runs which will blink empty slots twice
            {
                //reset the indication runs
                slotBlinkCounter = 0;

                //stop the indication timer
                indicateBlanks.Stop();
            }
        }
        //------------------------------------------------------------------------------------------------------------------


    

}
}
