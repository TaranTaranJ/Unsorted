// GCD.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
// This is the Preprocessor Directive section
// This is the main SDL include file

// include OpenGL
#include <GL/gl.h>
#include <GL/glu.h>
// include relevant C standard libraries
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <stdbool.h>
#define PI 3.14159265359
#include <iostream>

int main()
{
    int a = 5;
    int b = 20;
    int t = 1;
    if (a < b) return 0; /* ensure valid parameters */
    while (t != 0)
    {
        t = a % b; /* remainder of a/b */
        if (t == 0) continue; /* if algorithm complete */
        a = b; /* update if GCD not yet found */
        b = t; /* update if GCD not yet found */
    }
    return b;
    printf("The sum of %d and %d is %d\n", a, b, a + b);
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
