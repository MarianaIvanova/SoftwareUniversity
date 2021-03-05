using System;
using System.Linq;

namespace Y_Ex_2_Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ").ToArray();
            Action<string[]> printNames = x => GetPrinted(names);
            printNames(names);
        }
        static void GetPrinted(string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"Sir {names[i]}");
            }
        }
    }
}
