//Standard Header Information for Cpsc223n:
//Author: Kendall Townsend
//Author's email: kendallcar@csu.fullerton.edu
//Course: Cpsc223n
//Assignment number: 2
//Due date: Feb 24, 2014
//Project name: Payroll Assignment 2
//Files in project: payrollmain.cs, payrolllogic.cs, payrolluserinterface.cs
//Project purpose:  Take inputs and be able to output their regular pay, overtime pay, gross pay, withhold tax, health deductible,
// soscial security deductible, and net pay. 
//partitioning the solution into three files: a top level generic driver module, a middle level user interface, and a third level
//algorithms module.  That later module is sometimes called the business logic of the system.
//Project status:  Works correctly with any outputs if inputs are negative will calculate negative values.
//Known bugs: Program crashes if the user input nothing and clicks on "Compute".
//
//This file's name: payrolluserinterface.cs
//This file purpose: This is a second level module; it defines the user interface window.
//Date last modified: Feb 23, 2014
//
//There are three files in this program.  They must be compiled in an order that satisfies dependencies.  In this case the correct order is:
//  1. payrolllogic.cs
//  2. payrolluserinterface.cs
//  3. payrollmain.cs
//
//To compile payrolluserinterface.cs: 
//          gmcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -r:payrolllogic.dll -out:payrolluserinterface.dll payrolluserinterface.cs
//
//Function: The payroll numerical calculator.  Enter a number in the input field, then
//click on the compute button, and the result will appear as a string.
//Sample results for small input values:
//
//Input                         Output
//  Christopher Columbus        Christopher Columbus
//  43.3                        394.80
//  9.87                        48.86
//  2                           443.66
//  yes                         70.99
//                              193.00
//                              17.75
//                              161.93
//
// Thomas Jefferson             Thomas Jefferson
// 65.2                         950.00
// 23.75                        897.75
// 4                            1,847.75
// no                           258.69
//                              0.00
//                              30.00
//                              1,559.07
//
// Amerigo Vespucci             Amerigo Vespuci
//22.9                          154.74
//6.757                         0.00
//0                             154.74
//Yes                           27.85
//                              85.00
//                              6.19
//                              35.69
//
//Marco Polo                    Marco Polo
//55.9                          1,190.80
//29.77                         710.01
//9                             1,900.81
//Yes                           171.07
//                              571.00
//                              30.00    
//                              1,129.74
//
//Vasco da Gama                 Vasco da Gama
//16.0                          476.32
//29.77                         0.00
//0                             476.32
//Yes                           85.74
//                              85.00
//                              19.05
//                              286.53
//
//John Paul Jones               John Paul Jones
// 60.0                         458.00
//11.45                         343.50
//5                             801.50
//no                            104.20
//                              0.00
//                              30.00
//                              667.31
//
//Francois Joseph Paul de Grasse 1,304.00
//75.2                           1,721.28
//32.60                          3,025.28
//5                              393.29
//Yes                            355.00
//                               30.00
//                               2,246.99
//
//
//Fernao de Magalhaes            Fernao de Magalhaes
//8.7                            46.89
//5.39                           0.00
//3                              46.89
//no                             7.03
//                               0.00
//                               1.88
//                               37.98
using System;
using System.Drawing;
using System.Windows.Forms;

public class payrolluserinterface: Form
{
private Label title = new Label();
private Label name = new Label();
private TextBox nameinput = new TextBox();
private Label hours = new Label();
private TextBox hoursinput = new TextBox();
private Label payrate = new Label();
private TextBox payrateinput = new TextBox();
private Label dependents = new Label();

private ComboBox dependentsinput = new ComboBox();


private Label healthplan = new Label();

private RadioButton healthplaninputY = new RadioButton();
private RadioButton healthplaninputN = new RadioButton();

private Label namerepeat = new Label();
private Label namerepeatoutput = new Label();
private Label regularpay = new Label();
private Label regularpayoutput = new Label();
private Label overtimepay = new Label();
private Label overtimepayoutput = new Label();
private Label grosspay = new Label();
private Label grosspayoutput = new Label();
private Label withholdtax = new Label();
private Label witholdtaxoutput = new Label();
private Label healthdeductible = new Label();
private Label healthdeductibleoutput = new Label();
private Label ssdeductible = new Label();
private Label ssdeductibleoutput = new Label();
private Label netpay = new Label();
private Label netpayoutput = new Label();
private Button computepay = new Button();
private Button clear = new Button();
private Button exitbutton = new Button();

