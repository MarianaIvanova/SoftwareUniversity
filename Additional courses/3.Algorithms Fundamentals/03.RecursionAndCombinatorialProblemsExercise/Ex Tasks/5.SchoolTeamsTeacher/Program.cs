using System;
using System.Linq;
using System.Collections.Generic;

namespace _5.SchoolTeamsTeacher
{
    class Program
    {
        private static int k = 3; //Number of girls to be chosen
        private static int p = 2; //Number of boys to be chosen
        static void Main(string[] args)
        {
            var allGirls = Console.ReadLine().Split(", ");
            var allBoys = Console.ReadLine().Split(", ");

            var combinationGirls = new string[k];
            var combinationBoys = new string[p];

            var combsGirls = new List<string[]>();
            var combsBoys = new List<string[]>();

            //Using 2 times one and the same method, that why we didn't make static varables:
            GenCombWithoutRepetition(0, 0, allGirls, combinationGirls, combsGirls);
            GenCombWithoutRepetition(0, 0, allBoys, combinationBoys, combsBoys);

            PrintFinalComb(combsGirls, combsBoys);
        }

        private static void PrintFinalComb(List<string[]> combsGirls, List<string[]> combsBoys)
        {
            foreach (var girlComb in combsGirls)
            {
                foreach (var combBoys in combsBoys)
                {
                    Console.WriteLine($"{string.Join(", ", girlComb)}, {string.Join(", ", combBoys)}");
                }
            }
        }

        private static void GenCombWithoutRepetition(int index, int start, string[] all, string[] comb, List<string[]> combinations)
        {
            //Base
            if (index >= comb.Length)
            {
                //if we use a list with arrays, not a list of string we need to make it with .ToArray(), not to make it as a reference - should be like this:
                combinations.Add(comb.ToArray());
                return;
            }

            for (int i = start; i < all.Length; i++)
            {
                comb[index] = all[i];
                GenCombWithoutRepetition(index + 1, i + 1, all, comb, combinations);
            }
        }
    }
}

