using System;

namespace _1.ReverseArrayTeacher
{
    class Program
    {
        //Write a program that reverses and prints an array. Use recursion.
        //Examples
        //Input	Output
        //1 2 3 4 5 6	6 5 4 3 2 1
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split(" ");

            ReverseArray(elements, 0);

            Console.WriteLine(string.Join(" ", elements));
        }

        private static void ReverseArray(string[] elements, int index)
        {
            if(index == elements.Length / 2)//При целочислено делене, този израз ще ни върне точно броя на размените на цифрите
            {
                return;
            }

            var tmp = elements[index];
            //Swap to the first and the last element, then the second and the one before the last and so on
            elements[index] = elements[elements.Length - 1 - index];
            elements[elements.Length - 1 - index] = tmp;
            ReverseArray(elements, index + 1);
        }
    }
}


