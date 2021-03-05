using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_6_Reverse_And_ExcludeEx2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int divider = int.Parse(Console.ReadLine());
            numbers.Reverse();
            Func<int, bool> predicate = x => x % divider != 0;
            numbers = numbers.Where(predicate).ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
