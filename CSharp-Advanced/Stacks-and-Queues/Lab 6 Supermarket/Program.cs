using System;
using System.Collections.Generic;

namespace Lab_6_Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> queue = new Queue<string>();
            int countRemaintingPeople = 0;

            while (input.ToLower() != "end")
            {
                if(input.ToLower() != "paid")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }

                input = Console.ReadLine();
            }

            if (queue.Count > 0)
            {
                while (queue.Count > 0)
                {
                    countRemaintingPeople++;
                    queue.Dequeue();
                }
            }
            
            Console.WriteLine($"{countRemaintingPeople} people remaining.");
        }
    }
}
