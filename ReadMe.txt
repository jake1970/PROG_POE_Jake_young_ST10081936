------------------------------------------------------------------------------------------------------------
Jake Young
ST10081936
------------------------------------------------------------------------------------------------------------

Dewy Trainer
------------------------------------------------------------------------------------------------------------

Welcome to Dewy Trainer.

Dewy Trainer is an interactive library training system designed to teach the user about the Dewey decimal system.

The software is comprised of a c# windows forms application that makes use of lists (the first game "Replacing Books") and dictionaries (the second game "Identify Areas") to store the data.

The software contains various games to take the user through the dewey decimal system to give them a well rounded learning and training expierience.


How to use
------------------------------------------------------------------------------------------------------------
There are 2 ways to run the software:
	
	1. Open the project file (the .sln file) in visual studio, afterwhich the app will run and load the welcome screen
	2. Open the project folder ("PROG_POE_Jake_young_ST10081936"), open the "bin" folder followed by the debug folder. To run the application, open the executable (.exe) file, afterwhich the app will run and load the welcome screen. NB: the app requires dependancies and therefore must be run inside the debug folder when using this method, alternatively the debug folder can be copied to another location to run however the executable and dependancies must remain in the same root folder.
	
To use the software:
	The software when opened will show the "welcome screen", this is the main navigation and allows for the selection of a training game.
	The game options include:
		1. Replacing Books
		2. Identify Areas
		3. Find Call Numbers


	Replacing Books:
	Select the "Replacing Books" book option on the bottom of the shelf on the welcome screen, this will start the game.
	The game will open to a shelf view with a row of books on the bottom with randomly generated dewey decimal values
	and an empty top shelf, it is the job of the user to sort the books in ascending order (left to right, smallest to 
	biggest). At the start of the game the users time will be recorded to track their speed of sorting, a user will have
	3 attempts at submitting a correct order of books before the game counts as a loss. To sort books a user will click
	and drag a book from the bottom shelf to the top shelf. Upon dragging, the top shelf will display indicators
	(darkened overlays) of empty slots where a book can be placed. The game contains 2 function buttons in the top right
	of the screen, the reset button (the arrow circling itself), and the submit button (the tick). Once a user has put
	all books into a slot on the top shelf, they may click the submit button. If there are still books that have not been
	put into a slot, the empty slots will blink to indicate where the remaining books need to be placed. If all books
	are in slots, the users order will be evaluated. Upon evaluation, if the user has submitted the correct order their
	score will be evaluated (combined calculation of time taken and lives remaining) and the game will display the results
	screen with the winning data, including score, time taken and the win status. If the submitted order is incorrect,
	the user will be notified and a "life will be lost". At the top of the screen, located in a brown book ontop of the
	shelf, the users remaining lives are displayed (indicated by hearts). Each time an incorrect order is submitted 
	an animation will play and the heart will break, indicating the loss of a life. The game is timed and has a limit
	of 3 minutes, after which the game will be ended and count as a loss. Upon the end of a round the user may click
	the "Play Again" option located on the bottom shelf of the results screen, this will start the round over and allow
	the user to replay the selected game. The results screen shows a close button in the top left indicated by
	an "X", upon clicking, the game will close along with the form.

	
	Identify Areas:
	Select the "Identify Areas" book option on the bottom of the shelf on the welcome screen, this will start the game.
	The game will open to a shelf view containing the book options, stacked, on the bottom left. By defualt the stack of
	books will contain a call number that matches a description that is shown on the right most shelf of the screen.
	The right most shelf, by default, shows the possible descriptions that could match one of the book answers. The user
	will click and drag the book answer into the middle shelf, and drop it next to the corresponding answer. Upon dragging
	a book, the options of where it may be placed will be "highlighted" by showing a darkened overlay. The user must match
	answer (whether its call numbers to descriptions or vice versa) to a corresponding question. The game functions on the
	"match column" premise and a user must associate each answer with a question. Located in the top left is a menu swap
	button, indicated by a menu icon, upon clicking, the game will restart in the reverse order, the stack of books in the
	left will display the descriptions and the list of possible call numbers will be shown in the shelf on the right. The
	game shows the stack of 4 books with 7 possible answers. Located above the book stack, on the shelf above, the round time
	is displayed, the user has 3 minutes to complete their answers before the round is ended and counted as a loss. The user
	has 3 chances at making a submission, each time the answers are submitted incorrectly, the user will lose a "life" or
	chance. The current status of the users "lives" are shown on the spine of a book below the round time. If the user loses
	all "lives" the round will end and count as a loss. Located in the top right, are the reset and submit buttons, the reset
	button is indicated by a arrow circling itself and the submit button is indicated as a tick. The reset button will move
	all placed book answers back to the initial stack on the left in their initial order. Upon clicking the submit button the
	game will validate that all answers (answer books) are placed in the middle shelf and are associated with a question, if 
	not all books (answers) are submitted, the remaining possible slots to place said books will "blink" and be indicated
	by flashing overlays. If all books are submitted, the answers submitted will be validated against the questions, if
	the submission of answers are not all correct, the user will be informed by a popup and a life will be subtracted and
	an animation of a heart breaking will be showed in the top left. If the order is correct the round will end and be counted
	as a win. If the incorrect answers are submitted 3 times, if the round timer hits 3 minutes, or the correct answers are
	submitted, the round will end and a feedback screen will be shown. The feedback screen will show the result of the game,
	whether its a win or loss, the round score, and the time taken. The score is comprised of the amount of lives remaining,
	multiplied by the game time in seconds minus the time taken in seconds. The results screen also shows the game time taken.
	Located towards the bottom of the results screen the "Play Again" option is shown, when the user clicks this, the round 
	is started over in the reverse configuration, if the previous game was matching the call numbers to the descriptions,
	the new round will be the opposite and vice versa. The results screen shows a close button in the top left indicated by
	an "X", upon clicking, the game will close along with the form.

	
	Find Call Numbers:
	Select the "Find Call Numbers" book option on the bottom of the shelf on the welcome screen, this will start the game.
	The game will open to a shelf view, the left shelf contains a top and bottom section, with the top section containing a
	book with a third level call numbers description (the call number and question level are not shown there). The bottom
	appears empty until a book is clicked, upon which the bottom section will appear highlighted to indicate where to place
	the chosen answer. The right shelf contains a stacked list of 4 books, these books display the possible answers to the
	given question, the user must click and drag the associated answer into the bottom left shelf. When the game starts, 
	the initial potential answers will consist of first level list entries, each time a correct answer is given, the
	potential answers will change to consist of the next level of list entires, until the most detailed list level is reached.
	When an incorrect answer is selected, the initial third level question will be regenerated and a new question will be asked.
	The potential answers contain the list levels dewey decimal call number (excluding the decimal points) and the associated
	description. The list of potential answers consists of the correct answer and 3 incorrect answers. Located on the top of the
	shelf, there is a game timer. The player has 3 minutes to complete a question before the game is ended. If the user completes
	the game within the 3 minutes, the game will end as a win and the user will be shown the feedback screen. Located to the right
	of the timer is a book containing 3 hearts. These hearts represent the chances that a user has at making a correct submission.
	If an incorrect submission is given a player "life" or chance will be lost and a sound will be played, following this one of
	the hearts contained in the book will animate and break to indicate that it is invalid. If the user loses all 3 "lives"
	the game will end and be counted as a loss. If the user runs out of time or they lose all 3 "lives" the game will end
	and be counted as a loss, the feedback screen will then be shown to the user. The feedback screen contains the game outcome,
	wether the user won or lost, the user score, the time taken, as well as a play again button towards the bottom of the screen.
	The players score is calculated using the amount of lives remaining, multiplied by the game time in seconds minus the time
	taken in seconds. Upon clicking play again, the feedback screen will be dismissed and the game will be restarted. The feedback
	screen contains a dismiss button indicated by an "X" located at the top left of the screen. Located in the top right of the
	find call numbers game screen are the action buttons. The right most button is the submit button (indicated with a tick symbol),
	when clicked it will check the submitted answer if it is valid. If the given answer is correct, the player will be shown a prompt,
	informing them that they have submitted the correct choice, however if the given answer is incorrect, the player will be shown a
	prompt informing them that the given answer is incorrect and a player "life" will be lost. If the submit button is clicked and
	no books are submitted, the user will be informed that they need to make a selection of an answer, the slot where the book must
	be placed will blink twice to further indicate this. To the left of the submit button is the reset button, indicated by an arrow
	turning into itself, when clicked it will move the currently selected book back into the stack of potential answers.



		

