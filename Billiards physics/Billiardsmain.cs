//Standard Header Information for Cpsc223n:
//Author: Kendall Townsend
//Author's email: kendallcar@csu.fullerton.edu
//Course: Cpsc223n
//Assignment number: 5
//Due date: April 21, 2014
//Project name: Assignment 5 Billiards
//Files in project: Billiardsmain.cs, Billiardsuserinterface.cs
//Project purpose:  Generate walls and a billiard ball that will bounce off of them and when reaches boundaries stops
//partitioning the solution into three files: a top level generic driver module, a middle level user interface, and a third level
//algorithms module.  That later module is sometimes called the business logic of the system.
//Project status:  Works correctly with non-negative integer inputs for speed
//Known bugs: Program crashes if the user input nothing for speed and clicks new maze/go
//
//This file's name:Billiardsmain.cs
//This file purpose: This is the top level module; it launches the user interface window.
//Date last modified: April 20, 2014
//
//There are three files in this program.  They must be compiled in an order that satisfies dependencies.  In this case the correct order is:
//  1. Billiardslogic.cs
//  2. Billiardsuserinterface.cs
//  3. Billiardsmain.cs
//
//To execute this program:
//          ./Billiardsapp.exe

using System;
//using System.Drawing;
using System.Windows.Forms;  //Needed for "Application" on next to last line of Main
public class Fibonaccimain
{  static void Main(string[] args)
   {System.Console.WriteLine("Welcome to the Main method of the Fibonacci program.");
    Billiardsuserinterface Billiardsapp = new Billiardsuserinterface();
    Application.Run(Billiardsapp);
    System.Console.WriteLine("Main method will now shutdown.");
   }//End of Main
}//End of Mazemain

