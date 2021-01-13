using System;
using System.Linq;

namespace Y_Ex_1_Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ").ToArray();
            Action<string[]> print = x => GetPrinted(names);
            print(names);
        }

        static void GetPrinted(string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
