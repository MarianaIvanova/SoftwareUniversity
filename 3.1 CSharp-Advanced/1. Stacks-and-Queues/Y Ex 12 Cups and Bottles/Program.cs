using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_12_Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        //It is safe to assume that there will be NO case in which the water is exactly as much as the cups' values, so that at the end there are no cups and no water in the bottles.
        {
            int[] allCapsRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] allBottlesRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> allCaps = new Queue<int>(allCapsRow);
            Stack<int> allBottles = new Stack<int>(allBottlesRow);
            int waterWaste = 0;

            while(allCaps.Count > 0 && allBottles.Count > 0)
            {
                int currentCap = allCaps.Peek();
                int currentBottle = allBottles.Peek();

                if(currentBottle >= currentCap)
                {
                    waterWaste += currentBottle - currentCap;
                    allCaps.Dequeue();
                    allBottles.Pop();
                }
                else if (currentBottle < currentCap)
                {
                    int tmp = currentCap;
                    while (tmp > 0 && allBottles.Count > 0)
                    {
                        if(currentBottle < tmp)
                        {
                            tmp -= allBottles.Pop();
                            currentBottle = allBottles.Peek();
                        }
                        else if (currentBottle == tmp)
                        {
                            tmp -= allBottles.Pop();
                            allCaps.Dequeue();
                            break;
                        }
                        else
                        {
                            waterWaste += currentBottle - tmp;
                            allCaps.Dequeue();
                            allBottles.Pop();
                            break;
                        }
                    }
                }
            }

            if(allCaps.Count == 0 && allBottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", allBottles)}");
            }
            else if (allCaps.Count > 0 && allBottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", allCaps)}");
            }

            Console.WriteLine($"Wasted litters of water: {waterWaste}");
        }
    }
}
