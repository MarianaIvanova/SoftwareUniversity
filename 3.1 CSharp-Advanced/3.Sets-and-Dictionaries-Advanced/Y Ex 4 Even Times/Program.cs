using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_4_Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> integers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if(!integers.ContainsKey(input))
                {
                    integers.Add(input, 0);
                }
                
                integers[input]++;
            }

            foreach (var integer in integers)
            {
                if(integer.Value % 2 == 0)
                {
                    Console.WriteLine(integer.Key);
                    break;
                }
            }
        }
    }
}
