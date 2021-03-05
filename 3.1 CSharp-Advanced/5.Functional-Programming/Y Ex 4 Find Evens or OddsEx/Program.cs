using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_4_Find_Evens_or_OddsEx
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

            Predicate<int> predicate = x => x % 2 == 0;

            if (criteria == "even")
            {
                List<int> evenNumbers = MyWhere(numbers, predicate);
                Console.WriteLine(string.Join(" ", evenNumbers));
            }
            else if (criteria == "odd")
            {
                predicate = x => x % 2 != 0;
                List<int> oddNumbers = MyWhere(numbers, predicate);
                Console.WriteLine(string.Join(" ", oddNumbers));
            }
        }

        static List<int> MyWhere(List<int> numbers, Predicate<int> predicate)
        {
            List<int> nums = new List<int>();

            foreach (var item in numbers)
            {
                if (predicate(item))
                {
                    nums.Add(item);
                }
            }

            return nums;
        }
    }
}

