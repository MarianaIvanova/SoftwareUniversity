using System;
using System.Linq;
using System.Collections.Generic;

namespace _3.BankRobbery
{
    class Program
    {
        static void Main(string[] args)
        {
            var goldBoxes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var totalSum = goldBoxes.Sum();
            var target = totalSum / 2;

            var possibleSums = GetAllPossibleSums(goldBoxes);

            if(possibleSums.ContainsKey(target))
            {
                var subsetJosh = FindSubset(possibleSums, target);

                subsetJosh = subsetJosh.OrderBy(x => x).ToList();

                var subsetPrakash = goldBoxes.ToList();

                foreach (var box in subsetJosh)
                {
                    if(subsetPrakash.Contains(box))
                    {
                        subsetPrakash.Remove(box);
                    }
                }

                subsetPrakash = subsetPrakash.OrderBy(x => x).ToList();

                Console.WriteLine(string.Join(" ", subsetJosh));
                Console.WriteLine(string.Join(" ", subsetPrakash));
            }
        }

        private static List<int> FindSubset(Dictionary<int, int> possibleSums, int newTarget)
        {
            var subset = new List<int>();

            while (newTarget > 0)
            {
                var num = possibleSums[newTarget];
                newTarget -= num;

                subset.Add(num);
            }

            return subset;
        }

        private static Dictionary<int, int> GetAllPossibleSums(int[] nums)
        {
            //The keys in the dictionary are the sums
            var possibleSums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var num in nums)
            {
                //This will return all the sums we have till now:
                var currentSums = possibleSums.Keys.ToArray();

                foreach (var sum in currentSums)
                {
                    var newSum = sum + num;

                    // We record only one sum, cause the key in the dictionary is unique. The sum is together with the last number used to be added
                    if (possibleSums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    possibleSums[newSum] = num;
                }
            }

            return possibleSums;
        }
    }
}
