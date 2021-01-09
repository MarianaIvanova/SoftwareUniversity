using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_1_Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] basicInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int nElementsToPush = basicInfo[0];
            int sElementsToPop = basicInfo[1];
            int xElementToSearch = basicInfo[2];

            List<int> ElementsToPush = Console.ReadLine()
                .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Stack<int> stack = new Stack<int>();

            if(nElementsToPush <= ElementsToPush.Count)
            {
                for (int i = 1; i <= nElementsToPush; i++)
                {
                    stack.Push(ElementsToPush[i - 1]);
                }
            }
            else
            {
                for (int i = 1; i <= ElementsToPush.Count; i++)
                {
                    stack.Push(ElementsToPush[i - 1]);
                }
            }

            if (sElementsToPop > ElementsToPush.Count)
            {
                stack.Clear();
            }
            else
            {
                int tmpInitialCount = stack.Count;
                while (stack.Count > tmpInitialCount - sElementsToPop)
                {
                    stack.Pop();
                }
            }

            int minValue = int.MaxValue;

            if(stack.Count == 0)
            {
                Console.WriteLine("0");
                Environment.Exit(0);
            }

            while(stack.Count > 0)
            {
                if(stack.Peek() == xElementToSearch)
                {
                    Console.WriteLine("true");
                    Environment.Exit(0);
                }
                else
                {
                    if(stack.Peek() <= minValue)
                    {
                        minValue = stack.Pop();
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }

            Console.WriteLine($"{minValue}");
        }
    }
}
