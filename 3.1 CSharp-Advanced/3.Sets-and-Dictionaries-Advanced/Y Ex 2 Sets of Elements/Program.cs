using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_2_Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nAndM = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = nAndM[0];
            int m = nAndM[1];
            HashSet<int> setN = new HashSet<int>();
            HashSet<int> setM = new HashSet<int>();

            for (int i = 1; i <= n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                setN.Add(input);
            }

            for (int j = 1; j <= m; j++)
            {
                int input = int.Parse(Console.ReadLine());
                setM.Add(input);
            }

            var setIntersect = setN.Intersect(setM);
            Console.WriteLine(string.Join(" ",setIntersect));
        }
    }
}
