using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_4_Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int start = range[0];
            int end = range[1];

            string criteria = Console.ReadLine();

            Func<int, int, List<int>> generateList = (start, end) =>
            {
                List<int> nums = new List<int>();
                for (int i = start; i <= end; i++)
                {
                    nums.Add(i);
                }
                return nums;
            };

            List<int> numbers = generateList(start, end);

            if(criteria == "even")
            {
                Func<int, bool> evenPredicate = x => x % 2 == 0;
                List<int> evenNumbers = numbers.Where(evenPredicate).ToList();
                Console.WriteLine(string.Join(" ", evenNumbers));
            }
            else if(criteria == "odd")
            {
                Func<int, bool> oddPredicate = x => x % 2 != 0;
                List<int> oddNumbers = numbers.Where(oddPredicate).ToList();
                Console.WriteLine(string.Join(" ", oddNumbers));
            }

        }

        static List<int> EvenNumbers(int[] range)
        {
            List<int> numsEven = new List<int>();

            for (int i = 0; i < range.Length; i++)
            {
                if(range[i] % 2 == 0)
                {
                    numsEven.Add(range[i]);
                }
            }

            return numsEven;
        }
        static List<int> OddNumbers(int[] range)
        {
            List<int> numsOdd = new List<int>();

            for (int i = 0; i < range.Length; i++)
            {
                if (range[i] % 2 != 0)
                {
                    numsOdd.Add(range[i]);
                }
            }

            return numsOdd;
        }
    }
}
