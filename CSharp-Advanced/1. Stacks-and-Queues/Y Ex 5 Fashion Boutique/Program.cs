using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_5_Fashion_Boutique
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
                while(currentSum + stack.Peek() <= rackCapacity)
                {
                    currentSum += stack.Pop();
                    if(stack.Count == 0)
                    {
                        break;
                    }

                }
                if (currentSum > 0)// if there is 0 0 0 0 0
                {
                    countOfRacks++;
                } 
                currentSum = 0;
            }

            Console.WriteLine(countOfRacks);
        }
    }
}
