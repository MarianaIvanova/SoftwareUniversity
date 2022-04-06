using System;
using System.Linq;

namespace _1.BinarySearch
{
    class Program
    {
        //Binary Search with complexity O(log(n))
        //Looking for a number. Iterative approach! In a sorted array - always! It is to find the middle element and to compare it to the number we are looking for. Then go on the left or on the right of the middle number i.e. to reduce the array in half by going to the part of the array where the number is.
        static void Main(string[] args)
        {
            //var numbers = new[] { 1, 5, 10, 15, 20, 30, 40, 50, 55, 60 };
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var number = int.Parse(Console.ReadLine());

            //Console.WriteLine(BinarySearch(numbers, 55));//8
            Console.WriteLine(BinarySearch(numbers, number));
        }

        private static int BinarySearch(int[] numbers, int number)
        {
            var left = 0;//Първоначално left е първото число на масива, а това е неговия индекс
            var right = numbers.Length - 1;//Първоначално right е последното число на масива, а това е неговия индекс

            while (left <= right)
            {
                var mid = (left + right) / 2;//Това е средния индекс

                if(numbers[mid] == number)
                {
                    return mid;
                }

                if(numbers[mid] < number)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1; //This is the result when we çan't find the number we are looking for!
        }
    }
}
