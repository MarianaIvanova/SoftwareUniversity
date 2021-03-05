using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab_3_Word_Count
{
    class Program
    {
        static void Main(string[] args)//NO Judge access to check it!!!
        {
            string input = string.Empty;
            string input2 = string.Empty;

            using (StreamReader reader = new StreamReader("../../../WordsToSeek.txt"))
            {
                input = reader.ReadToEnd().ToLower();
            }

            using (StreamReader reader2 = new StreamReader("../../../InputWordCount.txt"))
            {
                input2 = reader2.ReadToEnd().ToLower();
            }

            List<string> wordsToSeek = input.Split(" ").ToList();
            StringBuilder input2newText = new StringBuilder(input2);
            for (int m = 0; m < input2newText.Length; m++)
            {
                string word = string.Empty;
                if(input2newText[m] == '.' || input2newText[m] == ',' || input2newText[m] == '?' ||
                    input2newText[m] == '-' || input2newText[m] == '!')
                {
                    input2newText[m] = ' ';
                }
            }
            input2 = input2newText.ToString();
            List<string> inputWordCount = input2.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, int> finalResult = new Dictionary<string, int>();

            for (int i = 0; i < wordsToSeek.Count; i++)
            {
                string currentWord = wordsToSeek[i];
                int count = 0;

                for (int j = 0; j < inputWordCount.Count; j++)
                {
                    if(currentWord == inputWordCount[j])
                    {
                        count++;
                    }
                }

                finalResult.Add(currentWord, count);
            }

            finalResult = finalResult.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            using (StreamWriter writer = new StreamWriter("../../../OutputWordCount.txt"))
            {
                foreach(var word in finalResult)
                {
                    Console.WriteLine($"{word.Key} - {word.Value}");
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
