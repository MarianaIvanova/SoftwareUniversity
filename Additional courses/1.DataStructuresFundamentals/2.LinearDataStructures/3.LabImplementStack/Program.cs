using System;
using System.Collections.Generic;

namespace _3.LabImplementStack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Microsoft version of stack
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i <= 10; i++)
            {
                stack.Push(i);
            }

            Console.WriteLine(stack.Peek());

            while(stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
            //10
            //10
            //9
            //8
            //7
            //6
            //5
            //4
            //3
            //2
            //1
            //0

            Console.WriteLine();
            //Our version of stack
            CoolStack<int> coolStack = new CoolStack<int>();

            for (int i = 0; i <= 10; i++)
            {
                coolStack.Push(i);
            }

            Console.WriteLine(coolStack.Peek());

            while (coolStack.Count > 0)
            {
                Console.WriteLine(coolStack.Pop());
            }
            //10
            //10
            //9
            //8
            //7
            //6
            //5
            //4
            //3
            //2
            //1
            //0
        }
    }
}
