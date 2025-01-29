// ConsoleApplication1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <stdio.h>

int GCD(int a, int b)
{
    int t = 1;
    if (a < b) return 0; /* ensure valid parameters */
    while (t != 0)
    {
        t = a % b; /* remainder of a/b */
        if (t == 0) continue; /* if algorithm complete */
        a = b; /* update if GCD not yet found */
        b = t; /* update if GCD not yet found */
    }
    printf("%d\n", a);
    printf("%d\n", b);
    printf("%d\n", t);
    return b;
}

void easterDate(int* day, int* month, int year) {
    int M, N, a, b, c, d, e;

    // Set values for M and N based on the given year range
    if (year >= 1700 && year <= 1799) {
        M = 23;
        N = 3;
    }
    else if (year >= 1800 && year <= 1899) {
        M = 23;
        N = 4;
    }
    else if (year >= 1900 && year <= 2099) {
        M = 24;
        N = 5;
    }
    else if (year >= 2100 && year <= 2199) {
        M = 24;
        N = 3;
    }
    else {
        // Handle other year ranges if needed
        printf_s("Year not in the supported range.\n");
        return;
    }

    // Calculate values a, b, c, d, and e
    a = year / 19;
    b = year / 4;
    c = year / 7;
    d = (19 * a + M) % 30;
    e = (2 * b + 4 * c + 6 * d + N) % 7;

    // Adjust for special cases
    if (d == 29 && e == 6) {
        d -= 7;
    }

    if (d == 28 && e == 6 && ((11 * M + 11) % 30) < 19) {
        d -= 7;
    }

    // Calculate the date of Easter
    if ((22 + d + e) <= 31) {
        *day = 22 + d + e;
        *month = 3;  // March
    }
    else {
        *day = d + e - 9;
        *month = 4;  // April
    }
}

int main() {
    int day, month, year;

    // Input the year for which you want to calculate Easter
    printf("Enter the year: ");
    scanf_s("%d", &year);

    // Call the easterDate function to calculate the day and month
    easterDate(&day, &month, year);

    // Output the result
    printf("Easter in %d is on %d/%d\n", year, day, month);

    return 0;
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
