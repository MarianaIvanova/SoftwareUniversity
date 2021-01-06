using System;
using System.Collections.Generic;

namespace Lab_7_SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            string input = Console.ReadLine();
            if (input.Length == 8)
            {

                while (input != "PARTY")
                {
                    if (input[0] == '0' || input[0] == '1' || input[0] == '2' ||
                        input[0] == '3' || input[0] == '4' || input[0] == '5' ||
                        input[0] == '6' || input[0] == '7' || input[0] == '8' ||
                        input[0] == '9')
                    {
                        vipGuests.Add(input);
                    }
                    else
                    {
                        regularGuests.Add(input);
                    }

                    input = Console.ReadLine();
                }

                input = Console.ReadLine();
                while (input != "END")
                {
                    if (input[0] == '0' || input[0] == '1' || input[0] == '2' ||
                        input[0] == '3' || input[0] == '4' || input[0] == '5' ||
                        input[0] == '6' || input[0] == '7' || input[0] == '8' ||
                        input[0] == '9')
                    {
                        vipGuests.Remove(input);
                    }
                    else
                    {
                        regularGuests.Remove(input);
                    }

                    input = Console.ReadLine();

                }
            }

            if (vipGuests.Count <= 0 && regularGuests.Count <= 0)
            {
                Console.WriteLine(0);
            }
            else if (vipGuests.Count > 0 || regularGuests.Count > 0)
            {
                Console.WriteLine($"{vipGuests.Count + regularGuests.Count}");
            }

            if (vipGuests.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipGuests));
            }

            if (regularGuests.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, regularGuests));
            }
        }
    }
}
