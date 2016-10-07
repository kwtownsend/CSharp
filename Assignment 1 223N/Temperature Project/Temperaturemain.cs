//Standard Header Information for Cpsc223n:
//Author: Kendall Townsend
//Author's email: Kendallcar@csu.fullerton.edu
//Course: Cpsc223n
//Assignment number: 1
//Due date: Feb 10, 2014
//Project name: Temperature Conversion
//Files in project: Temeperaturemain.cs, Temperaturelogic.cs, Temperatureserinterface.cs
//Project purpose: Compute the temperature celsius or fahrenheit corresponding to user inputs. This project demonstrates
//the technique of partitioning the solution into three files: top level generic driver module, a middle level user interface,
// and a third level algorithms module, sometimes called the business logic of the system.
//Project status:  Works correctly with inputs and shows 12 decimal points.
//Known bugs: Program crashes if the user input nothing and clicks on "Convert to F" or "Convert to C".
//
//This file's name: Temperaturemain.cs
//This file purpose: This is the top level module; it launches the user interface window.
//Date last modified: Feb 5, 2014
//
//There are three files in this program.  They must be compiled in an order that satisfies dependencies.  In this case the correct order is:
//  1. Temperaturelogic.cs
//  2. Temperatureuserinterface.cs
//  3. Temperaturemain.cs
//
//To compile Temperaturelogic.cs:   
//          gmcs -target:library -out:Temperaturelogic.dll Temperaturelogic.cs
//To compile Temperatureuserinterface.cs: 
//          gmcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -r:Temperaturelogic.dll -out:Temperatureuserinterface.dll Temperatureuserinterface.cs
//To compile  and link Temperaturemain.cs:    
//          gmcs fibonaccimain.cs -r:System -r:System.Windows.Forms -r:Temperatureuserinterface.dll -out:Temperature.exe
//To execute this program:
//          ./Temperature.exe

using System;
//using System.Drawing;
using System.Windows.Forms;  //Needed for "Application" on next to last line of Main
public class Temperaturemain
{  static void Main(string[] args)
   {System.Console.WriteLine("Welcome to the Main method of the Temperature conversion program.");
    Temperatureuserinterface fibapp = new Temperatureuserinterface();
    Application.Run(fibapp);
    System.Console.WriteLine("Main method will now shutdown.");
   }//End of Main
}//End of Fibonaccimain
