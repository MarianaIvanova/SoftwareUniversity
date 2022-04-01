using System;

namespace _7.RecursiveFibonacci
{
    class Program
    {
        //Fibonacci SHOULD be calculated with iteration NOT with recursion! 
        //a0 = 1, a1 = 1, a2 = 2, a3 = 3, a4 = 5 , a5 = 8
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());//5

            Console.WriteLine(CalcFibonacci(n));//8
        }
        //The output should be the nth Fibonacci number counting from 0 
        private static long CalcFibonacci(int n)
        {
            //Base
            if(n <= 1)
            {
                return 1;
            }

            return CalcFibonacci(n - 1) + CalcFibonacci(n - 2);
        }
    }
}
