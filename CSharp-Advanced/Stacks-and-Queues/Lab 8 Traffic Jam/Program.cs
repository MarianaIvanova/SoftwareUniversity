using System;
using System.Collections.Generic;

namespace Lab_8_Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int countCarsGreen = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            string input = Console.ReadLine();
            int countCarsWaiting = 0;
            int countCarsTotalPassed = 0;

            while(input != "end")
            {
                if(input != "green")
                {
                    queue.Enqueue(input);
                    countCarsWaiting++;
                }
                else
                {
                    if(countCarsGreen >= countCarsWaiting)
                    {
                        for (int i = 1; i <= countCarsWaiting; i++)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                        }

                        countCarsTotalPassed += countCarsWaiting;
                        countCarsWaiting = 0;
                    }
                    else
                    {
                        for (int i = 1; i <= countCarsGreen; i++)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                        }

                        countCarsTotalPassed += countCarsGreen;
                        countCarsWaiting -= countCarsGreen;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{countCarsTotalPassed} cars passed the crossroads.");
        }
    }
}
