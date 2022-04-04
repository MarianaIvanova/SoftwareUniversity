using System;

namespace _1.PermutationWithoutRepetitions
{
    class Program
    {
        //Compexity is here 3n ~ n
        //We create static variables for the class, which we can use everywhere in the class. This way it won't be necessary to add them in all the methods we write - just use them!
        private static string[] elements;
        private static string[] permutations;
        private static bool[] used;

        static void Main(string[] args)
        {
            //elements = new[] { "A", "B", "C" };//Elements which we will use are in this array
            elements = Console.ReadLine().Split();//Elements which we will use are in this array
            permutations = new string[elements.Length]; //This array we will use to put the elements in it for print
            used = new bool[elements.Length]; //This array we will use to put the elements which is already used

            Permute(0);
        }

        private static void Permute(int index)
        {
            //Base
            if (index >= permutations.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            //A, B, C
            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])//If this element, which is the position i in array elements, is not used then:
                {
                    used[i] = true;//Make the element, which is the position i in array elements, to be used 
                    permutations[index] = elements[i];//Assign in the position index in the array permutations the element which is in the position i in array elements

                    Permute(index + 1);//Repeat all these actions for the rest of the positions!

                    used[i] = false;//Backtracking - Make the element, which is the position i in array elements, to be NOT used 
                }
            }
        }
    }
}
