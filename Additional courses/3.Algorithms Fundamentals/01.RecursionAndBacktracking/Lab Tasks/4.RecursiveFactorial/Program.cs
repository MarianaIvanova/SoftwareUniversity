using System;

namespace _4.RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFactorialRecursively(n));
        }

        private static int CalcFactorialRecursively(int n)
        {
            if(n == 0)//Because 0! = 1
            {
                return 1;
            }

            return n * CalcFactorialRecursively(n - 1);
        }
    }
}
