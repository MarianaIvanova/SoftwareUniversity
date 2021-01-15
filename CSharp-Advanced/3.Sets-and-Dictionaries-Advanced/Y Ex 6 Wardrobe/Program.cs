using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_6_Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> allClothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 1; i <= lines; i++)
            {
                List<string> infoColour = Console.ReadLine().
                    Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string currentColour = infoColour[0];

                if(!allClothes.ContainsKey(currentColour))
                {
                    allClothes.Add(currentColour, new Dictionary<string, int>());
                }

                for (int j = 1; j < infoColour.Count; j++)
                {
                    string currentClothes = infoColour[j];

                    if (!allClothes[currentColour].ContainsKey(currentClothes))
                    {
                        allClothes[currentColour].Add(currentClothes, 1);
                    }
                    else
                    {
                        allClothes[currentColour][currentClothes]++;
                    }
                }
            }

            string[] findClothesInfo = Console.ReadLine().Split(" ").ToArray();
            string findClothesColour = findClothesInfo[0];
            string findClothesType = findClothesInfo[1];

            foreach (var colour in allClothes)
            {
                Console.WriteLine($"{colour.Key} clothes:");
                foreach (var clothes in colour.Value)
                {
                    if(colour.Key == findClothesColour && clothes.Key == findClothesType)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
    }
}
