using System;
using System.Collections.Generic;

namespace _1.BinomialCoefficientsPascal
{
    class Program
    {
        //Using Recursion and Memorization!!!
        private static Dictionary<string, long> cache;//If row = 1 and col = 1, then here string = 1-1 or row-col
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            cache = new Dictionary<string, long>();

            Console.WriteLine(GetBinomPascalCell(n, k));
        }

        private static long GetBinomPascalCell(int row, int col)
        {
            //Bases
            //1. These are the 0 cells:
            if (col == 0 || col == row)
            {
                return 1;
            }

            var key = $"{row}-{col}";
            //2.If is calculated already, it should be more than 0. We use Memorization!!!Not to calculate again and again
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            var result = GetBinomPascalCell(row - 1, col - 1) + GetBinomPascalCell(row - 1, col);

            cache[key] = result;

            return result;
        }
    }
}
//Write a program that finds the binomial coefficient () for given non-negative integers n and k.The coefficient can be found recursively by adding the two numbers above using the formula: 
 
//However, this leads to calculating the same coefficient multiple times (a problem that also occurs when solving the Fibonacci problem recursively). Use memoization to improve performance.
//You can check your answers using the picture below(row and column indices start from 0)
