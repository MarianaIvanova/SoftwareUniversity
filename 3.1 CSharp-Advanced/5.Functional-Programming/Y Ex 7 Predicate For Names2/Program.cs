using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_7_Predicate_For_Names2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(" ").ToList();

            Func<string, bool> predicateForNames = x => x.Length <= n;
            names = names.Where(predicateForNames).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
