//Kendall Townsend
//kendallcar@csu.fullerton.edu
//Cpsc 223N
//May 12, 2014
//Final Exam


using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class Stationaryball : Form
{
    private const int formwidth = 1000;
    private const int formheight = 1000;
    private const int sunradius = 25;
    private const int earthradius = 15;
    private int counter = 0;
    private Color backgroundcolor = Color.Black;
    private const double delta = 0.81;  //Number of pixels traveled in one time unit.  A larger delta
    //will increase speed at the expense of more jerkiness.
    private double thetadegrees = 0;  //Number of degrees in direction of travel relative to the horizontal.
    //Be aware that in computer graphics a positive angle slopes downward.
    private const double degreesinsemicircle = 360.0;
    private double thetaradians;
    private double earthrealcoordinatex;  //Ball's x coordinate measured in real numbers
    private double earthrealcoordinatey;  //Ball's y coordinate measured in real numbers
    private double deltax;  //Amount of change in x direction per clock cycle
    private double deltay;  //Amount of change in y direction per clock cycle
    private int sunintx= 450;   //The integer x-coordinate of the ball
    private int suninty = 300;   //The integer y-coordinate of the ball
    private int earthintx = 400;
    private int earthinty= 400;
    int cycle = 0;
    //Declare the clock
    private static System.Timers.Timer myclock = new System.Timers.Timer();
    private const double clocktickspersecond = 7.5;  //Increasing the clock speed will increase the speed of ball.
    //Eventually you will max out at the top speed of your CPU.
    private int clockdelayinterval = 50;

    public Stationaryball()   //The constructor of this class
    {
        Text = "Earth around the Sun";
        //Set the initial size of this form
        Size = new Size(formwidth, formheight);
        //Set the background color of this form
        BackColor = backgroundcolor;
        //Set start position of the ball
        earthrealcoordinatex = 400;
        earthrealcoordinatey = 400;
        earthintx = (int)System.Math.Round(earthrealcoordinatex);
        earthinty = (int)System.Math.Round(earthrealcoordinatey);
        //Set the amount of incremental travel in both x and y directions.

        //Set up the clock
        myclock.Interval = clockdelayinterval;
        myclock.Enabled = true; //The clock is on from the start of the run.
        //Register event handlers
        myclock.Elapsed += new ElapsedEventHandler(Clockticking);
        myclock.Disposed += new System.EventHandler(Clockgone);   //<== Needs research: What does this do?
    }//End of constructor

    protected override void OnPaint(PaintEventArgs ee)
    {
        Graphics graph = ee.Graphics;

        graph.FillEllipse(Brushes.Red, sunintx, suninty, 2 * sunradius, 2 * sunradius);
     

        if (cycle >= 0 && cycle < 10)
        {
            graph.FillEllipse(Brushes.Blue, earthintx, earthinty, 2 * earthradius, 2 * earthradius);
        }
        if (cycle >= 10 && cycle < 20)
        {
            graph.FillEllipse(Brushes.Red, earthintx, earthinty, 2 * earthradius, 2 * earthradius);
        }
        if (cycle >= 20 && cycle < 30)
        {
            graph.FillEllipse(Brushes.Orange, earthintx, earthinty, 2 * earthradius, 2 * earthradius);
        }
        if (cycle >= 30 && cycle < 40)
        {
            graph.FillEllipse(Brushes.Green, earthintx, earthinty, 2 * earthradius, 2 * earthradius);
        }
        if (cycle >= 40 && cycle < 50)
        {
            graph.FillEllipse(Brushes.Cyan, earthintx, earthinty, 2 * earthradius, 2 * earthradius);
            if (cycle == 49)
            {
                cycle = 0;
            }
        }
        
        //The next statement looks like recursion, but it really is not recursion.
        //In fact, it calls the method with the same name located in the super class.
        base.OnPaint(ee);
    }

    protected void Clockticking(System.Object sender, ElapsedEventArgs evt)
    {
        //thetadegrees = 200 + (25 * System.Math.Cos(.001 * counter));
        thetaradians = System.Math.PI * thetadegrees / degreesinsemicircle;
        
        //deltax = delta * System.Math.Cos(thetaradians);
        //deltay = delta * System.Math.Sin(thetaradians);

        deltax =450 +(System.Math.Cos(.01*counter) * 300);
        deltay =300 +(System.Math.Sin(.01*counter) * 300);

        earthrealcoordinatex = deltax;
        earthrealcoordinatey = deltay;
        /*
        deltax = delta * System.Math.Cos(thetaradians);
        deltay = delta * System.Math.Sin(thetaradians);
        */
        /*
        earthintx = (int)System.Math.Round(earthrealcoordinatex);
        earthinty = (int)System.Math.Round(earthrealcoordinatey);
        */

        earthintx = (int)System.Math.Round(earthrealcoordinatex);
        earthinty = (int)System.Math.Round(earthrealcoordinatey);

        //The ball is still within the graphical form, so do something to cause the form to repaint itself.
        Invalidate();  //Stupid: This creates an artificial event so that the graphic area will repaint itself.
        System.Console.WriteLine("The clock ticked and the time is {0}", evt.SignalTime);  //Debug statement; remove it later.
        cycle++;
        counter++;
    }//End of method Clockticking

    //The next one is a debug method.  Turn off this method when everything works correctly.
    protected void Clockgone(System.Object sender, System.EventArgs evt)
    {
        System.Console.WriteLine("My clock was deallocated");
    }

    public static void Main()
    {
        Application.Run(new Stationaryball());
    }
}//End of class Stationaryball

