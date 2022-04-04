using System;

namespace _4.VariationsWithRepetitions
{
    class Program
    {
        private static int k;//This is the number of slots we gonna use to put the letters
        private static string[] elements;
        private static string[] variations;


        static void Main(string[] args)
        {
            //elements = new string[] { "A", "B", "C" };//Elements which we will use are in this array
            elements = Console.ReadLine().Split();//Elements which we will use are in this array
            k = int.Parse(Console.ReadLine());

            variations = new string[k];//We have only k long, not elements.Length long variation

            VariationsWithRepetitions(0);
        }
        private static void VariationsWithRepetitions(int index)
        {
            //Base:
            if (index >= variations.Length)//variations.Length == k?
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                    variations[index] = elements[i];
                    VariationsWithRepetitions(index + 1);
            }
        }
    }
}
