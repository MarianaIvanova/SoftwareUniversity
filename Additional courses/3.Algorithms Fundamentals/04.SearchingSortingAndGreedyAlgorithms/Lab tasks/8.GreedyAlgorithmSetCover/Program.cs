using System;
using System.Linq;
using System.Collections.Generic;

namespace _8.GreedyAlgorithmSetCover
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is a set of numbers, which we gonna make a hashset:
            var universe = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToHashSet();//

            //This is the number of the subsets, which we will receive:
            var n = int.Parse(Console.ReadLine());

            var sets = new List<int[]>();

            //Reading all n subsets:
            for (int i = 0; i < n; i++)
            {
                var set = Console.ReadLine()
                        .Split(", ")
                        .Select(int.Parse)
                        .ToArray();

                sets.Add(set);
            }

            var selectedSets = new List<int[]>();

            while(universe.Count > 0)
            {
                //We take the set which has the most elements, which we have in universal. The tasks says that all elements from these sets are the same as the universe, but when we delete the already used elements in the universe, it will not be like this! So every time we go through the loop, we need to order them and take the set which has the most elements, which we have in universal!
                var currentBestSet = sets
                    .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                    .FirstOrDefault();

                selectedSets.Add(currentBestSet);

                sets.Remove(currentBestSet);

                //for (int i = 0; i < currentBestSet.Length; i++)
                //{
                //    universe.Remove(currentBestSet[i]);
                //}
                foreach (var element in currentBestSet)
                {
                    universe.Remove(element);
                }
            }

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (var set in selectedSets)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }
    }
}
 