 public payrolluserinterface()
   {//Initialize text strings
       Text = "Steinerg Enterprises Payroll Project";
    title.Text = "Steinberg Enterprises Payroll";
    name.Text = "Name: ";
    nameinput.Text = "";
    hours.Text = "Hours ";
    hoursinput.Text = "";
    payrate.Text = "Pay rate ";
    payrateinput.Text = "";

    dependents.Text = "Dependents ";


    string textbox0 = "0";
    dependentsinput.Items.Add(textbox0);
    string textbox1 = "1";
    dependentsinput.Items.Add(textbox1);
    string textbox2 = "2";
    dependentsinput.Items.Add(textbox2);
    string textbox3 = "3";
    dependentsinput.Items.Add(textbox3);
    string textbox4 = "4";
    dependentsinput.Items.Add(textbox4);
    string textbox5 = "5";
    dependentsinput.Items.Add(textbox5);
    string textbox6 = "6";
    dependentsinput.Items.Add(textbox6);
    string textbox7 = "7";
    dependentsinput.Items.Add(textbox7);
    string textbox8 = "8";
    dependentsinput.Items.Add(textbox8);
    string textbox9 = "9";
    dependentsinput.Items.Add(textbox9);
     
    healthplan.Text = "Health Plan ";
    healthplaninputY.Text = "Yes";
    healthplaninputN.Text = "No";
    namerepeat.Text = "Name: ";
    namerepeatoutput.Text = "";
    regularpay.Text = "Regular pay: ";
    regularpayoutput.Text = "";
    overtimepay.Text = "Overtime pay: ";
    overtimepayoutput.Text = "";
    grosspay.Text = "Gross pay: ";
    grosspayoutput.Text = "";
    withholdtax.Text = "Withhold tax: ";
    witholdtaxoutput.Text = "";
    healthdeductible.Text = "Health: ";
    healthdeductibleoutput.Text = "";
    ssdeductible.Text = "Social Security: ";
    ssdeductibleoutput.Text = "";
    netpay.Text = "Net pay: ";
    netpayoutput.Text = "";

    computepay.Text = "Compute Pay";
    clear.Text = "Clear";
    exitbutton.Text = "Exit";


    //Set sizes
    Size = new Size(400,700);
    title.Size = new Size(200,30);
    name.Size = new Size(75,30);
    nameinput.Size = new Size(200, 30);
    hours.Size = new Size(75,30);
    hoursinput.Size = new Size(50, 50);
    payrate.Size = new Size(75, 30);
    payrateinput.Size = new Size(200, 30);
    dependents.Size = new Size(75, 30);
    dependentsinput.Size = new Size(200, 30);
    healthplan.Size = new Size(75, 30);
    healthplaninputY.Size = new Size(85, 30);
    healthplaninputN.Size = new Size(85, 30);
    namerepeat.Size = new Size(75, 30);
    namerepeatoutput.Size = new Size(200, 30);
    regularpay.Size = new Size(75, 30);
    regularpayoutput.Size = new Size(200, 30);
    overtimepay.Size = new Size(75, 30);
    overtimepayoutput.Size = new Size(200, 30);
    grosspay.Size = new Size(75, 30);
    grosspayoutput.Size = new Size(200, 30);
    withholdtax.Size = new Size(75, 30);
    witholdtaxoutput.Size = new Size(200, 30);
    healthdeductible.Size = new Size(75, 30);
    healthdeductibleoutput.Size = new Size(200, 30);
    ssdeductible.Size = new Size(75, 30);
    ssdeductibleoutput.Size = new Size(200, 30);
    netpay.Size = new Size(75, 30);
    netpayoutput.Size = new Size(200, 30);
    computepay.Size = new Size(85, 30);
    clear.Size = new Size(85, 30);
    exitbutton.Size = new Size(85, 30);

    //Set locations
    title.Location = new Point(140,20);
    name.Location = new Point(20,60);
    nameinput.Location = new Point(100, 60);
     hours.Location = new Point(20,100);
     hoursinput.Location = new Point(100, 100);
     payrate.Location = new Point(20,140);
     payrateinput.Location = new Point(100, 140);
     dependents.Location = new Point(20,190);
     dependentsinput.Location = new Point(100, 190);
    healthplan.Location = new Point(20, 230);
    healthplaninputY.Location = new Point(100, 230);
    healthplaninputN.Location = new Point(200, 230);
    namerepeat.Location = new Point(20, 300);
    namerepeatoutput.Location = new Point(100, 300);
    regularpay.Location = new Point(20, 340);
    regularpayoutput.Location = new Point(100, 340);
    overtimepay.Location = new Point(20, 380);
    overtimepayoutput.Location = new Point(100, 380);
    grosspay.Location = new Point(20, 420);
    grosspayoutput.Location = new Point(100, 420);
    withholdtax.Location = new Point(20, 460);
    witholdtaxoutput.Location = new Point(100, 460);
    healthdeductible.Location = new Point(20, 500);
    healthdeductibleoutput.Location = new Point(100, 500);
    ssdeductible.Location = new Point(20, 540);
    ssdeductibleoutput.Location = new Point(100, 540);
    netpay.Location = new Point(20, 580);
    netpayoutput.Location = new Point(100, 580);
    computepay.Location = new Point(20, 620);
    clear.Location = new Point(120, 620);
    exitbutton.Location = new Point(220, 620);

    //Associate the Compute button with the Enter key of the keyboard
  

    //Add controls to the form
    Controls.Add(title);
    Controls.Add(name);
    Controls.Add(nameinput);
    Controls.Add(hours);
    Controls.Add(hoursinput);
    Controls.Add(payrate);
    Controls.Add(payrateinput);
    Controls.Add(dependents);
    Controls.Add(dependentsinput);
    Controls.Add(healthplan);
    Controls.Add(healthplaninputY);
    Controls.Add(healthplaninputN);
    Controls.Add(namerepeat);
    Controls.Add(namerepeatoutput);
    Controls.Add(regularpay);
    Controls.Add(regularpayoutput);
    Controls.Add(overtimepay);
    Controls.Add(overtimepayoutput);
    Controls.Add(grosspay);
    Controls.Add(grosspayoutput);
    Controls.Add(withholdtax);
    Controls.Add(witholdtaxoutput);
    Controls.Add(healthdeductible);
    Controls.Add(healthdeductibleoutput);
    Controls.Add(ssdeductible);
    Controls.Add(ssdeductibleoutput);
    Controls.Add(netpay);
    Controls.Add(netpayoutput);
    Controls.Add(computepay);
     Controls.Add(clear);
    Controls.Add(exitbutton);

    //Register the event handler.  In this case each button has an event handler, but no other 
    //controls have event handlers.
    computepay.Click += new EventHandler(payrollcalculation);
    clear.Click += new EventHandler(cleartext);
    exitbutton.Click += new EventHandler(stoprun);  //The '+' is required.

   }//End of constructor Fibuserinterface

