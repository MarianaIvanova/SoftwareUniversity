using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_2_Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            //int n = basicInfo[0];
            int s = input[1];

            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 1; i <= s; i++)//Приемаме, че s <= stack.count
            {
                queue.Dequeue();
            }

            int x = input[2];

            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
