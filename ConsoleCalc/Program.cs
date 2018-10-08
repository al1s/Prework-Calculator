using System;
using System.Text.RegularExpressions;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter arithmetic expression (ex. 2 + 3):");
            Console.WriteLine(GetUserInputAndCalc());
            Console.ReadLine();
        }
        static int GetUserInputAndCalc()
        {
            string userInput = default(string);
            do
            {
                userInput = Console.ReadLine();
            } while (!IsValid(userInput));
            int[] numbers = ConvertToInt(GetOperands(userInput));
            switch (GetAction(userInput))
            {
                case "+": return Add(numbers[0], numbers[1]);
                case "-": return Sub(numbers[0], numbers[1]);
                case "/": return Div(numbers[0], numbers[1]);
                case "*": return Mul(numbers[0], numbers[1]);
            }
            return default(int);
        }

        static int[] ConvertToInt(string[] operands)
        {
            return new int[] { Int32.Parse(operands[0]), Int32.Parse(operands[1]) };
        }
        public static string CleanUpInput(string expression)
        {
            Regex regex = new Regex(@"\s+");
            return regex.Replace(expression, "");
        }
        static string[] GetOperands(string expression)
        {
            return CleanUpInput(expression).Split('+', '-', '/', '*');
        }
        public static string GetAction(string expression)
        {
            Regex regex = new Regex(@"[\+-/\\*]");
            foreach (Match match in regex.Matches(
                CleanUpInput(expression)
                ))
            {
                return match.Value;
            }
            return string.Empty;
        }
        static bool IsValid(string str)
        {
            string[] numbers = GetOperands(str);
            int valueA = default(int);
            int valueB = -1;
            string action = GetAction(str);
            bool isEnoughOperands = numbers.Length == 2;
            bool isValidAction = action != string.Empty;
            bool isValidIntegers = Int32.TryParse(numbers[0], out valueA) && Int32.TryParse(numbers[1], out valueB);
            bool isDivideByZero = valueB == 0 && action == "/";
            if (!isValidAction || !isValidIntegers || !isEnoughOperands)
            {
                Console.WriteLine("Incorrect expression. Two integers and an action (+, -, *, /) expected. Try again!");
            }
            if (isDivideByZero)
            {
                Console.WriteLine("Can't divide by zero. Try again!");
            }
            return isValidIntegers && isValidAction && isEnoughOperands && !isDivideByZero;
        }

        static int GetCalcResult(string expression)
        {
            return default(int);
        }
        static int Add(int a, int b) { return a + b; }
        static int Sub(int a, int b) { return a - b; }
        static int Mul(int a, int b) { return a * b; }
        static int Div(int a, int b) { return a / b; }
    }
}
