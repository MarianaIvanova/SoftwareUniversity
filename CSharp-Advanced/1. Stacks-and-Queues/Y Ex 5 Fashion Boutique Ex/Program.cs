using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_5_Fashion_Boutique_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> clothsInTheBox = Console.ReadLine().Split().Select(int.Parse).ToList();
            Stack<int> stack = new Stack<int>(clothsInTheBox);
            int rackCapacity = int.Parse(Console.ReadLine());
            int currentSum = 0;
            int countOfRacks = 0;

            while (stack.Count > 0)
            {
                if (currentSum + stack.Peek() > rackCapacity)
                {
                    countOfRacks++;
                    currentSum = 0;
                }
                else
                {
                    currentSum += stack.Pop();
                }

            }

            if(currentSum > 0)
            {
                countOfRacks++;
            }
            Console.WriteLine(countOfRacks);
        }
    }
}
