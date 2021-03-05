using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y_Ex_10_Crossroads
{
    class Program
    {
        static void Main(string[] args)
        //The input will be within the constaints specified above and will always be valid. There is no need to check it explicitly.
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();

            string input = Console.ReadLine();
            int countCars = 0;

            while (input != "END")
            {
                if(input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    int timeLeftGreen = greenLightDuration;
                    int timeLeftFree = freeWindowDuration;
                    bool isItOnlyFreeWindowLeft = false;

                    while (queue.Count > 0 && (timeLeftGreen + timeLeftFree) > 0)
                    {
                        if (queue.Peek().Length <= timeLeftGreen)
                        {
                            timeLeftGreen = timeLeftGreen - queue.Peek().Length;
                            queue.Dequeue();
                            countCars++;
                        }
                        else
                        {
                            if (timeLeftGreen > 0)
                            {
                                if (queue.Peek().Length - timeLeftGreen <= timeLeftFree )
                                {

                                    timeLeftFree = timeLeftFree - (queue.Peek().Length - timeLeftGreen);
                                    timeLeftGreen = 0;
                                    queue.Dequeue();
                                    countCars++;
                                }
                                else
                                {
                                    char characterHit = queue.Peek()[timeLeftGreen + timeLeftFree];
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{queue.Peek()} was hit at {characterHit}.");
                                    Environment.Exit(0);
                                }
                            }
                            else
                            {
                                isItOnlyFreeWindowLeft = true;
                            }
                        }

                        if (isItOnlyFreeWindowLeft)
                        {
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{countCars} total cars passed the crossroads.");
        }
    }
}
