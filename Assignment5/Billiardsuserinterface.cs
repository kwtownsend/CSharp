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
//Function: The Maze generator and logic.  Enter a non-negative sequence integer in the input field, then
//click on new maze to generate new speed and direcrtion and the ball will bounce on rectangles until it reaches out of bounds and stop.
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class Billiardsuserinterface: Form
{
 private Label title = new Label();
 private const int formwidth = 500;
 private const int formheight = 420;
 private const int ballradius = 5;
 //private Color backgroundcolor = Color.Green;
 private const double delta = 0.81;  //Number of pixels traveled in one time unit.  A larger delta
 //will increase speed at the expense of more jerkiness.
 private double thetadegrees;  //Number of degrees in direction of travel relative to the horizontal.
 //Be aware that in computer graphics a positive angle slopes downward.
 private const double degreesinsemicircle = 180.0;
 private double thetaradians;
 private double ballrealcoordinatex;  //Ball's x coordinate measured in real numbers
 private double ballrealcoordinatey;  //Ball's y coordinate measured in real numbers
 private double deltax;  //Amount of change in x direction per clock cycle
 private double deltay;  //Amount of change in y direction per clock cycle
 private int ballintx = 200;   //The integer x-coordinate of the ball
 private int ballinty = 200;   //The integer y-coordinate of the ball
 //Declare the clock
 private static System.Timers.Timer myclock = new System.Timers.Timer();
 private const double clocktickspersecond = 7.5;  //Increasing the clock speed will increase the speed of ball.
 //Eventually you will max out at the top speed of your CPU.
 private int clockdelayinterval = (int)System.Math.Round(1000.0 / clocktickspersecond);


 private Label Speed = new Label();
 private TextBox Speedinput = new TextBox();
 private Label Direction = new Label();
 private TextBox Directioninput = new TextBox();

 private Button New = new Button();
 private Button Go = new Button();
 private Button Pause = new Button();
 private Button Exit = new Button();

 public Billiardsuserinterface()
   {
     //Initialize text strings
    Text = "Billiards Assignment";
    title.Text = "Billiards";
    Speed.Text = "Speed";
    Speedinput.Text = "";
    Direction.Text = "Direction";
    Directioninput.Text = "";
   
    New.Text = "New";
    Go.Text = "Go";
    Pause.Text = "Pause";
    Exit.Text = "Quit";
 
    //Set sizes
    Size = new Size(450,550);
    title.Size = new Size(50,30);
    
    Speed.Size = new Size(40, 30);
    Speedinput.Size = new Size(75, 30);
    Direction.Size = new Size(60, 30);
    Directioninput.Size = new Size(75, 30);
    New.Size = new Size(85, 30);
    Go.Size = new Size(85, 30);
    Pause.Size = new Size(85, 30);
    Exit.Size = new Size(85, 30);


    //Set locations
    title.Location = new Point(140,20);
    
    Speed.Location = new Point(20, 400);
    Speedinput.Location = new Point(60, 400);
    Direction.Location = new Point(220, 400);
    Directioninput.Location = new Point(280, 400);

    New.Location = new Point(20, 450);
    Go.Location = new Point(125, 450);
    Pause.Location = new Point(220, 450);
    Exit.Location = new Point(315, 450);

    //Set the default speed of the clock.
    myclock.Interval = 1000; //1 second between ticks.

    //Add controls to the form
    Controls.Add(title);
    Controls.Add(Speed);
    Controls.Add(Speedinput);
    Controls.Add(Direction);
    Controls.Add(Directioninput);

    Controls.Add(New);
    Controls.Add(Go);
    Controls.Add(Pause);
    Controls.Add(Exit);
    Control.CheckForIllegalCrossThreadCalls = false;
    

     
    //Register the event handler.  In this case each button has an event handler, but no other 
    //controls have event handlers.
  
    New.Click += new EventHandler(newGame);
    Go.Click += new EventHandler(start);
    Pause.Click += new EventHandler(pauseTimer);
    Exit.Click += new EventHandler(stoprun);  //The '+' is required.
    myclock.Elapsed += new ElapsedEventHandler(Clockticking);
    myclock.Disposed += new System.EventHandler(Clockgone);

   }//End of constructor mazeuserinterface

 //Method to execute when the compute button receives an event, namely: receives a mouse click


 //Author: Kendall Townsend
 //Author's email: Kendallcar@csu.fullerton.edu
 //Course: Cpsc223n
 //Assignment number: 6
 //Due date: April 21, 2014
 //Project name: Assignment 5 Billiards
 //Files in project: Billiardsmain.cs, Billiardslogic.cs, Billiardsuserinterface.cs
 //Project purpose:  Generate walls and a billiard ball that will bounce off of them and when reaches boundaries stops
 //partitioning the solution into three files: a top level generic driver module, a middle level user interface, and a third level
 //algorithms module.  That later module is sometimes called the business logic of the system.
 //Project status: Works correctly with non-negative integer inputs for speed
 //Known bugs:  Program crashes if the user input nothing for speed and clicks new maze/go
 //This file's name: Billiardsilogic.cs
 //This file purpose: This is a third level module; it is called from Billiardsuserinterface.cs.
 //Date last modified: April 20, 2014


 protected void newGame(Object sender, EventArgs events)
   {
       thetadegrees = Convert.ToDouble(Directioninput.Text);

       thetaradians = System.Math.PI * thetadegrees / degreesinsemicircle;

       clockdelayinterval = Convert.ToInt16(Speedinput.Text);
       //clockdelayinterval = (int)System.Math.Round(1000.0 / clocktickspersecond);

       myclock.Interval = clockdelayinterval;


       //Set start position of the ball
       ballrealcoordinatex = 200;
       ballrealcoordinatey = 200;
       ballintx = (int)System.Math.Round(ballrealcoordinatex);
       ballinty = (int)System.Math.Round(ballrealcoordinatey);
       
     //Set the amount of incremental travel in both x and y directions.
       deltax = delta * System.Math.Cos(thetaradians);
       deltay = delta * System.Math.Sin(thetaradians);
   }

 protected override void OnPaint(PaintEventArgs ee)
 {
     Graphics graph = ee.Graphics;
     graph.FillEllipse(Brushes.Blue, ballintx, ballinty, 2 * ballradius, 2 * ballradius);
     graph.FillRectangle(Brushes.Green, 50, 100, 10, 200); //50 = xcoord, 100 = ycoord, 10 = width, 200 = height
     graph.FillRectangle(Brushes.Green, 20, 50, 10, 300); //20 = xcoord, 50 = ycoord, 10 = width, 300 = height
     graph.FillRectangle(Brushes.Green, 370, 100, 10, 200);
     graph.FillRectangle(Brushes.Green, 400, 50, 10, 300);

     //The next statement looks like recursion, but it really is not recursion.
     //In fact, it calls the method with the same name located in the super class.
     base.OnPaint(ee);
 }

 protected void start(Object sender, EventArgs events)
 {
     myclock.Enabled = true;
 }
  
    
    protected void pauseTimer(Object sender, EventArgs events)
 {
     myclock.Enabled = false;     
 }

//calls upon logic to do the work every tick of the timer
 protected void Clockticking(Object sender, ElapsedEventArgs evt)
 {

     ballrealcoordinatex += deltax;
     ballrealcoordinatey += deltay;
     ballintx = (int)System.Math.Round(ballrealcoordinatex);
     ballinty = (int)System.Math.Round(ballrealcoordinatey);

     if ((ballintx >= 0) && ((ballintx + 2 * ballradius >= 55) && (ballintx + 2 * ballradius <= 65)) && (ballinty >= 0) && (ballinty + 2 * ballradius >= 100 && ballinty + 2 * ballradius <= 300))
     {  //The ball is still within the graphical form, so do something to cause the form to repaint itself.
         thetadegrees = (180 - thetadegrees);
         thetaradians = System.Math.PI * thetadegrees / degreesinsemicircle;
         deltax = delta * System.Math.Cos(thetaradians);
         deltay = delta * System.Math.Sin(thetaradians);
     }
     else if ((ballintx >= 0) && ((ballintx + 2 * ballradius >= 25) && (ballintx + 2 * ballradius <= 35)) && (ballinty >= 0) && (ballinty + 2 * ballradius >= 50 && ballinty + 2 * ballradius <= 350))
     {  //The ball is still within the graphical form, so do something to cause the form to repaint itself.
         thetadegrees = (180 - thetadegrees);
         thetaradians = System.Math.PI * thetadegrees / degreesinsemicircle;
         deltax = delta * System.Math.Cos(thetaradians);
         deltay = delta * System.Math.Sin(thetaradians);
     }
     else if ((ballintx >= 0) && ((ballintx + 2 * ballradius >= 405) && (ballintx + 2 * ballradius <= 415)) && (ballinty >= 0) && (ballinty + 2 * ballradius >= 50 && ballinty + 2 * ballradius <= 350))
     {  //The ball is still within the graphical form, so do something to cause the form to repaint itself.
         if (thetadegrees == 0)
         {
             thetadegrees = (180 + thetadegrees);
         }
         else
         {
             thetadegrees = (180 - thetadegrees);
         }
         thetaradians = System.Math.PI * thetadegrees / degreesinsemicircle;
         deltax = delta * System.Math.Cos(thetaradians);
         deltay = delta * System.Math.Sin(thetaradians);
     }
     else if ((ballintx >= 0) && ((ballintx + 2 * ballradius >= 375) && (ballintx + 2 * ballradius <= 385)) && (ballinty >= 0) && (ballinty + 2 * ballradius >= 100 && ballinty + 2 * ballradius <= 300))
     {  //The ball is still within the graphical form, so do something to cause the form to repaint itself.
         if (thetadegrees == 0)
         {
             thetadegrees = (180 + thetadegrees);
         }
         else
         {
             thetadegrees = (180 - thetadegrees);
         }
         thetaradians = System.Math.PI * thetadegrees / degreesinsemicircle;
         deltax = delta * System.Math.Cos(thetaradians);
         deltay = delta * System.Math.Sin(thetaradians);
     }
     else if ((ballintx >= 0) && (ballintx + 2 * ballradius < Width) && (ballinty >= 0) && (ballinty + 2 * ballradius < 400))
     {
         Invalidate();  //Stupid: This creates an artificial event so that the graphic area will repaint itself.
         System.Console.WriteLine("The clock ticked and the time is {0}", evt.SignalTime);  //Debug statement; remove it later.
     }
     else
     {
         myclock.Enabled = false;
     }


 }

 protected void Clockgone(System.Object sender, System.EventArgs evt)
 {
     System.Console.WriteLine("My clock was deallocated");
 }

 //Method to execute when the exit button receives an event, namely: receives a mouse click
 protected void stoprun(Object sender, EventArgs events)
   {Close();
   }//End of stoprun
     
}//End of clas Billiardsuserinterface

