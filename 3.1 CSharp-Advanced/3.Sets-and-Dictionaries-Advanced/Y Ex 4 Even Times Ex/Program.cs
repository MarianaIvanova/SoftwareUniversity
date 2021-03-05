using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_4_Even_Times_Ex
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

                if (!integers.ContainsKey(input))
                {
                    integers.Add(input, 0);
                }

                integers[input]++;
            }

            var num = integers.Where(x => x.Value % 2 == 0).FirstOrDefault().Key;

            Console.WriteLine(num);

            //foreach (var integer in integers)
            //{
            //    if (integer.Value % 2 == 0)
            //    {
            //        Console.WriteLine(integer.Key);
            //        break;
            //    }
            //}
        }
    }
}
