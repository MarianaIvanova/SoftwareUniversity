using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_7_Truck_Tour_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> basicQueue = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                string currentPumpInfo = Console.ReadLine();//1 5
                currentPumpInfo += $" { i}";//1 5 0
                basicQueue.Enqueue(currentPumpInfo);
            }

            int totalLitters = 0;
            for (int k = 0; k < n; k++)
            {
                string currentPump = basicQueue.Dequeue();
                List<int> pump = currentPump.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                int petrolLitters = int.Parse(pump[0].ToString());
                int distanceKm = int.Parse(pump[1].ToString());
                totalLitters += petrolLitters;

                if (totalLitters >= distanceKm)
                {
                    totalLitters -= distanceKm;
                }
                else
                {
                    totalLitters = 0;
                    k = -1;
                }

                basicQueue.Enqueue(currentPump);
            }

            List<int> firstElement = basicQueue.Dequeue().Split(" ").Select(int.Parse).ToList();
            Console.WriteLine(firstElement[2]);
        }
    }
}