 //Method to execute when the compute button receives an event, namely: receives a mouse click
 protected void payrollcalculation(Object sender, EventArgs events)
 {
     string name = nameinput.Text;
     namerepeatoutput.Text = name;
     regularpaycalculation(sender, events);
     overtimepaycalculation(sender, events);
     grosspaycalculation(sender, events);
     withholdtaxcalculation(sender, events);
     socialsecuritycalculation(sender, events);
     netpaycalculation(sender, events);

     if (healthplaninputY.Checked == true)
     {
         healthplandeductionYes(sender, events);
     }
     else
         healthplandeductionNo(sender, events);

 }

 protected void netpaycalculation(Object sender, EventArgs events)
 {
     double hours = double.Parse(hoursinput.Text);
     double payperhour = double.Parse(payrateinput.Text);
     double amountofdependents = double.Parse(dependentsinput.Text);

     double grosspay = payroll.hourstogrosspay(hours, payperhour);  
     double ssamount = payroll.socialsecurityamount(hours, payperhour);
     double withholdtaxamount = payroll.deductiblestaxcalculation(amountofdependents, hours, payperhour);
     double healthdeductible;
     if(healthplaninputY.Checked == true)
     {
       healthdeductible = payroll.healthplan(amountofdependents);
     }
     else
        healthdeductible = 0;

     double netpay = payroll.netpayamount(ssamount, withholdtaxamount, healthdeductible, grosspay);
     Console.Write("{0:F12}", netpay);

     string netpayvalue = netpay.ToString("n" + 2 /*decimal places */);
     string output =netpayvalue;
     netpayoutput.Text = output;
 
 }

