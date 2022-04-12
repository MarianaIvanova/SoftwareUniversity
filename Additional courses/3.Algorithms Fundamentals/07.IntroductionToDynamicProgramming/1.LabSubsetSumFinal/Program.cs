using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.LabSubsetSumFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            //In the task we need to find a given sum from the numbers in the array, but without repeting them!
            var nums = new[] { 3, 5, 1, 4, 2 };//Да изчислим всички възможни суми, които тези числа образуват
            var target = 6;//Target sum 

            var possibleSums = GetAllPossibleSums(nums);
            if(possibleSums.ContainsKey(target))
            {
                var subset = FindSubset(possibleSums, target);

                Console.WriteLine(string.Join(" ", subset));//1 5//Изважда само първия срещнат вариант, защото сме запазили първия вариант на сумата, която сме намерили! Тази задача може да има различни решения за един и същи таргет, затова Я НЯМА В Judge!
            }
            else
            {
                Console.WriteLine($"Sum is not possible!");
            }
        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();

            while(target > 0)
            {
                var num = sums[target];
                target -= num;

                subset.Add(num);
            }

            return subset;
        }

        private static Dictionary<int, int> GetAllPossibleSums(int[] nums)
        {
            //The keys in the dictionary are the sums
            var possibleSums = new Dictionary<int, int> { { 0, 0 } };//WE SHOULD ADD sum = 0!!!!, otherwise it's not working, this is a base case we add!

            foreach (var num in nums)
            {
                //This will return all the sums we have till now:
                var currentSums = possibleSums.Keys.ToArray();//Use .ToArray(), because otherwise we have reference!!!

                foreach (var sum in currentSums)
                {
                    var newSum = sum + num;

                    //We record only one sum. The sum is together with the last number used to be added
                    if(possibleSums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    possibleSums.Add(newSum, num);
                }
            }

            return possibleSums;
        }
    }
}
