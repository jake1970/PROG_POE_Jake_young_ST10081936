using PROG_POE_Jake_young_ST10081936.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace PROG_POE_Jake_young_ST10081936
{
    internal class ShelfContentFindCallNumbers
    {
        //the game manager object that is controlling the current game
        private GameManager gameManager;


        //the red black tree to hold the data
        private RedBlackTree deweyTree = new RedBlackTree();


        //list of panels that hold the potential answers to the main question
        private List<Panel> potentialAnswers = new List<Panel>();


        //panel to hold the question
        private Panel questionBook = new Panel();


        //panel to hold the slot
        private Panel slotPanel = new Panel();


        //font of dewey decimal label 
        private readonly Font normalDewyLabel = new Font("Microsoft Sans Serif", 8);


        //font of enlarged book text
        private readonly Font enlargedText = new Font("Microsoft Sans Serif", 9);


        //the standard book panel size
        private System.Drawing.Size originalSize = new System.Drawing.Size();


        //the enlarged book panel size
        private System.Drawing.Size enlargedSize = new System.Drawing.Size();


        //the current qestion list level
        private short questionLevel = 0;


        //how many times the empty slot indicator has run
        private short slotBlinkCounter = 0;


        //the selected third level question node
        private RedBlackTree.Node initialQuestionNode = null;


        //the description of the selected third level question node
        private string initialQuestionText = "";


        //semi transparent empty slot indicator color
        private readonly Color darkOverlay = Color.FromArgb(70, Color.Black);


        //the initial starting postition of the panel in a slot
        private System.Drawing.Point currentPanelLocation = new System.Drawing.Point();


        //the initial starting position of a panel that is attempting to be moved
        private System.Drawing.Point attemptedPanelLocation = new System.Drawing.Point();


        //the layer order of the current book being moved
        private int zIndex = 0;





        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gameManager"></param>
        /// <param name="potentialAnswers"></param>
        /// <param name="questionBook"></param>
        /// <param name="slotPanel"></param>
        public ShelfContentFindCallNumbers(GameManager gameManager, List<Panel> potentialAnswers, Panel questionBook, Panel slotPanel)
        {

            this.gameManager = gameManager;
            this.potentialAnswers = potentialAnswers;
            this.questionBook = questionBook;
            this.slotPanel = slotPanel;
           
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to increase book size to appear closer to the user
        /// </summary>
        /// <param name="selectedBook"></param>
        private void EnlargeBook(Panel selectedBook)
        {

            try
            {

                //the increased book panel size
                selectedBook.Size = enlargedSize;

                //the custom label inside the book panel
                var panelLabel = FindPanelLabel(selectedBook as Panel);

                //set the labels font size to be bigger
                panelLabel.Font = enlargedText;

                //reformat the text spacing with the font size
                panelLabel.ManualFormatLabel(selectedBook);

            }
            catch (Exception e)
            {
                var outputError = MessageBox.Show(e.ToString());
            }
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to decrease book size to appear at the same depth
        /// </summary>
        /// <param name="selectedBook"></param>
        private void ShrinkBook(Panel selectedBook)
        {
            try
            {

                //the decreased book panel size
                selectedBook.Size = originalSize;

                //the custom label inside the book panel
                var panelLabel = FindPanelLabel(selectedBook as Panel);

                //set the labels font size to be smaller
                panelLabel.Font = normalDewyLabel;

                //reformat the text spacing with the font size
                panelLabel.ManualFormatLabel(selectedBook);

            }
            catch (Exception e)
            {
                var outputError = MessageBox.Show(e.ToString());
            }
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to load and prime the game to be played
        /// </summary>
        public void InitialSetup()
        {
            //call method to populate the redblack tree instance with the dewey decimal data data
            //method reads the file data into the tree
            PopulateTree();

            try
            {
                //define standard book panel size
                originalSize = questionBook.Size;

                //define enlarged book panel size
                enlargedSize = new System.Drawing.Size(originalSize.Width + 10, originalSize.Height + 10);


                //loop through list of panels where potential answers are displayed
                foreach (Panel answerPossibility in potentialAnswers)
                {
                    //set the mouse click events for the panels
                    answerPossibility.MouseDown += new MouseEventHandler(AnswerPanel_MouseDown);
                    answerPossibility.MouseUp += new MouseEventHandler(AnswerPanel_MouseUp);

                    //set the book panel to be draggable
                    ControlExtension.Draggable(answerPossibility, true);

                    //bring the book panel to the front
                    answerPossibility.BringToFront();
                }

            }
            catch (Exception e)
            {
                var outputError = MessageBox.Show(e.ToString());
            }

            //call method to load the books and shelf content with the populated tree data
            InstantiateGameContent();
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to get the panel currently placed in the answer slot
        /// </summary>
        /// <returns></returns>
        private Panel FindDroppedPanel()
        {
            //the panel to be returned
            Panel passBack = null;

            try
            {

                //loop through list of panels where potential answers are displayed
                foreach (Panel question in potentialAnswers)
                {
                    //if the answer panel has the same position/location as the slot panel
                    if (question.Location == slotPanel.Location)
                    {
                        //set the panel to be returned
                        passBack = question;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                var outputError = MessageBox.Show(e.ToString());
            }

            return passBack;
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to get the custom label inside of the "book" panels
        /// </summary>
        /// <param name="inputPanel"></param>
        /// <returns></returns>
        private CustomLabel FindPanelLabel(Panel inputPanel)
        {
       
            //the custom label to be returned
            CustomLabel panelChild = null;

            try
            {

                //if the given panel has sub controls "children"
                if (inputPanel.HasChildren == true)
                {
                    //set the custom label to be returned from the first custom label in the given panel
                    panelChild = inputPanel.Controls.OfType<CustomLabel>().First();
                }

            }
            catch (Exception e)
            {
                var outputError = MessageBox.Show(e.ToString());
            }

            return panelChild;
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to check if the given answer is correct
        /// </summary>
        /// <param name="indicateBlanks"></param>
        public void EvaluateAnswer(Timer indicateBlanks)
        {
            try
            {

                //get the panel in the slot
                var thisPanel = FindDroppedPanel();

                //if there is a panel in the slot
                if (thisPanel != null)
                {


                    //check if the correct answer is given
                    if (thisPanel.Name == "match")
                    {
                        //if the correct answer is given

                        //reset the panels name
                        thisPanel.Name = "";

                        //check if most details level is reached
                        if (questionLevel == 2)
                        {
                            //if most detailed level is reached

                            //call method to end the game as a win
                            gameManager.EndGame(true);

                        }
                        else
                        {
                            //if most detailed level has not yet been reached
                            //go a level deeper

                            //new sound manager object
                            SoundManager soundEffect = new SoundManager();

                            //call method to play sound effect
                            soundEffect.PlaySound("ButtonClick");

                            //inform the user of the correct choice
                            var result = MessageBox.Show("Correct");

                            //increment the question level to go a level deeper
                            questionLevel++;

                            //remove the current question
                            questionBook.Controls.Clear();

                            //call method to reload the game shelf content
                            InstantiateGameContent();
                        }


                    }
                    else
                    {

                        //if the incorrect answer is given
                        //move onto the next question

                        //inform the user of the incorrect choice
                        var result = MessageBox.Show("The selected answer is not a member of the current question", "Incorrect Answer");

                        //call method to remove a user "life"
                        gameManager.SubtractLife();

                        //call method to delete the selected third level question node from the tree
                        deweyTree.DeleteGivenNode(initialQuestionNode);

                        //remove the current question
                        questionBook.Controls.Clear();

                        //reset the selected third level question node variable
                        initialQuestionNode = null;

                        //reset the selected question text variable
                        initialQuestionText = "";

                        //reset the question level
                        questionLevel = 0;

                        //call method to reload the game shelf content
                        InstantiateGameContent();
                    }

                    //call method to reset the selected answer back to the list of possible answers
                    ResetPanel();
                }
                else
                {
                    //if the slot is empty

                    //start timer to indicate the unfilled slots
                    indicateBlanks.Start();

                    //inform the user
                    var informUser = MessageBox.Show("Select an answer", "Not all books in slots");
                }
            }
            catch (Exception e)
            {
                var outputError = MessageBox.Show(e.ToString());
            }


        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// When the mouse click is released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnswerPanel_MouseUp(object sender, MouseEventArgs e)
        {

            try
            {

                //set the slot to be transparent "hidden"
                slotPanel.BackColor = Color.Transparent;

                //get the current panel - https://stackoverflow.com/a/2681968
                Control thisPanel = (Control)sender;


                //if the slot is empty
                if (FindDroppedPanel() == null)
                {
               

                    //if the current panel is touching the empty slot
                    if (thisPanel.Bounds.IntersectsWith(slotPanel.Bounds))
                    {
                        //place the current panel in the slot

                        //set the current panels location to the slots location
                        thisPanel.Location = slotPanel.Location;

                    }
                    else
                    {
                        //if the current panel is not touching the empty slot

                        //reset the current panels position
                        thisPanel.Location = currentPanelLocation;

                    }
                }
                else
                {
                    //if the slot is not empty
                    
                    //check if an attempt has been made to put a book into the filled slot
                    if (attemptedPanelLocation.X == 0 && attemptedPanelLocation.Y == 0)
                    {
                        //if an attempt was not made
                        //the book in the slot was clicked and dropped in the same spot inside the slot

                        //put the book back into the slot
                        thisPanel.Location = slotPanel.Location;
                       
                    }
                    else
                    {
                        //if an attempt was made to put the book into the already filled slot

                        //reset attempted book position
                        thisPanel.Location = attemptedPanelLocation;

                        //reset recorded attempted book position value
                        attemptedPanelLocation = new System.Drawing.Point(0, 0);
                     
                    }
                }


                //reset the books layer (z index) position to appear "stacked" with the other books
                thisPanel.Parent.Controls.SetChildIndex(thisPanel, zIndex);

                //call method to reset the book size
                ShrinkBook(thisPanel as Panel);

            }
            catch (Exception ex)
            {
                var outputError = MessageBox.Show(ex.ToString());
            }

        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// When the mouse click is performed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnswerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {

                //get the current panel - https://stackoverflow.com/a/2681968
                Control thisPanel = (Control)sender;


                //set the slot to be highlighted "shown"
                slotPanel.BackColor = darkOverlay;


                //check if the panel is in the starting position
                //starting left (X) position is 420
                if (thisPanel.Left == 420)
                {

                    //if the slot is empty
                    if (FindDroppedPanel() == null)
                    {
                        //set the current panels recorded location variable to the panels current location
                        currentPanelLocation = thisPanel.Location;
                    }
                    else
                    {
                        //set the attempted panels recorded location variable to the panels current location
                        attemptedPanelLocation = thisPanel.Location;
                    }


                }


                //record the books current layer value (z index)
                zIndex = thisPanel.Parent.Controls.GetChildIndex(thisPanel);

                //bring the book panel to the front
                thisPanel.BringToFront();

                //call method to increase the book size
                EnlargeBook(thisPanel as Panel);

            }
            catch (Exception ex)
            {
                var outputError = MessageBox.Show(ex.ToString());
            }

        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to reset the position of the panel in the slot back to the initial stack on the right shelf
        /// </summary>
        public void ResetPanel()
        {
            try
            {

                //get the current panel in the slot
                var currentPanel = FindDroppedPanel();

                //if there is a panel in the slot
                if (currentPanel != null)
                {
                    //set the current panel in the slots location to the recorded initial location
                    currentPanel.Location = currentPanelLocation;
                }
            }
            catch (Exception e)
            {
                var outputError = MessageBox.Show(e.ToString());
            }

        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to load the shelf content and populate the "book" panels with the loaded tree data
        /// </summary>
        private void InstantiateGameContent()
        {
            try
            {
                //collection of third level questions randomly ordered
                var thirdLevelQuestions = deweyTree.FindMatchingNodesLevel(3).OrderBy(x => Guid.NewGuid()).Distinct().ToList();

                //if the question node has not yet been set
                if (initialQuestionNode == null)
                {
                    //set the question node to the first node in the random list of third level question nodes
                    initialQuestionNode = thirdLevelQuestions.First();

                    //set the question text to the description of the selected question node
                    initialQuestionText = initialQuestionNode.entryData.deweyDescription;
                }


                //collection of the path of the selected third level question
                //holds the matching first and second level nodes to the selected question third level node
                var questionPath = deweyTree.FindDeweyPath(initialQuestionNode);


                //add the question to the UI
                //call method to add the selected question to the question "book" panel
                AddCustomLabelToPanel(initialQuestionText, questionBook);

                //call method to get the custom label in the question book and call method to format the appearance of the text
                FindPanelLabel(questionBook).ManualFormatLabel(questionBook);


                //list of random first level questions, excluding the selected questions first level question
                var questionList = deweyTree.FindMatchingNodesLevel(questionLevel + 1).OrderBy(x => Guid.NewGuid()).Where(x => x.data != questionPath[questionLevel].data).Distinct().Take(potentialAnswers.Count() - 1).ToList();

                //if the question level is on the second level
                if (questionLevel == 1)
                {
                    //list of random second level questions, excluding the selected questions second level question
                    questionList = deweyTree.FindMatchingNodesLevel(questionLevel + 1).OrderBy(x => Guid.NewGuid()).Where(x => x.data != questionPath[questionLevel].data && x.entryData.deweyCallNumber[0].ToString() == initialQuestionNode.entryData.deweyCallNumber[0].ToString()).Distinct().Take(potentialAnswers.Count() - 1).ToList();
                    //questionList = deweyTree.FindMatchingNodesLevel(questionLevel + 1).OrderBy(x => Guid.NewGuid()).Where(x => x.data != questionPath[questionLevel].data && x.data.ToString()[0].ToString() == initialQuestionNode.data.ToString()[0].ToString()).Distinct().Take(potentialAnswers.Count() - 1).ToList();
                }

                //if the question level is on the third level
                if (questionLevel == 2)
                {
                    //list of random second level questions, excluding the selected questions second level question
                    questionList = deweyTree.FindMatchingNodesLevel(questionLevel + 1).OrderBy(x => Guid.NewGuid()).Where(x => x.data != questionPath[questionLevel].data && x.entryData.deweyCallNumber[0].ToString() == initialQuestionNode.entryData.deweyCallNumber[0].ToString() && x.entryData.deweyCallNumber[1].ToString() == initialQuestionNode.entryData.deweyCallNumber[1].ToString()).Distinct().Take(potentialAnswers.Count() - 1).ToList();
                    //questionList = deweyTree.FindMatchingNodesLevel(questionLevel + 1).OrderBy(x => Guid.NewGuid()).Where(x => x.data != questionPath[questionLevel].data && x.data.ToString()[0].ToString() == initialQuestionNode.data.ToString()[0].ToString() && x.data.ToString()[1].ToString() == initialQuestionNode.data.ToString()[1].ToString()).Distinct().Take(potentialAnswers.Count() - 1).ToList();
                }



                //add the selected question to the list of questions
                questionList.Add(questionPath[questionLevel]);

                //the sorted list of questions including the selected question
                var selectedQuestions = questionList.OrderBy(x => x.data).Reverse().ToList();


                //list to hold the book texture selection index
                List<int> textureHolder = new List<int>() { 1, 2, 3, 4 };

                //randomise the book texture selection list
                var shuffled = textureHolder.OrderBy(x => Guid.NewGuid()).ToList(); //source - https://stackoverflow.com/a/4262134


                //loop through answer panels
                foreach (Panel answerPossibility in potentialAnswers)
                {
                    //remove the current question text
                    answerPossibility.Controls.Clear();

                    //the answer lables formatted text, with the callnumber and description
                    var answerText = selectedQuestions.First().entryData.deweyCallNumber + " " + selectedQuestions.First().entryData.deweyDescription;

                    //if the current question is the correct matching answer
                    if (selectedQuestions.First() == questionPath[questionLevel])
                    {
                        //set the name of the matching panel to indicate its the correct answer
                        answerPossibility.Name = "match";
                    }


                    //add the potential answer label to the panel
                    AddCustomLabelToPanel(answerText, answerPossibility);


                    //call method to get the custom label in the potential answer book and call method to format the appearance of the text
                    FindPanelLabel(answerPossibility).ManualFormatLabel(answerPossibility);


                    //remove the added question from the list
                    selectedQuestions.Remove(selectedQuestions.First());

                    //book structure instance
                    Book utilBook = new Book();

                    //set the books "color"
                    //call method to get the book texture
                    answerPossibility.BackgroundImage = utilBook.GetHorizontalBookImage(shuffled.First());

                    //remove the selected texture index
                    shuffled.Remove(shuffled.First());

                }
            }
            catch (Exception e)
            {
                var outputError = MessageBox.Show(e.ToString());
            }

        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to add a custom label to a panel
        /// </summary>
        /// <param name="labelText"></param>
        /// <param name="labelContainer"></param>
        private void AddCustomLabelToPanel(String labelText, Panel labelContainer)
        {
            try
            {

                //create a label from the custom label class
                CustomLabel dewyLabel = new CustomLabel();

                //set the label font
                dewyLabel.Font = normalDewyLabel;

                //set the label font color
                dewyLabel.ForeColor = Color.White;

                //set the custom labels text
                dewyLabel.Text = labelText;

                //set the label to be contained inside the book
                dewyLabel.Parent = labelContainer;

                //disable the label to prevent the events from being registered when the user attempts to interact with the label
                dewyLabel.Enabled = false;

                //call method on custom label to format its position to appeat on the spine of the book
                dewyLabel.ManualFormatLabel(labelContainer);

                //add the label to the book
                labelContainer.Controls.Add(dewyLabel);
            }
            catch (Exception e)
            {
                var outputError = MessageBox.Show(e.ToString());
            }
        }
        //------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Control the blinking indicator of an empty slot when a user attempts to submit without adding an answer book to the slot
        /// </summary>
        /// <param name="indicateBlanks"></param>
        public void BlankSlotTicker(Timer indicateBlanks)
        {

            try
            {

                //if a slot is being indicaed
                if (slotPanel.BackColor == darkOverlay) //ShelfContent.DarkOverlay
                {
                    //set the slots color to be transparent (not indicated)
                    slotPanel.BackColor = Color.Transparent;
                }
                else
                {
                    //set the slots color to be semi transparent (indicated)
                    slotPanel.BackColor = darkOverlay; //ShelfContent.DarkOverlay


                    //new sound manager object
                    SoundManager soundEffect = new SoundManager();

                    //call method to play sound effect
                    soundEffect.PlaySound("ButtonHover");

                }

            }
            catch (Exception e)
            {
                var outputError = MessageBox.Show(e.ToString());
            }


            //increment the amount of slot indication runs
            slotBlinkCounter++;

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



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to read data from a file and populate the red black tree
        /// </summary>
        private void PopulateTree()
        {
            try
            {
                //get the file of dewey decimal data
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PROG_POE_Jake_young_ST10081936.Resources.DeweyFile.txt"))
                {
                    //open th file
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        //the current line in the file
                        String line;

                        //loop through the lines in the file until completion
                        while ((line = reader.ReadLine()) != null)
                        {
                            //split the read line into 3 types by # symbol
                            var splitLine = line.Split('#');

                            //structure to hold dewey decimal list data
                            DeweyData readEntry = new DeweyData();

                            //set the structures call number value as a string to ensure that its format is preserved
                            //example is if call number is 001, as a string the prefixing 0's are preserved whereas an int the call number removes the 0's and would just be 1
                            readEntry.deweyCallNumber = splitLine[0];

                            //set the structures descripion to the datas description
                            readEntry.deweyDescription = splitLine[1];

                            //set the structure list level to the datas list level
                            readEntry.listLevel = int.Parse(splitLine[2]);

                            //add the read data to a new node in the tree
                            //set the key to the call number
                            deweyTree.Insert(int.Parse(splitLine[0]), readEntry);

                        }

                        //close file
                        reader.Close();
                    }
                  
                }

            }
            catch (Exception e)
            {
                var outputError = MessageBox.Show(e.ToString());
            }
           
        }

    }
    //------------------------------------------------------------------------------------------------------------------

}