using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int upperCounter = 0;
            string password = "fgsdfgf";
            string charactes = "fgsdfgf";
            Console.WriteLine("Hello World!");

            List<string> scoreBreakdown = new List<string>();

            char[] specialCharacters = new char[] { '!', '%' };

            

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

                foreach (char specialCharacter in specialCharacters)
                {
                    if (character == specialCharacter)
                    {
                        score += 10;
                        Console.WriteLine("fsagsdfgfdsgsdfgfds");
                    }
                }

                if (char.IsLower(character))
                {
                    score = 5;
                }
            }
            foreach (char characte in charactes.ToCharArray())
            {
                if (char.IsUpper(characte))
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
            }
        }
    }
}
