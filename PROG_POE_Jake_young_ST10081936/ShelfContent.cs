using DeweyDecimalLibrary;
using PROG_POE_Jake_young_ST10081936.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG_POE_Jake_young_ST10081936
{

    //******************************************************************************************************************
    //book data structure
    struct Book
    {
        //dewey decimal value
        public string bookDewy;

        //location of book in the shelf
        public Point bookPosition;

        //book image (color)
        public Image bookImage;


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to assign a book image (color) randomly
        /// </summary>
        /// <param name="randomTexture"></param>
        /// <returns></returns>
        public Image GetBookImage(int randomTexture) //input: random number between 1 and 4
        {
            //new image set to default, if random number = 4 then use default image
            Image bookImage = Resources.red_book;
            

            switch (randomTexture)
            {
                case 1:
                    //if random number is 1
                    bookImage = Resources.purple_book;
                    break;

                case 2:
                    //if random number is 2
                    bookImage = Resources.blue_book;
                    break;

                case 3:
                    //if random number is 3
                    bookImage = Resources.green_book;
                    break;
            }

            return bookImage;
        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to assign a horizontal book image (color) randomly
        /// </summary>
        /// <param name="randomTexture"></param>
        /// <returns></returns>
        public Image GetHorizontalBookImage(int randomTexture) //input: random number between 1 and 4
        {
            //new image set to default, if random number = 4 then use default image
            Image bookImage = Resources.red_book_side;


            switch (randomTexture)
            {
                case 1:
                    //if random number is 1
                    bookImage = Resources.purple_book_side;
                    break;

                case 2:
                    //if random number is 2
                    bookImage = Resources.dark_blue_book_side;
                    break;

                case 3:
                    //if random number is 3
                    bookImage = Resources.blue_book_side;
                    break;
            }

            return bookImage;
        }
        //------------------------------------------------------------------------------------------------------------------


    }

    //******************************************************************************************************************


    //******************************************************************************************************************
    //slot data structure
    struct Slot
    {
        //the number of the slot (slot 1, slot 2, ...)
        public int slotNumber;

        //location of slot in the shelf
        public Point slotPosition;
    }
    //******************************************************************************************************************


    class ShelfContent
    {
         
        //string list to hold the call numbers of the dewey decimals
        private List<String> callNumbers = new List<String>();

        //list to hold the book data
        private List<Book> bookList = new List<Book>();

        //list to hold the slot data
        private List<Slot> slotList = new List<Slot>();
         
        //location of current book
        private Point currentBookPosition = new Point();
        
        //the size of dynamically generated panels
        private readonly Size panelSize = new Size(56, 180);

        //size of book panels when being moved
        private readonly Size enlargedBookSize = new Size(66, 190);

        //font of dewey decimal label 
        private readonly Font normalDewyLabel = new Font("Microsoft Sans Serif", 8);

        //font of dewey decimal label when the book panel is being moved
        private readonly Font enlargedDewyLabel = new Font("Microsoft Sans Serif", 9);

        //top (Y) position of the book slots
        private const int bookSlottedTop = 43;

        //top (Y) position of the books
        private const int bookUnslottedTop = 268;

        //the Y position of the bookshelf divider that seperates the top and bottom shelves
        private const int shelfDividerTop = 230;

        //the starting position (Left/X) of the first book and slot
        private const int panelLeftStart = 54;

        //response to display when an invalid submission of book order is made
        private const string invalidSubmissionResponse = "Please order from smallest to biggest (left to right)";
        
        //how many times the empty slot indicator has run
        private int slotBlinkCounter = 0;

        //semi transparent empty slot indicator color
        private readonly Color darkOverlay = Color.FromArgb(70, Color.Black);

        //the control where the dynamic panels (books and slots) are generated
        private Control bookshelf = new Control();

        //the game manager object that is controlling the current game
        private GameManager gameManager;


        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="bookshelf"></param>
        /// <param name="gameManager"></param>
        public ShelfContent(Control bookshelf, GameManager gameManager)
        {
            this.bookshelf = bookshelf;
            this.gameManager = gameManager;
        }

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to populate the shelf
        /// </summary>
        public void PopulateShelf()
        {
            //method to populate a list of unique dewey decimals
            PopulateDeweyDecimalList();

            //method to populate a list of the book data
            GenerateBookData();

            //method to populate a list of the slot data
            GenerateSlotData();

            //method to create the dynamic book panels using the list of book data
            CreateSlots();

            //method to create the dynamic slot panels using the list of slot data
            CreateBooks();
        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to reset all book positions
        /// </summary>
        public void ResetBooks()
        {

            //get all books that are currently on the top shelf
            var books = from panels in bookshelf.Controls.OfType<Panel>() where panels.Top == bookSlottedTop && panels.HasChildren == true select panels;

            
            //loop through top shelf books
            foreach (Control book in books)
            {
                //get the books corresponding original location from the book list
                var booksExpanded = from avaliableBooks in bookList where book.Controls.OfType<Label>().First().Text == avaliableBooks.bookDewy select avaliableBooks;

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

            //find all books that are on the bottom shelf (not in a slot)
            var unslottedBooks = from books in bookshelf.Controls.OfType<Panel>() where books.Top != bookSlottedTop select books;

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
        /// Method sort dewey decimal list in ascending order using bubble sorting algorithm
        /// </summary>
        /// <param name="deweyList"></param>
        /// <returns></returns>
        //source - https://www.tutorialspoint.com/Bubble-Sort-program-in-Chash
        public List<String> SortDeweyList(List<String> deweyList)
        {
            //array from the randomly generated dewey decimal list
            string[] dewyArray = deweyList.ToArray();

            //temp string to hold the dewey decimal being moved
            string tempDewey;

            //outer loop
            for (int j = 0; j <= dewyArray.Count()-2; j++)
            {
                //inner loop
                for (int i = 0; i <= dewyArray.Count()-2; i++)
                {
                    //compare current dewey decimal to the next in the array
                    if (dewyArray[i].CompareTo(dewyArray[i + 1]) > 0)
                    {
                        //set next dewey decimal to temp
                        tempDewey = dewyArray[i + 1];

                        //swap next dewey decimal and current dewey decimal values
                        dewyArray[i + 1] = dewyArray[i];

                        //set current dewey decimal to temp (next dewey decimal)
                        dewyArray[i] = tempDewey;
                    }
                }
            }

            //return array as a list
            return dewyArray.ToList();
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to evaluate the users order of books
        /// </summary>
        /// <param name="indicateBlanks"></param>
        public void EvaluatePlacement(Timer indicateBlanks)
        {

            //new sound manager object
            SoundManager soundEffect = new SoundManager();

            //call method to play sound effect
            soundEffect.PlaySound("BookClick");

            //check if all books are on the top shelf and in a slot
            if (AllBooksSubmitted() == true)
            {
                
                //get all book panels in ascending order
                var bookPanels = (from book in bookshelf.Controls.OfType<Panel>() where book.HasChildren == true select book).OrderBy(book => int.Parse(book.Name));

                //get the text value (dewey decimals) of the labels of the books 
                var dewyLabels = (from dewyLabel in bookPanels select dewyLabel.Controls.OfType<Label>().First().Text);

                //string list of dewey decimals in the order the user placed them
                List<string> userOrder = new List<string>(dewyLabels);


                
                //sort the initial list of dewey decimals to find the correct order
                callNumbers.Sort();

                //compare the users dewey decimal order to the actual order
                bool comparison = callNumbers.SequenceEqual(userOrder);


                //check if the users order matches the actual order
                if (comparison == true)
                {
                    //if the order is correct
                    //call game ending method as a win
                    gameManager.EndGame(true);
                }
                else
                {
                    //if the order is incorrect
                    //inform the user
                    var informUser = MessageBox.Show(invalidSubmissionResponse, "Incorrect Order");

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
        /// Method to populate the list of dewey decimals
        /// </summary>
        private void PopulateDeweyDecimalList()
        {

            //how many dewey decimals have been already generated
            int deweyCounter = 0;

            //the dewey decimal value
            string newDewyDecimal = "";

            //new dewey decimal manager object
            DeweyDecimalManager deweyDecimalHandler = new DeweyDecimalManager();

            try
            {
                //loop to generate 10 valid and unqiue dewey decimal values
                while (deweyCounter < 10)
                {

                    //generate new dewey decimal
                    newDewyDecimal = deweyDecimalHandler.GenerateDeweyDecimal(3); //input the authro length = 3


                    //check that the dewey decimal value is unqiue
                    if (!callNumbers.Contains(newDewyDecimal))
                    {
                        //if the value is unique
                        //add the dewey decimal to the call numbers list
                        callNumbers.Add(newDewyDecimal);

                        //increment the counter for dewey decimals
                        deweyCounter++;
                    }
                }
            }
            catch (Exception ex)
            {
                var inform = MessageBox.Show("Dewey decimals could not be generated", "Error");
            }

        }
        //------------------------------------------------------------------------------------------------------------------
        


        
        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to create the book data
        /// </summary>
        private void GenerateBookData()
        {

            //the starting left position for the book panel
            int bookLeft = panelLeftStart;

            //random value object
            Random rand = new Random();

            //loop through the call numbers to generate a book for each slot
            foreach (string i in callNumbers)
            {

                //create a new book object from the structure
                Book newBook = new Book();

                //assign the books dewey decimal data
                newBook.bookDewy = i;

                //record book position in the shelf
                newBook.bookPosition = new Point(bookLeft, bookUnslottedTop);

                ///increase book spacing
                bookLeft += 60;

                //generate random number to select a random book color
                int randBook = rand.Next(1, 5);

                //assign the book image from the random value
                newBook.bookImage = newBook.GetBookImage(randBook);

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
            int currentSlot = 0;

            //the starting left position for the slot panel
            int slotLeft = panelLeftStart;

            //loop through the call numbers to generate a slot for each book
            foreach (string i in callNumbers)
            {

                //create a new slot object from the structure
                Slot newSlot = new Slot();

                //set the slots number to an incremented value
                newSlot.slotNumber = ++currentSlot;


                //record slot position in the shelf
                newSlot.slotPosition = new Point(slotLeft, bookSlottedTop);

                //increase slot spacing
                slotLeft += 60;

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


                //assign the book panel a location on the bottom shelf
                newBook.Location = i.bookPosition;


                //assign the book image
                newBook.BackgroundImage = i.bookImage;

                //set the book image sizing behaviour
                newBook.BackgroundImageLayout = ImageLayout.Stretch;

                //set the book panels background to be transparent
                newBook.BackColor = Color.Transparent;

                //add the book to the shelf
                bookshelf.Controls.Add(newBook);

                //bring the book to the front of the shelf
                newBook.BringToFront();



                //generate dewey decimal labeles
                //create the label
                Label dewyLabel = new Label();

                //set the label font
                dewyLabel.Font = normalDewyLabel;

                //set the label font color
                dewyLabel.ForeColor = Color.White;

                //set the dewey decimal value to the labels text
                dewyLabel.Text = i.bookDewy;

                //set the label to be contained inside the book
                dewyLabel.Parent = newBook;

                //align the label text to be centered
                dewyLabel.TextAlign = ContentAlignment.MiddleCenter;

                //set the labels text sizing
                dewyLabel.AutoSize = false;
                dewyLabel.Height = 32;
                dewyLabel.Width = 49;

                //set the labels positioning in the book
                dewyLabel.Top = 140;
                dewyLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

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
                    thisPanel.Controls.OfType<Label>().First().Font = normalDewyLabel;
                }
                catch (Exception ex) 
                {
                    var inform = MessageBox.Show("Book text cannot be scaled down", "Error");
                }

            }


            //if the book enters a slot
            bool matches = false;


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
                //if the book is on the top shelf
                if (thisPanel.Top <= shelfDividerTop)
                {

                    //set the books location back to its initial slot on the top shelf
                    thisPanel.Top = currentBookPosition.Y;
                    thisPanel.Left = currentBookPosition.X;

                }
                else
                {
                    //if the book is moved onto the bottom shelf

                    try
                    {
                        //get the dewy decimal text value from the current books child label
                        var dewyLabel = thisPanel.Controls.OfType<Label>().First().Text;

                        //find the current books data in the list of book data, if the dewy decimal matches a book in the list
                        var matchingBook = from book in bookList where book.bookDewy == dewyLabel select book;

                        //set the current books location to its original point on the bottom shelf
                        thisPanel.Location = matchingBook.First().bookPosition;
                    }
                    catch (Exception ex)
                    {
                        var inform = MessageBox.Show("Book could not return to bottom shelf", "Error");
                    }

                }
            }


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
            var openSlots = from slot in bookshelf.Controls.OfType<Panel>() where slot.HasChildren == false select slot;

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


            //if the book is normal sized
            if (thisPanel.Size == panelSize)
            {
                //reset the books size
                thisPanel.Size = enlargedBookSize;

                try
                {

                    //reset the label size
                    thisPanel.Controls.OfType<Label>().First().Font = enlargedDewyLabel;
                }
                catch(Exception ex)
                {
                    var inform = MessageBox.Show("Book text cannot be scaled up", "Error");
                }

                //bring the enlarged book to the front
                thisPanel.BringToFront();
            }

            //record the books current position
            currentBookPosition.X = thisPanel.Left;
            currentBookPosition.Y = thisPanel.Top;

            //if book is currently in a slot
            if (currentBookPosition.Y != bookUnslottedTop)
            {
                //get all slots that currently have books in them
                var populatedSlots = from slot in bookshelf.Controls.OfType<Panel>() where slot.HasChildren == false && slot.Left == currentBookPosition.X && slot.Visible == false select slot;

                //loop through the slots that contain books
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
        public void BlankSlotTicker(Timer indicateBlanks)
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
