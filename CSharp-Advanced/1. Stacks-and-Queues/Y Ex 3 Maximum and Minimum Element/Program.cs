using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_3_Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueries = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 1; i <= numberOfQueries; i++)
            {
                List<int> query = Console.ReadLine().Split().Select(int.Parse).ToList();

                int action = query[0];

                switch(action)
                {
                    case 1:
                        stack.Push(query[1]);
                        break;
                    case 2:
                        {
                            if(stack.Count > 0)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                    case 3:
                        {
                            if (stack.Count > 0)
                            {
                                Console.WriteLine(stack.Max());
                            }
                        }
                        break;
                    case 4:
                        {
                            if (stack.Count > 0)
                            {
                                Console.WriteLine(stack.Min());
                            }
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
