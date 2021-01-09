using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_7_Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> basicQueue = new Queue<string>();

            for (int i = 1; i <= n; i++)
            {
                string currentPumpInfo = Console.ReadLine();
                basicQueue.Enqueue(currentPumpInfo);
            }

            int count = 0;

            for (int k = 0; k < basicQueue.Count; k++)
            {
                Queue<string> currentQueueTmp = new Queue<string>(basicQueue);
                Queue<string> currentQueue = new Queue<string>(currentQueueTmp);

                for (int j = 0; j < k; j++)
                {
                    currentQueue.Enqueue(currentQueue.Dequeue());
                }
                int totalLitters = 0;
                int totalKm = 0;

                while (currentQueue.Count > 0)
                {
                    string currentPump = currentQueue.Peek();
                    List<int> pump = currentPump.Split(" ").Select(int.Parse).ToList();
                    int petrolLitters = int.Parse(pump[0].ToString());
                    int distanceKm = int.Parse(pump[1].ToString());
                    totalLitters += petrolLitters;
                    totalKm += distanceKm;

                    if (totalLitters >= totalKm)
                    {
                        currentQueue.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
                
                if(currentQueue.Count == 0)
                {
                    count = k;
                    break;
                }
            }

            Console.WriteLine(count);
        }
    }
}
