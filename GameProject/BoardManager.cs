using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    class Cell
    {
        public int touching { get; set; }   //Indicates the number of mines the cell is touching 0-8.
        public int fieldIndex { get; set; } //Indicates the index of the cell on the field.
        public bool hasMine { get; set; }
        public bool isRevealed { get; set; }
        public bool isQueued { get; set; }
        public bool hasBeenChecked { get; set; }

        public Cell(int extIndex)
        {
            fieldIndex = extIndex;
            isRevealed = false;
            hasBeenChecked = false;

        }
    };

    class BoardManager
    {
        GameForm GF;

        Random rand = new Random();

        public int revealedCount { get; set; }
        public int buttonWidth { get; set; }
        public int buttonHeight { get; set; }
        public int columns { get; set; }
        public int rows { get; set; }
        public int cellCount { get; set; }
        public int mineCount { get; set; }

        Cell[] cellsRA;
        int[] indicators;
        Queue<int> quRevealQueue;
        public Panel gamePanel;

        public BoardManager( int c, int r, int m )
        {
            columns = c;
            rows = r;
            mineCount = m;
            buttonWidth = 32;
            buttonHeight = 32;
            cellCount = columns * rows;
            revealedCount = 0;
        }

        /// <summary>
        /// Checks if the given button clicked corresponds with a mined cell. Function changes
        /// board color and locks all controls if yes.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="b"></param>
        public void checkLoseState(int index, ref Button b)
        {
            if (cellsRA[index].isRevealed)
            {
                if (cellsRA[index].hasMine)
                {
                    b.BackColor = Color.DarkRed;
                    gamePanel.Enabled = false;
                    gamePanel.BackColor = Color.Red;
                    gamePanel.ForeColor = Color.Red;

                    //TODO: display gameover label over board
                }
            }
        }

        /// <summary>
        /// Function uses a series of conditional checks to determine if a cell is valid and returns a
        /// bool value indicating a pass or fail.
        /// </summary>
        /// <param name="extIndex"></param>
        /// <returns></returns>
        private bool checkValidCell(int extIndex)
        {
            //Check the cell for the following conditions:

            if (extIndex < 0 || extIndex >= cellCount) //If the cell index is beyond the bounds of the play field, return false
            {
                return false;
            }

            if (cellsRA[extIndex].hasBeenChecked)
            {
                return false;
            }

            if (cellsRA[extIndex].isRevealed) //If the cell has already been revealed, return false.
            {
                return false;
            }

            if (cellsRA[extIndex].isQueued) //If the cell has already been enqueued, return false.
            {
                return false;
            }

            if (cellsRA[extIndex].hasMine) //If the cell contains a mine, return false.
            {
                return false;
            }

            return true;
        }

        //private void button_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        //do something here
        //    }
        //    else//left or middle click
        //    {
        //        //do something here
        //    }
        //}

        //protected void button_Click(object sender, EventArgs e)
        //{
        //    Button newButton = (Button)sender;

        //    Console.WriteLine($"Button {newButton.Tag} clicked");

        //    //newButton.BackColor = Color.Red;

        //    pathFinder(int.Parse(newButton.Tag.ToString()));

        //    updateBoard();

        //    sender = newButton;

        //    //determineWinStatus();
        //}

        //Utilizes the function checkValidCell(int) to determine if the cell should be enqueued.
        //@Param extClickedIndex: the integer index of the cell to be inspected
        //@Return bool: the result of the cell inspection.

        /// <summary>
        /// Function handles the marking and enqueueing of cells for pathFinder(int).
        /// Param int extIndex: The vector index of the cell to be marked & enqueued
        /// Return: NONE
        /// </summary>
        /// <param name="extIndex"></param>
        private void enqueueCell(int extIndex)
        {
            cellsRA[extIndex].isQueued = true; //Mark cell
            quRevealQueue.Enqueue(extIndex); //Enqueue cell
        }

        /// <summary>
        /// Locates all cells surrounding the one indicated by tempIndex. In identifying "neighbors," the
        /// algorithm ensures it has not erroneously moved up or down a row. This prevents a cell at the far
        /// right of the board from initiating checks on the next row down at the far left, and vice versa.
        /// </summary>
        /// <param name="tempIndex"></param>
        private void enqueueNeighbors(int tempIndex)
        {
            int checkIndex;

            //If cell contains no indicator, begin enqueueing any neighbors. (Up to 8 per cell)
            if (cellsRA[tempIndex].touching == 0)
            {
                checkIndex = tempIndex - (columns + 1);
                if (checkValidCell(checkIndex) && ((checkIndex + 1) % columns) != 0) //Check for a cell to the top left.
                {
                    enqueueCell(checkIndex);
                }

                checkIndex = tempIndex - (columns);
                if (checkValidCell(checkIndex)) //Check for a cell to the top.
                {
                    enqueueCell(checkIndex);
                }

                checkIndex = tempIndex - (columns - 1);
                if (checkValidCell(checkIndex) && (checkIndex % columns) != 0) //Check for a cell to the top right.
                {
                    enqueueCell(checkIndex);
                }

                checkIndex = tempIndex - 1;
                if (checkValidCell(checkIndex) && ((checkIndex + 1) % columns) != 0) //Check for a cell to the left.
                {
                    enqueueCell(checkIndex);
                }

                checkIndex = tempIndex + 1;
                if (checkValidCell(checkIndex) && (checkIndex % columns) != 0) //Check for a cell to the right.
                {
                    enqueueCell(checkIndex);
                }

                checkIndex = tempIndex + (columns - 1);
                if (checkValidCell(checkIndex) && ((checkIndex + 1) % columns) != 0) //Check for a cell to the bottom left.
                {
                    enqueueCell(checkIndex);
                }

                checkIndex = tempIndex + columns;
                if (checkValidCell(checkIndex)) //Check for a cell to the bottom.
                {
                    enqueueCell(checkIndex);
                }

                checkIndex = tempIndex + (columns + 1);
                if (checkValidCell(checkIndex) && (checkIndex % columns) != 0) //Check for a cell to the bottom right.
                {
                    enqueueCell(checkIndex);
                }
            }
        }

        /// <summary>
        /// Fills the cell array with new, empty cells.
        /// </summary>
        private void fillCellsRA()
        {
            for (int i = 0; i < cellsRA.Length; i++)
            {
                cellsRA[i] = new Cell(i);
                cellsRA[i].isRevealed = false;
                cellsRA[i].isQueued = false;
            }
        }

        /// <summary>
        /// Initializes the game board and underlying Cell array.
        /// </summary>
        public void InitBoard()
        {
            if (cellCount > 0)
            {
                if (initCellRA() && initGamePanel())
                {
                    quRevealQueue = new Queue<int>();
                    fillCellsRA();
                    populateButtons();
                    Console.WriteLine("Initialization and board generation successful!");
                }
                else
                {
                    Console.WriteLine("Initialization failure! Process aborted.");
                }
            }
            else
            {
                Console.WriteLine("Cell count == 0! Process aborted.");
            }
        }

        /// <summary>
        /// Creates the cell array.
        /// </summary>
        /// <returns></returns>
        private bool initCellRA()
        {
            try
            {
                cellsRA = new Cell[cellCount];

                if (cellsRA != null && cellsRA.Length == cellCount)
                {
                    Console.WriteLine("cellsRA init successful");
                    return true;
                }
            }

            catch
            {
                //Throw error
            }

            return false;
        }

        /// <summary>
        /// Creates the panel control, which will hold the buttons representing the game field.
        /// </summary>
        /// <returns></returns>
        private bool initGamePanel()
        {
            try
            {
                gamePanel = new Panel()
                {
                    AutoSize = true
                };

                if (gamePanel != null)
                {
                    Console.WriteLine("gamePanel init successful");
                    return true;
                }
            }
            catch
            {

            }

            return false;
        }

        /// <summary>
        /// Handles the process of selecting and enqueueing cells for review. Calls enqueueNeighbors on
        /// the cell index currently in focus and repeats this process until all relevant cells have been
        /// processed.
        /// </summary>
        /// <param name="extClickedIndex"></param>
        public void pathFinder(int extClickedIndex)
        {
            //cout << "Pathfinder initiated on cell " << (extClickedIndex);
            int tempIndex = extClickedIndex;

            if (cellsRA[tempIndex].hasMine) //If a mine exists in the cell selected by the player, game over.
            {
                cellsRA[tempIndex].isRevealed = true; //Reveal the mine
            }
            else //If no mine exists, enqueue its index and begin process of revealing and inspecting.
            {
                cellsRA[tempIndex].isQueued = true;
                cellsRA[tempIndex].hasBeenChecked = true;
                quRevealQueue.Enqueue(tempIndex);

                while (quRevealQueue.Count > 0) //while the queue still contains cells
                {
                    tempIndex = quRevealQueue.Dequeue(); //Get the index at the front of the queue
                    //quRevealQueue.pop(); //Pop the index from the queue
                    //cellsRA[tempIndex].setQueued(false);

                    revealCell(tempIndex);

                    enqueueNeighbors(tempIndex);

                    //If the cell contains an indicator, do nothing more.
                }
            }

            uncheckAllCells();
            //Console.WriteLine($"Revealed cells: {revealedCount}");
        }

        /// <summary>
        /// Gets a random number between 0 and the number of cells, ensures it is not the designated
        /// safe cell, and that it does not already contain a mine from a previous iteration, and
        /// places a mine at that index.
        /// </summary>
        /// <param name="safe"></param>
        private void placeMines(int safe)
        {
            int cellIndex;

            //For as many mines as we need...
            for (int minesPlaced = 0; minesPlaced < mineCount; minesPlaced++)
            {
                //... search for a random, unoccupied cell...
                do
                {
                    cellIndex = rand.Next(0, cellCount);
                } while (cellIndex == safe || cellsRA[cellIndex].hasMine);

                //... then place a mine in the found available cell.
                cellsRA[cellIndex].hasMine = true;
            }
        }

        /// <summary>
        /// Kicks off the process of placing mines and indicators, reserving a "safe" index based on the
        /// integer passed, preventing first-click loss situation.
        /// </summary>
        /// <param name="sender"></param>
        public void populateBoard(int safeIndex)
        {
            placeMines(safeIndex);
            setIndicators();
        }

        /// <summary>
        /// Generates as many buttons as needed for the play field and adds them to the panel in a grid.
        /// Grid width is based upon the number of columns requested. Number of rows follows as a function
        /// of columnarization.
        /// </summary>
        private void populateButtons()
        {
            int buttonsNeeded = cellCount;

            for (int i = 0; i < buttonsNeeded; i++)
            {
                gamePanel.Controls.Add(
                    new Button()
                    {
                        Tag = i.ToString(),
                        Location = new Point(
                            (buttonWidth * (i % columns)),
                            (buttonHeight * (i / columns))),
                        Size = new Size(buttonWidth, buttonHeight),
                    });
                gamePanel.Controls[i].Click += new System.EventHandler(GF.button_Click);
            }
        }

        /// <summary>
        /// Sets the appropriate values on the cell object and its representative control (button) to indicate it
        /// has been revealed.
        /// </summary>
        /// <param name="index"></param>
        private void revealCell(int index)
        {
            int i;
            string s;

            s = cellsRA[index].touching.ToString();
            i = int.Parse(s);

            cellsRA[index].isRevealed = true; //Mark the cell as revealed if it is not, already.

            if (i > 0)
            {
                gamePanel.Controls[index].Text = s;
                gamePanel.Controls[index].Font = new Font(gamePanel.Controls[index].Font, FontStyle.Bold);
                gamePanel.Controls[index].ForeColor = getColorFromInt(i);
            }

            gamePanel.Controls[index].BackColor = System.Drawing.Color.White;
            gamePanel.Controls[index].Tag = "disable";
            revealedCount++;
        }

        /// <summary>
        /// A publicly accessible method to create a link to the active GameForm object for access
        /// to the button_click method.
        /// </summary>
        /// <param name="form"></param>
        public void setGameFormReference(GameForm form)
        {
            GF = form;
        }

        /// <summary>
        /// Scans the entire array of cells and increments the "touching" indicator of each for every
        /// mine it finds within range.
        /// </summary>
        private void setIndicators()
        {
            int check;
            int loopCT = 0;
            int mines = mineCount;

            indicators = new int[cellCount];

            while (mines > 0 && loopCT < cellCount)
            {
                if (cellsRA[loopCT].hasMine) //If a mine is found.
                {
                    indicators[loopCT] = 9; //As no cell can have 9 neighbors, 9 is used to indicate a mine's presence.

                    //Orientation is shown through use of keyboard layout. If a bomb sits at S,
                    //then Q is top left, D is right, and X is down.

                    //Q
                    check = loopCT - (columns + 1);
                    if (check >= 0)
                        if (!cellsRA[check].hasMine && (check + 1) % columns != 0)
                        {
                            indicators[check]++;
                            //cout << "ele: " << loopCT << " check: " << check << " compare: " << check % (cols - 1) << "\n";
                        }
                    //W
                    check = loopCT - columns;
                    if (check >= 0)
                        if (!cellsRA[check].hasMine)
                        {
                            indicators[check]++;
                        }
                    //E
                    check = loopCT - (columns - 1);
                    if (check >= 0)
                        if (!cellsRA[check].hasMine && check % columns != 0)
                        {
                            indicators[check]++;
                        }
                    //A
                    check = loopCT - 1;
                    if (check >= 0)
                        if (!cellsRA[check].hasMine && (check + 1) % columns != 0)
                        {
                            indicators[check]++;
                        }
                    //D
                    check = loopCT + 1;
                    if (check < rows * columns)
                        if (!cellsRA[check].hasMine && check % columns != 0)
                        {
                            indicators[check]++;
                        }
                    //Z
                    check = loopCT + (columns - 1);
                    if (check < rows * columns)
                        if (!cellsRA[check].hasMine && (check + 1) % columns != 0)
                        {
                            indicators[check]++;
                        }
                    //X
                    check = loopCT + columns;
                    if (check < rows * columns && !cellsRA[check].hasMine)
                    {
                        indicators[check]++;
                    }
                    //C
                    check = loopCT + (columns + 1);
                    if (check < rows * columns)
                        if (!cellsRA[check].hasMine && check % columns != 0)
                        {
                            indicators[check]++;
                        }
                    mines--;
                }
                loopCT++;
            }

            for (loopCT = 0; loopCT < cellCount; loopCT++)
            {
                cellsRA[loopCT].touching = (indicators[loopCT]);
            }
        }

        /// <summary>
        /// Takes an integer, indicating the "touching" value of a cell and returns the Syste.Drawing.Color
        /// associated with its value.
        /// </summary>
        /// <param name="touching"></param>
        private System.Drawing.Color getColorFromInt(int touching)
        {
            switch (touching)
            {
                case 1:
                    return System.Drawing.Color.Blue;
                case 2:
                    return System.Drawing.Color.DarkGreen;
                case 3:
                    return System.Drawing.Color.Red;
                case 4:
                    return System.Drawing.Color.Purple;
                case 5:
                    return System.Drawing.Color.Maroon;
                case 6:
                    return System.Drawing.Color.Turquoise;
                case 7:
                    return System.Drawing.Color.Black;
                case 8:
                    return System.Drawing.Color.DarkGray;
                default:
                    return System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// Resets the boolean value in each cell used to prevent multiple enqueueings on a single turn, allowing
        /// it to be enqueued the next turn.
        /// </summary>
        private void uncheckAllCells()
        {
            foreach (Cell c in cellsRA)
            {
                if (c.hasBeenChecked)
                {
                    c.hasBeenChecked =false;
                }
            }
        }
    }
}

//Indicator placement method documentation:

//Determine the contents of the array's elements and assign numerical values
//indicating the number of mines a particular square in touching. Values range
//from 0 to 8 and will be assigned to the array as a character between
// '0' and '8'.

//Search the array until an element is found which contains a mine, represented
//by 'X'. Using a mathematical algorithm to determine which array elements will
//"touch" the 'X', bearing in mind rows and columns, assign a value to the
//integer array corresponding to the field.

//Determine left side: element# % cols = 0
//Determine right side: element# % cols-1 = 0

//E.g.: Cols = 9, 0-8.   check % 9 = 0, start of new row. Left side.
//      Cols = 9, 0-8. check+1 % 9 = 0, end of row. Right side.

//Determine top:    (Element# - cols) < 0
//Determine bottom: (Element# + cols) > total cells

//E.g.: Cols = 9, 0-8. 3 - 9 = -6. Top.
//      Cols = 9, 0-8. Total cells = 81. Element 73 + cols = 82. Bottom.

//When a boundary has been found, that portion of the algorithm will be skipped.

//From the "mine", find all cells (potentially) in contact with it. Procedure will
//be performed as follows:

//In the following diagram, the mine is replaced with a ' ' and the letters surrounding
//'S' on a standard US keyboard represent the locations to which the algorithm will count.

//Count back from the array element by...
//				the number of columns + 1 (Q)
//				cols (W)
//				cols - 1 (E)
//              ele - 1 (A)

//Next, count forward by...
//				ele + 1 (D)
//				cols -1 (Z)
//              cols (X)
//              cols +1 (C)


// [Q][W][E]
// [A][ ][D]
// [Z][X][C]

//If at any time the count overruns the boundaries of the field, it will be skipped.

//Procedure will require a nested loop. The outer loop will advance through the array from
//start to finish (0 - n). If at any point an 'X' is discovered in the mine array, an
//internal loop will run through the counting procedure.