//Standard Header Information for Cpsc223n:
//Author: Kendall Townsend
//Author's email: kendallcar@csu.fullerton.edu
//Course: Cpsc223n
//Assignment number: 2
//Due date: Feb 24, 2014
//Project name: Payroll Assignment 2
//Files in project: payrollmain.cs, payrolllogic.cs, payrolluserinterface.cs
//Project purpose:  Take inputs and be able to output their regular pay, overtime pay, gross pay, withhold tax, health deductible,
// soscial security deductible, and net pay. 
//partitioning the solution into three files: a top level generic driver module, a middle level user interface, and a third level
//algorithms module.  That later module is sometimes called the business logic of the system.
//Project status:  Works correctly with any outputs if inputs are negative will calculate negative values.
//Known bugs: Program crashes if the user input nothing and clicks on "Compute".
//
//This file's name: payrollmain.cs
//This file purpose: This is the top level module; it launches the user interface window.
//Date last modified: Feb 23, 2014
//
//There are three files in this program.  They must be compiled in an order that satisfies dependencies.  In this case the correct order is:
//  1. payrolllogic.cs
//  2. payrolluserinterface.cs
//  3. payrollmain.cs
//
//To compile payrolllogic.cs:   
//          gmcs -target:library -out:payrolllogic.dll payrolllogic.cs
//To compile payrolluserinterface.cs: 
//          gmcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -r:payrolllogic.dll -out:payrolluserinterface.dll payrolluserinterface.cs
//To compile  and link payrollmain.cs:    
//          gmcs payrollmain.cs -r:System -r:System.Windows.Forms -r:payrolluserinterface.dll -out:payroll.exe
//To execute this program:
//          ./payroll.exe

using System;
//using System.Drawing;
using System.Windows.Forms;  //Needed for "Application" on next to last line of Main
public class payrollmain
{  static void Main(string[] args)
   {System.Console.WriteLine("Welcome to the Main method of the Payroll program.");
   payrolluserinterface fibapp = new payrolluserinterface();
    Application.Run(fibapp);
    System.Console.WriteLine("Main method will now shutdown.");
   }//End of Main
}//End of payrollmain
