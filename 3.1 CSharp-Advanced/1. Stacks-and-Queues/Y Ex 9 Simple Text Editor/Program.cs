using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y_Ex_9_Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> hystoryStack = new Stack<string>();
            StringBuilder text = new StringBuilder();
            hystoryStack.Push(text.ToString());
            int numberCommands = int.Parse(Console.ReadLine());


            for (int i = 0; i < numberCommands; i++)
            {
                string[] commandInfo = Console.ReadLine().Split(' ').ToArray();
                int commandName = int.Parse(commandInfo[0]);

                switch (commandName)
                {
                    case 1:
                        {
                            string appendString = commandInfo[1];
                            text.Append(appendString);
                            hystoryStack.Push(text.ToString());
                        }
                        break;
                    case 2:
                        {
                            int charToRemove = int.Parse(commandInfo[1]);
                            if (text.Length - charToRemove >= 0 && charToRemove > 0)
                            {
                                text.Remove(text.Length - charToRemove, charToRemove);
                                hystoryStack.Push(text.ToString());
                            }
                        }
                        break;
                    case 3:
                        {
                            int index = int.Parse(commandInfo[1]);
                            if (index - 1 >= 0 && index - 1 < text.Length)
                            {
                                Console.WriteLine(text[index - 1]);
                            }
                        }
                        break;
                    case 4:
                        {
                            if (hystoryStack.Count > 1)
                            {
                                hystoryStack.Pop();
                                text = new StringBuilder();
                                text.Append(hystoryStack.Peek());
                            }
                        }
                        break;
                }
            }
        }
    }
}
