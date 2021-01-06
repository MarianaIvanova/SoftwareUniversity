using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_2_Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Stack<int> stack = new Stack<int>(firstIntegers);
            int numbersInStack = firstIntegers.Count;

            string input = Console.ReadLine().ToLower();

            while(input != "end")
            {
                List<string> currentCommand = input.Split(' ').ToList();
                string command = currentCommand[0];

                if(command == "add")
                {
                    int fisrt = int.Parse(currentCommand[1].ToString());
                    int second = int.Parse(currentCommand[2].ToString());
                    stack.Push(fisrt);
                    stack.Push(second);
                    numbersInStack += 2;
                }
                else if (command == "remove")
                {
                    int times = int.Parse(currentCommand[1].ToString());

                    if(numbersInStack < times)
                    {
                        input = Console.ReadLine().ToLower();
                        continue;
                    }
                    else
                    {
                        for (int i = 1; i <= times; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                input = Console.ReadLine().ToLower();
            }

            int sum = 0;

            while(stack.Count > 0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
