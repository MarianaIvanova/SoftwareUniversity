using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_6_Songs_Queue_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialSongs = Console.ReadLine().Split(", ").ToList();
            Queue<string> queueOfSongs = new Queue<string>(initialSongs);

            while (queueOfSongs.Count > 0)
            {
                string command = Console.ReadLine();

                if (command.Contains("Play"))
                {
                    queueOfSongs.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    //List<string> currentCommand = command.Split("Add ",StringSplitOptions.RemoveEmptyEntries).ToList();
                    //string songToAdd = currentCommand[0];
                    //Above two lines can be like this:
                    string songToAdd = command.Substring(4, command.Length - 4);

                    if (queueOfSongs.Contains(songToAdd))
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                    else
                    {
                        queueOfSongs.Enqueue(songToAdd);
                    }
                }
                else if (command.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", queueOfSongs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
