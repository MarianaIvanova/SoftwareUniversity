using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_ex_10_Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitationList = Console.ReadLine().Split(" ").ToList();

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                List<string> commandInfo = input.Split(" ").ToList();
                string command = commandInfo[0];
                string filterType = commandInfo[1];
                string givenString = commandInfo[2];

                if (command == "Double")
                {
                    switch (filterType)
                    {
                        case "StartsWith":
                            {
                                List<string> filterDouble = invitationList.Where(x => x.StartsWith(givenString)).ToList();
                                invitationList = resultInsertName(invitationList, filterDouble);
                            }
                            break;
                        case "EndsWith":
                            {
                                List<string> filterDouble = invitationList.Where(x => x.EndsWith(givenString)).ToList();
                                invitationList = resultInsertName(invitationList, filterDouble);
                            }
                            break;
                        case "Length":
                            {
                                List<string> filterDouble = invitationList.Where(x => x.Length == int.Parse(givenString)).ToList();
                                invitationList = resultInsertName(invitationList, filterDouble);
                            }
                            break;
                    }
                }
                else if (command == "Remove")
                {
                    switch (filterType)
                    {
                        case "StartsWith":
                            {
                                List<string> filterDelete = invitationList.Where(x => x.StartsWith(givenString)).ToList();
                                invitationList = resultDeleteName(invitationList, filterDelete);
                            }
                            break;
                        case "EndsWith":
                            {
                                List<string> filterDelete = invitationList.Where(x => x.EndsWith(givenString)).ToList();
                                invitationList = resultDeleteName(invitationList, filterDelete);
                            }
                            break;
                        case "Length":
                            {
                                List<string> filterDelete = invitationList.Where(x => x.Length == int.Parse(givenString)).ToList();
                                invitationList = resultDeleteName(invitationList, filterDelete);
                            }
                            break;
                    }
                }
                input = Console.ReadLine();
            }
            if(invitationList.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", invitationList)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }
        static List<string> resultInsertName(List<string> invitationList, List<string> filterDouble)
        {
            for (int k = 1; k < filterDouble.Count; k++)
            {
                if(filterDouble[k] == filterDouble[k - 1])
                {
                    filterDouble.RemoveAt(k);
                    k--;
                }
            }

            for (int i = 0; i < invitationList.Count; i++)
            {
                for (int j = 0; j < filterDouble.Count; j++)
                {
                    if (invitationList[i] == filterDouble[j])
                    {
                        invitationList.Insert(i + 1, filterDouble[j]);
                        i++;
                    }
                }
            }

            return invitationList;
        }

        static List<string> resultDeleteName(List<string> invitationList, List<string> filterDelete)
        {
            for (int k = 1; k < filterDelete.Count; k++)
            {
                if (filterDelete[k] == filterDelete[k - 1])
                {
                    filterDelete.RemoveAt(k);
                    k--;
                }
            }

            for (int i = 0; i < invitationList.Count; i++)
            {
                for (int j = 0; j < filterDelete.Count; j++)
                {
                    if (invitationList[i] == filterDelete[j])
                    {
                        invitationList.RemoveAt(i);
                        i--;
                    }
                }
            }

            return invitationList;
        }
    }
}
