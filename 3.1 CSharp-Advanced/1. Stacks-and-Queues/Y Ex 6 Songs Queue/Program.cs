using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_6_Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialSongs = Console.ReadLine().Split(", ").ToList();
            Queue<string> queueOfSongs = new Queue<string>(initialSongs);

            while(queueOfSongs.Count > 0)
            {
                List<string> command = Console.ReadLine().Split(" ").ToList();
                string currentCommand = command[0];

                switch(currentCommand)
                {
                    case "Play":
                        queueOfSongs.Dequeue();
                        break;
                    case "Add":
                        {
                            string songToAdd = command[1];
                            if(command.Count > 2)
                            for (int i = 2; i < command.Count; i++)
                            {
                                songToAdd = songToAdd + " " + command[i];
                            }
                            
                            if(queueOfSongs.Contains(songToAdd))
                            {
                                Console.WriteLine($"{songToAdd} is already contained!");
                            }
                            else
                            {
                                queueOfSongs.Enqueue(songToAdd);
                            }
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ",queueOfSongs));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
