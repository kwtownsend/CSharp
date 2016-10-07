//Standard Header Information for Cpsc223n:
//Author: Kendall Townsend
//Author's email: kendallcar@csu.fullerton.edu
//Course: Cpsc223n
//Assignment number: 3
//Due date: March 12, 2014
//Project name: Assignment 3 tic tac toe
//Files in project: tictactoemain.cs, tictactoelogic.cs, tictactoeuserinterface.cs
//Project purpose:  Play tic tac toe and have the computer intelligently block the player from winning and print out the resulting winner and
//partitioning the solution into three files: a top level generic driver module, a middle level user interface, and a third level
//algorithms module.  That later module is sometimes called the business logic of the system.
//Project status:  Only known problem is after the player wins it still has to go through a cycle and the computer will play an extra move that has no effect on the results
//Known bugs: Program crashes if the user input nothing and clicks on "Start Game".
//
//This file's name: tictactoemain.cs
//This file purpose: This is the top level module; it launches the user interface window.
//Date last modified: March 10, 2014
//
//There are three files in this program.  They must be compiled in an order that satisfies dependencies.  In this case the correct order is:
//  1. tictactoelogic.cs
//  2. tictactoeuserinterface.cs
//  3. tictactoemain.cs
//


using System;
//using System.Drawing;
using System.Windows.Forms;  //Needed for "Application" on next to last line of Main
public class TicTacToemain
{  static void Main(string[] args)
   {System.Console.WriteLine("Welcome to the Main method of the TicTacToe program.");
    TicTacToeuserinterface TicTacToeapp = new TicTacToeuserinterface();
    Application.Run(TicTacToeapp);
    System.Console.WriteLine("Main method will now shutdown.");
   }//End of Main
}//End of tictactoemain
