using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Y_Ex_1_Even_LinesEx//Use StreamReader
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../InputOddLinesEx.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../OutputOddLinesEx.txt"))
                {
                    string line = reader.ReadLine();
                    int counter = 0;

                    while (line != null)
                    {
                        if (counter % 2 == 0)
                        {
                            Regex pattern = new Regex(@"[-,!?.]");
                            line = pattern.Replace(line, "@");
                            var array = line.Split(" ").Reverse().ToArray();
                            writer.WriteLine(string.Join(" ", array));
                            Console.WriteLine(string.Join(" ", array));
                        }
                        line = reader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
