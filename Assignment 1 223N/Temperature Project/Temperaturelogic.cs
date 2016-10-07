//Standard Header Information for Cpsc223n:
//Author: Kendall Townsend
//Author's email: Kendallcar@csu.fullerton.edu
//Course: Cpsc223n
//Assignment number: 1
//Due date: Feb 10, 2014
//Project name: Temperature Conversion
//Files in project: Temeperaturemain.cs, Temperaturelogic.cs, Temperatureserinterface.cs
//Project purpose: Compute the temperature celsius or fahrenheit corresponding to user inputs. This project demonstrates
//the technique of partitioning the solution into three files: top level generic driver module, a middle level user interface,
// and a third level algorithms module, sometimes called the business logic of the system.
//Project status:  Works correctly with inputs and shows 12 decimal points.
//Known bugs: Program crashes if the user input nothing and clicks on "Convert to F" or "Convert to C".
//
//This file's name: Temperaturelogic.cs
//This file purpose: This is a third level module; it is called from Temperatureuserinterface.cs.
//Date last modified: Feb 5, 2014
//
//
//To compile Temperaturelogic.cs:   
//          gmcs -target:library -out:Temperaturelogic.dll Temperaturelogic.cs
//
////
//
using System;
public class convertTemperature
{
 public static decimal convertFtoC(decimal sequencenun)
   {
    decimal celsius = sequencenun-32;
     celsius = celsius * 5;
     celsius = celsius / 9;
   
    return celsius;
   }//End of converting fahrenheit to celsius logic
 public static decimal convertCtoF(decimal sequencenun)
 {
     decimal fahrenheit = sequencenun * 9;
     fahrenheit = fahrenheit / 5;
     fahrenheit = fahrenheit + 32;

     return fahrenheit;
 }//end of converting celsius to fahrenheit logic
}//End of templogic
