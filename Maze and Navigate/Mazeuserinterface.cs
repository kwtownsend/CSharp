//Standard Header Information for Cpsc223n:
//Author: Kendall Townsend
//Author's email: kendallcar@csu.fullerton.edu
//Course: Cpsc223n
//Assignment number: 4
//Due date: April 7, 2014
//Project name: Mickey Mouse in C Sharp
//Files in project: Mazemain.cs, Mazeuserinterface.cs
//Project purpose:  Generate a maze and navigate it through an AI.  This project demonstrates a commom technique of 
//partitioning the solution into three files: a top level generic driver module, a middle level user interface, and a third level
//algorithms module.  That later module is sometimes called the business logic of the system.
//Project status:  Works correctly with non-negative integer inputs 
//Known bugs: Program crashes if the user input nothing and clicks on "Compute".
//
//This file's name: Mazeuserinterface.cs
//This file purpose: This is a second level module; it defines the user interface window.
//Date last modified: April 6, 2014
//
//There are three files in this program.  They must be compiled in an order that satisfies dependencies.  In this case the correct order is:
//  1. Mazelogic.cs
//  2. Mazeuserinterface.cs
//  3. Mazemain.cs
//
//Function: The Maze generator and logic.  Enter a non-negative sequence integer in the input field, then
//click on new maze to generate maze, and go to start the mouse and pause to stop it.

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class Mazeuserinterface: Form
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

public int xPos = new int();
public int yPos = new int();
public int stepstaken = new int();
public char[,] moves = new char[1000, 1000];
public Label board =  new Label();


 private static System.Timers.Timer myclock = new System.Timers.Timer();

 private Button NewMaze = new Button();
 private Button Go = new Button();
 private Button Pause = new Button();
 private Button Exit = new Button();

 public Mazeuserinterface()
   {
     //Initialize text strings
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
     xPos = 0;
     yPos = 1;
     stepstaken = 0;
    board.Font = new Font("Courier New", 8);

     
    NewMaze.Text = "New Maze";
    Go.Text = "Go";
    Pause.Text = "Pause";
    Exit.Text = "Exit";
    xcoord.Text = "Current x-coord";
    xcoordinput.Text = "";
    ycoord.Text = "Current y-coord";
    ycoordinput.Text = "";
    totalsteps.Text = "Total steps";
    totalstepsinput.Text = "";
    Conclusion.Text = "Conclusion";
    Conclusioninput.Text = "";
    

     
    //Set sizes
    Size = new Size(750,1000);
    title.Size = new Size(300,30);
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
    board.Size = new Size(10000, 10000);



    //Set locations
    title.Location = new Point(140,20);
    Widthmaze.Location = new Point(20, 60);
    Widthinput.Location = new Point(120, 60);
    Heightmaze.Location = new Point(300, 60);
    Heightinput.Location = new Point(400, 60);
    Blocked.Location = new Point(20, 100);
    Blockedinput.Location = new Point(120, 100);
    Speed.Location = new Point(300, 100);
    Speedinput.Location = new Point(400, 100);
    
     NewMaze.Location = new Point(75, 140);
    Go.Location = new Point(175, 140);
    Pause.Location = new Point(275, 140);
    Exit.Location = new Point(370, 140);
    xcoord.Location = new Point(20, 180);
    xcoordinput.Location = new Point(120, 180);
    totalsteps.Location = new Point(300, 180);
    totalstepsinput.Location = new Point(400, 180);
    ycoord.Location = new Point(20, 220);
    ycoordinput.Location = new Point(120, 220);
    Conclusion.Location = new Point(300, 220);
    Conclusioninput.Location = new Point(400, 220);

    board.Location = new Point(20, 260);




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
    Control.CheckForIllegalCrossThreadCalls = false;
    Controls.Add(xcoordinput);
    xcoordinput.Enabled = false;
    
     Controls.Add(ycoord); 
     Controls.Add(ycoordinput);
     ycoordinput.Enabled = false;

     Controls.Add(totalsteps);
     Controls.Add(totalstepsinput);
     totalstepsinput.Enabled = false;

     Controls.Add(Conclusion);
    Controls.Add(Conclusioninput);
    Conclusioninput.Enabled = false;
    
    Controls.Add(board);

     
    //Register the event handler.  In this case each button has an event handler, but no other 
    //controls have event handlers.
  
    NewMaze.Click += new EventHandler(newMaze);
    Go.Click += new EventHandler(startMaze);
    Pause.Click += new EventHandler(pauseTimer);
    Exit.Click += new EventHandler(stoprun);  //The '+' is required.
    myclock.Elapsed += new ElapsedEventHandler(Clockticking);


   }//End of constructor mazeuserinterface

 //Method to execute when the compute button receives an event, namely: receives a mouse click
 protected void newMaze(Object sender, EventArgs events)
   {
     int newheight, newwidth, newblockedinput;
     int newspeedinput;
     double tickspersecond;
     
     tickspersecond = Double.Parse(Speedinput.Text);
     newspeedinput = (int)Math.Round(tickspersecond);
     myclock.Interval = newspeedinput;
     
     yPos = 1;
     xPos = 0;
     
     stepstaken = 0;
     Conclusioninput.Text = "";
     board.Text = "";

     newheight = Convert.ToInt16(Heightinput.Text);
     newwidth = Convert.ToInt16(Widthinput.Text);
     newblockedinput = Convert.ToInt16(Blockedinput.Text);

     

     Random rng = new Random(); 
       for (int i = 0; i < newheight; i++)
       {
           for (int j = 0; j < newwidth; j++)
           {

               if (rng.Next(1, 100) >= (100 - newblockedinput))
               {
                   moves[i, j] = 'X';
               }
               else
               {
                   moves[i, j] = ' ';
               }
           }
       }

     //north line of x's
       for (int i = 0; i < newheight; i++)
       {
           moves[i, 0] = 'X';
       }
     
     //west line of x's
       for (int i = 0; i <= newwidth; i++)
       {
           moves[0, i] = 'X';
       }
     
       //south line of x's
        for (int i = 0; i <= newwidth; i++)
        {
            moves[newheight-1, i] = 'X';
        }
     //east line of x's
        for (int i = 0; i <= newheight; i++)
         {
             moves[i, newwidth-1] = 'X';
         }
      
       moves[1, 0] = ' ';
       moves[1, 1] = ' ';
       moves[newheight-2, newwidth-1] = ' ';
       moves[newheight-2, newwidth-2] = ' ';


       //put char into label
       makeMaze(sender, events);
 

   }

 protected void startMaze(Object sender, EventArgs events)
 {
     myclock.Enabled = true;
 }
    //has problems when the mazes are too large to print them out in time so i put this for when it finishes to get a clean finished maze
 protected void pauseTimer(Object sender, EventArgs events)
 {
     myclock.Enabled = false;     
     makeMaze(sender, events);
 }

