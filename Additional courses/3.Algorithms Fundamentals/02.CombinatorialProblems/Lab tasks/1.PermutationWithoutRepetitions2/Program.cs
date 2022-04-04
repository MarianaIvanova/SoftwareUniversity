using System;

namespace _1.PermutationWithoutRepetitions2
{
    class Program
    {
        //Compexity is here only n
        //We create static variables for the class, which we can use everywhere in the class. This way it won't be necessary to add them in all the methods we write - just use them!
        private static string[] elements;


        static void Main(string[] args)
        {
           //elements = new[] { "A", "B", "C" };//Elements which we will use are in this array
           elements = Console.ReadLine().Split();//Elements which we will use are in this array

            Permute(0);
        }

        private static void Permute(int index)
        {
            //Base
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(index + 1);//Тук винаги стигаме до нашето дъно!!! Имаме в масива A B C!!!! Това е нашето оригинално състояние

            //От тези A B C - искаме да сменяме разположението на два елемента т.е. с едно надясно:       
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
