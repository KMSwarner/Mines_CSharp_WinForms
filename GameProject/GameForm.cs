using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class GameForm : Form
    {
        int gameDifficulty;
        bool bGameIsRunning;

        BoardManager gameBoard;
        Panel gamePanel;
        ScoresForm scoresForm;
        //Thread timeThread;
        Timekeeper timer;

        /// <summary>
        /// Constructor initializes objects
        /// </summary>
        public GameForm()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            scoresForm = null;
            bGameIsRunning = false;
            timer = new Timekeeper();
            //timeThread = new Thread(stopWatch);
        }

        #region GAME PROCESSES
        //--------------------------------------------- GAME PROCESSES --------------------------------------------

        /// <summary>
        /// Sets properties of the GameForm object based on fetched gamePanel and places the panel within it.
        /// </summary>
        private void buildFormAppearance()
        {
            int formHeight;
            int formWidth;

            Point panelLocation;

            //Gets the gamePanel
            fetchNewBoard();

            formHeight = (menuStrip.Height * 2) + gamePanel.Height + (statusStrip.Height * 2);
            formWidth = gamePanel.Width + (gamePanel.Margin.Horizontal * 4);

            panelLocation = new Point(gamePanel.Margin.Left, gamePanel.Margin.Top + menuStrip.Height);

            gameBoard.gamePanel.Location = panelLocation;
            gameBoard.gamePanel.Visible = true;

            this.Size = new Size(formWidth, formHeight);

            Console.WriteLine($"Form dimensions: w = {this.Size.Width}, h = {this.Size.Height}");
        }

        /// <summary>
        /// Function is called after each player move to determine if the win condition has been met.
        /// If win condition has been met, board is locked and its color changed to signifiy a win.
        /// </summary>
        /// <returns></returns>
        private bool determineWinStatus()
        {
            if (gameBoard.cellCount - gameBoard.revealedCount == gameBoard.mineCount)
            {
                gamePanel.Enabled = false;
                gamePanel.BackColor = Color.Green;
                gamePanel.ForeColor = Color.Green;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves the newly constructed "Dummy" board from the gameBoard BoardManager object.
        /// </summary>
        public void fetchNewBoard()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                {
                    this.Controls.Remove(c);
                }
            }

            gamePanel = gameBoard.gamePanel;

            this.Controls.Add(gamePanel);
        }

        /// <summary>
        /// Handles the process of initializing game state and defining the board parameters.
        /// </summary>
        /// <param name="diff"></param>
        private void stageNewGame(int diff)
        {
            gameDifficulty = diff;
            bGameIsRunning = false;

            switch (diff)
            {
                case 1:
                    gameBoard = new BoardManager(9, 9, 10);
                    break;
                case 2:
                    gameBoard = new BoardManager(16, 16, 40);
                    break;
                case 3:
                    gameBoard = new BoardManager(30, 16, 99);
                    break;
                default:
                    gameBoard = new BoardManager(9, 9, 10);
                    break;
            }

            gameBoard.setGameFormReference(this);
            gameBoard.InitBoard();
            buildFormAppearance();
        }

        /// <summary>
        /// Begins a new game, setting all game cycle monitoring properties and calling function to set the board
        /// with a safe index based on firstClicked.
        /// 
        /// </summary>
        /// <param name="firstClicked"></param>
        private void startNewGame(int firstClicked)
        {
            bGameIsRunning = true;
            gameBoard.populateBoard(firstClicked);
            timer.startTimer();
            //timeThread.Start(); //Has Crossthreading issue, currently. UI thread holds label, causing error.
        }
        //---------------------------------------------------------------------------------------------------------
        #endregion

        #region CLICK EVENTS
        //--------------------------------------------- CLICK EVENTS --------------------------------------------

        #region Difficulty Settings
        //-------------------------------Difficulty Settings --------------------------------
        /// <summary>
        /// Starts a new game at beginner level (1)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beginnerMItem_Click(object sender, EventArgs e)
        {
            stageNewGame(1);
            Console.WriteLine("First click event");
        }

        private void beginnerMItem_Click2(object sender, EventArgs e)
        {
            Console.WriteLine("Second click event");
        }

        /// <summary>
        /// Starts a new game at intermediate level (2)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void intermediateMItem_Click(object sender, EventArgs e)
        {
            stageNewGame(2);
        }

        /// <summary>
        /// Starts a new game at expert level (3)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expertMItem_Click(object sender, EventArgs e)
        {
            stageNewGame(3);
        }
        //-----------------------------------------------------------------------------------
        #endregion

        #region Menu Item Click Events
        //-------------------------------Menu Item Click Events --------------------------------
        /// <summary>
        /// Creates and opens a new scoresForm object using singleton pattern.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scoresMItem_Click(object sender, EventArgs e)
        {
            if (scoresForm == null)
            {
                scoresForm = new ScoresForm();
                scoresForm.Closed += scores_closed;
                scoresForm.Show();
            }
        }

        /// <summary>
        /// Resets the scoresForm object to null, completing singleton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scores_closed(object sender, EventArgs e)
        {
            scoresForm = null;
        }

        /// <summary>
        /// Event handler for game exit menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitMItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //--------------------------------------------------------------------------------------
        #endregion

        /// <summary>
        /// Event handler assigned to each button on the play field. Click will start new game if not already
        /// in progress, and will otherwise trigger a board update based upon the clicked button's numerical tag.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button_Click(object sender, EventArgs e)
        {
            Button newButton = (Button)sender;
            int btnIndex;

            if (newButton.Tag.ToString() != "disable")
            {
                btnIndex = int.Parse(newButton.Tag.ToString());

                if (!bGameIsRunning)
                {
                    startNewGame(btnIndex);
                }
                //Console.WriteLine($"Button {newButton.Tag} clicked");

                gameBoard.pathFinder(btnIndex);
                gameBoard.checkLoseState(btnIndex, ref newButton);

                newButton.Tag = "disable";

                sender = newButton;

                if (determineWinStatus())
                {
                    bGameIsRunning = false;
                    timer.stopTimer();
                    timer.logTime(gameDifficulty, timer);
                    //timeThread.Suspend();
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------
        #endregion
    }
}

//public void button_MouseDown(object sender, MouseEventArgs e)
//{
//    if (e.Button == MouseButtons.Left)
//    {
//        Console.WriteLine("Left Click");
//    }
//    if (e.Button == MouseButtons.Right)
//    {
//        Console.WriteLine("Right Click");
//    }
//}

//private void stopWatch()
//{
//    DateTime now;
//    DateTime last = DateTime.Now;
//    TimeSpan delta;
//    while (true)
//    {
//        now = DateTime.Now;
//        last = now;
//        delta += now - last;

//        if (delta.TotalSeconds >= 1 / 30)
//            lblStripTime.Text = timer.deltaTime().ToString();
//    }
//}


//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions#expression-lambdas
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions#statement-lambdas
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions