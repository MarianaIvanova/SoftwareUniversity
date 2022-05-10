using System;
using System.Collections.Generic;

namespace _4.LabImplemenQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            //Microsoft version of queue
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i <= 10; i++)
            {
                queue.Enqueue(i);
            }

            Console.WriteLine(queue.Peek());

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
            //0
            //0
            //1
            //2
            //3
            //4
            //5
            //6
            //7
            //8
            //9
            //10

            Console.WriteLine();
            //our version of queue
            CoolQueue<int> coolQueue = new CoolQueue<int>();

            for (int i = 0; i <= 10; i++)
            {
                coolQueue.Enqueue(i);
            }

            Console.WriteLine(coolQueue.Peek());

            while (coolQueue.Count > 0)
            {
                Console.WriteLine(coolQueue.Dequeue());
            }
            //0
            //0
            //1
            //2
            //3
            //4
            //5
            //6
            //7
            //8
            //9
            //10
        }
    }
}
