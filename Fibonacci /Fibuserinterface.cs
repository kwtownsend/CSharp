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
//This file's name: fibuserinterface.cs
//This file purpose: This is a second level module; it defines the user interface window.
//Date last modified: Feb 1, 2014
//
//There are three files in this program.  They must be compiled in an order that satisfies dependencies.  In this case the correct order is:
//  1. fibonaccilogic.cs
//  2. fibuserinterface.cs
//  3. fibonaccimain.cs
//
//To compile fibuserinterface.cs: 
//          gmcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -r:fibonaccilogic.dll -out:fibuserinterface.dll fibuserinterface.cs
//
//Function: The Fibonacii numerical calculator.  Enter a non-negative sequence integer in the input field, then
//click on the compute button, and the result will appear as a string.
//Sample results for small input values:
//
//Input  Fib number
//  0     1
//  1     1
//  2     2
//  3     3
//  4     5
//  5     8
//  6    13
//  7    21
//  8    34
//  9    55
// 10    89
//
using System;
using System.Drawing;
using System.Windows.Forms;

public class Fibuserinterface: Form
{private Label title = new Label();
private Label name = new Label();
 private Label sequencemessage = new Label();
 private TextBox sequenceinputarea = new TextBox();
 private Label outputinfo = new Label();
 private Button convertToF = new Button();
 private Button convertToC = new Button();
 private Button clear = new Button();
 private Button exitbutton = new Button();

 public Fibuserinterface()
   {//Initialize text strings
    Text = "Temperature conversion Assignment";
    title.Text = "Temperature Conversion";
    name.Text = "By Kendall Townsend";
    sequencemessage.Text = "Enter a temperature in the box below:";
    sequenceinputarea.Text = ""; //Empty string
    outputinfo.Text = "Click on a button below.";
    convertToF.Text = "Convert To F";
    convertToC.Text = "Convert to C";
    clear.Text = "Clear";
    exitbutton.Text = "Exit";
    
    //Set sizes
    Size = new Size(400,240);
    title.Size = new Size(120,30);
    sequencemessage.Size = new Size(150,30);
    sequenceinputarea.Size = new Size(150,30);
    outputinfo.Size = new Size(370,30);
    convertToF.Size = new Size(85,30);
    convertToC.Size = new Size(85,30);
    clear.Size = new Size(85, 30);
    exitbutton.Size = new Size(85,30);

    //Set locations
    title.Location = new Point(140,20);
    sequencemessage.Location = new Point(20,60);
    sequenceinputarea.Location = new Point(20,100);
    outputinfo.Location = new Point(20,140);
    convertToF.Location = new Point(20,190);
    convertToC.Location = new Point(150,190);
    clear.Location = new Point(280, 190);
    exitbutton.Location = new Point(410,190);

    //Associate the Compute button with the Enter key of the keyboard
  

    //Add controls to the form
    Controls.Add(title);
    Controls.Add(sequencemessage);
    Controls.Add(sequenceinputarea);
    Controls.Add(outputinfo);
    Controls.Add(convertToF);
    Controls.Add(convertToC);
    Controls.Add(clear);
    Controls.Add(exitbutton);

    //Register the event handler.  In this case each button has an event handler, but no other 
    //controls have event handlers.
    convertToF.Click += new EventHandler(convertToFahrenheit);
    convertToC.Click += new EventHandler(convertToCelsius);
    clear.Click += new EventHandler(cleartext);
    exitbutton.Click += new EventHandler(stoprun);  //The '+' is required.

   }//End of constructor Fibuserinterface

 //Method to execute when the compute button receives an event, namely: receives a mouse click
 protected void convertToFahrenheit(Object sender, EventArgs events)
   {uint sequencenun = uint.Parse(sequenceinputarea.Text);
    double fahrenheit = convertTemperature.convertFtoC(sequencenun);
    Console.Write("{0:F12}", sequencenun);
    string output = sequencenun + " °C = " + fahrenheit + "°F";
    outputinfo.Text = output;
   }
 protected void convertToCelsius(Object sender, EventArgs events)
 {
 }
 //The following function has been relocated to the file Fibonaccilogic.cs
 //protected ulong computefibonaccinumber(uint sequencenun);
   //{ulong past = 0;
   // ulong present = 1;
   // ulong saved;
   // while(sequencenun > 0)
   //   {saved = past+present;
   //    past = present;
   //    present = saved;
   //    sequencenun--;
   //   }
   // return present;
 //}//End of computefibonaccinumber

 //Method to execute when the clear button receives an event, namely: receives a mouse click
 protected void cleartext(Object sender, EventArgs events)
   {sequenceinputarea.Text = ""; //Empty string
    outputinfo.Text = "Result will display here.";
   }//End of cleartext

 //Method to execute when the exit button receives an event, namely: receives a mouse click
 protected void stoprun(Object sender, EventArgs events)
   {Close();
   }//End of stoprun

}//End of clas Fibuserinterface

