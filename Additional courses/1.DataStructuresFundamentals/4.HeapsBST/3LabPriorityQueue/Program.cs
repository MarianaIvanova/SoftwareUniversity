using System;
using System.Collections.Generic;

namespace _3LabPriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new PriorityQueue<int>();
            var elements = new List<int>() { 15, 25, 6, 9, 5, 8, 17, 16 };
            foreach (var element in elements)
            {
                queue.Add(element);
            }

            while (queue.Size > 0)
            {
                Console.WriteLine(queue.DFSInOrder(0, 0));
                Console.WriteLine($"Max element: {queue.Dequeue()}");
            }
            //Max element: 25
            //Max element: 17
            //Max element: 16
            //Max element: 15
            //Max element: 9
            //Max element: 8
            //Max element: 6
            //Max element: 5
        }
    }
}
