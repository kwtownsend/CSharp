//Standard Header Information for Cpsc223n:
//Author: Kendall Townsend
//Author's email: kendallcar@csu.fullerton.edu
//Course: Cpsc223n
//Assignment number: 3
//Due date: March 12, 2014
//Project name: Assignment 3 tic tac toe
//Files in project: tictactoemain.cs, tictactoelogic.cs, tictactoeuserinterface.cs
//Project purpose:  Play tic tac toe and have the computer intelligently block the player from winning and print out the resulting winner and
//partitioning the solution into three files: a top level generic driver module, a middle level user interface, and a third level
//algorithms module.  That later module is sometimes called the business logic of the system.
//Project status:  Only known problem is after the player wins it still has to go through a cycle and the computer will play an extra move that has no effect on the results
//Known bugs: Program crashes if the user input nothing and clicks on "Start Game".
//
//This file's name: tictactoeuserinterface.cs
//This file purpose: This is a second level module; it defines the user interface window.
//Date last modified: March 10, 2014
//
//There are three files in this program.  They must be compiled in an order that satisfies dependencies.  In this case the correct order is:
//  1. tictactoelogic.cs
//  2. tictactoeuserinterface.cs
//  3. tictactoemain.cs
//
//
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class TicTacToeuserinterface: Form
{private Label title = new Label();

    private TextBox one = new TextBox();
    private TextBox two = new TextBox();
    private TextBox three = new TextBox();
    private TextBox four = new TextBox();
    private TextBox five = new TextBox();
    private TextBox  six = new TextBox();
    private TextBox seven = new TextBox();
    private TextBox eight = new TextBox();
    private TextBox nine = new TextBox();
    private TextBox ten = new TextBox();
    private TextBox eleven = new TextBox();
    private TextBox twelve = new TextBox();
    private TextBox thirteen = new TextBox();
    private TextBox fourteen = new TextBox();
    private TextBox fifteen = new TextBox();
    private TextBox sixteen = new TextBox();
    private TextBox seventeen = new TextBox();
    private TextBox eighteen = new TextBox();
    private TextBox nineteen = new TextBox();
    private TextBox  twenty = new TextBox();
    private TextBox  twentyone = new TextBox();
    private TextBox  twentytwo = new TextBox();
    private TextBox  twentythree = new TextBox();
    private TextBox  twentyfour = new TextBox();
    private TextBox  twentyfive = new TextBox();

 private static System.Timers.Timer myclock = new System.Timers.Timer();

 private RadioButton startingplayerperson = new RadioButton();
 private RadioButton startingplayercomputer = new RadioButton();
 
 private Label startingplayerlabel = new Label();
 private Label maxsecondlabel = new Label();
 private TextBox maxseconds = new TextBox();
 private Label winnerlabel = new Label();

 private Button startgame = new Button();
 private Button clear = new Button();
 private Button quitbutton = new Button();

 public TicTacToeuserinterface()
   {//Initialize text strings
    Text = "Tic Tac Toe";
    title.Text = "Tic Tac Toe";
    
     one.Text = "";
    two.Text = "";
    three.Text = "";
    four.Text = "";
    five.Text = "";
    six.Text = "";
    seven.Text = "";
    eight.Text = "";
    nine.Text = "";
    ten.Text = "";
    eleven.Text = "";
    twelve.Text = "";
    thirteen.Text = "";
    fourteen.Text = "";
    fifteen.Text = "";
    sixteen.Text = "";
    seventeen.Text = "";
    eighteen.Text = "";
    nineteen.Text = "";
    twenty.Text = "";
    twentyone.Text = "";
    twentytwo.Text = "";
    twentythree.Text = "";
    twentyfour.Text = "";
    twentyfive.Text = "";
    startingplayerlabel.Text = "Starting Player";
    startingplayerperson.Text = "Person";
    startingplayercomputer.Text = "Computer";
    maxsecondlabel.Text = "Max Seconds (1-10)";
    maxseconds.Text = "";
    winnerlabel.Text = "";
    startgame.Text = "Start Game";
    clear.Text = "Clear";
    quitbutton.Text = "Quit";
    
    //Set sizes
    Size = new Size(500,400);
    one.Size = new Size(25, 25);
    two.Size = new Size(25, 25);
    three.Size = new Size(25, 25);
    four.Size = new Size(25, 25);
    five.Size = new Size(25, 25);
    six.Size = new Size(25, 25);
    seven.Size = new Size(25, 25);
    eight.Size = new Size(25, 25);
    nine.Size = new Size(25, 25);
    ten.Size = new Size(25, 25);
    eleven.Size = new Size(25, 25);
    twelve.Size = new Size(25, 25);
    thirteen.Size = new Size(25, 25);
    fourteen.Size = new Size(25, 25);
    fifteen.Size = new Size(25, 25);
    sixteen.Size = new Size(25, 25);
    seventeen.Size = new Size(25, 25);
    eighteen.Size = new Size(25, 25);
    nineteen.Size = new Size(25, 25);
    twenty.Size = new Size(25, 25);
    twentyone.Size = new Size(25, 25);
    twentytwo.Size = new Size(25, 25);
    twentythree.Size = new Size(25, 25);
    twentyfour.Size = new Size(25, 25);
    twentyfive.Size = new Size(25, 25);
    startingplayerlabel.Size = new Size(100, 30);
    startingplayerperson.Size = new Size(85, 30);
    startingplayercomputer.Size = new Size(85, 30);
    maxsecondlabel.Size = new Size(125, 30);
    maxseconds.Size = new Size(75, 30);
    winnerlabel.Size = new Size(75, 30);
    clear.Size = new Size(85, 30);
    startgame.Size = new Size(85, 30);
    quitbutton.Size = new Size(85, 30);
     
     
     //Set locations
    title.Location = new Point(140,20);
    one.Location = new Point(120,60);
    two.Location = new Point(145, 60);
    three.Location = new Point(170, 60);
    four.Location = new Point(195, 60);
    five.Location = new Point(220, 60);
    six.Location = new Point(120, 85);
    seven.Location = new Point(145, 85);
    eight.Location = new Point(170, 85);
    nine.Location = new Point(195, 85);
    ten.Location = new Point(220, 85);
    eleven.Location = new Point(120, 110);
    twelve.Location = new Point(145, 110);
    thirteen.Location = new Point(170, 110);
    fourteen.Location = new Point(195, 110);
    fifteen.Location = new Point(220, 110);
    sixteen.Location = new Point(120, 135);
    seventeen.Location = new Point(145, 135);
    eighteen.Location = new Point(170, 135);
    nineteen.Location = new Point(195, 135);
    twenty.Location = new Point(220, 135);
    twentyone.Location = new Point(120, 160);
    twentytwo.Location = new Point(145, 160);
    twentythree.Location = new Point(170, 160);
    twentyfour.Location = new Point(195, 160);
    twentyfive.Location = new Point(220, 160);
    startingplayerlabel.Location = new Point(150, 200);
    maxsecondlabel.Location = new Point(300, 200);
    clear.Location = new Point(20, 250);
    startingplayerperson.Location = new Point(110, 250);
    startingplayercomputer.Location = new Point(210, 250);
    maxseconds.Location = new Point(300, 250);
    winnerlabel.Location = new Point(20, 300);
    startgame.Location = new Point(210, 300);
    quitbutton.Location = new Point(300, 300);

    //Set the default speed of the clock.
    myclock.Interval = 1000; //1 second between ticks.

     //enable or disable controls
    one.Enabled = false;
    two.Enabled = false;
    three.Enabled = false;
    four.Enabled = false;
    five.Enabled = false;
    six.Enabled = false;
    seven.Enabled = false;
    eight.Enabled = false;
    nine.Enabled = false;
    ten.Enabled = false;
    eleven.Enabled = false;
    twelve.Enabled = false;
    thirteen.Enabled = false;
    fourteen.Enabled = false;
    fifteen.Enabled = false;
    sixteen.Enabled = false;
    seventeen.Enabled = false;
    eighteen.Enabled = false;
    nineteen.Enabled = false;
    twenty.Enabled = false;
    twentyone.Enabled = false;
    twentytwo.Enabled = false;
    twentythree.Enabled = false;
    twentyfour.Enabled = false;
    twentyfive.Enabled = false;
    myclock.Enabled = false; // the clock is off initially



    //Add controls to the form
    Controls.Add(title);
    Controls.Add(one);
    Controls.Add(two);
    Controls.Add(three);
    Controls.Add(four);
    Controls.Add(five);
    Controls.Add(six);
    Controls.Add(seven);
    Controls.Add(eight);
    Controls.Add(nine);
    Controls.Add(ten);
    Controls.Add(eleven);
    Controls.Add(twelve);
    Controls.Add(thirteen);
    Controls.Add(fourteen);
    Controls.Add(fifteen);
    Controls.Add(sixteen);
    Controls.Add(seventeen);
    Controls.Add(eighteen);
    Controls.Add(nineteen);
    Controls.Add(twenty);
    Controls.Add(twentyone);
    Controls.Add(twentytwo);
    Controls.Add(twentythree);
    Controls.Add(twentyfour);
    Controls.Add(twentyfive);
    Controls.Add(startingplayerlabel);
    Controls.Add(maxsecondlabel);
    Controls.Add(clear);
    Controls.Add(startingplayerperson);
    Controls.Add(startingplayercomputer);
    Controls.Add(maxseconds);
    Controls.Add(winnerlabel);
    Controls.Add(startgame);
    Controls.Add(quitbutton);
    Controls.Add(clear);

    //Register the event handler.  In this case each button has an event handler, but no other 
    //controls have event handlers.
    startgame.Click += new EventHandler(StartGame);
    clear.Click += new EventHandler(cleartext);
    quitbutton.Click += new EventHandler(stoprun);  //The '+' is required.
    myclock.Elapsed += new ElapsedEventHandler(Clockticking);

   }//End of constructor Fibuserinterface

 //Method to execute when the compute button receives an event, namely: receives a mouse click
 protected void StartGame(Object sender, EventArgs events)
   {
       double tickspersecond;
       int intervalbetweenticks;
       tickspersecond = Double.Parse(maxseconds.Text);
       intervalbetweenticks = (int)Math.Round(1000.0 * tickspersecond);
       myclock.Interval = intervalbetweenticks;

     
       one.Enabled = true;
       two.Enabled = true;
       three.Enabled = true;
       four.Enabled = true;
       five.Enabled = true;
       six.Enabled = true;
       seven.Enabled = true;
       eight.Enabled = true;
       nine.Enabled = true;
       ten.Enabled = true;
       eleven.Enabled = true;
       twelve.Enabled = true;
       thirteen.Enabled = true;
       fourteen.Enabled = true;
       fifteen.Enabled = true;
       sixteen.Enabled = true;
       seventeen.Enabled = true;
       eighteen.Enabled = true;
       nineteen.Enabled = true;
       twenty.Enabled = true;
       twentyone.Enabled = true;
       twentytwo.Enabled = true;
       twentythree.Enabled = true;
       twentyfour.Enabled = true;
       twentyfive.Enabled = true;

       if (startingplayercomputer.Checked == true)
       {
           thirteen.Text = "C";
           thirteen.Enabled = false;
           myclock.Enabled = true;
       }
       else
       {
           myclock.Enabled = true;
       }
 }

 protected void Clockticking(Object sender, ElapsedEventArgs evt)
 {
         bool one1 = false, two2 = false, three3 = false, four4 = false, five5 = false, six6 = false, seven7 = false, eight8 = false, nine9 = false,
             ten10 = false, eleven11 = false, twelve12 = false, thirteen13 = false, fourteen14 = false, fifteen15 = false, sixteen16 = false,
             seventeen17 = false, eighteen18 = false, nineteen19 = false, twenty20 = false, twentyone21 = false, twentytwo22 = false, twentythree23 = false, twentyfour24 = false, twentyfive25 = false;



         if (one.Text == "P" || one.Text == "C")
         { one.Enabled = false; one1 = true; }
         if (two.Text == "P" || two.Text == "C")
         { two.Enabled = false; two2 = true; }
         if (three.Text == "P" || three.Text == "C")
         { three.Enabled = false; three3 = true; }
         if (four.Text == "P" || four.Text == "C")
         { four.Enabled = false; four4 = true; }
         if (five.Text == "P" || five.Text == "C")
         { five.Enabled = false; five5 = true; }
         if (six.Text == "P" || six.Text == "C")
         { six.Enabled = false; six6 = true; }
         if (seven.Text == "P" || seven.Text == "C")
         { seven.Enabled = false; seven7 = true; }
         if (eight.Text == "P" || eight.Text == "C")
         { eight.Enabled = false; eight8 = true; }
         if (nine.Text == "P" || nine.Text == "C")
         { nine.Enabled = false; nine9 = true; }
         if (ten.Text == "P" || ten.Text == "C")
         { ten.Enabled = false; ten10 = true; }
         if (eleven.Text == "P" || eleven.Text == "C")
         { eleven.Enabled = false; eleven11 = true; }
         if (twelve.Text == "P" || twelve.Text == "C")
         { twelve.Enabled = false; twelve12 = true; }
         if (thirteen.Text == "P" || thirteen.Text == "C")
         { thirteen.Enabled = false; thirteen13 = true; }
         if (fourteen.Text == "P" || fourteen.Text == "C")
         { fourteen.Enabled = false; fourteen14 = true; }
         if (fifteen.Text == "P" || fifteen.Text == "C")
         { fifteen.Enabled = false; fifteen15 = true; }
         if (sixteen.Text == "P" || sixteen.Text == "C")
         { sixteen.Enabled = false; sixteen16 = true; }
         if (seventeen.Text == "P" || seventeen.Text == "C")
         { seventeen.Enabled = false; seventeen17 = true; }
         if (eighteen.Text == "P" || eighteen.Text == "C")
         { eighteen.Enabled = false; eighteen18 = true; }
         if (nineteen.Text == "P" || nineteen.Text == "C")
         { nineteen.Enabled = false; nineteen19 = true; }
         if (twenty.Text == "P" || twenty.Text == "C")
         { twenty.Enabled = false; twenty20 = true; }
         if (twentyone.Text == "P" || twentyone.Text == "C")
         { twentyone.Enabled = false; twentyone21 = true; }
         if (twentytwo.Text == "P" || twentytwo.Text == "C")
         { twentytwo.Enabled = false; twentytwo22 = true; }
         if (twentythree.Text == "P" || twentythree.Text == "C")
         { twentythree.Enabled = false; twentythree23 = true; }
         if (twentyfour.Text == "P" || twentyfour.Text == "C")
         { twentyfour.Enabled = false; twentyfour24 = true; }
         if (twentyfive.Text == "P" || twentyfive.Text == "C")
         { twentyfive.Enabled = false; twentyfive25 = true; }

         TicTacToeLogic.computermove(ref one1, ref two2, ref three3, ref four4, ref five5, ref six6, ref seven7, ref eight8, ref nine9, ref ten10, ref eleven11, ref twelve12, ref thirteen13, ref fourteen14, ref fifteen15, ref sixteen16, ref seventeen17, ref eighteen18, ref nineteen19, ref twenty20, ref twentyone21, ref twentytwo22, ref twentythree23, ref twentyfour24, ref twentyfive25);

         if (one.Text != "P" && one.Text != "C" && one1 == true)
         { one.Text = "C"; one.Enabled = false; }
         else if (two.Text != "P" && two.Text != "C" && two2 == true)
         { two.Text = "C"; two.Enabled = false; }
         else if (three.Text != "P" && three.Text != "C" && three3 == true)
         { three.Text = "C"; three.Enabled = false; }
         else if (four.Text != "P" && four.Text != "C" && four4 == true)
         { four.Text = "C"; four.Enabled = false; }
         else if (five.Text != "P" && five.Text != "C" && five5 == true)
         { five.Text = "C"; five.Enabled = false; }
         else if (six.Text != "P" && six.Text != "C" && six6 == true)
         { six.Text = "C"; six.Enabled = false; }
         else if (seven.Text != "P" && seven.Text != "C" && seven7 == true)
         { seven.Text = "C"; seven.Enabled = false; }
         else if (eight.Text != "P" && eight.Text != "C" && eight8 == true)
         { eight.Text = "C"; eight.Enabled = false; }
         else if (nine.Text != "P" && nine.Text != "C" && nine9 == true)
         { nine.Text = "C"; nine.Enabled = false; }
         else if (ten.Text != "P" && ten.Text != "C" && ten10 == true)
         { ten.Text = "C"; ten.Enabled = false; }
         else if (eleven.Text != "P" && eleven.Text != "C" && eleven11 == true)
         { eleven.Text = "C"; eleven.Enabled = false; }
         else if (twelve.Text != "P" && twelve.Text != "C" && twelve12 == true)
         { twelve.Text = "C"; twelve.Enabled = false; }
         else if (thirteen.Text != "P" && thirteen.Text != "C" && thirteen13 == true)
         { thirteen.Text = "C"; thirteen.Enabled = false; }
         else if (fourteen.Text != "P" && fourteen.Text != "C" && fourteen14 == true)
         { fourteen.Text = "C"; fourteen.Enabled = false; }
         else if (fifteen.Text != "P" && fifteen.Text != "C" && fifteen15 == true)
         { fifteen.Text = "C"; fifteen.Enabled = false; }
         else if (sixteen.Text != "P" && sixteen.Text != "C" && sixteen16 == true)
         { sixteen.Text = "C"; sixteen.Enabled = false; }
         else if (seventeen.Text != "P" && seventeen.Text != "C" && seventeen17 == true)
         { seventeen.Text = "C"; seventeen.Enabled = false; }
         else if (eighteen.Text != "P" && eighteen.Text != "C" && eighteen18 == true)
         { eighteen.Text = "C"; eighteen.Enabled = false; }
         else if (nineteen.Text != "P" && nineteen.Text != "C" && nineteen19 == true)
         { nineteen.Text = "C"; nineteen.Enabled = false; }
         else if (twenty.Text != "P" && twenty.Text != "C" && twenty20 == true)
         { twenty.Text = "C"; twenty.Enabled = false; }
         else if (twentyone.Text != "P" && twentyone.Text != "C" && twentyone21 == true)
         { twentyone.Text = "C"; twentyone.Enabled = false; }
         else if (twentytwo.Text != "P" && twentytwo.Text != "C" && twentytwo22 == true)
         { twentytwo.Text = "C"; twentytwo.Enabled = false; }
         else if (twentythree.Text != "P" && twentythree.Text != "C" && twentythree23 == true)
         { twentythree.Text = "C"; twentythree.Enabled = false; }
         else if (twentyfour.Text != "P" && twentyfour.Text != "C" && twentyfour24 == true)
         { twentyfour.Text = "C"; twentyfour.Enabled = false; }
         else if (twentyfive.Text != "P" && twentyfive.Text != "C" && twentyfive25 == true)
         { twentyfive.Text = "C"; twentyfive.Enabled = false; }


         Checkforwinner(sender, evt);
 }


    //function to check whether the computer or player has won and to stop the clock
 protected void Checkforwinner(Object sender, ElapsedEventArgs evt)
 {
     //check for horizontal win 1,2,3,4,5 win
     if (one.Text == "C" && two.Text == "C" && three.Text == "C" && four.Text == "C" && five.Text == "C")
     {
         winnerlabel.Text = "Computer Wins";
         myclock.Enabled = false;
     }
     else if (one.Text == "P" && two.Text == "P" && three.Text == "P" && four.Text == "P" && five.Text == "P")
     {
         winnerlabel.Text = "Player Wins";
         myclock.Enabled = false;
     }

    //check for diagonal win 1,7,13,19,25
     else if (one.Text == "C" && seven.Text == "C" && thirteen.Text == "C" && nineteen.Text == "C" && twentyfive.Text == "C")
     {
         winnerlabel.Text = "Computer Wins";
         myclock.Enabled = false;
     }
     else if (one.Text == "P" && seven.Text == "P" && thirteen.Text == "P" && nineteen.Text == "P" && twentyfive.Text == "P")
     {
         winnerlabel.Text = "Player Wins";
         myclock.Enabled = false;
     }

     //check for vertical win 1,6,11,16,21
     else if (one.Text == "C" && six.Text == "C" && eleven.Text == "C" && sixteen.Text == "C" && twentyone.Text == "C")
     {
         winnerlabel.Text = "Computer Wins";
         myclock.Enabled = false;
     }
     else if (one.Text == "P" && six.Text == "P" && eleven.Text == "P" && sixteen.Text == "P" && twentyone.Text == "P")
     {
         winnerlabel.Text = "Player Wins";
         myclock.Enabled = false;
     }

     //check for vertical win 2,7,12,17,22
     else if (two.Text == "C" && seven.Text == "C" && twelve.Text == "C" && seventeen.Text == "C" && twentytwo.Text == "C")
     {
         winnerlabel.Text = "Computer Wins";
         myclock.Enabled = false;
     }
     else if (two.Text == "P" && seven.Text == "P" && twelve.Text == "P" && seventeen.Text == "P" && twentytwo.Text == "P")
     {
         winnerlabel.Text = "Player Wins";
         myclock.Enabled = false;
     }

     //check for vertical win 3,8,13,18,23
     else if (three.Text == "C" && eight.Text == "C" && thirteen.Text == "C" && eighteen.Text == "C" && twentythree.Text == "C")
     {
         winnerlabel.Text = "Computer Wins";
         myclock.Enabled = false;
     }

     else if (three.Text == "P" && eight.Text == "P" && thirteen.Text == "P" && eighteen.Text == "P" && twentythree.Text == "P")
     {
         winnerlabel.Text = "Player Wins";
         myclock.Enabled = false;
     }

    //check for vertical win 4,9,14,19,24
     else if (four.Text == "C" && nine.Text == "C" && fourteen.Text == "C" && nineteen.Text == "C" && twentyfour.Text == "C")
     {
         winnerlabel.Text = "Computer Wins";
         myclock.Enabled = false;
     }
     else if (four.Text == "P" && nine.Text == "P" && fourteen.Text == "P" && nineteen.Text == "P" && twentyfour.Text == "P")
     {
         winnerlabel.Text = "Player Wins";
         myclock.Enabled = false;
     }

     //check for vertical win 5,10,15,20,25
     else if (five.Text == "C" && ten.Text == "C" && fifteen.Text == "C" && twenty.Text == "C" && twentyfive.Text == "C")
     {
         winnerlabel.Text = "Computer Wins";
         myclock.Enabled = false;
     }
     else if (five.Text == "P" && ten.Text == "P" && fifteen.Text == "P" && twenty.Text == "P" && twentyfive.Text == "P")
     {
         winnerlabel.Text = "Player Wins";
         myclock.Enabled = false;
     }

     //check for diagnoal win 5,9,13,17,21
     else if (five.Text == "C" && nine.Text == "C" && thirteen.Text == "C" && seventeen.Text == "C" && twentyone.Text == "C")
     {
         winnerlabel.Text = "Computer Wins";
         myclock.Enabled = false;
     }
     else if (five.Text == "P" && nine.Text == "P" && thirteen.Text == "P" && seventeen.Text == "P" && twentyone.Text == "P")
     {
         winnerlabel.Text = "Player Wins";
         myclock.Enabled = false;
     }

    //check for horizontal win 6,7,8,9,10
     else if (six.Text == "C" && seven.Text == "C" && eight.Text == "C" && nine.Text == "C" && ten.Text == "C")
     {
         winnerlabel.Text = "Computer Wins";
         myclock.Enabled = false;
     }
     else if (six.Text == "P" && seven.Text == "P" && eight.Text == "P" && nine.Text == "P" && ten.Text == "P")
     {
         winnerlabel.Text = "Player Wins";
         myclock.Enabled = false;
     }

    //check for horizontal win 11, 12, 13, 14, 15
     else if (eleven.Text == "C" && twelve.Text == "C" && thirteen.Text == "C" && fourteen.Text == "C" && fifteen.Text == "C")
     {
         winnerlabel.Text = "Computer Wins";
         myclock.Enabled = false;
     }
     else if (eleven.Text == "P" && twelve.Text == "P" && thirteen.Text == "P" && fourteen.Text == "P" && fifteen.Text == "P")
     {
         winnerlabel.Text = "Player Wins";
         myclock.Enabled = false;
     }

     //check for horizontal win 16,17,18,19,20
     else if (sixteen.Text == "C" && seventeen.Text == "C" && eighteen.Text == "C" && nineteen.Text == "C" && twenty.Text == "C")
     {
         winnerlabel.Text = "Computer Wins";
         myclock.Enabled = false;
     }
     else if (sixteen.Text == "P" && seventeen.Text == "P" && eighteen.Text == "P" && nineteen.Text == "P" && twenty.Text == "P")
     {
         winnerlabel.Text = "Player Wins";
         myclock.Enabled = false;
     }

     //check for horizontal win 21,22,23,24,25
     else if (twentyone.Text == "C" && twentytwo.Text == "C" && twentythree.Text == "C" && twentyfour.Text == "C" && twentyfive.Text == "C")
     {
         winnerlabel.Text = "Computer Wins";
         myclock.Enabled = false;
     }
     else if (twentyone.Text == "P" && twentytwo.Text == "P" && twentythree.Text == "P" && twentyfour.Text == "P" && twentyfive.Text == "P")
     {
         winnerlabel.Text = "Player Wins";
         myclock.Enabled = false;
     }

     //check if no winner then its a cat game cause no one was able to win
     else if (one.Text != "" && two.Text != "" && three.Text != "" && four.Text != "" && five.Text != "" && six.Text != "" && seven.Text != "" && eight.Text != "" && nine.Text != "" && ten.Text != "" && eleven.Text != "" && twelve.Text != "" && thirteen.Text != "" && fourteen.Text != "" && fifteen.Text != "" && sixteen.Text != "" && seventeen.Text != "" && eighteen.Text != "" && nineteen.Text != "" && twenty.Text != "" && twentyone.Text != "" && twentytwo.Text != "" && twentythree.Text != "" && twentyfour.Text != "" && twentyfive.Text != "")
     {
         winnerlabel.Text = "Cat's Game";
         myclock.Enabled = false;
     }

 }


 //Method to execute when the clear button receives an event, namely: receives a mouse click
 protected void cleartext(Object sender, EventArgs events)
   {one.Text = ""; //Empty string
   two.Text = "";
   three.Text = "";
   four.Text = "";
   five.Text = "";
   six.Text = "";
   seven.Text = "";
   eight.Text = "";
   nine.Text = "";
   ten.Text = "";
   eleven.Text = "";
   twelve.Text = "";
   thirteen.Text = "";
   fourteen.Text = "";
   fifteen.Text = "";
   sixteen.Text = "";
   seventeen.Text = "";
   eighteen.Text = "";
   nineteen.Text = "";
   twenty.Text = "";
   twentyone.Text = "";
   twentytwo.Text = "";
   twentythree.Text = "";
   twentyfour.Text = "";
   twentyfive.Text = "";
   one.Enabled = false;
   two.Enabled = false;
   three.Enabled = false;
   four.Enabled = false;
   five.Enabled = false;
   six.Enabled = false;
   seven.Enabled = false;
   eight.Enabled = false;
   nine.Enabled = false;
   ten.Enabled = false;
   eleven.Enabled = false;
   twelve.Enabled = false;
   thirteen.Enabled = false;
   fourteen.Enabled = false;
   fifteen.Enabled = false;
   sixteen.Enabled = false;
   seventeen.Enabled = false;
   eighteen.Enabled = false;
   nineteen.Enabled = false;
   twenty.Enabled = false;
   twentyone.Enabled = false;
   twentytwo.Enabled = false;
   twentythree.Enabled = false;
   twentyfour.Enabled = false;
   twentyfive.Enabled = false;
   startingplayerperson.Checked = false;
   startingplayercomputer.Checked = false;
    winnerlabel.Text = "";
   }//End of cleartext

 //Method to execute when the exit button receives an event, namely: receives a mouse click
 protected void stoprun(Object sender, EventArgs events)
   {Close();
   }

 private void InitializeComponent()
 {
     this.SuspendLayout();
     // 
     // Fibuserinterface
     // 
     this.ClientSize = new System.Drawing.Size(333, 322);
     this.Name = "TicTacToeuserinterface";
     this.ResumeLayout(false);

 }//End of stoprun

}//End of clas TicTacToeuserinterface

