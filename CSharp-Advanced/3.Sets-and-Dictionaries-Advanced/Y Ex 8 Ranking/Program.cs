using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_8_Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputContests = Console.ReadLine();
            Dictionary<string, string> infoContests = new Dictionary<string, string>();

            while(inputContests != "end of contests")
            {
                string[] currentInfo = inputContests.Split(":").ToArray();
                string contest = currentInfo[0];
                string password = currentInfo[1];
                infoContests.Add(contest, password);
                inputContests = Console.ReadLine();
            }

            string inputSubmissions = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> infoSubmissions = new Dictionary<string, Dictionary<string, int>>();

            while (inputSubmissions != "end of submissions")
            {
                string[] currentInfo = inputSubmissions.Split("=>").ToArray();
                string contest = currentInfo[0];
                string password = currentInfo[1];
                string username = currentInfo[2];
                int points = int.Parse(currentInfo[3]);
                //string infoContest = $"{contest}:{password}";

                if (infoContests.ContainsKey(contest))
                {
                    if (infoContests[contest] == password)
                    {
                        if (!infoSubmissions.ContainsKey(username))
                        {
                            infoSubmissions.Add(username, new Dictionary<string, int>());
                            infoSubmissions[username].Add(contest, points);
                        }
                        else if(!infoSubmissions[username].ContainsKey(contest))
                        {
                            infoSubmissions[username].Add(contest, points);
                        }
                        else
                        {
                            if (infoSubmissions[username][contest] < points)
                            {
                                infoSubmissions[username][contest] = points;
                            }
                        }
                    }
                }

                inputSubmissions = Console.ReadLine();
            }

            var bestCandidateInfo = infoSubmissions.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, x => x.Value).Take(1);
            string candidateName = string.Empty;
            foreach (var bestCandidate in bestCandidateInfo)
            {
                candidateName = bestCandidate.Key;
                Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
            }

            var infoSubmissionsOrdered = infoSubmissions
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Ranking:");
            foreach (var user in infoSubmissionsOrdered)
            {
                Console.WriteLine(user.Key);

                var contestsPointsOrdered = user.Value.OrderByDescending(x => x.Value);
                foreach (var userContest in contestsPointsOrdered)
                {
                    Console.WriteLine($"#  {userContest.Key} -> {userContest.Value}");
                }
            }
        }
    }
}