 protected void socialsecuritycalculation(Object sender, EventArgs events)
 {
     double hours = double.Parse(hoursinput.Text);
     double payperhour = double.Parse(payrateinput.Text);
     double ssamount = payroll.socialsecurityamount(hours, payperhour);
     Console.Write("{0:F12}", grosspay);

     string ssamountvalue = ssamount.ToString("n" + 2 /*decimal places */);
     string output = ssamountvalue;
     ssdeductibleoutput.Text = output;
 }

 protected void withholdtaxcalculation(Object sender, EventArgs events)
 {
     double amountofdependents = double.Parse(dependentsinput.Text);
     double hours = double.Parse(hoursinput.Text);
     double payperhour = double.Parse(payrateinput.Text);
     double withholdtaxamount = payroll.deductiblestaxcalculation(amountofdependents, hours, payperhour);
     Console.Write("{0:F12}", withholdtaxamount);

     string withholdtaxamountvalue = withholdtaxamount.ToString("N" + 2 /* decimal places */);
     string output = withholdtaxamountvalue;
     witholdtaxoutput.Text = output;
 }

 protected void grosspaycalculation(Object sender, EventArgs events)
 {
     double hours = double.Parse(hoursinput.Text);
     double payperhour = double.Parse(payrateinput.Text);
     double grosspay = payroll.hourstogrosspay(hours, payperhour);
     Console.Write("{0:F12}", grosspay);

     string grosspayvalue = grosspay.ToString("n" + 2 /*decimal places */);
     string output = grosspayvalue;
     grosspayoutput.Text = output;
 }
 protected void regularpaycalculation(Object sender, EventArgs events)
 {
     double hours = double.Parse(hoursinput.Text);
     double payperhour = double.Parse(payrateinput.Text);
     double pay = payroll.hourstopay(hours, payperhour);
     Console.Write("{0:F12}", pay);

     string payvalue = pay.ToString("n" + 2 /*decimal places */);
     string output = payvalue;
     regularpayoutput.Text = output;

 }

 protected void overtimepaycalculation(Object sender, EventArgs events)
{
     double hours = double.Parse(hoursinput.Text);
     double payperhour = double.Parse(payrateinput.Text);
     double overtimepay = payroll.overtimehourstopay(hours, payperhour);
     Console.Write("{0:F12}", overtimepay);

     string overtimepayvalue = overtimepay.ToString("n" + 2 /*decimal places */);
     string output = overtimepayvalue;
     overtimepayoutput.Text = output;
}
   protected void healthplandeductionYes(Object sender, EventArgs events)
   {
       double sequencenun = double.Parse(dependentsinput.Text);
       double deductible = payroll.healthplan(sequencenun);
    Console.Write("{0:F12}", deductible);

    string deductiblevalue = deductible.ToString("N" + 2 /* decimal places */);
     string output = deductiblevalue;
    healthdeductibleoutput.Text = output;
   }

 protected void healthplandeductionNo(Object sender, EventArgs events)
 {
     double deductible = 0;
     Console.Write("{0:F12}", deductible);

     string deductiblevalue = deductible.ToString("N" + 2/* decimal places */);
     string output = deductiblevalue;
     healthdeductibleoutput.Text = output;
 }

 //Method to execute when the clear button receives an event, namely: receives a mouse click
 protected void cleartext(Object sender, EventArgs events)
   { //Empty string
   nameinput.Text = "";
   hoursinput.Text = "";
   payrateinput.Text = "";
   dependentsinput.Text = "";
   namerepeatoutput.Text = "";
   regularpayoutput.Text = "";
   overtimepayoutput.Text = "";
   grosspayoutput.Text = "";
   witholdtaxoutput.Text = "";
   healthdeductibleoutput.Text = "";
   ssdeductibleoutput.Text = "";
   netpayoutput.Text = "";




   healthplaninputY.Checked = false;
   healthplaninputN.Checked = false;

    
   }//End of cleartext

 //Method to execute when the exit button receives an event, namely: receives a mouse click
 protected void stoprun(Object sender, EventArgs events)
   {Close();
   }//End of stoprun

}//End of class payrolluserinterface

