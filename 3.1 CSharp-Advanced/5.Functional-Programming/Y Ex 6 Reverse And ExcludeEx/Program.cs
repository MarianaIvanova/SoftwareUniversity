using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_6_Reverse_And_ExcludeEx
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int divider = int.Parse(Console.ReadLine());
            numbers.Reverse();
            numbers = numbers.Where(x => x % divider != 0).ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
