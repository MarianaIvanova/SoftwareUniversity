using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_8_Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> numbersTmp1 = numbers.ToList();
            List<int> numbersTmp2 = numbers.ToList();

            numbersTmp1 = numbersTmp1.Where(x => x % 2 == 0).OrderBy(x => x).ToList();
            numbersTmp2 = numbersTmp2.Where(x => x % 2 != 0).OrderBy(x => x).ToList();

            List<int> numbersFinal = new List<int>();

            for (int i = 0; i < numbersTmp1.Count; i++)
            {
                numbersFinal.Add(numbersTmp1[i]);
            }

            for (int i = 0; i < numbersTmp2.Count; i++)
            {
                numbersFinal.Add(numbersTmp2[i]);
            }

            Console.WriteLine(string.Join(" ", numbersFinal));
        }
    }
}
