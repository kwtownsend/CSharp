//Author: Kendall Townsend
//Author's email: Kendallcar@csu.fullerton.edu
//Course: Cpsc223n
//Assignment number: 6
//Due date: May 7, 2014
//Project name: Assignment 6 Pong
//Files in project: Pongmain.cs, Ponglogic.cs, Ponguserinterface.cs
//Project purpose:  Generate Pong Paddles and a  ball that will bounce off of them and when reaches right or left boundaries stops and counts points W,S moves left paddle, O, L moves right paddle
//partitioning the solution into three files: a top level generic driver module, a middle level user interface, and a third level
//algorithms module.  That later module is sometimes called the business logic of the system.
//Project status: Works correctly with non-negative integer inputs for speed
//Known bugs:  Program crashes if the user input nothing for speed and clicks new game
//
//This file's name:Pongmain.cs
//This file purpose: This is the top level module; it launches the user interface window.
//Date last modified: May 4, 2014
//
//There are three files in this program.  They must be compiled in an order that satisfies dependencies.  In this case the correct order is:
//  1. Ponglogic.cs
//  2. Ponguserinterface.cs
//  3. Pongmain.cs
//
//To execute this program:
//          ./Pongapp.exe


using System;
//using System.Drawing;
using System.Windows.Forms;  //Needed for "Application" on next to last line of Main
public class Pongmain
{  static void Main(string[] args)
   {System.Console.WriteLine("Welcome to the Main method of the Fibonacci program.");
    Ponguserinterface Pongapp = new Ponguserinterface();
    Application.Run(Pongapp);
    System.Console.WriteLine("Main method will now shutdown.");
   }//End of Main
}//End of POngmain

