//Author: Floyd Holliday
//Author's email: holliday@fullerton.edu  or  activeprofessor@yahoo.com
//Course: Cpsc223n
//Assignment number: 10
//Due date: Feb 28, 2014
//Project name: Fibonacci Number Computing System
//Files in project: fibonaccimain.cs, fibonaccilogic.cs, fibuserinterface.cs
//Project purpose:  Compute the Fibonacci number corresponding to user inputs.
//Project status:  Works correctly with non-negative integer inputs up to 55 when the output value overflows its storage.
//Known bugs: Program crashes if the user input nothing and clicks on "Compute".
//
//This file's name: fibonaccilogic.cs
//This file purpose: This is a third level module; it is called from fibuserinterface.cs.
//Date last modified: Feb 1, 2014
//
//
//To compile fibonaccilogic.cs:   
//          gmcs -target:library -out:fibonaccilogic.dll fibonaccilogic.cs
//
////Ref: for data types uint and ulong see Gittleman, p. 149
//
using System;
public class convertTemperature
{
 public static double convertFtoC(uint sequencenun)
   {
    double celsius = sequencenun-32;
     celsius = celsius / 5;
     celsius = celsius + 32;
     Console.Write("{0:F12}", celsius);
    return celsius;
   }//End of computefibonaccinumber

}//End of Fibonaccilogic
