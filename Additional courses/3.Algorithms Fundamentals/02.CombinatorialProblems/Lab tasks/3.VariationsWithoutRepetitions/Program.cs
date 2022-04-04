using System;

namespace _3.VariationsWithoutRepetitions
{
    class Program
    {
        private static int k;//This is the number of slots we gonna use to put the letters
        private static string[] elements;
        private static string[] variations;
        private static bool[] used;

        static void Main(string[] args)
        {
            //elements = new string[] { "A", "B", "C" };//Elements which we will use are in this array
            elements = Console.ReadLine().Split();//Elements which we will use are in this array
            k = int.Parse(Console.ReadLine());

            variations = new string[k];//We have only k long, not elements.Length long variation
            used = new bool[elements.Length];

            VariationsWithoutRepetitions(0);
        }
        private static void VariationsWithoutRepetitions(int index)
        {
            //Base:
            if(index >= variations.Length)//variations.Length == k?
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if(!used[i])
                {
                    used[i] = true;
                    variations[index] = elements[i];
                    VariationsWithoutRepetitions(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
