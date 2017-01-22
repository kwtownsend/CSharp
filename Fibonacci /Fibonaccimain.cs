//Standard Header Information for Cpsc223n:
//Author: Floyd Holliday
//Author's email: holliday@fullerton.edu  or  activeprofessor@yahoo.com
//Course: Cpsc223n
//Assignment number: 10
//Due date: Feb 28, 2014
//Project name: Fibonacci Number Computing System
//Files in project: fibonaccimain.cs, fibonaccilogic.cs, fibuserinterface.cs
//Project purpose:  Compute the Fibonacci number corresponding to user inputs.  This project demonstrates a commom technique of 
//partitioning the solution into three files: a top level generic driver module, a middle level user interface, and a third level
//algorithms module.  That later module is sometimes called the business logic of the system.
//Project status:  Works correctly with non-negative integer inputs up to 55 when the output value overflows its storage.
//Known bugs: Program crashes if the user input nothing and clicks on "Compute".
//
//This file's name: fibonaccimain.cs
//This file purpose: This is the top level module; it launches the user interface window.
//Date last modified: Feb 1, 2014
//
//There are three files in this program.  They must be compiled in an order that satisfies dependencies.  In this case the correct order is:
//  1. fibonaccilogic.cs
//  2. fibuserinterface.cs
//  3. fibonaccimain.cs
//
//To compile fibonaccilogic.cs:   
//          gmcs -target:library -out:fibonaccilogic.dll fibonaccilogic.cs
//To compile fibuserinterface.cs: 
//          gmcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -r:fibonaccilogic.dll -out:fibuserinterface.dll fibuserinterface.cs
//To compile  and link Fibonaccimain.cs:    
//          gmcs fibonaccimain.cs -r:System -r:System.Windows.Forms -r:fibuserinterface.dll -out:Fibo.exe
//To execute this program:
//          ./Fibo.exe

using System;
//using System.Drawing;
using System.Windows.Forms;  //Needed for "Application" on next to last line of Main
public class Fibonaccimain
{  static void Main(string[] args)
   {System.Console.WriteLine("Welcome to the Main method of the Fibonacci program.");
    Fibuserinterface fibapp = new Fibuserinterface();
    Application.Run(fibapp);
    System.Console.WriteLine("Main method will now shutdown.");
   }//End of Main
}//End of Fibonaccimain
