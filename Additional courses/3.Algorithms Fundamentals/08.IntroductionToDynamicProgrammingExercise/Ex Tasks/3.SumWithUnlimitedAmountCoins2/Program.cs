using System;
using System.Linq;

namespace _3.SumWithUnlimitedAmountCoins2
{
    class Program
    {
        //Although it looks like we need to use  Subset With Repetition Final, we can miss some of the collections, so we gonna use something else

        //Find all the collections which can be used to make a target
        static void Main(string[] args)
        {
            var coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());          

            var combinations = NumberCombinations(coins, target);
            Console.WriteLine(combinations);
        }

        private static int NumberCombinations(int[] coins, int target)
        {
            var cache = new int[target + 1];
            cache[0] = 1;//Виж обясненията в AlgorithsALLNotes файла

            foreach (var coin in coins)
            {
                for (int sum = coin; sum < target + 1; sum++)
                {
                    cache[sum] += cache[sum - coin];
                }
            }

            return cache[target];
        }
    }
}
//We have a set of coins with predetermined values, e.g. 1, 2, 5, 10, 20, 50. Given a sum S, the task is to find how many combinations of coins will sum up to S. For each value, we can use an unlimited number of coins, e.g. we can use S coins of value 1 or S/2 coins of value 2 (if S is even), etc.
