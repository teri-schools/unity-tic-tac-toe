# Lab 1 (maximum - 10 points)
[Views original pdf file](./Lab01.pdf) 

## Topic: Object-Oriented Programming Review. Tic-Tac-Toe Game
### Purpose:
To review the principles of OOP and create an engaging console game.

### Tasks for the laboratory work:

**Task 0: Preparation for the task execution**
1. Install DotNet CLI version 6 or 7.
2. Create a separate repository on GitHub or GitLab. This repository will contain all the tasks you complete for the "Software Engineering" course. Each task will be in a separate directory labeled lab-1, lab-2 ... lab-n.
3. Grant access to the instructor vkich7.
4. Clone the created repository.
5. Create the lab-1 directory.
6. Navigate to the created directory and run the command `dotnet new console`.
7. Proceed to Task 1.

**Task 1: Creating the "Tic-Tac-Toe" Game**
1. Familiarize yourself with the game specifications and additional features. You will need to implement at least ONE additional feature of your choice.
2. Plan the structure, possible issues, and difficulties associated with the implementation and maintenance of the game code.
3. Create the game.
4. Note that it is not mandatory to implement ALL additional features. However, it is a plus if you consider how you would implement them. It is an even bigger plus if you implement more than one.
5. You will receive five out of ten possible points for timely submission and another five for the correctness of implementation.

### Tic-Tac-Toe Game Specifications:
1. The initial game screen should look as follows:
```
 1 | 2 | 3 
-----------
 4 | 5 | 6 
-----------
 7 | 8 | 9 
```
2. Each game cell has its number. If the cell is empty, its number is displayed. If the cell is filled, "X" or "O" is displayed.
3. The user selects a cell to fill by entering the corresponding number in the console. The input is validated. If an invalid number is entered, the message "There is no cell "{CHAR}" on the field." is displayed. If the selected cell is already occupied, "Cell "{CHAR}" is already set." is displayed. If a non-numeric value is entered, "Please enter a valid number between 1 and 9." is displayed. The message is repeated until the user enters an acceptable input.
4. After each move, the screen refreshes, clearing the results of previous moves.
5. Players 1 and 2 take turns until one of them wins or all cells are filled (draw).
6. At the end of the game, the result should be displayed: "Player 1 wins", "Player 2 wins", or "It’s a draw". After that, the process ends.

### Additional Feature 1: Saving and Loading the Game
Add the ability to save and load the game from a file on the computer.
1. At any point during the game, the user can press the "S" key. After that, the current state of the game should be saved to the current directory in a special file with any extension of your choice (e.g., saved-game.(xml, csv, txt)).
2. To load a saved game, the user needs to run it with the --load-saved flag, for example, `dotnet run --load-saved`.
3. If the user tries to load the game without a previously saved file, a warning "No saved game was found!" should appear, and the game starts from the beginning.

### Additional Feature 2: Single Player Mode
Add the option for a single-player mode.
1. The computer intelligence should follow the game algorithm as accurately as possible.
2. To start the single-player mode, the --single-player flag should be passed, for example, `dotnet run --single-player`.

### Additional Feature 3: Game Replay
Add the ability to replay the game and keep track of the overall score.
1. After the game ends, do not exit the process. Instead, ask the user "Do you want to play again? (y/n)".
2. If the user chooses "n", the game ends as in the previous version.
3. If the user chooses "y", the game is replayed, but the players' symbols are swapped (X => O), and information about the overall score is displayed.

### Additional Feature 4: Undo Action
Add the ability to undo the previous action.
1. The user can press the "U" key to undo the previous action (the "X" or "O" will disappear, and the corresponding cell will be cleared).
2. If the game is in single-player mode, pressing "U" should also cancel the computer's action.