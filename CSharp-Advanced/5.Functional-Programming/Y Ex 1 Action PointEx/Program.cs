using System;
using System.Linq;

namespace Y_Ex_1_Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ").ToArray();
            Action<string[]> print = x => Console.WriteLine(string.Join(Environment.NewLine, x));
            print(names);
        }
    }
}
