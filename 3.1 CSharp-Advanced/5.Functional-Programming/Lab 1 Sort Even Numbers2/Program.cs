using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_1_Sort_Even_Numbers2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> allNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            List<int> evenNumbersSorted = allNumbers.Where(x => x % 2 == 0).OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(", ", evenNumbersSorted));
        }
    }
}
