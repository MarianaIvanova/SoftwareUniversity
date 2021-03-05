using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_3_Periodic_Table_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> periodicTable = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] currentElements = Console.ReadLine().Split(" ").ToArray();
                for (int j = 0; j < currentElements.Length; j++)
                {
                    periodicTable.Add(currentElements[j]);
                }
            }

            var sorted = periodicTable.OrderBy(x => x);
            Console.WriteLine(string.Join(" ", sorted));
        }
    }
}
