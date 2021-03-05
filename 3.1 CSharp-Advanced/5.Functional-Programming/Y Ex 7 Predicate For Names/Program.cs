using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_7_Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(" ").ToList();

            names = names.Where(x => x.Length <= n).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
