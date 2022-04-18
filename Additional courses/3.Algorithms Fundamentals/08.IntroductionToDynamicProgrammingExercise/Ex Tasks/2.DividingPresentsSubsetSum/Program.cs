using System;
using System.Linq;
using System.Collections.Generic;

namespace _2.DividingPresentsSubsetSum
{
    class Program
    {
        //Using subset sums!
        //Mine with the hint of the teacher to use subset sums!!!
        static void Main(string[] args)
        {
            //Да изчислим всички възможни суми, които тези числа образуват и да видим коя е най-близка до тази, която е сума на всички, делена на 2
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();//new[] { 2 2 4 4 1 1};

            var totalSum = nums.Sum();
            var target = totalSum / 2;

            var possibleSums = GetAllPossibleSums(nums);

            //Най-близкото до таргета число, но по-малко от него
            var newTarget = possibleSums
                .Where(x => x.Key <= target)
                .OrderByDescending(x => x.Key)
                .FirstOrDefault().Key;

            var subset = FindSubset(possibleSums, newTarget);

            var amountAlan = newTarget;
            var amountBob = totalSum - newTarget;
            var difference = amountBob - amountAlan;

            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Alan:{amountAlan} Bob:{amountBob}");
            Console.WriteLine($"Alan takes: {string.Join(" ", subset)}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static List<int> FindSubset(Dictionary<int, int> possibleSums, int newTarget)
        {
            var subset = new List<int>();

            while(newTarget > 0)
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
            var possibleSums = new Dictionary<int, int> { { 0, 0 } };// WE SHOULD ADD sum = 0!!!!, otherwise it's not working, this is a base case we add!

            foreach (var num in nums)
            {
                //This will return all the sums we have till now:
                var currentSums = possibleSums.Keys.ToArray();//Use .ToArray(), because otherwise we have reference!!!


                foreach (var sum in currentSums)
                {
                    var newSum = sum + num;

                    // We record only one sum, cause the key in the dictionary is unique. The sum is together with the last number used to be added
                    if(possibleSums.ContainsKey(newSum))
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
//Alan and Bob are twins. For their birthday they received some presents and now they need to split them amongst themselves. The goal is to minimize the difference between the values of the presents received by the two brothers, i.e. to divide the presents as equally as possible. 
//Assume the presents have values represented by positive integer numbers and that presents cannot be split in half (a present can only go to one brother or the other). 
//Find the minimal difference that can be obtained and print which presents each brother has received (you may only print the presents for one of them, it is obvious that the rest will go to the other brother).
//In the examples below Alan always takes a value less than or equal to Bob, but you may do it the other way around.


