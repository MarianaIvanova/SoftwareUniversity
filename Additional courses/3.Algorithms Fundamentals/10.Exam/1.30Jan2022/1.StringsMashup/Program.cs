using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.StringsMashup
{
    class Program
    {
        private static int p;
        private static int n;
        private static char[] orderedStr;
        private static char[] combinations;
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            p = str.Length;
            n = int.Parse(Console.ReadLine());//This is the number of slots we gonna use to put the letters

            orderedStr = new char[p];

            for (int i = 0; i < p; i++)
            {
                orderedStr[i] = str[i];
            }

            orderedStr = orderedStr.OrderBy(x => x).ToArray();

            combinations = new char[n];//We have only k long, not elements.Length long variation

            CombinationssWithRepetitions(0, 0);
        }
        private static void CombinationssWithRepetitions(int index, int elementsStartIndex)
        {
            //Base:
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(string.Empty, combinations));
                return;
            }

            for (int i = elementsStartIndex; i < p; i++)
            {
                combinations[index] = orderedStr[i];
                CombinationssWithRepetitions(index + 1, i);
            }
        }
    }
}