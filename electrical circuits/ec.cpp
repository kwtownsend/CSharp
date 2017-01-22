//=======1=========2=========3=========4=========5=========6=========7=========8=========9=========0=========1=========2=========3=========4=========5=========6=========7**
//Author information
//  Author name: Kendall Townsend
//  Author email: kendallcar@csu.fullerton.edu
//  Author location: CSUF
//Course information
//  Course number: CPSC240
//  Assignment number: 1
//  Due date: 2014-Aug-25
//Project information
//  Project title: Electric Circuits in Parallel
//  Purpose: Learn how to use some of the instruction acting on the avx component.
//  Status: Performs correctly on Linux 64-bit platforms with AVX
//  Project files: ec.cpp, ec.asm
//Module information
//  This module's call name: ec.out  This module is invoked by the user
//  Language: C++
//  Date last modified: 2014-Sep-8
//  Purpose: This module is the top level driver: it will call ec
//  File name: ec.cpp
//  Status: No known errors.
//  Future enhancements: None planned
//Translator information
//  Gnu compiler: g++ -c -m64 -Wall -l ec-driver.lis -o ec-driver.o ec.cpp
//  Gnu linker:   g++ -m64 -o ec.out ec-driver.o ec.o
//References and credits
//  No references: this module is standard C++
//Format information
//  Page width: 172 columns
//  Begin comments: 61
//  Optimal print specification: Landscape, 7 points or smaller, monospace, 8½x11 paper
//
//===== Begin code area ===================================================================================================================================================

#include <stdio.h>
#include <stdint.h>
#include <ctime>
#include <cstring>

extern "C" double ec();

int main(){

  double return_code = -99.99;

  printf("%s","This Program is brought to you by Kendall Townsend \n");
  return_code = ec();
  printf("%s%1.18lf%s\n","The return code received by the driver is ",return_code,
         ". Bye.");

  return 0;

}//End of main
//=======1=========2=========3=========4=========5=========6=========7=========8=========9=========0=========1=========2=========3=========4=========5=========6=========7**
