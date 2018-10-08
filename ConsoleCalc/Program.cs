using System;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter arithmetic expression:");
            string input = getUserInput();
            Console.WriteLine(getCalcResult(input));
            Console.ReadLine();
        }
        static string getUserInput()
        {
            return default(String);
        }

        static int getCalcResult(string expression)
        {
            return default(int);
        }
        static int Add(int a, int b) { return a + b; }
        static int Sub(int a, int b) { return a - b; }
        static int Mul(int a, int b) { return a * b; }
        static int Div(int a, int b) { return a / b; }
    }
}
