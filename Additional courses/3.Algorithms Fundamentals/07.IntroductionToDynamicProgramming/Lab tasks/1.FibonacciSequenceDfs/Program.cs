using System;
using System.Collections.Generic;

namespace _1.FibonacciSequenceDfs
{
    class Program
    {
        //Using Recursion and Memorization!!!
        private static Dictionary<int, long> cache = new Dictionary<int, long>();//dp, memo

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFib(n));//For 5 we print 5, for 50 - we print 12586269025 and the result comes out in seconds, thanks to the cache
        }

        private static long CalcFib(int n)
        {
            //Bases - it mean that for n we have already found the result in the Fibonacci line:
            if(cache.ContainsKey(n))//this operation is with complexity O(1) - constant complexity
            {
                return cache[n];
            }

            if(n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            var result = CalcFib(n - 1) + CalcFib(n - 2);

            cache[n] = result;

            return result;
        }
    }
}
//	The Fibonacci sequence holds the following integers:
//	0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, …
//	The first two numbers are 0 and 1
//	Each subsequent number is the sum of the previous two numbers
//	Recursive mathematical formula:
//	F0 = 0, F1 = 1
//	Fn = Fn - 1 + Fn - 2

