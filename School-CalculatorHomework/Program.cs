using System;

namespace School_CalculatorHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.Clear();

                Console.WriteLine("Hi! The program is running.");
                Console.WriteLine();

                double userNum1 = GetUserDouble();
                double userNum2 = GetUserDouble();

                Console.WriteLine();

                Console.WriteLine($"{userNum1} <operator> {userNum2}");
                char userOperator = GetUserChar();

                Console.WriteLine("\n---- Result ----");

                switch (userOperator)
                {
                    case '+':
                        Add(userNum1, userNum2);
                        break;
                    case '-':
                        Subtract(userNum1, userNum2);
                        break;
                    case '*':
                        Multiply(userNum1, userNum2);
                        break;
                    case '/':
                        Divide(userNum1, userNum2);
                        break;
                    case '%':
                        Modulus(userNum1, userNum2);
                        break;
                    default:
                        Console.WriteLine("Only the written operators can be used.\nPress any key to restart.");
                        Console.ReadKey();
                        continue;
                }

                programIsRunning = RestartProgramQuestion();
            }

            Console.Clear();
            Console.WriteLine("Exiting program!");
            Environment.Exit(0);
        }

        // Math methods
        static void Add(double num1, double num2)
        {
            Console.WriteLine($"{num1} + {num2} =  {num1 + num2}");
        }

        static void Subtract(double num1, double num2)
        {
            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
        }

        static void Multiply(double num1, double num2)
        {
            Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
        }

        static void Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                Console.WriteLine("Can't divide by zero. Please write the second number as non-zero.");
            }
            else
            {
                Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
            }
        }

        static void Modulus(double num1, double num2)
        {
            if (num2 == 0)
            {
                Console.WriteLine("Can't modulus by zero. Please write the second number as non-zero.");
            }
            else
            {
                Console.WriteLine($"{num1} % {num2} = {num1 % num2}");
            }
        }

        // Helper methods
        static bool RestartProgramQuestion()
        {
            Console.WriteLine("\nProgram done!");

            char userChoice;
            bool isChar;
            do
            {
                Console.WriteLine("Do you want to run the program again? y/n:");

                isChar = char.TryParse(Console.ReadLine(), out userChoice);

                if (!isChar)
                {
                    Console.WriteLine("\nOnly one character can be used. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (!isChar);

            bool restartProgram = true;
            if (userChoice.ToString().ToLower().Equals("n"))
            {
                restartProgram = false;
            }

            return restartProgram;
        }

        static double GetUserDouble()
        {
            double userNum;
            bool conversionIsSuccessful;

            do
            {
                Console.WriteLine("Write a number:");

                conversionIsSuccessful = double.TryParse(Console.ReadLine(), out userNum);
                if (!conversionIsSuccessful)
                {
                    Console.WriteLine("\nOnly numbers can be used. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (!conversionIsSuccessful);

            return userNum;
        }

        static char GetUserChar()
        {
            char userChar;
            bool conversionIsSuccessful;

            do
            {
                Console.WriteLine("Operators: +, -, *, /, %");

                conversionIsSuccessful = char.TryParse(Console.ReadLine(), out userChar);
                if (!conversionIsSuccessful)
                {
                    Console.WriteLine("\nOnly the written operators can be used. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (!conversionIsSuccessful);

            return userChar;
        }
    }
}