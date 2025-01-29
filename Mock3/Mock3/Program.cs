using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;

namespace Mock3
{
    internal class students
    {
        public string studentName { get; set; }
        public int studentMark { get; set; }
        public string studentGrade { get; set; } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            try //This is for error handling, the program will "try" to run the code and continue to give the outputs. If there is a problem then it catchs it and throws a error message, repeating the program until the user gets it correct
            {
                int studentsAmount; //variable that will hold the amount of students that the user will be inputting results for. This is so we can look the code instead of having to repeat it a bunch of times, unneccessarily. 
                                    // it is held as a integer as the user needs to enter a whole number not a decimal because you cant get a .5 of a person
                Console.WriteLine("Please enter amount of students. Minimum = 6"); //Asks the user how many students they want to input the results for. This is so we can repeat the list a certain number of times and get a exact number for the list.
                studentsAmount = int.Parse(Console.ReadLine()); //Collects the reply from the user and holds it to the variable. This is so I can put the number into the loop and repeat the code a certain amount of times

                if (studentsAmount < 6) // If the answer is less than 6 the program will send out a error message and repeat the program
                {
                    Console.WriteLine("You did not enter enough students, please try again"); //error message letting the user know what has happened so they do not get confused when the program starts itself again
                }
                else
                {
                    Console.Clear(); //Clears the console so that the program does not look messy when the code have fully run.
                    Console.WriteLine("{0} students have been added to the list", studentsAmount);
                    Thread.Sleep(3000); //Creates a delay in the program so the user has time to read before the message is cleared
                    Console.Clear(); //Clears the console so that the program does not look messy when the code have fully run.
                }
                List<students> student = new List<students>(); //List that will hold all of the information regarding the student. This is so I can put it into descending order and export it to the text file

                for (int studentNum = 0; studentNum < studentsAmount; studentNum++) //This is the loop, the studentNum will increase every time the loop is run until the studentNum is equal to the number that the user replied with and is held in the variable studentsAmount
                {

                    students Student = new students { }; //makes a new list within the loop to hold the student information as they enter it.
                    Console.WriteLine("Please enter student name"); //asks the user to input the student name. This is so it can be held by the variable and matched with the marks.
                    Student.studentName = Console.ReadLine(); //Holds the name in a variable and the list. This is so I can match the name, mark and grade together without having to piece them together.

                    Console.Clear(); //Clears the console so that the program does not look messy when the code have fully run.
                    Console.WriteLine("Please enter student marks", 0, 100); //Asks for the student mark and is limited to 0 to 100 as these are the minimum and maximum grades.
                    Student.studentMark = int.Parse(Console.ReadLine()); //Holds the marks and adds it to the list with the student name. This is so I can calculate the grade that they will recieve.

                    if (Student.studentMark >= 70 && Student.studentMark <= 100) //This is where the grade gets calculated. If the mark is greater than or equal to 70 and the mark is less than or equal to 100 they will recieve a distinction.
                    {
                        Console.Clear(); //Clears the console so that the program does not look messy when the code have fully run.
                        Console.WriteLine("{0} has recieved a Distinction", Student.studentName);//There will be a message saying what grade the student has gotten. This is so the user knows that the program is working and is not left clueless.
                        Student.studentGrade = "Distinction"; //Holds the grade that the student has recieved and adds it to the list. This is so I can match the correct student with the their mark and sort it into descending order.
                        Thread.Sleep(3000); //Creates a 3 second delay.This gives the user a chance to read the message.
                        Console.Clear(); //Clears the console so that the program does not look messy when the code have fully run.
                    }
                    else if (Student.studentMark >= 51 && Student.studentMark <= 69)//If the mark is greater than and equal to 51 and the mark is less than or equal to 69 the student will recieve a Merit.
                    {
                        Console.Clear(); //Clears the console so that the program does not look messy when the code have fully run.
                        Console.WriteLine("{0} has recieved a Merit", Student.studentName); //Confirmation message presenting to the user that the student has recieved a Merit. This allows the user to know the program is working.
                        Student.studentGrade = "Merit"; //Holds the grade that the student has recieved and adds it to the list. This is so I can match the correct student with their name and mark and sort it into descending order to export to the txt file.
                        Thread.Sleep(3000); //Creates a 3 second delay.This gives the user a chance to read the message.
                        Console.Clear(); //Clears the console so that the program does not look messy when the code have fully run.
                    }
                    else if (Student.studentMark >= 40 && Student.studentMark <= 50) //If the mark is greater than and equal to 40 and the mark is less than or equal to 50 the user will recieve a Pass.
                    {
                        Console.Clear(); //Clears the console so that the program does not look messy when the code have fully run.
                        Console.WriteLine("{0} has recieved a Pass", Student.studentName); //confirmation message allowing the user to see the grade that student has received. 
                        Student.studentGrade = "Pass"; //Adds the grade to the variable and list. This is so I can sort it into descending order and export it to the list.
                        Thread.Sleep(3000); //Creates a 3 second delay.This gives the user a chance to read the message.
                        Console.Clear(); //Clears the console so that the program does not look messy when the code have fully run.
                    }
                    else if (Student.studentMark < 40 && Student.studentMark >= 0) //If the user has recieved a mark that is less than 40 and the mark is greater than 0 they would have failed.
                    {
                        Console.Clear(); //Clears the console so that the program does not look messy when the code have fully run.
                        Console.WriteLine("{0} has failed", Student.studentName); //Notifys the user to understand that the student has failed the exam.
                        Student.studentGrade = "Fail"; //Holds the grade to the variable and list. This is so I can sort it into descending order and export the list to a txt file for the user to look at without having to run the code repeatedly.
                        Thread.Sleep(3000); //Creates a 3 second delay.This gives the user a chance to read the message.
                        Console.Clear(); //Clears the console so that the program does not look messy when the code have fully run.

                    }
                    else //In the scenario that something has gone wrong the code will run a error message.
                    {
                        Console.Clear(); //Clears the console so that the program does not look messy when the code have fully run.
                        Console.WriteLine("There was an error with your answer, please try again"); //If something went wrong with the answer and the reply that the user gave, the program will display a error message letting the user understand what has happened.
                        Thread.Sleep(3000); //Creates a 3 second delay.This gives the user a chance to read the message.
                    }
                    student.Add(Student); //Adds the list to a new list so it can be sorted into descending order.

                }
                List<students> sortedStudents = student.OrderByDescending(students => students.studentMark).ToList(); //This sorts the list into descending order meaning the top score will be at the top of the txt file.

                Console.WriteLine("Please open the file called grades.txt"); //notifys the user to let them know they have to open the file to see the results

                using (StreamWriter outputFile = new StreamWriter(@"E:\College\Adam\Mock 3\activity4code_Ford_A\grades.txt")) //Allows the program to where and what file the list is being exported to. 
                {
                    foreach (students Student in sortedStudents) //loops the entire list so that all of the students are exported to the txt file.
                    {
                        outputFile.WriteLine("Student Name - {0}", Student.studentName); //Adds the student name to the txt file. This is so the user can understand which student recieved what mark and grade.
                        outputFile.WriteLine("Student Mark - {0}", Student.studentMark); //Adds the student mark to the txt file. This is so the user can see what mark the student got.
                        outputFile.WriteLine("Student Grade - {0}\n", Student.studentGrade); //Adds the student grade to the txt file. This is so the user can find out what student got what grade in the exam.
                    }
                }
            }
            finally
            {

            }
        }
    }
}
