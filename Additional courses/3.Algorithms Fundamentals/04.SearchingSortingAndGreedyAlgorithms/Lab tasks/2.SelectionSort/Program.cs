using System;
using System.Linq;

namespace _2.SelectionSort
{
    class Program
    {
        //Compexity for time is O(n^2)
        //The searching is to go on the first element, then to find the minimum element amoung the other elements on the right and to swap the first element with this minimum, then to go on with the second element and so on.
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            SelectionSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var minIndex = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if(numbers[minIndex] > numbers[j])
                    {
                        minIndex = j;
                    }    
                }

                Swap(i, minIndex, numbers);
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
