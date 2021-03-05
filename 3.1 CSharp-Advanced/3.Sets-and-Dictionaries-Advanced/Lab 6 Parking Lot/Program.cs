using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_6_Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();
            string input = Console.ReadLine();

            while(input != "END")
            {
                string[] inputSplit = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string direction = inputSplit[0];
                string carNumber = inputSplit[1];

                if(direction == "IN")
                {
                    parking.Add(carNumber);
                }
                else if(direction == "OUT")
                {
                    parking.Remove(carNumber);
                }

                input = Console.ReadLine();
            }

            if(parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, parking));
            }
        }
    }
}
