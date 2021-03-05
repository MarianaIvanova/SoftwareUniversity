using System;
using System.IO;

namespace Lab_2_Line_Numbers//NO Judge access to check it!!!
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader reader = new StreamReader("../../../InputLineNumbers.txt"))
            {
                using(StreamWriter writer = new StreamWriter("../../../OutputLineNumbers.txt"))
                {
                    string currentLine = reader.ReadLine();
                    int index = 1;
                    while(currentLine != null)
                    {
                        writer.WriteLine($"{index}. {currentLine}");
                        Console.WriteLine($"{index}. {currentLine}");
                        index++;
                        currentLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}
