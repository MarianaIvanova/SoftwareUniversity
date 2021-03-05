using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Y_Ex_2_Line_Numbers_Ex //Use the static class File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../InputLineNumbers.txt");
            string[] newLines = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                newLines[i] = $"Line {i + 1}: {line} ({CountLetters(line)})({CountPunctualMarks(line)})";
                Console.WriteLine(newLines[i]);
            }

            File.WriteAllLines("../../../OutputLineNumbers.txt", lines);
        }

        static int CountLetters(string line)
        {
            int countLetters = 0;
            for (int i = 0; i < line.Length; i++)
            {
                char currentSymbol = line[i];
                if(char.IsLetter(currentSymbol))
                {
                    countLetters++;
                }
            }
            return countLetters;
        }
        static int CountPunctualMarks(string line)
        {
            char[] punctuationMarks = new char[] { '-', ',', '.', '!', '?', '\'', ':',';',':' };
            int countPunctuationMarks = 0;
            for (int i = 0; i < line.Length; i++)
            {
                char currentSymbol = line[i];
                if (punctuationMarks.Contains(currentSymbol))
                {
                    countPunctuationMarks++;
                }
            }
            return countPunctuationMarks;
        }
    }
}
