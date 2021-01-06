using System;
using System.Collections.Generic;

namespace Lab_8_Traffic_Jam_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int countCarsGreen = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            string input = Console.ReadLine();
            int countCarsTotalPassed = 0;

            while (input != "end")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    for (int i = 1; i <= countCarsGreen; i++)
                    {
                        if(queue.Count == 0)
                        {
                            break;
                        }

                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        countCarsTotalPassed++;
                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{countCarsTotalPassed} cars passed the crossroads.");
        }
    }
}
