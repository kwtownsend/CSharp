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
//  Project title: Amortization Schedule
//  Purpose: Inputting 4 loans with %interest and amount of months and generating an amort schedule
//  Status: Performs correctly on Linux 64-bit platforms with AVX
//  Project files: amort.cpp, amort.asm, amortfunc.cpp
//Module information
//  This module's call name: amort.out  This module is invoked by the user
//  Language: C++
//  Date last modified: 2014-Sep-28
//  Purpose: This module is called by amort.asm to perform math
//  File name: amortfunc.cpp
//  Status: No known errors.
//  Future enhancements: None planned
//Translator information
//  Gnu compiler: g++ -c -m64 -Wall -l amortfunc-driver.lis -o amortfunc-driver.o amortfunc.cpp
//  
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
#include <cmath>
#include <iostream>
using namespace std;
extern "C" double amortfunc(double, double, double, double);


double amortfunc(double a, double i, double p, double n)
{	
	i = i/12;
	double initi = i;

	i = 1;
	for(int z=0; z<n; z++)
	{
		i = i * (1+initi);
	}

	a = p * ((initi * i) / (i-1));

	return a;
}
