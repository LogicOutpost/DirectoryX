using System;

namespace DirectoryX
{
    class Validation
    {
        public string InputValidation(string? message)
        {
            // while string has no input, keep asking for input 
            while (string.IsNullOrEmpty(message))
            {
                Console.WriteLine("Your input can not be empty");
                message = Console.ReadLine();
            }
            // return the input when it is called
            return message;
        }

        public int NumberValidation(string? message)
        {
            while (true)
            {
                while (string.IsNullOrEmpty(message))
                {
                    Console.WriteLine("Your input can not be empty");
                    message = Console.ReadLine();
                }
                // if input is a valid number, parse string into an int 
                if (int.TryParse(message, out int result))
                {
                    return result;
                }
                // ask users to input a valid number if their input is not already a number
                Console.WriteLine("Enter a valid number");
                message = Console.ReadLine();
            }
        }
    }
}