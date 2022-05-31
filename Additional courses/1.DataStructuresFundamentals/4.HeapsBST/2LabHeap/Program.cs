using System;
using System.Collections.Generic;

namespace _2LabHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            var integerHeap = new Heap<int>();
            var elements = new List<int>() { 4, 3, -5, 1, 15, 6, 9, 5, 25, 8, 17, 16 };
            foreach (var el in elements)
            {
                integerHeap.Add(el);
            }

            Console.WriteLine(integerHeap.DFSInOrder(0, 0));
            //            1
            //      5
            //         4
            //   17
            //         3
            //      15
            //         8
            //25
            //         - 5
            //      9
            //   16
            //      6
        }
    }
}
