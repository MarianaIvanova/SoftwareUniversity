using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Y_Ex_1_Even_Lines //Use StreamReader
{
    class Program
    {
        static void Main(string[] args)//It is odd lines, not even
        {
            using(StreamReader reader = new StreamReader("../../../InputOddLines.txt"))
            {
                string input = reader.ReadLine();
                int counter = 0;
                Dictionary<int, List<string>> finalData = new Dictionary<int, List<string>>();

                while(input != null)
                {
                    if(counter % 2 == 0)
                    {
                        StringBuilder inputText = new StringBuilder(input);

                        for (int i = 0; i < inputText.Length; i++)
                        {
                            if (inputText[i] == '-' || inputText[i] == ',' ||
                                inputText[i] == '.' || inputText[i] == '!' || inputText[i] == '?')
                            {
                                inputText[i] = '@';
                            }
                            //We can use also input.Replace('-', '@');
                        }

                        string text = inputText.ToString();
                        List<string> textTmp = text.Split(" ").ToList();
                        List<string> textReverse = new List<string>();

                        for (int i = textTmp.Count - 1; i >= 0; i--)
                        {
                            textReverse.Add(textTmp[i]);
                        }

                        finalData.Add(counter, textReverse);
                    }

                    input = reader.ReadLine();
                    counter++;
                }

                using (StreamWriter writer = new StreamWriter("../../../OutputOddLines.txt"))
                {
                    foreach (var line in finalData)
                    {
                        writer.WriteLine(string.Join(" ", line.Value));
                        Console.WriteLine(string.Join(" ", line.Value));
                    }
                }
            }
        }
    }
}
