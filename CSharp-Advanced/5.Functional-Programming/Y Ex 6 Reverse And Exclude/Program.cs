using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_6_Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int divider = int.Parse(Console.ReadLine());
            List<int> numbersReverse = new List<int>();

            for (int i = numbers.Count - 1; i >= 0 ; i--)
            {
                numbersReverse.Add(numbers[i]);
            }

            for (int j = 0; j < numbersReverse.Count; j++)
            {
                if(numbersReverse[j] % divider == 0)
                {
                    numbersReverse.RemoveAt(j);
                    j--;
                }
            }

            Console.WriteLine(string.Join(" ", numbersReverse));
        }
    }
}
