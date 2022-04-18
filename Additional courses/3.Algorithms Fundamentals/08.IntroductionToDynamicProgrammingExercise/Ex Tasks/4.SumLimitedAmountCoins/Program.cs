using System;
using System.Linq;
using System.Collections.Generic;

namespace _4.SumLimitedAmountCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            //Using subset sums! And every time when we generate a sum, we need to increase the combination for this sum with 1
            //

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();//coins
            var target = int.Parse(Console.ReadLine());

            Console.WriteLine(CountSum(numbers, target));
        }

        private static int CountSum(int[] numbers, int target)
        {
            var count = 0;

            var sums = new HashSet<int> { 0 };//IMPORTANT!!!

            foreach (var num in numbers)
            {
                var newSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    var newSum = num + sum;

                    if(newSum == target)
                    {
                        count += 1;
                    }

                    newSums.Add(newSum);
                }

                sums.UnionWith(newSums);
            }

            return count;
        }
    }
}
//In the previous problem, the coins represented values, not actual coins (we could take as many coins of a certain value as we wanted). In this problem, we’ll regard the coins as actual coins, e.g. 1, 2, 5 are three coins and we can use each of them only once. We can, of course, have more coins of a given value, e.g. – 1, 1, 2, 2, 10.
//The task is the same - find the number of ways we can combine the coins to obtain a certain sum S.
//Example
//Input    Comments
//1 2 2 3 3 4 6
//6	
//Output
//4	
//The 4 combinations are:
//6 = 6
//6 = 4 + 2
//6 = 3 + 3
//6 = 3 + 2 + 1

