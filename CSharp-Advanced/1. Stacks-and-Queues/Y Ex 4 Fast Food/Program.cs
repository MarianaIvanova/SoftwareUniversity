using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_4_Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            List<int> orders = Console.ReadLine().Split().Select(int.Parse).ToList();

            Queue<int> queueOfOrders = new Queue<int>(orders);

            Console.WriteLine(queueOfOrders.Max());

            for (int i = 1; i <= orders.Count; i++)
            {
                if(queueOfOrders.Peek() <= quantity)
                {
                    quantity -= queueOfOrders.Peek();
                    queueOfOrders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if(queueOfOrders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write("Orders left: ");
                Console.Write(string.Join(" ", queueOfOrders));
            }
        }
    }
}
