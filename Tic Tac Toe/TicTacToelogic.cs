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
//This file's name: tictactoelogic.cs
//This file purpose: This is a third level module; it is called from fibuserinterface.cs.
//Date last modified: March 10, 2014
//
//

using System;
public class TicTacToeLogic
{
 public static void computermove(ref bool one, ref bool two, ref bool three, ref bool four, ref bool five, ref bool six, ref bool seven, ref bool eight, ref bool nine, ref bool ten,ref bool eleven, ref bool twelve, ref bool thirteen, ref bool fourteen, ref bool fifteen, ref bool sixteen, ref bool seventeen, ref bool eighteen, ref bool nineteen, ref bool twenty, ref bool twentyone, ref bool twentytwo, ref bool twentythree, ref bool twentyfour, ref bool twentyfive)
   {
       if (one == true && two == true && three == true && four == true && five == false)
       {
           five = true;
       }
       else if (one == false && two == true && three == true && four == true && five == true)
       {
           one = true;
       }
       else if (one == true && two == false && three == true && four == true && five == true)
       {
           two = true;
       }
       else if (one == true && two == true && three == false && four == true && five == true)
       {
           three = true;
       }
       else if (one == true && two == true && three == true && four == false && five == true)
       {
           four = true;
       }
       else if (one == true && six == true && eleven == true && sixteen == true && twentyone == false)
       {
           twentyone = true;
       }
     else if (one == true && six == true && eleven == true && sixteen == false && twentyone == true)
     {
         sixteen = true;
     }
     else if (one == true && six == true && eleven == false && sixteen == true && twentyone == true)
     {
         eleven = true;
     }
     if (one == true && six == false && eleven == true && sixteen == true && twentyone == true)
     {
         six = true;
     }
     else if (one == false && six == true && eleven == true && sixteen == true && twentyone == true)
     {
         one = true;
     }
     else if(one == true && seven == true && thirteen == true && nineteen == true && twentyfive == false)
     {
         twentyfive = true;
     }
     else if(one == true && seven == true && thirteen == true && nineteen == false && twentyfive == true)
     {
         nineteen = true;
     }
     else if(one == true && seven == true && thirteen == false && nineteen == true && twentyfive == true)
     {
         thirteen = true;
     }
     else if(one == true && seven == false && thirteen == true && nineteen == true && twentyfive == true)
     {
         seven = true;
     }
     else if(one == false && seven == true && thirteen == true && nineteen == true && twentyfive == true)
     {
         one = true;
     }

     else if(two == true && seven == true && twelve == true && seventeen == true && twentytwo == false)
     {
         twentytwo = true;
     }
     else if(two == true && seven == true && twelve == true && seventeen == false && twentytwo == true)
     {
         seventeen = true;
     }
     else if(two == true && seven == true && twelve == false && seventeen == true && twentytwo == true)
     {
         twelve = true;
     }
     else if(two == true && seven == false && twelve == true && seventeen == true && twentytwo == true)
     {
         seven = true;
     }
     else if(two == false && seven == true && twelve == true && seventeen == true && twentytwo == true)
     {
         two = true;
     }
     else if(three == true && eight == true && thirteen == true && eighteen == true && twentythree == false)
     {
         twentythree = true;
     }
     else if(three == true && eight == true && thirteen == true && eighteen == false && twentythree == true)
     {
         eighteen = true;
     }
     else if(three == true && eight == true && thirteen == false && eighteen == true && twentythree == true)
     {
         thirteen = true;
     }
     else if(three == true && eight == false && thirteen == true && eighteen == true && twentythree == true)
     {
         eight = true;
     }
     else if(three == false && eight == true && thirteen == true && eighteen == true && twentythree == true)
     {
         three = true;
     }
     else if(four == false && nine == true && fourteen == true && nineteen == true && twentyfour == true)
     {
         four = true;
     }
     else if(four == true && nine == false && fourteen == true && nineteen == true && twentyfour == true)
     {
         nine = true;
     }
     else if(four == true && nine == true && fourteen == false && nineteen == true && twentyfour == true)
     {
         fourteen = true;
     }
     else if(four == false && nine == true && fourteen == true && nineteen == false && twentyfour == true)
     {
         nineteen = true;
     }
     else if(four == false && nine == true && fourteen == true && nineteen == true && twentyfour == false)
     {
         twentyfour = true;
     }
    else if(five == true && ten == true && fifteen == true && twenty == true && twentyfive == false)
    {
        twentyfive = true;
    }
     else if(five == true && ten == true && fifteen == true && twenty == false && twentyfive == true)
     {
         twenty = true;
     }
     else if(five == true && ten == true && fifteen == false && twenty == true && twentyfive == true)
     {
         fifteen = true;
     }
     else if(five == true && ten == false && fifteen == true && twenty == true && twentyfive == true)
     {
         ten = true;
     }
     else if(five == false && ten == true && fifteen == true && twenty == true && twentyfive == true)
     {
         five = true;
     }
     else if(five == true && nine == true && thirteen == true && seventeen == true && twentyone == false)
     {
         twentyone = true;
     }
     else if(five == true && nine == true && thirteen == true && seventeen == false && twentyone == true)
     {
         seventeen = true;
     }
     else if(five == true && nine == true && thirteen == false && seventeen == true && twentyone == true)
     {
         thirteen = true;
     }
     else if(five == true && nine == false && thirteen == true && seventeen == true && twentyone == true)
     {
         nine = true;
     }
     else if(five == false && nine == true && thirteen == true && seventeen == true && twentyone == true)
     {
         five = true;
     }
     else if(six == true && seven == true && eight == true && nine == true && ten == false)
     {
         ten = true;

     }
     else if(six == true && seven == true && eight == true && nine == false && ten == true)
     {
         nine = true;
     }
     else if(six == true && seven == true && eight == false && nine == true && ten == true)
     {
         eight = true;
     }
     else if(six == true && seven == false && eight == true && nine == true && ten == true)
     {
         seven = true;
     }
     else if(six == false && seven == true && eight == true && nine == true && ten == true)
     {
         six = true;
     }     
     else if(eleven == true && twelve == true && thirteen == true && fourteen == true && fifteen == false)
     {
         fifteen = true;
     }
     else if (eleven == true && twelve == true && thirteen == true && fourteen == false && fifteen == true)
     {
         fourteen = true;
     }
     else if (eleven == true && twelve == true && thirteen == false && fourteen == true && fifteen == true)
     {
         thirteen = true;
     }
     else if (eleven == true && twelve == false && thirteen == true && fourteen == true && fifteen == true)
     {
         twelve = true;
     }
     else if (eleven == false && twelve == true && thirteen == true && fourteen == true && fifteen == true)
     {
         eleven = true;
     }
     else if (sixteen == true && seventeen == true && eighteen == true && nineteen == true && twenty == false)
     {
         twenty = true;
     }
     else if (sixteen == true && seventeen == true && eighteen == true && nineteen == false && twenty == true)
     {
         nineteen = true;
     }
     else if (sixteen == true && seventeen == true && eighteen == false && nineteen == true && twenty == true)
     {
         eighteen = true;
     }
     else if (sixteen == true && seventeen == false && eighteen == true && nineteen == true && twenty == true)
     {
         seventeen = true;
     }
     else if (sixteen == false && seventeen == true && eighteen == true && nineteen == true && twenty == true)
     {
         sixteen = true;
     }
     else if (twentyone == true && twentytwo == true && twentythree == true && twentyfour == true && twentyfive == false)
     {
         twentyfive = true;
     }
     else if (twentyone == true && twentytwo == true && twentythree == true && twentyfour == false && twentyfive == true)
     {
         twentyfour = true;
     }
     else if (twentyone == true && twentytwo == true && twentythree == false && twentyfour == true && twentyfive == true)
     {
         twentythree = true;
     }
     else if (twentyone == true && twentytwo == false && twentythree == true && twentyfour == true && twentyfive == true)
     {
         twentytwo = true;
     }
     else if (twentyone == false && twentytwo == true && twentythree == true && twentyfour == true && twentyfive == true)
     {
         twentyone = true;
     }
     else if (eleven == false)
     {
         eleven = true;
     }
     else if (twelve == false)
     {
         twelve = true;
     }
     else if (thirteen == false)
     {
         thirteen = true;
     }
     else if (fourteen == false)
     {
         fourteen = true;
     }
     else if (fifteen == false)
     {
         fifteen = true;
     }
     else if (six == false)
     {
         six = true;
     }
     else if (seven == false)
     {
         seven = true;
     }
     else if (eight == false)
     {
         eight = true;
     }
     else if (nine == false)
     {
         nine = true;
     }
     else if (ten == false)
     {
         ten = true;
     }
     else if (sixteen == false)
     {
         sixteen = true;
     }
     else if (seventeen == false)
     {
         seventeen = true;
     }
     else if (eighteen == false)
     {
         eighteen = true;
     }
     else if (nineteen == false)
     {
         nineteen = true;
     }
     else if (twenty == false)
     {
         twenty = true;
     }
     else if (one == false)
     {
         one = true;
     }
     else if (two == false)
     {
         two = true;
     }
     else if (three == false)
     {
         three = true;
     }
     else if (four == false)
     {
         four = true;
     }
     else if (five == false)
     {
         five = true;
     }
     else if (twentyone == false)
     {
         twentyone = true;
     }
     else if (twentytwo == false)
     {
         twentytwo = true;
     }
     else if (twentythree == false)
     {
         twentythree = true;
     }
     else if (twentyfour == false)
     {
         twentyfour = true;
     }
     else if (twentyfive == false)
     {
         twentyfive = true;
     }

     
 }//End of tictactoelogic
    
}//End of tictactoelogic
