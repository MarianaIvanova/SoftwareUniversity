using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_2_Knights_of_HonorEx
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ").ToList();
            names = names.Select(x => $"Sir {x}").ToList();

            Action<List<string>> printNames = x => Console.WriteLine(string.Join(Environment.NewLine, x));
            printNames(names);
        }
    }
}
