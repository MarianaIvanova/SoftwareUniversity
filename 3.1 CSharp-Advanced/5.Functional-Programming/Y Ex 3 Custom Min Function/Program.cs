using System;
using System.Linq;

namespace Y_Ex_3_Custom_Min_Function//Without Func<>
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int minNumber = numbers.Min();
            Console.WriteLine(minNumber);
        }
    }
}
