using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.ReverseArray
{
    class Program
    {
        //Mine - more complex then it should be! I swap the first with the second, then second with third and soon.
        //Write a program that reverses and prints an array. Use recursion.
        //Examples
        //Input	Output
        //1 2 3 4 5 6	6 5 4 3 2 1
        private static int maxLength;
        private static string[] array;
        static void Main(string[] args)
        {
            array = Console.ReadLine().Split(" ");

            maxLength = array.Length - 1;

            ReverseArray1(0);

            Console.WriteLine(string.Join(" ", array));
            
        }
        private static void ReverseArray1(int index)
        {
            if (maxLength == 0)
            {
                return;
            }
            ReverseArray2(index);
            maxLength = maxLength - 1;
            ReverseArray1(index);
        }

        private static void ReverseArray2(int index)
        {
            if (index >= maxLength)
            {
                return;
            }           
                Swap(index, index + 1);
                ReverseArray2(index + 1);
        }

        private static void Swap(int first, int second)
        {
            var tmp = array[first];
            array[first] = array[second];
            array[second] = tmp;
        }
    }
}
