using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_11_Party_Reservation_Filter_Module
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
                if (input.StartsWith("Add filter"))
                {
                    if (!filters.Contains(input))
                    {
                        filters.Add(input);
                    }
                }
                else if (input.StartsWith("Remove filter"))
                {
                    if (filters.Contains("Add filter" + input.Substring(13)))
                    {
                        string filterToRemove = "Add filter" + input.Substring(13);
                        filters.Remove(filterToRemove);
                    }
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < filters.Count; i++)
            {
                List<string> commandInfo = filters[i].Split(";").ToList();
                string command = commandInfo[0];
                string filterType = commandInfo[1];
                string filterParameter = commandInfo[2];
                switch (command)
                {
                    //Each command will be valid e.g. you won’t be asked to remove a non-existent filter. 
                    case "Add filter":
                        {
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
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", invitationList));
        }
    }
}
