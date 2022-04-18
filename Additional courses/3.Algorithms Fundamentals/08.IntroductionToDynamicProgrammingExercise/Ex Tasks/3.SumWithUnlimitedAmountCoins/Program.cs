using System;
using System.Linq;
using System.Collections.Generic;

namespace _3.SumWithUnlimitedAmountCoins
{
    class Program
    {
        //Although it looks like we need to use  Subset With Repetition Final, we can miss some of the collections, so we gonna use something else
        private static int[] cache; 

        //Find all the collections which can be used to make a target
        static void Main(string[] args)
        {
            var coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());

            cache = new int[target + 1];

            var combinations = NumberCombinations(coins, target);
            Console.WriteLine(combinations);
        }

        private static int NumberCombinations(int[] coins, int target)
        {
            cache[0] = 1;//Виж обясненията в AlgorithsALLNotes файла

            for (int num = 0; num < coins.Length; num++)
            {
                for (int sum = 1; sum < target + 1; sum++)
                {
                    var prevCashe = sum - coins[num];
                    if(prevCashe < 0)
                    {
                        continue;
                    }

                    cache[sum] += cache[prevCashe];
                }
            }

            return cache[target];
        }
    }
}
//We have a set of coins with predetermined values, e.g. 1, 2, 5, 10, 20, 50. Given a sum S, the task is to find how many combinations of coins will sum up to S. For each value, we can use an unlimited number of coins, e.g. we can use S coins of value 1 or S/2 coins of value 2 (if S is even), etc.