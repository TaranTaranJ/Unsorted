using System;
using System.Collections.Generic;

namespace ASDF
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "";
            byte score = 0;

            byte upperCounter = 0;
            byte lowerCounter = 0;
            byte numberCounter = 0;

            List<string> scoreBreakdown = new List<string>();

            char[] specialCharacters = new char[] { '!', '%' };

            Console.WriteLine("Welcome message");

            do
            {
                Console.WriteLine("Enter password");

                password = Console.ReadLine();
                if (password.Length >= 8 && password.Length <= 15)
                {

                }
                else
                {
                    Console.WriteLine("error message");
                }

            } while (password.Length < 8 || password.Length > 15);

            foreach (char character in password.ToCharArray())
            {
                if (char.IsUpper(character))
                {
                    upperCounter++;
                    score += 5;

                    // Finds if it exists within the list
                    if (scoreBreakdown.IndexOf("Upper case character") == -1)
                    {
                        scoreBreakdown.Add("Upper case character");
                    }
                    // Runs if upper case
                }
                else
                {
                    lowerCounter++;
                    // Runs if lower case
                }

                if (char.IsNumber(character))
                {
                    numberCounter++;
                    score += 10;
                    // Runs if a number
                }

                foreach (char specialCharacter in specialCharacters)
                {
                    if (character == specialCharacter)
                    {
                        score += 10;
                        Console.WriteLine("fsagsdfgfdsgsdfgfds");
                    }
                }

                // The hard way - Not for Harry

                /*if (Regex.IsMatch(character.ToString(), @"[!%&*+=]")) {
                    score += 10;
                }*/
            }

            if (upperCounter == password.Length || lowerCounter == password.Length)
            {
                score -= Convert.ToByte(3 * password.Length);
                // Runs if upper counter is the length of the string
            }

            if (numberCounter == password.Length)
            {
                score -= Convert.ToByte(5 * password.Length);
            }


            Console.WriteLine(score);
            Console.WriteLine($"You got score from: {upperCounter} upper case letters");
        }
    }
}