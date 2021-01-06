using System;
using System.Collections.Generic;

namespace Lab_1_Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            string inputString = Console.ReadLine();

            for (int i = 0; i < inputString.Length; i++)
            {
                char current = inputString[i];
                stack.Push(current);
            }

            while(stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
