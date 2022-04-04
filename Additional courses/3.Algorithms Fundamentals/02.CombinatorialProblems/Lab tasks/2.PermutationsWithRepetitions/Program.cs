using System;
using System.Collections.Generic;

namespace _2.PermutationsWithRepetitions
{
    class Program
    {
        //THIS WAY WE NEED TO GO THROUGH ALL PERMUTATIONS i.e. N! In Judge this has: 80/100, because of the time limit!
        //We create static variables for the class, which we can use everywhere in the class. This way it won't be necessary to add them in all the methods we write - just use them!
        private static string[] elements;
        private static HashSet<string> permutations;//We add the the array of elements to the hashset to avoid the repetition of one and the same arrays of elements


        static void Main(string[] args)
        {
            //elements = new[] { "A", "B", "C" };//Elements which we will use are in this array
            elements = Console.ReadLine().Split();//Elements which we will use are in this array
            permutations = new HashSet<string>();

            Permute(0);

            Console.WriteLine(string.Join(Environment.NewLine, permutations));
        }

        private static void Permute(int index)
        {
            //Base
            if (index >= elements.Length)
            {
                permutations.Add(string.Join(" ", elements));
                return;
            }

            Permute(index + 1);//Тук винаги стигаме до нашето дъно!!! Имаме в масива A B C!!!!

            //От тези A B C - искаме да сменяме разположението на два елемента с едно надясно т.е.
            for (int i = index + 1; i < elements.Length; i++)
            {
                Swap(index, i);
                Permute(index + 1);//SEEE IT AGAIN MINUTE 0:46 - 1:00 and debugging!
                Swap(index, i);//SEEE IT AGAIN MINUTE 0:46 - 1:00
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
