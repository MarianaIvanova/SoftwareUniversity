using System;
using System.Linq;

namespace _4.InsertionSort
{
    class Program
    {
        //Compexity for time is O(n^2)
        //The searching is to go on the first element and swap it with the second if the first element is bigger. Then to check for the second and third one and if it's bigger swap, then check the thisd and the first and if it's necessary - swap and so on.
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            InsertionSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void InsertionSort(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                var j = i;//We use this j for checking the current number and the left number!

                while(j > 0 && numbers[j - 1] > numbers[j])
                {
                    Swap(j - 1, j, numbers);
                    j -= 1;
                }
            }
        }
        private static void Swap(int first, int second, int[] numbers)
        {
            var tmp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = tmp;
        }
    }
}
