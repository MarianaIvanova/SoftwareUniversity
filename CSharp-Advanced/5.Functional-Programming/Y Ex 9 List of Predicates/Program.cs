using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_9_List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> divisibleNumbers = new List<int>();

            for (int i = 1; i <= end; i++)
            {
                int counter = 0;
                for (int j = 0; j < dividers.Count; j++)
                {
                    if(i % dividers[j] == 0)
                    {
                        counter++;
                    }
                }

                if(counter == dividers.Count)
                {
                    divisibleNumbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", divisibleNumbers));
        }
    }
}
