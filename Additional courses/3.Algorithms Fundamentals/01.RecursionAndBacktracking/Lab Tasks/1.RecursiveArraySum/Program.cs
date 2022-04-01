using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int sum = RecursiveArraySum(numbers, 0);
            Console.WriteLine(sum);
        }

        private static int RecursiveArraySum(int[] numbers, int index)
        {
            //Base case mine:
            //if(index > numbers.Length - 1)
            //{
            //    return 0;
            //}

            if (index == numbers.Length - 1)
            {
                return numbers[index];
            }
            return numbers[index] + RecursiveArraySum(numbers, index + 1);//This doesn't work work with index++, should be index + 1
        }
    }
}
