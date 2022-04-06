using System;
using System.Linq;

namespace _5.Quicksort
{
    class Program
    {
        //Compexity for time is O(
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Quicksort(numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Quicksort(int[] numbers, int start, int end)
        {
            //Base:
            if(start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                //when we reach to the point when left and write has been swaped, cause:
                if (numbers[left] > numbers[pivot] && numbers[right] < numbers[pivot])
                {
                    //Swap(right, left, numbers);
                    Swap(left, right, numbers);
                }

                if (numbers[left] <= numbers[pivot])
                {
                    left += 1;
                }

                if (numbers[right] >= numbers[pivot])
                {
                    right -= 1;
                }
            }

            Swap(pivot, right, numbers);
            //We should make first the array, which is smaller
            var leftArrayIsSmaller = right - 1 - start < end - right - 1;
            if(leftArrayIsSmaller)
            {
                Quicksort(numbers, start, right - 1);//this is for the left array
                Quicksort(numbers, right + 1, end);//this is for the right array
            }
            else
            {
                Quicksort(numbers, right + 1, end);//this is for the right array
                Quicksort(numbers, start, right - 1);//this is for the left array
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

