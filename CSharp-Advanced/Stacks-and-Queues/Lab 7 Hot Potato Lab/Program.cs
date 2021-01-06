using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_7_Hot_Potato_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string[] children = Console.ReadLine().Split(' ').ToArray();

            for (int i = 0; i < children.Length; i++)
            {
                queue.Enqueue(children[i]);
            }
            int count = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {

                for (int i = 1; i < count; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
