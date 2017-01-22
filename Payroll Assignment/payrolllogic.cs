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
//This file's name: payrolllogic.cs
//This file purpose: This is a third level module; it is called from payrolluserinterface.cs.
//Date last modified: Feb 23, 2014
//
//
//To compile payrolllogic.cs:   
//          gmcs -target:library -out:payrolllogic.dll payrolllogic.cs
//
//
//
using System;
public class payroll
{

   public static double netpayamount(double ssamount, double withholdtaxamount, double healthdeductible, double grosspay)
   {
       double netpay;
       netpay = grosspay - (ssamount + withholdtaxamount + healthdeductible);
       return netpay;
   }

    public static double socialsecurityamount(double hoursworked, double hourlypay)
    {
        double ssamount;
        double grosspay;
        if (hoursworked > 40)
        {
            grosspay = 40 * hourlypay;
            grosspay = grosspay + ((hourlypay * 1.5) * (hoursworked - 40));
        }
        else
            grosspay = hoursworked * hourlypay;
        
        ssamount = grosspay * .04;
        if (ssamount > 30)
            ssamount = 30;

        return ssamount;
    }

    public static double deductiblestaxcalculation(double dependentsinput, double hoursworked, double hourlypay)
    {
        double withholdtaxamount;
        double grosspay;
        if (hoursworked > 40)
        {
            grosspay = 40 * hourlypay;
            grosspay = grosspay + ((hourlypay * 1.5) * (hoursworked - 40));
        }
        else
            grosspay = hoursworked * hourlypay;

        withholdtaxamount = (.18 - (dependentsinput * .01)) * grosspay;
        return withholdtaxamount;

    }
    public static double hourstogrosspay(double hoursworked, double hourlypay)
    {

        double grosspay;
        if (hoursworked > 40)
        {
            grosspay = 40 * hourlypay;
            grosspay = grosspay + ((hourlypay * 1.5) * (hoursworked - 40));
        }
        else
            grosspay = hoursworked * hourlypay;
        return grosspay;
    }
    public static double overtimehourstopay(double hoursworked, double hourlypay)
    {
        double pay, hoursovertime;
        if (hoursworked > 40)
        {
            hoursovertime = (hoursworked - 40);
            pay = hoursovertime * (hourlypay * 1.5);
        }
        else
            pay = 0;
        return pay;
    }

    public static double hourstopay(double hoursworked, double hourlypay)
    {
        double pay;
        if (hoursworked > 40)
        {
            pay = hourlypay * 40;
        }
        else
            pay = hoursworked * hourlypay;

        return pay;
    }

 public static double healthplan(double dependentsinput)
   {
       double healthdeductible = (dependentsinput * 54) + 85;
    return healthdeductible;
   }

}//End of payrolllogic