Other Information
------------------------------------------------------------------------------------------------------------

The game displays a random set of dewey decimal related data in a series of books that are randomly assigned a color.

In the first game "Replacing Books", the data concerning both the books and slots on the shelf is stored using a list of a custom structure type, one for
book data and the other for slot data.

In the second game "Identify Areas", a dictionary is used to hold all of the call numbers and their descriptions and lists of custom structures are used
to hold the book data.

In the third game "Find Call Numbers", a Red Black Tree is used to store the dewey decimal related data, the key is populated with the call number and the 
data associated is inputted into a structure that contains the associated call number (as a string to preserve its format), call numbers description and position (list level) in the multi level list.

In the second and third game, a custom label class is created and used to apply custom styling to the labels displayed on the books when the text
is disabled. This allows for the user to interact with the labels while still allowing for events to be passed to the panel behind it, allowing the
player to still drag a book even when the text is selected instead of the panel. 

The app contains gifs designed to animate once before stopping, if a new animation attempts to start before the previous
animation completes, the previous animation will be instantly completed and the new animation will begin.

The app implements a custom class library to generate the dewey decimal values

A nuget package was added to the projct "Control.Draggable" and is used to move the components (book panels) on the shelf


Credits
------------------------------------------------------------------------------------------------------------

Throughout the app, various sources were used:

	ChatGPT:
	- https://chat.openai.com/share/fb07dba1-4993-46f3-beea-3607ea018bac > dewey decimal generation
	- https://chat.openai.com/share/1765476c-69b1-4e50-a66f-fd9efc287769 > random author generation
	- https://chat.openai.com/share/19c6bf9b-abfe-4505-9e7b-a6a290bfb6e5 > access tree elements and go through tree data
	
	StackOverflow:
	- https://stackoverflow.com/a/14282467 > disable image stuttering when moving
	- https://stackoverflow.com/a/27875407 > handling setting of gif frame
	- https://stackoverflow.com/a/3259925 > determine if lists contains any values
	- https://stackoverflow.com/a/2681968 > getting the current control in execuion of its event
	- https://stackoverflow.com/a/13528048 > closing a form from its user control
	- https://stackoverflow.com/a/6002751 > changing the disabled text color of a label
	- https://stackoverflow.com/a/4262134 > randomise a list (according to GUID)
	
	TutorialsPoint:
	- https://www.tutorialspoint.com/Bubble-Sort-program-in-Chash > bubble sort assistance
	
	Microsoft:
	- https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-play-a-sound-from-a-windows-form?view=netframeworkdesktop-4.8 > playing custom sounds

	CSharpInDeep
	- https://csharpindeep.wordpress.com/2013/08/10/c-snippet-shuffling-a-dictionary-beginner/ > randomise the order of a dictionary
	
	Simple Dev Code
	- https://simpledevcode.wordpress.com/2014/12/25/red-black-tree-in-c/ > Red Black Tree Assistance
	
	
Github
------------------------------------------------------------------------------------------------------------
	https://github.com/jake1970/PROG_POE_Jake_young_ST10081936.git