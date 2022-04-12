using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.LabSubsetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 3, 5, 1, 4, 2 };//Да изчислим всички възможни суми, които тези числа образуват
            var target = 6;//Target sum - the code is just to chech if we have or not this sum, but we don't know which numbers make it

            var possibleSums = GetAllPossibleSums(nums);

            ////All possible cmbinations
            //Console.WriteLine(string.Join(", ", possibleSums));//0, 3, 5, 8, 1, 4, 6, 9, 7, 12, 10, 13, 2, 11, 14, 15

            Console.WriteLine(possibleSums.Contains(target));//true
        }

        private static HashSet<int> GetAllPossibleSums(int[] nums)
        {
            var possibleSums = new HashSet<int> { 0 };//WE SHOULD ADD sum = 0!!!!, otherwise it's not working, this is a base case we add!

            foreach (var num in nums)
            {
                //Това е само за новите суми, които се образуват от старите + новото число. Използваме нов сет, защото ако ползваме стария, постоянно броя на числата в него се увеличава и неможем да използваме foreach, защото ще стане stack overflow
                var newSums = new HashSet<int>();

                foreach (var sum in possibleSums)
                {
                    newSums.Add(sum + num);
                }

                possibleSums.UnionWith(newSums);
            }

            return possibleSums;
        }
    }
}
