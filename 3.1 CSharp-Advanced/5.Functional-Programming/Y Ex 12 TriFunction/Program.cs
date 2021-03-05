using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_12_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split().ToList();

            Console.WriteLine(string.Join(" ", SumLeetersASCCIIName(names, n)));
        }

        static List<string> SumLeetersASCCIIName(List<string> names, int n)
        {
            List<string> namesSum = new List<string>();

            for (int i = 0; i < names.Count; i++)
            {
                string currentName = names[i];
                int sumLetters = 0;
                for (int j = 0; j < currentName.Length; j++)
                {
                    sumLetters += currentName[i];
                }

                if(sumLetters >= n)
                {
                    namesSum.Add(currentName);
                }
            }

            return namesSum;
        }
    }
}
