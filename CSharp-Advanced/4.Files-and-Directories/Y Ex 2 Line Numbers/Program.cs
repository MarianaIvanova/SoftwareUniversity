using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Y_Ex_2_Line_Numbers //Use the static class File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../InputLineNumbers.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                int totalLength = lines[i].Length;
                Regex pattern = new Regex(@"[-,.!?';:]");
                var punctuationMarks = pattern.Matches(lines[i]);
                int countPunctuationMarks = punctuationMarks.Count;
                //foreach (Match matches in punctuationMarks) //Other way of counting
                //{
                //    countpunctuationMarks++;
                //}

                Regex patternLetters = new Regex(@"[A-Za-z]");
                var allLetters = patternLetters.Matches(lines[i]);
                int countLetters = allLetters.Count;

                lines[i] = $"Line {i + 1}: {lines[i]} ({countLetters})({countPunctuationMarks})";
                Console.WriteLine(lines[i]);
            }

            File.WriteAllLines("../../../OutputLineNumbers.txt", lines);
        }
    }
}
