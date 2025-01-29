#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            const int bonusPercentage = 15; // This integer stores the bonus percentage to be applied to the employee with the most sales, I marked it as a constant as it will never change throughout the program and this stops acidental re-assignment from occuring.

            int totalCommission = 0; // This stores the total amount of money earnt for every commission. This is an integer as only whole products can be sold meaniing there will never be the introduction of a decimal place.
            int totalSold = 0; // This stores the total amount of sold products from each employee. This is also an integer as employees are only going to sell whole numbers of houses rather than a half or a quarter.

            int IntInput(string message, int min, int max)
            { // This is a function to gather an input from the user in the type of "int", this is used to ensure it is of the correct type and fits within given bounds. If it does not meet the bounds the inside of the function repeats until all success critera are met.
                bool canPass = false; // This variable stores whether the while loop can end / pass onto the next part of the program. It starts a false as the loop should run by default.
                int toReturn = 0; // This is the variable that will be returned by the function, it is set to 0 by default as otherwise it would be unable to be assigned to further down the loop.

                while (!canPass)
                { // While the "canPass" variable is set to false the lines contained within the loop will run.
                    Console.WriteLine(message); // The message passed by the user is output onto the console.

                    if (!int.TryParse(Console.ReadLine(), out toReturn))
                    { // This line will attempt to parse the user's input into an integer, if it does the function will return "true", if it does not "false" will be returned.
                        Console.WriteLine("Please only provide an integer as an input"); // If the TryParse fails it will return false, meaning that this statement will fire. This statement will output an error telling the user than only an integer can be used for this input.
                    }
                    else if (toReturn < min || toReturn > max)
                    { // If the check succeeds this if statement will run as the input was an integer. This will ensure that the input that the user has given is within the correct bounds by comparing it with the "min" argument passed and the "max" argument passed.
                        Console.WriteLine("Please provide a number within the specified bounds"); // If it is outside the bounds the program will output an error telling the user that the number is outside the required bounds.
                    }
                    else
                    { // If the input the user has given passes all checks this else statement will fire, setting the canPass variable to true allowing the function to end and the value to be returned.
                        canPass = true; // This sets the canPass variable to true allowing the while statement to end and allowing the program to move onto the next part.
                    }
                }

                return toReturn; // This returns the toReturn variable which will be set to whatever the user has provided as an input.
            }

            string StringInput(string message)
            { // This is a function that will allow the program to take user input as a string, while this is normally possible using a function allows for extra checks to be in place such as length checks.
                bool canPass = false; // This variable stores whether the while loop can end, it is set to false by default as the loop should be active by default.
                string toReturn = ""; // This stores the value that the function will return, it is set to a blank string by default so it can be assigned to later on.

                while (!canPass)
                { // This will run the for loop while the canPass variable is set to false.
                    Console.WriteLine(message); // As soon as the loop runs the message passed by the user is printed allowing the user to know what sort of input is requiered such as a name or username.

                    string temp = Console.ReadLine(); // This reads the user's input and stores it in a temporary variable called temp, this is done as checks need to be carried out so it is not yet ready to be assigned to the return variable.
                    if (temp.Trim().Length <= 0)
                    { // This will ensure that the string is not empty, by using .Trim() it ensures that no leading or trailing whitespace exists meaning that a user putting their input as just a space will be caught and will return an error.
                        Console.WriteLine("Please provide a string with a length greater than 0"); // This will print out an error if the input's length is less than or equal to 0. While there is little to no chance of it being less than 0 it is important to check for edge cases.
                    }
                    else
                    { // If the length is more than 0 this else statement will be fired and all code inside run.
                        toReturn = temp; // As the string has passed all checks the toReturn variable is assigned to the temporary variable's value meaning it can be returned by the function.
                        canPass = true; // The canPass value is set to true allowing the while loop to finish and the program to move on to the next line.
                    }
                }

                return toReturn; // This line returns the user's input from the function.
            }

            List<Employee> employees = new List<Employee>(); // This creates a new list to store employees, a list is used as a fixed length is not known of the amount of employees. It is also used as lists have a sorting function built-in, making it much easier when it comes to sorting the list.

            int employeeAmount = IntInput("Please provide the number of employees. Minimum = 2 | Maximum = 5", 2, 5); // This line gathers the user's input for the amount of employees they wish to input for, with a minimum of 2 and a maximum of 5 in place. This uses the IntInput function.

            for (int employeeNumber = 1; employeeNumber < employeeAmount + 1; employeeNumber++)
            { // This loops for the amount of employees selected, it adds one to the employee amount so that when printing the employee number it starts at 1 rather than 0 making it more user friendly.
                Employee employee = new Employee
                { // This creates a new instance of the Employee class, setting all the public values of the class inline with the creation to make it easier to read when reviewing or modifying the code.
                    Name = StringInput($"What is employee {employeeNumber}'s name?"), // This will set the name property of the new employee to the result of the StringInput function. The funciton is passed an argument for the message to display.
                    EmployeeID = IntInput($"What is employee {employeeNumber}'s ID?", 0, 1000), // This will set the employee id property of the new employee to the result of the IntInput function. The funciton is run with arguments for the message, minimum number and maxmimum number.
                    PropertiesSold = IntInput($"What is employee {employeeNumber}'s amount of sold properties?", 0, 1000) // This will set the properties sold property of the new employee to the result of the IntInput function. The funciton is run with arguments for the message, minimum number and maxmimum number.
                };
                employee.SalesCommission = employee.PropertiesSold * 500; // This will set the sales comission property of the employee to their properties sold times 500, this can not be set inline with the others as it uses one of the properties in its calculation, meaning it must be set outside of the creation.

                totalSold += employee.PropertiesSold; // This updates the totalSold variable with the amount of properties sold by the employee,

                employees.Add(employee); // This adds the new employee to the employee list, allowing it to be sorted and used later.

                Console.Clear(); // This clears the console to provide an easier to use experience when users go to input employees.
            }

            List<Employee> sortedEmployees = employees.OrderByDescending(employee => employee.PropertiesSold).ToList(); // This line sorts the employees in descending order by the amount of properties sold. Due to the sort returning an enumerable object it is conveted to a list for ease of use.

            sortedEmployees[0].SalesCommission += sortedEmployees[0].SalesCommission / 100 * bonusPercentage; // This adds 15% on to the sales comission for the person with the most sales, this is done to the employee at 0 index as due to it being sorted we know that they will be the one with the most sales.

            foreach (Employee employee in sortedEmployees)
            { // This loops through each employee in the sortedEmployees list, this is a foreach loop as use of the index is not required for what is being done.
                totalCommission += employee.SalesCommission; // This updates the total sales comission with the comission of each employee. This is done here as if it were to be done when the employee is created the bonus would not be applied to the calculation.
            }

            string[] employeeInfoSelectString = sortedEmployees.Select(employee => { // This function acts like a map function in JavaScript, taking each entry in the sortedEmployees list and creating a string. These strings are then added to a string array as the end result is converted to an array. This could have been converted to a list however no further modifications are required to be done so it is safe to assume nothing will be added nor modified.
                return
                $"\n - Name: {employee.Name}" + // This adds the employee's name to the string.
                $"\n - Employee ID: {employee.EmployeeID}" + // This adds the employee's ID to the string.
                $"\n - Properties sold: {employee.PropertiesSold}" + // This adds the employee's properties sold to the string.
                $"\n - Commission: £{Math.Round((double)employee.SalesCommission, 2)}"; // This adds the sales comission for the employee to the string, casting it to a double to allow it to be rounded to 2 decimal places as per the brief.
            }).ToArray(); // This converts the end result from an enumerable to a string array allowing it to be assigned to the string array variable.

            Console.WriteLine($"List of employees in order of properties sold: {string.Join("\n", employeeInfoSelectString)}"); // This writes out the amount of properties sold by each employee, joining the newly created string array by new lines to create an easy to read output for the end-user.
            Console.WriteLine($"\nTotal commission: £{Math.Round((double)totalCommission, 2)}"); // This writes out the total comission for the company, casted to a double allowing for the rounding to 2 decimal places as per the brief.
            Console.WriteLine($"Total properties sold: {totalSold}"); // This writes out the total propeties sold by the company.
            Console.WriteLine($"\nTotal commission for each employee: {string.Join("", sortedEmployees.Select(employee => $"\n - {employee.Name}: {employee.SalesCommission}"))}"); // This writes out the total comission for each employee, using a select statement on the sortedEmployees list to quickly print out each employee's name and their sales commission.
            Console.WriteLine($"\nEmployee that sold the most: {sortedEmployees[0].Name} (Sold {sortedEmployees[0].PropertiesSold} properties)"); // This prints out the name and amount of properties sold for the employee who sold the most. This can be assumed to be the 0 index as the array has been sorted by the amount sold on each employee.
            Console.WriteLine($"Bonus amount to be applied to: {sortedEmployees[0].Name} ({bonusPercentage}%)"); // This prints out the bonus amount they will recieve as well as the name of the employee recieving it.
        }
    }
}

#nullable disable

namespace Program
{
    internal class Employee
    {
        public string Name { get; set; }
        public int EmployeeID { get; set; }
        public int SalesCommission { get; set; }
        public int PropertiesSold { get; set; }
    }
}