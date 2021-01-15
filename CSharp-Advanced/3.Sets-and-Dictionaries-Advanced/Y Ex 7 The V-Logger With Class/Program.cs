using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_7_The_V_Logger_With_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Vlogger> allVloggers = new List<Vlogger>();

            while (input != "Statistics")
            {
                string[] actionsInfo = input.Split(" ").ToArray();
                string action = actionsInfo[1];

                switch (action)
                {
                    case "joined":
                        {
                            string vloggerName = actionsInfo[0];
                            if (!allVloggers.Any(x => x.Name == vloggerName))
                            {
                                Vlogger currentVlogger = new Vlogger(vloggerName, new List<string>(), new List<string>());
                                allVloggers.Add(currentVlogger);
                            }
                        }
                        break;
                    case "followed":
                        {
                            string vloggerName1 = actionsInfo[0];
                            string vloggerName2 = actionsInfo[2];
                            if (allVloggers.Any(x => x.Name == vloggerName1) &&
                                allVloggers.Any(x => x.Name == vloggerName2) &&
                                vloggerName1 != vloggerName2)
                            {
                                Vlogger vlogger1 = allVloggers.FirstOrDefault(x => x.Name == vloggerName1);
                                Vlogger vlogger2 = allVloggers.FirstOrDefault(x => x.Name == vloggerName2);
                                if (!vlogger1.Followed.Contains(vlogger2.Name))
                                {
                                    allVloggers.FirstOrDefault(x => x.Name == vloggerName1).Followed.Add(vloggerName2);
                                }

                                if (!vlogger2.Followers.Contains(vlogger1.Name))
                                {
                                    allVloggers.FirstOrDefault(x => x.Name == vloggerName2).Followers.Add(vloggerName1);
                                }
                            }
                        }
                        break;
                }

                input = Console.ReadLine();
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
                    List<string> currentVloggerFollowersOrdered = currentVlogger.Followers.OrderBy(x => x).ToList();

                    for (int j = 0; j < currentVloggerFollowersOrdered.Count; j++)
                    {
                        Console.WriteLine($"*  {currentVloggerFollowersOrdered[j]}");
                    }
                }
            }
        }
    }

    public class Vlogger
    {
        //vlogger with followers - 1/ following - 2
        private string name;
        private List<string> followers;
        private List<string> followed;

        public Vlogger(string name, List<string> followers, List<string> followed)
        {
            Name = name;
            Followers = followers;
            Followed = followed;
        }

        public string Name { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Followed { get; set; }
    }
}
