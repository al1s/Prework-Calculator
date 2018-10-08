using System;
using System.Text.RegularExpressions;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter arithmetic expression (ex. 2 + 3):");
            Console.WriteLine(getUserInputAndCalc());
            Console.ReadLine();
        }
        static int getUserInputAndCalc()
        {
            string userInput = default(string);
            do
            {
                userInput = Console.ReadLine();
            } while (!isValid(userInput));
            int[] numbers = convertToInt(getOperands(userInput));
            switch (getAction(userInput))
            {
                case "+": return Add(numbers[0], numbers[1]);
                case "-": return Sub(numbers[0], numbers[1]);
                case "/": return Div(numbers[0], numbers[1]);
                case "*": return Mul(numbers[0], numbers[1]);
            }
            return default(int);
        }

        static int[] convertToInt(string[] operands)
        {
            return new int[] {Int32.Parse(operands[0]), Int32.Parse(operands[1])};
        }
        public static string cleanUpInput (string expression)
        {
            Regex regex = new Regex(@"\s+");
            return regex.Replace(expression, "");
        }
        static string[] getOperands(string expression)
        {
            return cleanUpInput(expression).Split('+', '-', '/', '*');
        }
        public static string getAction(string expression)
        {
            Regex regex = new Regex(@"[\+\-\\\*]");
            foreach (Match match in regex.Matches(
                cleanUpInput(expression)
                ))
            {
                return match.Value;
            }
            return string.Empty;
        }
        static bool isValid(string str)
        {
            string[] numbers = getOperands(str);
            int value = default(int);
            bool isEnoughOperands = numbers.Length == 2;
            bool isValidAction = getAction(str) != string.Empty;
            bool isValidIntegers = Int32.TryParse(numbers[0], out value) && Int32.TryParse(numbers[1], out value);
            if (!isValidAction || !isValidIntegers || !isEnoughOperands)
            {
                Console.WriteLine("Incorrect expression. Two integers and an action (+, -, *, /) expected. ");
            }
            return isValidIntegers && isValidAction && isEnoughOperands;
        }

        static int getCalcResult(string expression)
        {
            return default(int);
        }
        static int Add(int a, int b) { return a + b; }
        static int Sub(int a, int b) { return a - b; }
        static int Mul(int a, int b) { return a * b; }
        static int Div(int a, int b) {
            if (b == 0) return 0;
            return a / b;
        }
    }
}
