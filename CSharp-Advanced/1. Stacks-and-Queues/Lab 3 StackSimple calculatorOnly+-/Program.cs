using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_3_StackSimple_calculator_only_addition_and_subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            Stack<string> stack = new Stack<string>();

            for (int i = input.Count - 1; i >= 0 ; i--)
            {
                string current = input[i].ToString();
                stack.Push(current);
            }

            while(stack.Count > 1)
            {
                double sumTmp = 0;
                sumTmp += double.Parse(stack.Peek().ToString());
                stack.Pop();
                switch(stack.Peek().ToString())
                {
                    case "+":
                        {
                            stack.Pop();
                            sumTmp += double.Parse(stack.Peek().ToString());
                            stack.Pop();
                        }
                        break;
                    case "-":
                        {
                            stack.Pop();
                            sumTmp -= double.Parse(stack.Peek().ToString());
                            stack.Pop();
                        }
                        break;
                }

                stack.Push(sumTmp.ToString());
            }
            
            Console.WriteLine(stack.Peek());
        }
    }
}
