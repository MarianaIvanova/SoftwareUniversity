using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_1_Sort_Even_NumbersLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> allNumbers = Console.ReadLine()
                .Split(", ")
                .Select(number =>
                {
                    return int.Parse(number);
                })
                .Where(x =>
                {
                    return x % 2 == 0;
                })
                .OrderBy((int x) =>
                { 
                    return x;
                })
                .ToList();

            Console.WriteLine(string.Join(", ", allNumbers));
        }
    }
}
