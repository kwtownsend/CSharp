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

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class Temperatureuserinterface : Form
{
    private Label title = new Label();

    private Label Widthmaze = new Label();
    private TextBox Widthinput = new TextBox();
    private Label Heightmaze = new Label();
    private TextBox Heightinput = new TextBox();
    private Label Blocked = new Label();
    private TextBox Blockedinput = new TextBox();
    private Label Speed = new Label();
    private TextBox Speedinput = new TextBox();
    private Label xcoord = new Label();
    private TextBox xcoordinput = new TextBox();
    private Label ycoord = new Label();
    private TextBox ycoordinput = new TextBox();
    private Label totalsteps = new Label();
    private TextBox totalstepsinput = new TextBox();
    private Label Conclusion = new Label();
    private TextBox Conclusioninput = new TextBox();

    private Label[][] board = new Label[60][];

    private static System.Timers.Timer myclock = new System.Timers.Timer();

    private Button NewMaze = new Button();
    private Button Go = new Button();
    private Button Pause = new Button();
    private Button Exit = new Button();

    public Temperatureuserinterface()
    {//Initialize text strings
        Text = "Mickey Mouse Assignment";
        title.Text = "Mickey Mouse Maze by Kendall Townsend";
        Widthmaze.Text = "Width";
        Widthinput.Text = "";
        Heightmaze.Text = "Height";
        Heightinput.Text = "";
        Blocked.Text = "Blocked (%)";
        Blockedinput.Text = "";
        Speed.Text = "Speed (ms)";
        Speedinput.Text = "";
        NewMaze.Text = "New Maze";
        Go.Text = "Go";
        Pause.Text = "Pause";
        Exit.Text = "Exit";
        xcoord.Text = "Current x-coord";
        xcoordinput.Text = "";
        xcoordinput.Enabled = false;
        ycoord.Text = "Current y-coord";
        ycoordinput.Text = "";
        ycoordinput.Enabled = false;
        totalsteps.Text = "Total steps";
        totalstepsinput.Text = "";
        totalstepsinput.Enabled = false;
        Conclusion.Text = "Conclusion";
        Conclusioninput.Text = "";
        Conclusioninput.Enabled = false;
        Random rnd = new Random();
        int x;
        for (int i = 0; i < 61; i++)
        {
            for (int j = 0; j < 23; i++)
            {
                x = rnd.Next(1, 99);
                string y = Convert.ToString(x);
                board[i][j].Text = y;
            }
        }

        for (int i = 0; i < 61; i++)
        {
            for (int j = 0; j < 23; j++)
            {
                int a = Convert.ToInt16(board[i][j].Text);
                if (a >= 50)
                {
                    board[i][j].Text = "X";
                }
                else
                {
                    board[i][j].Text = "";
                }
            }
        }
        for (int i = 0; i < 61; i++)
        {
            board[i][0].Text = "X";
        }
        for (int i = 0; i < 23; i++)
        {
            board[0][i].Text = "X";
        }
        for (int i = 0; i < 61; i++)
        {
            board[22][i].Text = "X";
        }
        for (int i = 0; i < 23; i++)
        {
            board[i][60].Text = "X";
        }


        //Set sizes
        Size = new Size(1000, 500);
        title.Size = new Size(200, 30);
        Widthmaze.Size = new Size(100, 30);
        Widthinput.Size = new Size(75, 30);
        Heightmaze.Size = new Size(100, 30);
        Heightinput.Size = new Size(75, 30);
        Blocked.Size = new Size(100, 30);
        Blockedinput.Size = new Size(75, 30);
        Speed.Size = new Size(100, 30);
        Speedinput.Size = new Size(75, 30);
        NewMaze.Size = new Size(85, 30);
        Go.Size = new Size(85, 30);
        Pause.Size = new Size(85, 30);
        Exit.Size = new Size(85, 30);
        xcoord.Size = new Size(100, 30);
        xcoordinput.Size = new Size(75, 30);
        ycoord.Size = new Size(100, 30);
        ycoordinput.Size = new Size(75, 30);
        totalsteps.Size = new Size(100, 30);
        totalstepsinput.Size = new Size(75, 30);
        Conclusion.Size = new Size(100, 30);
        Conclusioninput.Size = new Size(75, 30);
        for (int i = 0; i < 61; i++)
            for (int j = 0; j < 23; j++)
            {
                board[i][j].Size = new Size(10, 10);
            }

        //Set locations
        title.Location = new Point(140, 20);
        Widthmaze.Location = new Point(20, 60);
        Widthinput.Location = new Point(120, 60);
        Heightmaze.Location = new Point(200, 60);
        Heightinput.Location = new Point(300, 60);
        Blocked.Location = new Point(20, 100);
        Blockedinput.Location = new Point(120, 100);
        Speed.Location = new Point(200, 100);
        Speedinput.Location = new Point(300, 100);
        int d = 140;
        for (int i = 0; i < 61; i++)
        {
            int c = 20;
            for (int j = 0; j < 23; j++)
            {
                board[i][j].Location = new Point(c, d);
                c = c + 1;
            }
            d = d + 1;
        }
        NewMaze.Location = new Point(20, d + 40);
        Go.Location = new Point(120, d + 40);
        Pause.Location = new Point(220, d + 40);
        Exit.Location = new Point(320, d + 40);
        xcoord.Location = new Point(20, d + 80);
        xcoordinput.Location = new Point(120, d + 80);
        totalsteps.Location = new Point(300, d + 80);
        totalstepsinput.Location = new Point(400, d + 80);
        ycoord.Location = new Point(20, d + 120);
        ycoordinput.Location = new Point(120, d + 120);
        Conclusion.Location = new Point(300, d + 120);
        Conclusioninput.Location = new Point(400, d + 120);

        //Set the default speed of the clock.
        myclock.Interval = 1000; //1 second between ticks.


        //Add controls to the form
        Controls.Add(title);
        Controls.Add(Widthmaze);
        Controls.Add(Widthinput);
        Controls.Add(Heightmaze);
        Controls.Add(Heightinput);
        Controls.Add(Blocked);
        Controls.Add(Blockedinput);
        Controls.Add(Speed);
        Controls.Add(Speedinput);
        Controls.Add(NewMaze);
        Controls.Add(Go);
        Controls.Add(Pause);
        Controls.Add(Exit);
        Controls.Add(xcoord);
        Controls.Add(xcoordinput);
        Controls.Add(ycoord);
        Controls.Add(ycoordinput);
        Controls.Add(totalsteps);
        Controls.Add(totalstepsinput);
        Controls.Add(Conclusion);
        Controls.Add(Conclusioninput);
        for (int i = 0; i < 61; i++)
            for (int j = 0; j < 23; j++)
            {
                Controls.Add(board[i][j]);
            }


        //Register the event handler.  In this case each button has an event handler, but no other 
        //controls have event handlers.
        NewMaze.Click += new EventHandler(newMaze);
        Go.Click += new EventHandler(startMaze);
        Pause.Click += new EventHandler(pauseTimer);
        Exit.Click += new EventHandler(stoprun);  //The '+' is required.
        myclock.Elapsed += new ElapsedEventHandler(Clockticking);


    }//End of constructor Fibuserinterface

    //Method to execute when the compute button receives an event, namely: receives a mouse click
    protected void newMaze(Object sender, EventArgs events)
    {

    }

    protected void startMaze(Object sender, EventArgs events)
    {

    }

    protected void pauseTimer(Object sender, EventArgs events)
    {

    }

    protected void Clockticking(Object sender, ElapsedEventArgs evt)
    {

    }


    //Method to execute when the exit button receives an event, namely: receives a mouse click
    protected void stoprun(Object sender, EventArgs events)
    {
        Close();
    }//End of stoprun

}//End of clas Fibuserinterface

