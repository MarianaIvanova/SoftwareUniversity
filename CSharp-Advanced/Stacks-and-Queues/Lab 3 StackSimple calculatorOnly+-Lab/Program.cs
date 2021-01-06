using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_3_StackSimple_calculator_only_addition_and_subtraction_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').Reverse().ToList();
            Stack<string> stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                //PrintStack(stack);
                int first = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int second = int.Parse(stack.Pop());
                switch (sign)
                {
                    case "+":
                        stack.Push((first + second).ToString());
                        break;
                    case "-":
                        stack.Push((first - second).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Peek());
        }

        static void PrintStack(Stack<string> stack)
        {
            foreach (var item in stack)
            {
                Console.Write(item);
            }

            Console.WriteLine();
        }
    }
}
