//Author: F. Holliday
//Course: CPSC223n
//Last modification: 2012-Aug-01
//Email: activeprofessor@yahoo.com
//File: Timermech.cs
//This program is intended to demonstrate how the timer mechanism works in C-sharp.
//This program does not show good software separation.  This program needs to be partioned into 
//three cohesive files: main, form, and logic.  For those in the Cpsc223n class you should use
//this example only to learn about the class called Timer.  In your homework you still have to 
//make at least 3 source files with good partitioning of the software.  That means the software
//in one file does only one important task.  For example, "define the form" or "start the 
//application" are important individual tasks.

//References used: Deitel, Visual C# 2008, pp 791-792.
//http://www.dijksterhuis.org/using-timers-in-c#/
//For help using Windows Forms inside Mono go to http://zetcode.com/tutorials/monowinformstutorial/
//For general help programming in C# visit http://zetcode.com/language/csharptutorial/

//Compile: gmcs -r:System.Windows.Forms.dll -r:System.Drawing.dll Timermech.cs -out:Random.exe

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class Timermech : Form  //Timermech inherits from Form
{
    private Label randomnumberdescription = new Label();
    private TextBox randombox = new TextBox();
    private Label speedlabel = new Label();
    private TextBox speedinput = new TextBox();
    private Label units = new Label();
    private Button start = new Button();
    private Button pause = new Button();
    private Button exit = new Button();
    private static System.Timers.Timer myclock = new System.Timers.Timer();
    private Random randomintegergenerator = new Random();
    private const int smallestrandomnumber = 0;
    private const int largestrandomnumber = 99;

    public Timermech()   //The constructor of this class
    {
        
        
        Text = "Random Integers";
        CenterToScreen();  //Open this form in the center of the monitor.
        randomnumberdescription.Text = "Random:";
        randombox.Text = ""; //Empty string
        speedlabel.Text = "Speed:";
        speedinput.Text = "";
        units.Text = "t/s";
        start.Text = "Start";
        pause.Text = "Pause";
        exit.Text = "Close";
    
        
        //Set the various sizes
        Size = new Size(390, 190);
        randomnumberdescription.Size = new Size(155, 20);
        randombox.Size = new Size(150, 30);
        speedlabel.Size = new Size(155, 20);
        speedinput.Size = new Size(150, 30);
        units.Size = new Size(40, 20);
        start.Size = new Size(100, 30);
        pause.Size = new Size(100, 30);
        exit.Size = new Size(100, 30);
        
        
        //Set the default speed of the clock.
        myclock.Interval = 1000; //200 milliseconds between ticks.
        
        
        //Set the locations of different objects
        randomnumberdescription.Location = new Point(15, 20);
        randombox.Location = new Point(15 + randomnumberdescription.Width + 10, 20);
        speedlabel.Location = new Point(15, 50);
        speedinput.Location = new Point(15 + speedlabel.Width + 10, 50);
        units.Location = new Point(15 + speedlabel.Width + 10 + speedinput.Width + 10, 50);
        start.Location = new Point(15, 110);
        pause.Location = new Point(15 + start.Width + 10, 110);
        exit.Location = new Point(15 + start.Width + 10 + pause.Width + 10, 110);
        
        
        //Enable or disable the controls
        randomnumberdescription.Enabled = false;
        randombox.Enabled = false;
        speedlabel.Enabled = false;
        speedinput.Enabled = true;
        units.Enabled = false;
        start.Enabled = true;
        pause.Enabled = true;
        exit.Enabled = true;
        myclock.Enabled = false; //The clock is off initially.
        
        
        //Add the control to this form.
        Controls.Add(randomnumberdescription);
        Controls.Add(randombox);
        Controls.Add(speedlabel);
        Controls.Add(speedinput);
        Controls.Add(units);
        Controls.Add(start);
        Controls.Add(pause);
        Controls.Add(exit);
        
        
        //Register the event handler(s).
        start.Click += new EventHandler(Startbutton);
        pause.Click += new EventHandler(Pausebutton);
        exit.Click += new EventHandler(Exitbutton);
        myclock.Elapsed += new ElapsedEventHandler(Clockticking);
        myclock.Disposed += new EventHandler(Clockgone);   //<== Needs research: What does this do?

        //Bug: myclock.Tic += new EventHandler(Clockticking);
    }//End of constructor

    protected void Startbutton(Object sender, EventArgs evt)
    {
        double tickspersecond;
        int intervalbetweenticks;
        tickspersecond = Double.Parse(speedinput.Text);
        intervalbetweenticks = (int)Math.Round(1000.0 * tickspersecond);
        start.Text = "Start";
       // myclock.Interval = intervalbetweenticks;
        myclock.Enabled = true;
        myclock.Interval = 1;
        myclock.Interval = intervalbetweenticks;
    }

    protected void Pausebutton(Object sender, EventArgs evt)
    {
        myclock.Enabled = false;
        start.Text = "Resume";
        //Waiting for the programmer.
    }

    protected void Exitbutton(Object sender, EventArgs evt)
    {
        myclock.Enabled = false;
        myclock.Dispose();  //Deallocate space held by the clock and return that space to free memory.
        Close();  //This one statement closes the form created from the Timermech class
    }

    protected void Clockticking(Object sender, ElapsedEventArgs evt)
    {
        int number = randomintegergenerator.Next(smallestrandomnumber, largestrandomnumber);
        randombox.Text = number.ToString();
        Console.WriteLine("The clock ticked and the time is {0}", evt.SignalTime);  //Debug statement; remove it later.
    }

    //The next one is a debug method.  Turn off this method when everything works correctly.
    protected void Clockgone(Object sender, EventArgs evt)
    {
        Console.WriteLine("My clock was deallocated");
    }

    protected void Clearbutton(Object sender, EventArgs evt)
    {
        randombox.Text = "";  //Empty string
        speedinput.Text = ""; //Empty string
    }

    static void Main()
    {
        Application.Run(new Timermech());
    }
}//End of class Timermech