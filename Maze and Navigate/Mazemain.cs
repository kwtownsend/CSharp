//Standard Header Information for Cpsc223n:
//Author: Kendall Townsend
//Author's email: kendallcar@csu.fullerton.edu
//Course: Cpsc223n
//Assignment number: 4
//Due date: April 7, 2014
//Project name: Mickey Mouse in C Sharp
//Files in project: Mazemain.cs, Mazeuserinterface.cs
//Project purpose:  Generate a maze and navigate it through an AI.  This project demonstrates a commom technique of 
//partitioning the solution into three files: a top level generic driver module, a middle level user interface, and a third level
//algorithms module.  That later module is sometimes called the business logic of the system.
//Project status:  Works correctly with non-negative integer inputs 
//Known bugs: Program crashes if the user input nothing and clicks on "Compute".
//
//This file's name: Mazemain.cs
//This file purpose: This is the top level module; it launches the user interface window.
//Date last modified: April 6, 2014
//
//There are three files in this program.  They must be compiled in an order that satisfies dependencies.  In this case the correct order is:
//  1. Mazelogic.cs
//  2. Mazeuserinterface.cs
//  3. Mazemain.cs
//
//To execute this program:
//          ./mazeapp.exe

using System;
//using System.Drawing;
using System.Windows.Forms;  //Needed for "Application" on next to last line of Main
public class Fibonaccimain
{  static void Main(string[] args)
   {System.Console.WriteLine("Welcome to the Main method of the Fibonacci program.");
    Mazeuserinterface mazeapp = new Mazeuserinterface();
    Application.Run(mazeapp);
    System.Console.WriteLine("Main method will now shutdown.");
   }//End of Main
}//End of Mazemain
