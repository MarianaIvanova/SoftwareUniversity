using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab_4_Merge_Files
{
    class Program
    {
        static void Main(string[] args)//NO Judge access to check it!!!
        {
            List<int> inputFile1 = new List<int>();

            using (StreamReader reader1 = new StreamReader("../../../InputMergeFiles1.txt"))
            {
                string currentLine = reader1.ReadLine();
                while(currentLine != null)
                {
                    inputFile1.Add(int.Parse(currentLine.ToString()));
                    currentLine = reader1.ReadLine();
                }
            }

            List<int> inputFile2 = new List<int>();

            using (StreamReader reader2 = new StreamReader("../../../InputMergeFiles2.txt"))
            {
                string currentLine = reader2.ReadLine();
                while (currentLine != null)
                {
                    inputFile2.Add(int.Parse(currentLine.ToString()));
                    currentLine = reader2.ReadLine();
                }
            }

            inputFile1 = inputFile1.OrderBy(x => x).ToList();
            inputFile2 = inputFile2.OrderBy(x => x).ToList();
            Queue<int> file1Tmp = new Queue<int>(inputFile1);
            Queue<int> file2Tmp = new Queue<int>(inputFile2);

            List<int> output = new List<int>();
            while (file1Tmp.Count > 0 && file2Tmp.Count > 0)
            {
                if(file1Tmp.Peek() <= file2Tmp.Peek())
                {
                    output.Add(file1Tmp.Dequeue());
                }
                else
                {
                    output.Add(file2Tmp.Dequeue());
                }
            }

            while(!(file1Tmp.Count == 0 && file2Tmp.Count == 0))
            {
                if (file1Tmp.Count == 0 && file2Tmp.Count > 0)
                {
                    while (file2Tmp.Count > 0)
                    {
                        output.Add(file2Tmp.Dequeue());
                    }
                }
                else if (file2Tmp.Count == 0 && file1Tmp.Count > 0)
                {
                    while (file1Tmp.Count > 0)
                    {
                        output.Add(file1Tmp.Dequeue());
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("../../../OutputMergeFiles.txt"))
            {
                for (int i = 0; i < output.Count; i++)
                {
                    Console.WriteLine(output[i]);
                    writer.WriteLine(output[i]);
                }
            }
        }
    }
}
