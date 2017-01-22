//Author: Kendall Townsend
//Author's email: Kendallcar@csu.fullerton.edu
//Course: Cpsc223n
//Assignment number: 6
//Due date: May 7, 2014
//Project name: Assignment 6 Pong
//Files in project: Pongmain.cs, Ponglogic.cs, Ponguserinterface.cs
//Project purpose:  Generate Pong Paddles and a  ball that will bounce off of them and when reaches right or left boundaries stops and counts points
//partitioning the solution into three files: a top level generic driver module, a middle level user interface, and a third level
//algorithms module.  That later module is sometimes called the business logic of the system.
//Project status: Works correctly with non-negative integer inputs for speed
//Known bugs:  Program crashes if the user input nothing for speed and clicks new game
//This file's name: Ponguserinterface.cs
//This file purpose: This is a second level module; it defines the user interface window.
//Date last modified: May 4, 2014

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class Ponguserinterface : Form
{

    private Label title = new Label();
    private const int formwidth = 500;
    private const int formheight = 420;
    private const int ballradius = 5;

    private const int paddlelength = 6;
    private const int paddlewidth = 50;
    private const int paddlelength2 = 6;
    private const int paddlewidth2 = 50;

    private int paddlex;  //The x-coordinate of the paddle
    private int paddley;  //The y-coordinate of the paddle
    private int paddle2x;  //The x-coordinate of the paddle
    private int paddle2y;  //The y-coordinate of the paddle

    //private Color backgroundcolor = Color.Green;
    private const double delta = 1;  //Number of pixels traveled in one time unit.  A larger delta
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
    private double clockdelayinterval = (double)System.Math.Round(1000.0 / clocktickspersecond);


    private Label Speed = new Label();
    private TextBox Speedinput = new TextBox();
    private Label Playerleft = new Label();
    private TextBox Playerleftscore = new TextBox();
    private Label Playerright = new Label();
    private TextBox Playerrightscore = new TextBox();

    private Button New = new Button();

    private Button Pause = new Button();
    private Button Exit = new Button();

    public Ponguserinterface()
    {
        KeyPreview = true;
        //Initialize text strings
        Text = "Pong Assignment";
        title.Text = "Pong";
        Speed.Text = "Speed";
        Speedinput.Text = "";
        Playerleft.Text = "Player Left";
        Playerleftscore.Text = "0";
        Playerleftscore.Enabled = false;
        Playerright.Text = "Player Right";
        Playerrightscore.Text = "0";
        Playerrightscore.Enabled = false;
        New.Text = "New Game";

        Pause.Text = "Pause";
        Exit.Text = "Exit";

        //Set sizes
        Size = new Size(500, 550);
        title.Size = new Size(50, 30);

        Speed.Size = new Size(40, 30);
        Speedinput.Size = new Size(75, 30);
        Playerleft.Size = new Size(85, 20);
        Playerleftscore.Size = new Size(85, 30);
        Playerright.Size = new Size(85, 20);
        Playerrightscore.Size = new Size(85, 30);
        New.Size = new Size(85, 30);

        Pause.Size = new Size(85, 30);
        Exit.Size = new Size(85, 30);


        //Set locations
        title.Location = new Point(225, 20);

        Speed.Location = new Point(150, 400);
        Speedinput.Location = new Point(190, 400);
        Playerleft.Location = new Point(20, 440);
        Playerleftscore.Location = new Point(20, 460);
        Playerright.Location = new Point(330, 440);
        Playerrightscore.Location = new Point(330, 460);
        New.Location = new Point(20, 400);

        Pause.Location = new Point(170, 450);
        Exit.Location = new Point(330, 400);

        //Set the default speed of the clock.
        myclock.Interval = 1000; //1 second between ticks.

        //Add controls to the form
        Controls.Add(title);
        Controls.Add(Speed);
        Controls.Add(Speedinput);
        Controls.Add(Playerleft);
        Controls.Add(Playerleftscore);
        Controls.Add(Playerright);
        Controls.Add(Playerrightscore);

        Controls.Add(New);

        Controls.Add(Pause);
        Controls.Add(Exit);
        Control.CheckForIllegalCrossThreadCalls = false;

        paddlex = 400;
        paddley = 200;
        paddle2x = 50;
        paddle2y = 200;


        //Register the event handler.  In this case each button has an event handler, but no other 
        //controls have event handlers.

        New.Click += new EventHandler(newGame);

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
    //Due date: May 7, 2014
    //Project name: Assignment 6 Pong
    //Files in project: Pongmain.cs, Ponglogic.cs, Ponguserinterface.cs
    //Project purpose:  Generate Pong Paddles and a  ball that will bounce off of them and when reaches right or left boundaries stops and counts points
    //partitioning the solution into three files: a top level generic driver module, a middle level user interface, and a third level
    //algorithms module.  That later module is sometimes called the business logic of the system.
    //Project status: Works correctly with non-negative integer inputs for speed
    //Known bugs:  Program crashes if the user input nothing for speed and clicks new game
    //This file's name: Ponglogic.cs
    //This file purpose: This is a third level module; it is called from Ponguserinterface.cs.
    //Date last modified: May 4, 2014


    protected void newGame(Object sender, EventArgs events)
    {
        Random rnd = new Random();
        int rng;
        rng = rnd.Next(0, 360);

        if (rng >= 80 && rng <= 100)
        {
            rng = rng + 10;
        }
        if (rng >= 260 && rng <= 280)
        {
            rng = rng + 10;
        }
        if (Playerrightscore.Text == "Winner" || Playerrightscore.Text == "Loser")
        {
            Playerrightscore.Text = "0";
            Playerleftscore.Text = "0";
        }

        paddlex = 400;
        paddley = 200;
        paddle2x = 50;
        paddle2y = 200;

        thetadegrees = rng;

        thetaradians = System.Math.PI * thetadegrees / degreesinsemicircle;

        clockdelayinterval = Convert.ToDouble(Speedinput.Text);


        myclock.Interval = clockdelayinterval;


        //Set start position of the ball
        ballrealcoordinatex = 200;
        ballrealcoordinatey = 200;
        ballintx = (int)System.Math.Round(ballrealcoordinatex);
        ballinty = (int)System.Math.Round(ballrealcoordinatey);

        //Set the amount of incremental travel in both x and y directions.
        deltax = delta * System.Math.Cos(thetaradians);
        deltay = delta * System.Math.Sin(thetaradians);
        Speedinput.Enabled = false;


        myclock.Enabled = true;
    }

    protected override void OnPaint(PaintEventArgs ee)
    {
        Graphics graph = ee.Graphics;


        graph.FillEllipse(Brushes.Blue, ballintx, ballinty, 2 * ballradius, 2 * ballradius);
        graph.FillRectangle(Brushes.Black, paddlex, paddley, paddlelength, paddlewidth);
        graph.FillRectangle(Brushes.Black, paddle2x, paddle2y, paddlelength2, paddlewidth2);

        /*
        graph.FillRectangle(Brushes.Green, 50, 100, 10, 200); //50 = xcoord, 100 = ycoord, 10 = width, 200 = height 
        graph.FillRectangle(Brushes.Green, 20, 50, 10, 300); //20 = xcoord, 50 = ycoord, 10 = width, 300 = height
        graph.FillRectangle(Brushes.Green, 370, 100, 10, 200);
        graph.FillRectangle(Brushes.Green, 400, 50, 10, 300); // 400 = xcoord, 50 = ycoord, 10 = width, 300 = height
       paddlex = 400; height = 50 width = 6
       paddley = 200;
         400 = xcoord 200 = ycoord 6 = width 50 = height 
     
       paddle2x = 50; height = 50 width = 6
       paddle2y = 200;  
      
        */

        //The next statement looks like recursion, but it really is not recursion.
        //In fact, it calls the method with the same name located in the super class.
        base.OnPaint(ee);
    }
    protected override void OnKeyDown(KeyEventArgs eee)
    {  //This method is called by every key press, but clearly the method performs
        //an action only when one of four keys is pressed: Left arrow, Right arrow,
        //character W, and character S.

        if (eee.KeyCode == Keys.W)
            paddle2y = paddle2y-10;
        else if (eee.KeyCode == Keys.S)
            paddle2y = paddle2y+10;
        else if (eee.KeyCode == Keys.O)
            paddley = paddley-10;
        else if (eee.KeyCode == Keys.L)
           paddley = paddley+10;
        //The next statement is a gimick that creates an event, and that invokes 
        //OnPaint, and that displays an updated graphical image, and that creates 
        //the illusion of motion.
        Invalidate();
        base.OnKeyDown(eee);
    }




    protected void pauseTimer(Object sender, EventArgs events)
    {
        if (myclock.Enabled == true)
        {
            myclock.Enabled = false;
        }
        else
        {
            myclock.Enabled = true;
        }
    }

    //calls upon logic to do the work every tick of the timer
    protected void Clockticking(Object sender, ElapsedEventArgs evt)
    {

        ballrealcoordinatex += deltax;
        ballrealcoordinatey += deltay;
        ballintx = (int)System.Math.Round(ballrealcoordinatex);
        ballinty = (int)System.Math.Round(ballrealcoordinatey);

        if ((ballintx >= 0) && ((ballintx + 2 * ballradius >= 0) && (ballintx + 2 * ballradius <= 450)) && (ballinty >= 0) && (ballinty + 2 * ballradius >= 50 && ballinty + 2 * ballradius <= 50))
        {  //The ball is still within the graphical form, so do something to cause the form to repaint itself.
            thetadegrees = (360 - thetadegrees);
            thetaradians = System.Math.PI * thetadegrees / degreesinsemicircle;
            deltax = delta * System.Math.Cos(thetaradians);
            deltay = delta * System.Math.Sin(thetaradians);
        }
        else if ((ballintx >= 0) && ((ballintx + 2 * ballradius >= 0) && (ballintx + 2 * ballradius <= 450)) && (ballinty >= 0) && (ballinty + 2 * ballradius >= 400 && ballinty + 2 * ballradius <= 400))
        {  //The ball is still within the graphical form, so do something to cause the form to repaint itself.
            thetadegrees = (360 - thetadegrees);
            thetaradians = System.Math.PI * thetadegrees / degreesinsemicircle;
            deltax = delta * System.Math.Cos(thetaradians);
            deltay = delta * System.Math.Sin(thetaradians);
        }
        else if ((ballintx >= 0) && ((ballintx + 2 * ballradius >= (paddlex + 5)) && (ballintx + 2 * ballradius <= (paddlex + paddlelength + 5))) && (ballinty >= 0) && (ballinty + 2 * ballradius >= (paddley + 5) && ballinty + 2 * ballradius <= (paddley + paddlewidth + 5)))
        {  //The ball is still within the graphical form, so do something to cause the form to repaint itself.
            thetadegrees = (180 - thetadegrees);
            thetaradians = System.Math.PI * thetadegrees / degreesinsemicircle;
            deltax = delta * System.Math.Cos(thetaradians);
            deltay = delta * System.Math.Sin(thetaradians);
        }
        else if ((ballintx >= 0) && ((ballintx + 2 * ballradius >= (paddle2x + 5)) && (ballintx + 2 * ballradius <= (paddle2x + paddlelength2 + 5))) && (ballinty >= 0) && (ballinty + 2 * ballradius >= (paddle2y + 5) && ballinty + 2 * ballradius <= (paddle2y + paddlewidth2 + 5)))
        {  //The ball is still within the graphical form, so do something to cause the form to repaint itself.
            thetadegrees = (180 - thetadegrees);
            thetaradians = System.Math.PI * thetadegrees / degreesinsemicircle;
            deltax = delta * System.Math.Cos(thetaradians);
            deltay = delta * System.Math.Sin(thetaradians);
        }
        else if ((ballintx >= 0) && ((ballintx + 2 * ballradius >= 450) && (ballintx + 2 * ballradius <= 450)) && (ballinty >= 0) && (ballinty + 2 * ballradius >= 0 && ballinty + 2 * ballradius <= 400))
        {  //The ball is still within the graphical form, so do something to cause the form to repaint itself.

            if (Playerrightscore.Text == "0")
            {
                Playerrightscore.Text = "1";
            }
            else if (Playerrightscore.Text == "1")
            {
                Playerrightscore.Text = "2";
            }
            else if (Playerrightscore.Text == "2")
            {
                Playerrightscore.Text = "Winner";
                Playerleftscore.Text = "Loser";
            }
            Speedinput.Enabled = true;
            myclock.Enabled = false;
        }
        else if ((ballintx >= 0) && ((ballintx + 2 * ballradius >= 10) && (ballintx + 2 * ballradius <= 10)) && (ballinty >= 0) && (ballinty + 2 * ballradius >= 0 && ballinty + 2 * ballradius <= 400))
        {  //The ball is still within the graphical form, so do something to cause the form to repaint itself.

            if (Playerleftscore.Text == "0")
            {
                Playerleftscore.Text = "1";
            }
            else if (Playerleftscore.Text == "1")
            {
                Playerleftscore.Text = "2";
            }

            else if (Playerleftscore.Text == "2")
            {
                Playerleftscore.Text = "Winner";
                Playerrightscore.Text = "Loser";
            }
            Speedinput.Enabled = true;
            myclock.Enabled = false;
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
    {
        Close();
    }//End of stoprun

}//End of clas Ponguserinterface