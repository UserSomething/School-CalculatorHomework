using System;
using System.Collections.Generic;

namespace School_CalculatorHomework
{
    public static class Program
    {
        static void Main(string[] args)
        {
            StartCalculator();
        }

        public static void StartCalculator()
        {
            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.Clear();

                Console.WriteLine("Hi! The program is running.");
                Console.WriteLine();

                int userNumCount = GetUserNumberCount();

                CalculateByNumberCount(userNumCount);

                programIsRunning = RestartProgramQuestion();
            }

            ExitProgram();
        }

        // Math methods
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double Add(double[] numbers)
        {
            double sum = 0;
            foreach (double number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        public static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Subtract(double[] numbers)
        {
            double difference = numbers[0];
            numbers[0] = 0;

            foreach (double number in numbers)
            {
                difference -= number;
            }

            return difference;
        }

        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double Divide(double num1, double num2)
        {
            if (num2 != 0)
            {
                return num1 / num2;
            }
            else
            {
                Console.WriteLine("Can't divide by zero. -1 means undefined.");
                return -1;
            }
        }

        public static double Modulus(double num1, double num2)
        {
            if (num2 != 0)
            {
                return num1 % num2;
            }
            else
            {
                Console.WriteLine("Can't modulus by zero. -1 means undefined.");
                return -1;
            }
        }

        // Helper methods
        static bool RestartProgramQuestion()
        {
            Console.WriteLine("\nProgram done!");

            char userChoice;
            bool conversionIsSuccessful;
            do
            {
                Console.WriteLine("Do you want to run the program again? y/n:");
                Console.Write("Choice: ");

                conversionIsSuccessful = char.TryParse(Console.ReadLine(), out userChoice);

                if (!conversionIsSuccessful)
                {
                    ShowConversionFailed();
                }
            }
            while (!conversionIsSuccessful);

            bool restartProgram = true;
            if (userChoice.ToString().ToLower().Equals("n"))
            {
                restartProgram = false;
            }

            return restartProgram;
        }

        // User input helper methods
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
                    ShowConversionFailed();
                }
            }
            while (!conversionIsSuccessful);

            return userNum;
        }

        static double[] GetDoubleArray(int numberCount)
        {
            double userNum;
            var userNumList = new List<double>(numberCount);
            bool conversionIsSuccessful;

            do
            {
                Console.Write("Write a number: ");

                conversionIsSuccessful = double.TryParse(Console.ReadLine(), out userNum);

                if (!conversionIsSuccessful)
                {
                    ShowConversionFailed();
                }
                else
                {
                    numberCount--;
                    Console.WriteLine($"{userNum} appended.\n");

                    if (numberCount > 0)
                    {
                        Console.WriteLine($"{numberCount} numbers left.");
                    }

                    userNumList.Add(userNum);
                }
            }
            while (!conversionIsSuccessful || numberCount > 0);

            return userNumList.ToArray();
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
                    ShowConversionFailed();
                }
            }
            while (!conversionIsSuccessful);

            return userChar;
        }

        // Display helper methods
        static void ShowAdditionResult(double userNum1, double userNum2)
        {
            Console.WriteLine("\n---- Result ----");
            Console.WriteLine($"{userNum1} + {userNum2} = {Add(userNum1, userNum2)}");
        }

        static void ShowSubtractionResult(double userNum1, double userNum2)
        {
            Console.WriteLine("\n---- Result ----");
            Console.WriteLine($"{userNum1} - {userNum2} = {Subtract(userNum1, userNum2)}");
        }

        static void ShowMultiplicationResult(double userNum1, double userNum2)
        {
            Console.WriteLine("\n---- Result ----");
            Console.WriteLine($"{userNum1} * {userNum2} = {Multiply(userNum1, userNum2)}");
        }

        static void ShowDivisionResult(double userNum1, double userNum2)
        {
            Console.WriteLine("\n---- Result ----");
            Console.WriteLine($"{userNum1} / {userNum2} = {Divide(userNum1, userNum2)}");
        }

        static void ShowModulusResult(double userNum1, double userNum2)
        {
            Console.WriteLine("\n---- Result ----");
            Console.WriteLine($"{userNum1} % {userNum2} = {Modulus(userNum1, userNum2)}");
        }

        static void ShowArrayCalculationResult(string userChoice, double[] userNumArray)
        {
            if (userChoice.Equals("+"))
            {
                Console.WriteLine($"Result: {Add(userNumArray)}");
            }
            else if (userChoice.Equals("-"))
            {
                Console.WriteLine($"Result: {Subtract(userNumArray)}");
            }
        }

        static void CalculateByNumberCount(int userNumCount)
        {
            double userNum1;
            double userNum2;
            char userOperator;
            double[] userNumArray;

            if (userNumCount == 2)
            {
                userNum1 = GetUserDouble();
                userNum2 = GetUserDouble();

                Console.WriteLine($"{userNum1} <operator> {userNum2}");

                userOperator = GetUserChar();

                if (userOperator.Equals('+'))
                {
                    ShowAdditionResult(userNum1, userNum2);
                }
                else if (userOperator.Equals('-'))
                {
                    ShowSubtractionResult(userNum1, userNum2);
                }
                else if (userOperator.Equals('*'))
                {
                    ShowMultiplicationResult(userNum1, userNum2);
                }
                else if (userOperator.Equals('/'))
                {
                    ShowDivisionResult(userNum1, userNum2);
                }
                else if (userOperator.Equals('%'))
                {
                    ShowModulusResult(userNum1, userNum2);
                }
                else
                {
                    Console.WriteLine("Only the written operators can be used.");
                }
            }
            else if (userNumCount > 2)
            {
                userNumArray = GetDoubleArray(userNumCount);

                Console.WriteLine("Add or subtract the array: +, -");
                Console.Write("Choice: ");
                string userChoice = Console.ReadLine().ToLower();

                ShowArrayCalculationResult(userChoice, userNumArray);
            }
        }

        static int GetUserNumberCount()
        {
            int userNumCount = 0;
            do
            {
                Console.WriteLine("How many numbers do you want to write? Two numbers and above is allowed.");
                Console.Write("Number amount: ");

                bool conversionIsSuccessful = int.TryParse(Console.ReadLine(), out userNumCount);
                if (!conversionIsSuccessful)
                {
                    ShowConversionFailed();
                }

                Console.Clear();
            }
            while (userNumCount < 2);

            return userNumCount;
        }

        static void ExitProgram()
        {
            Console.Clear();
            Console.WriteLine("Exiting program!");
            Environment.Exit(0);
        }

        static void ShowConversionFailed()
        {
            Console.WriteLine("\nWrong input type. Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}