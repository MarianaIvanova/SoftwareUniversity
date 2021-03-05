using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_9_List_of_Predicates2
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();

            for (int k = 0; k < end; k++)
            {
                numbers.Add(k + 1);
            }

            List<int> dividers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            Console.WriteLine(string.Join(" ", CheckDivisability(numbers, dividers)));
        }

        static List<int> CheckDivisability(List<int> numbers, List<int> dividers)
        {
            List<int> divisibleNumbers = new List<int>();
            for (int i = 1; i <= numbers.Count; i++)
            {
                int counter = 0;
                for (int j = 0; j < dividers.Count; j++)
                {
                    if (numbers[i - 1] % dividers[j] == 0)
                    {
                        counter++;
                    }
                }

                if (counter == dividers.Count)
                {
                    divisibleNumbers.Add(i);
                }
            }

            return divisibleNumbers;
        }
    }
}
