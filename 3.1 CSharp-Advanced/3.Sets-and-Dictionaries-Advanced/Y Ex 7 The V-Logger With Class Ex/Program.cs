using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_7_The_V_Logger_With_Class_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ").ToArray();
            HashSet<Vlogger> allVloggers = new HashSet<Vlogger>();

            while (input[0] != "Statistics")
            {
                string action = input[1];

                switch (action)
                {
                    case "joined":
                        {
                            string vloggerName = input[0];
                            if (!allVloggers.Any(x => x.Name == vloggerName))
                            {
                                Vlogger currentVlogger = new Vlogger(input[0]);
                                allVloggers.Add(currentVlogger);
                            }
                        }
                        break;
                    case "followed":
                        {
                            string vloggerName1 = input[0];
                            string vloggerName2 = input[2];
                            if (allVloggers.Any(x => x.Name == vloggerName1) &&
                                allVloggers.Any(x => x.Name == vloggerName2) &&
                                vloggerName1 != vloggerName2)
                            {
                                Vlogger vlogger1 = allVloggers.FirstOrDefault(x => x.Name == vloggerName1);
                                Vlogger vlogger2 = allVloggers.FirstOrDefault(x => x.Name == vloggerName2);
                                allVloggers.FirstOrDefault(x => x.Name == vloggerName1).Followed.Add(vloggerName2);

                                if (!vlogger2.Followers.Contains(vlogger1.Name))
                                {
                                    allVloggers.FirstOrDefault(x => x.Name == vloggerName2).Followers.Add(vloggerName1);
                                }
                            }
                        }
                        break;
                }

                input = Console.ReadLine().Split(" ").ToArray();
            }

            Console.WriteLine($"The V-Logger has a total of {allVloggers.Count} vloggers in its logs.");
            List<Vlogger> allVloggersOrdered = allVloggers.
                OrderByDescending(x => x.Followers.Count).
                ThenBy(x => x.Followed.Count).ToList();

            for (int i = 0; i < allVloggersOrdered.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allVloggersOrdered[i].Name} : {allVloggersOrdered[i].Followers.Count} followers, {allVloggersOrdered[i].Followed.Count} following");
                if (i == 0)
                {
                    Vlogger currentVlogger = allVloggersOrdered[i];
                    List<string> currentVloggerFollowers = currentVlogger.Followers.ToList();

                    for (int j = 0; j < currentVloggerFollowers.Count; j++)
                    {
                        Console.WriteLine($"*  {currentVloggerFollowers[j]}");
                    }
                }
            }
        }
    }

    public class Vlogger
    {
        public Vlogger(string name)
        {
            this.Name = name;
            this.Followers = new SortedSet<string>();
            this.Followed = new HashSet<string>();
        }

        public string Name { get; set; }
        public SortedSet<string> Followers { get; set; }
        public HashSet<string> Followed { get; set; }
    }
}
