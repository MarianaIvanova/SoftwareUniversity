using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_7_Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allKids = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Queue<string> kidsPlaying = new Queue<string>(allKids);
            int tosses = int.Parse(Console.ReadLine());

            while(kidsPlaying.Count > 1)
            {

                    for (int i = 1; i < tosses; i++)
                    {
                        string tmp = kidsPlaying.Dequeue();
                        kidsPlaying.Enqueue(tmp);
                    }

                    Console.WriteLine($"Removed {kidsPlaying.Dequeue()}"); 
            }

            Console.WriteLine($"Last is {kidsPlaying.Dequeue()}");
        }
    }
}
