using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_5_Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            bool check = true;
            while (queue.Count > 0)
            {
                if (queue.Peek() % 2 == 0)
                {
                    if(check == false)
                    {
                        Console.Write($", ");
                    }
                    Console.Write($"{queue.Dequeue()}");
                    check = false;
                }
                else
                {
                    queue.Dequeue();
                }
            }
        }
    }
}
