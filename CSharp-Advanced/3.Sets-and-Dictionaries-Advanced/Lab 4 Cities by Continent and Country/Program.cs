using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_4_Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCities = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> allCities = 
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 1; i <= numberOfCities; i++)
            {
                string[] citiesInfo = Console.ReadLine().Split(" ").ToArray();
                string continent = citiesInfo[0];
                string country = citiesInfo[1];
                string city = citiesInfo[2];

                if(!allCities.ContainsKey(continent))
                {
                    allCities.Add(continent, new Dictionary<string, List<string>>());
                }

                if(!allCities[continent].ContainsKey(country))
                {
                    allCities[continent].Add(country, new List<string>());
                }

                allCities[continent][country].Add(city);
            }

            foreach (var continent2 in allCities)
            {
                Console.WriteLine($"{continent2.Key}:");

                var countryAll = continent2.Value;

                foreach (var country2 in countryAll)
                {
                    Console.WriteLine($"  {country2.Key} -> {string.Join(", ", country2.Value)}");
                }
            }
        }
    }
}
