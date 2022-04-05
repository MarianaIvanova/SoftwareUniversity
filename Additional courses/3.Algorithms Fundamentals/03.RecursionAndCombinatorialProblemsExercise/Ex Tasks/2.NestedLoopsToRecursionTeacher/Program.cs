using System;

namespace _2.NestedLoopsToRecursionTeacher
{
    class Program
    {
        private static int n;
        private static int[] result;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            result = new int[n];

            NestedLoops(0);
        }

        private static void NestedLoops(int index)
        {
            if (index >= result.Length)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }
            for (int i = 1; i <= result.Length; i++)
            {
                result[index] = i;
                NestedLoops(index + 1);
            }
        }
    }
}
//2.Nested Loops To Recursion
//Write a program that simulates the execution of n nested loops from 1 to n which prints the values of all its iteration variables at any given time on a single line. Use recursion.
//Examples
//Input	Output
//2	
//1 1
//1 2
//2 1
//2 2
//3	
//1 1 1
//1 1 2
//1 1 3
//1 2 1
//1 2 2
//…
//3 2 3
//3 3 1
//3 3 2
//3 3 3

