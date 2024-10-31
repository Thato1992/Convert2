using System;
using System.Collections.Generic;


namespace Convert2
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            while (true) // Start an infinite loop to keep asking for user input
            {
                Console.Write("Enter a valid number or type 'exit' to quit: ");
                string input = Console.ReadLine();

                // Check if the user wants to exit the program
                if (input.Trim().ToLower() == "exit")
                {
                    Console.WriteLine("Program exited. Thank you!");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    break; // Exit the loop and end the program
                }

                // Validate input and convert to an integer
                if (int.TryParse(input, out int number) && number >= 0 && number <= 9999)
                {
                    Console.WriteLine($"{number} -> {ConvertToWords(number)}");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number limited to four digits.");
                }
            }
        }

        static string ConvertToWords(int number)
        {
            if (number == 0) return "Zero";

            string[] units = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string[] teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            var words = new List<string>(); // List to hold parts of the number in words

            // Handle thousands place
            if (number >= 1000)
            {
                words.Add(units[number / 1000] + " Thousand");
                number %= 1000;
            }
            // Handle hundreds place
            if (number >= 100)
            {
                words.Add(units[number / 100] + " Hundred");
                number %= 100;
            }
            // Handle tens and units
            if (number >= 20)
            {
                words.Add(tens[number / 10]);
                number %= 10;
            }
            else if (number >= 10)
            {
                words.Add(teens[number - 10]);
                return string.Join(" ", words); // Join the list into a single string
            }
            // Handle units
            if (number > 0)
            {
                words.Add(units[number]);
            }

            return string.Join(" ", words); // Join the list into a single string
        }
    }



}
