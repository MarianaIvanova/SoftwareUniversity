using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_11_Party_Reservation_Filter_ModuleEx
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitationList = Console.ReadLine().Split(" ").ToList();

            string input = Console.ReadLine();
            List<string> filters = new List<string>();

            while (input != "Print")
            {
                List<string> commandInfo = input.Split(";").ToList();
                string command = commandInfo[0];
                string filterType = commandInfo[1];
                string filterParameter = commandInfo[2];

                if (command == "Add filter")
                {
                    if (!filters.Contains($"{filterType};{filterParameter}"))
                    {
                        filters.Add($"{filterType};{filterParameter}");
                    }
                }
                else if (command == "Remove filter")
                {
                    if (filters.Contains($"{filterType};{filterParameter}"))
                    {
                        filters.Remove($"{filterType};{filterParameter}");
                    }
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < filters.Count; i++)
            {
                List<string> commandInfo = filters[i].Split(";").ToList();
                string filterType = commandInfo[0];
                string filterParameter = commandInfo[1];

                //Each command will be valid e.g. you won’t be asked to remove a non-existent filter. 
                switch (filterType)
                {
                    case "Starts with":
                        invitationList = invitationList.Where(x => !x.StartsWith(filterParameter)).ToList();
                        break;
                    case "Ends with":
                        invitationList = invitationList.Where(x => !x.EndsWith(filterParameter)).ToList();
                        break;
                    case "Length":
                        invitationList = invitationList.Where(x => x.Length != int.Parse(filterParameter)).ToList();
                        break;
                    case "Contains":
                        invitationList = invitationList.Where(x => !x.Contains(filterParameter)).ToList();
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", invitationList));
        }
    }
}

