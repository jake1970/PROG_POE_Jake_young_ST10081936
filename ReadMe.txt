------------------------------------------------------------------------------------------------------------
Jake Young
ST10081936
------------------------------------------------------------------------------------------------------------

Dewy Trainer
------------------------------------------------------------------------------------------------------------

Welcome to Dewy Trainer.

Dewy Trainer is an interactive library training system designed to teach the user about the Dewey decimal system.

The software is comprised of a c# windows forms application that makes use of lists to store the data.


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
	Note: Currently only Replacing Books is implemented with the other 2 games to follow soon.

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
	of 3 minutes, after which the game will be ended and count as a loss.
		

Other Information
------------------------------------------------------------------------------------------------------------

The game displays a random set of dewey decimals in a series of books that are randomly assigned a color.

The data concerning both the books and slots on the shelf is stored using a list of a custom structure type, one for
book data and the other for slot data.

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
	
	StackOverflow:
	- https://stackoverflow.com/a/14282467 > disable image stuttering when moving
	- https://stackoverflow.com/a/27875407 > handling setting of gif frame
	- https://stackoverflow.com/a/3259925 > determine if lists contains any values
	- https://stackoverflow.com/a/2681968 > getting the current control in execuion of its event
	- https://stackoverflow.com/a/13528048 > closing a form from its user control
	
	TutorialsPoint:
	- https://www.tutorialspoint.com/Bubble-Sort-program-in-Chash > bubble sort assistance
	
	Microsoft:
	- https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-play-a-sound-from-a-windows-form?view=netframeworkdesktop-4.8 > playing custom sounds
	
	
