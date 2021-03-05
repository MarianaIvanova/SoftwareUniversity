using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_5_Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> countSymbols = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char currentLetter = text[i];
                
                if(!countSymbols.ContainsKey(currentLetter))
                {
                    countSymbols.Add(currentLetter, 0);
                }

                countSymbols[currentLetter]++;
            }

            //We may use sorted dictionary - it's easier
            countSymbols = countSymbols.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var chars in countSymbols)
            {
                Console.WriteLine($"{chars.Key}: {chars.Value} time/s");
            }
        }
    }
}
