using System;
using System.Collections.Generic;

namespace Lab_4_Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    int firstIndex = stack.Pop();
                    int lastIndex = i;

                    for (int j = firstIndex; j <= lastIndex; j++)
                    {
                        Console.Write(input[j]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
