using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_2_Knights_of_HonorEx2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ").ToList();
            //names = names.Select(x => $"Sir {x}").ToList();
            names = MySelect(names, x => $"Sir {x}");

            Action<List<string>> printNames = x => Console.WriteLine(string.Join(Environment.NewLine, x));
            printNames(names);
        }

        static List<string> MySelect(List<string> names, Func<string, string> func)
        {
            List<string> namesNew = new List<string>();

            foreach (var name in names)
            {
                string newName = func(name);
                namesNew.Add(newName);
            }

            return namesNew;
        }
    }
}
