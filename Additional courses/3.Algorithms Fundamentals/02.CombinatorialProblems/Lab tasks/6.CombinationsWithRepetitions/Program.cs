using System;

namespace _6.CombinationsWithRepetitions
{
    class Program
    {
        private static int k;//This is the number of slots we gonna use to put the letters
        private static string[] elements;
        private static string[] combinations;

        static void Main(string[] args)
        {
            //elements = new string[] { "A", "B", "C" };//Elements which we will use are in this array
            elements = Console.ReadLine().Split();//Elements which we will use are in this array
            k = int.Parse(Console.ReadLine());

            combinations = new string[k];//We have only k long, not elements.Length long variation

            CombinationssWithRepetitions(0, 0);
        }
        private static void CombinationssWithRepetitions(int index, int elementsStartIndex)
        {
            //Base:
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIndex; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                CombinationssWithRepetitions(index + 1, i);
            }
        }
    }
}