//calls upon logic to do the work every tick of the timer
 protected void Clockticking(Object sender, ElapsedEventArgs evt)
 {
     mouseLogic(sender, evt);
     assignValues(sender, evt);
     checkWinner(sender, evt);
     makeMaze(sender, evt);

     //couldn't find alternative way to show maze at each step that wouldnt fall behind
     //makeMaze(sender, evt);
 }

 //Author: Kendall Townsend
 //Author's email: kendallcar@csu.fullerton.edu
 //Course: Cpsc223n
 //Assignment number: 4
 //Due date: April 7, 2014
 //Project name: Mickey Mouse Maze
 //Files in project: Mazemain.cs, Mazelogic.cs, Mazeuserinterface.cs
 //Project purpose:  Generate a user defined maze and solve it.
 //Project status:  Works correctly with non-negative integer inputs.
 //Known bugs: Program crashes if the user input nothing and clicks on "Compute". It also has a threading error for the for loop that prevents 
 //   it from updating fast enough and loses track so I decided to let it run through the maze before it updates it to cause less errors
 //
 //This file's name: Mazelogic.cs
 //This file purpose: This is a third level module; it is called from fibuserinterface.cs.
 //Date last modified: April 6, 2014
 //




    //logic mouse uses to traverse maze
 protected void mouseLogic(Object Sender, EventArgs events)
 {
     // check south
     if (moves[yPos + 1, xPos] == ' ')
     {
         // keep track of the trail
         // by marking it with '.'
         moves[yPos, xPos] = '1';
         moves[yPos + 1, xPos] = 'M';
         yPos++;
     }

     // check east
     else if (moves[yPos, xPos + 1] == ' ')
     {
         moves[yPos, xPos] = '1';
         moves[yPos, xPos + 1] = 'M';
         xPos++;
     }

         //check north
     else if (moves[yPos - 1, xPos] == ' ')
     {
         moves[yPos, xPos] = '1';
         moves[yPos - 1, xPos] = 'M';
         yPos--;
     }
     //check west
     else if (moves[yPos, xPos - 1] == ' ')
     {
         moves[yPos, xPos] = '1';
         moves[yPos, xPos - 1] = 'M';
         xPos--;
     }
     // backtrack
     //check east
     else if (moves[yPos, xPos + 1] == '1')
     {
         moves[yPos, xPos] = '2';
         moves[yPos, xPos + 1] = 'M';
         xPos++;
     }
     //check west
     else if (moves[yPos, xPos - 1] == '1')
     {
         moves[yPos, xPos] = '2';
         moves[yPos, xPos - 1] = 'M';
         xPos--;
     }
     //check north
     else if (moves[yPos - 1, xPos] == '1')
     {
         moves[yPos, xPos] = '2';
         moves[yPos - 1, xPos] = 'M';
         yPos--;
     }
     //check south
     else if (moves[yPos + 1, xPos] == '1')
     {
         moves[yPos, xPos] = '2';
         moves[yPos + 1, xPos] = 'M';
         yPos++;
     }
     //backtrack two
     //check east
     else if (moves[yPos, xPos + 1] == '2')
     {
         moves[yPos, xPos] = '3';
         moves[yPos, xPos + 1] = 'M';
         xPos++;
     }
     //check west
     else if (moves[yPos, xPos - 1] == '2')
     {
         moves[yPos, xPos] = '3';
         moves[yPos, xPos - 1] = 'M';
         xPos--;
     }
     //check north
     else if (moves[yPos - 1, xPos] == '2')
     {
         moves[yPos, xPos] = '3';
         moves[yPos - 1, xPos] = 'M';
         yPos--;
     }
     //check south
     else if (moves[yPos + 1, xPos] == '2')
     {
         moves[yPos, xPos] = '3';
         moves[yPos + 1, xPos] = 'M';
         yPos++;
     }
     //backtrack three
     //check east
     else if (moves[yPos, xPos + 1] == '3')
     {
         moves[yPos, xPos] = '2';
         moves[yPos, xPos + 1] = 'M';
         xPos++;
     }
     //check west
     else if (moves[yPos, xPos - 1] == '3')
     {
         moves[yPos, xPos] = '2';
         moves[yPos, xPos - 1] = 'M';
         xPos--;
     }
     //check north
     else if (moves[yPos - 1, xPos] == '3')
     {
         moves[yPos, xPos] = '2';
         moves[yPos - 1, xPos] = 'M';
         yPos--;
     }
     //check south
     else if (moves[yPos + 1, xPos] == '3')
     {
         moves[yPos, xPos] = '2';
         moves[yPos + 1, xPos] = 'M';
         yPos++;
     }
     //check east
     else if (moves[yPos, xPos + 1] == '2')
     {
         moves[yPos, xPos] = '1';
         moves[yPos, xPos + 1] = 'M';
         xPos++;
     }
     //check west
     else if (moves[yPos, xPos - 1] == '2')
     {
         moves[yPos, xPos] = '1';
         moves[yPos, xPos - 1] = 'M';
         xPos--;
     }
     //check north
     else if (moves[yPos - 1, xPos] == '2')
     {
         moves[yPos, xPos] = '1';
         moves[yPos - 1, xPos] = 'M';
         yPos--;
     }
     //check south
     else if (moves[yPos + 1, xPos] == '2')
     {
         moves[yPos, xPos] = '1';
         moves[yPos + 1, xPos] = 'M';
         yPos++;
     }

     stepstaken++;
 }
    //assign values to the ui
 protected void assignValues(Object sender, EventArgs events)
 {


     totalstepsinput.Text = Convert.ToString(stepstaken);
     xcoordinput.Text = Convert.ToString(xPos+1);
     ycoordinput.Text = Convert.ToString(yPos+1);


 }

    //check to see if maze is impossible or finished
 protected void checkWinner(Object sender, EventArgs events)
 {
     int newheight, newwidth;
     newheight = Convert.ToInt16(Heightinput.Text);
     newwidth = Convert.ToInt16(Widthinput.Text);
     int ycoordinput, xcoordinput;
     ycoordinput = newheight - 1;
     xcoordinput = newwidth - 1;
     int newh = newheight - 2;
     int neww = newwidth - 1;
     if (moves[newh, neww] == 'M')
     {
         myclock.Enabled = false;
         Conclusioninput.Text = "Maze Finished";
         board.Text = "";
         makeMaze(sender, events);
     }
     else if (moves[1, 0] == 'M')
     {
         myclock.Enabled = false;
         Conclusioninput.Text = "Impossible";
         board.Text = "";
         makeMaze(sender, events);

     }


 }

    //print out the maze into the string
 protected void makeMaze(Object sender, EventArgs events)
 {
     int newheight, newwidth;
     string anything;
     anything = "";
     newheight = Convert.ToInt16(Heightinput.Text);
     newwidth = Convert.ToInt16(Widthinput.Text);
     
     board.Text = "";
     
     for(int i = 0; i < newheight; i++)
     {
         for(int j = 0; j < newwidth; j++)
         {
                 anything += moves[i, j];
         }

         anything += '\n';
     }
     board.Text = anything;
 }

 //Method to execute when the exit button receives an event, namely: receives a mouse click
 protected void stoprun(Object sender, EventArgs events)
   {Close();
   }//End of stoprun
     
}//End of clas Mazeuserinterface

