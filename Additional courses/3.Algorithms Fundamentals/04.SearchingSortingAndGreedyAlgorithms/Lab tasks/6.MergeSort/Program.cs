using System;
using System.Linq;

namespace _6.MergeSort
{
    class Program
    {
        //Compexity for time is O(n*log(n))
        //We split the first array in two arrays, then each of the arrays to two arrays, till we have many arrays which consist only of 1 element each. Then we rearrange them the way we want.
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var sorted = MergeSort(numbers);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] numbers)
        {
            //Base we reach when the array consist only of 1 element, then we return this array
            if(numbers.Length <= 1)
            {
                return numbers;
            }
            //This way we split the array to 2 arrays:
            var left = numbers.Take(numbers.Length / 2).ToArray();//Take the first half elements of the array
            var right = numbers.Skip(numbers.Length / 2).ToArray();//Skip the first half elements of the array and take the rest

            //Starting to gather together all arrays in one. This will start when we reach the bottom/base:
            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            //The new array will gather all elements of the two arrays, so it should be this long:
            var mergedNumbers = new int[left.Length + right.Length];

            //Sorting
            var leftIndex = 0;
            var rightIndex = 0;
            var merged = 0;

            while(leftIndex < left.Length && rightIndex < right.Length)
            {
                if(left[leftIndex] < right[rightIndex])
                {
                    mergedNumbers[merged++] = left[leftIndex++];
                    //leftIndex += 1;
                    //merged += 1;
                }
                else
                {
                    mergedNumbers[merged++] = right[rightIndex++];
                    //rightIndex += 1;
                   // merged += 1;
                }
            }

            //if we have left numbers in some of the arrays we need to add them so:
            for (int i = leftIndex; i < left.Length; i++)
            {
                mergedNumbers[merged++] = left[i];
            }

            for (int i = rightIndex; i < right.Length; i++)
            {
                mergedNumbers[merged++] = right[i];
            }

            return mergedNumbers;
        }
    }
}


