using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_4_Fast_Food_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            List<int> orders = Console.ReadLine().Split().Select(int.Parse).ToList();
            Queue<int> queue = new Queue<int>(orders);
            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                var food = queue.Peek();

                if(quantity >= food)
                {
                    quantity -= food;
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if(queue.Count > 0)
            {
                Console.WriteLine("Orders left: " + string.Join(" ", queue));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
