using System;

namespace _2.LabRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = Sum(a, b);
        }

        //Recursion without condition or base case - the result is stack overflow as the call stack has a limited size:
        public static int Sum(int a, int b)
        {
            return Sum(a, b);
        }
    }
}
