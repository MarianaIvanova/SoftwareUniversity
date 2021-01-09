using System;
using System.Collections.Generic;

namespace Y_Ex_8_Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> openingBracketsStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentBracket = input[i];

                switch(currentBracket)
                {
                    case '(':
                        openingBracketsStack.Push(currentBracket);
                        break;
                    case '{':
                        openingBracketsStack.Push(currentBracket);
                        break;
                    case '[':
                        openingBracketsStack.Push(currentBracket);
                        break;
                    case ')':
                        {
                            if (openingBracketsStack.Count == 0)
                            {
                                Console.WriteLine("NO");
                                Environment.Exit(0);
                            }
                            else
                            {
                                if (openingBracketsStack.Pop() == '(')
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("NO");
                                    Environment.Exit(0);
                                }
                            }
                        }
                        break;
                    case '}':
                        {
                            if(openingBracketsStack.Count == 0)
                            {
                                Console.WriteLine("NO");
                                Environment.Exit(0);
                            }
                            else
                            {
                                if (openingBracketsStack.Pop() == '{')
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("NO");
                                    Environment.Exit(0);
                                }
                            }
                        }
                        break;
                    case ']':
                        {
                            if (openingBracketsStack.Count == 0)
                            {
                                Console.WriteLine("NO");
                                Environment.Exit(0);
                            }
                            else
                            {
                                if (openingBracketsStack.Pop() == '[')
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("NO");
                                    Environment.Exit(0);
                                }
                            }
                        }
                        break;
                }    
            }

            if(openingBracketsStack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
