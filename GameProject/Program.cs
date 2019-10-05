using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameForm());
        }

        
    
    }
}

//Break program down into these major pieces:
//
//Construct board:
//
//  Create "cell"
//  Place mines
//  Create button object
//  Link cells with buttons
//  Create panel to hold buttons
//
//Present board
//
//  Siza panel to buttons
//  Arrange buttons in correspondance with "cell" placement
//  Size window to panel
//  Place panel in window
//
//React to player
//
//  Click initiates clickEvent
//      Check if mine
//          yes: change button image to mine; lock future moves; reveal board; Go to lose game state
//          no: reveal; queue surrounding, unrevealed cells; in queue, check if mine; if yes, do nothing; if no, repeat this line
//
//Monitor win condition
//
//  Game over will self-initiate from clicking mine.
//  Game win is dependent upon all non-mined cells being revealed.
//      Win state is implicit as all remaining cells have been determined to be mines
//