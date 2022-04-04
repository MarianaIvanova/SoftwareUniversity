using System;
using System.Collections.Generic;

namespace _2.PermutationsWithRepetitionsAndWo
{
    class Program
    {
        private static string[] elements;
        private static List<string> results;

        static void Main(string[] args)
        {
            //elements = new[] { "A", "B", "C" };//Elements which we will use are in this array
            elements = Console.ReadLine().Split();//Elements which we will use are in this array
            results = new List<string>();

            PermutetionsWithRepetition(0);
            Console.WriteLine($"Permuatations with repetition in the basic data: {results.Count}"); //For A B B - prints 3, for A B B B B B - prints 6

            //Нулираме отново списъка:
            results = new List<string>();

            PermutetionsWithoutRepetition(0);
            Console.WriteLine($"Permuatations without repetition in the basic data: {results.Count}");//For A B B - prints 6, for A B B B B B - prints 720 - много е!!!
        }

        private static void PermutetionsWithRepetition(int index)
        {
            //Base
            if (index >= elements.Length)
            {
                results.Add((string.Join(" ", elements)));
                return;
            }

            PermutetionsWithRepetition(index + 1);
            var used = new HashSet<string> { elements[index] };

            //От тези A B C - искаме да сменяме разположението на два елемента с едно надясно т.е.
            for (int i = index + 1; i < elements.Length; i++)
            {
                //We can swap only elements which weren't used
                if (!used.Contains(elements[i]))
                {
                    Swap(index, i);
                    PermutetionsWithRepetition(index + 1);
                    Swap(index, i);

                    used.Add(elements[i]);
                }
            }
        }
        private static void PermutetionsWithoutRepetition(int index)
        {
            //Base
            if (index >= elements.Length)
            {
                results.Add((string.Join(" ", elements)));
                return;
            }

            PermutetionsWithoutRepetition(index + 1);

            //От тези A B C - искаме да сменяме разположението на два елемента с едно надясно т.е.
            for (int i = index + 1; i < elements.Length; i++)
            {
                Swap(index, i);
                PermutetionsWithoutRepetition(index + 1);
                Swap(index, i);
            }
        }
        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}