using System;

namespace _1.LinearSearch
{
    class Program
    {
        //Linear Search with complexity O(n)
        //Looking for the index of the searched number:
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };


            Console.WriteLine(LinearSearch(numbers, 3));//2
        }

        private static int LinearSearch(int[] numbers, int number)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] == number)
                {
                    return i;
                }
            }

            return -1; //This is the result when we çan't find the number we are looking for!
        }
    }
}
