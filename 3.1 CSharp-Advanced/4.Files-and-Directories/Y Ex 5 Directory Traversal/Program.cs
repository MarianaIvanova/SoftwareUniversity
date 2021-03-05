using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Y_Ex_5_Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)// TO GET DESKPOT AT EVERY COMPUTER!!!!!
        {
            //string folderPath = Console.ReadLine();//../../../
            string[] files = Directory.GetFiles("../../../");//folderPath
            Dictionary<string, Dictionary<string, double>> allFiles = 
                new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo infoFile = new FileInfo(files[i]);
                string fileExtension = infoFile.Extension;
                double size = infoFile.Length / 1024.00;//In kb we need to devide to 1024.00
                string fileName = infoFile.Name;

                if (!allFiles.ContainsKey(fileExtension))
                {
                    allFiles.Add(fileExtension, new Dictionary<string, double>());
                }

                allFiles[fileExtension].Add(fileName, size);
            }

            // TO GET DESKPOT AT EVERY COMPUTER!!!!!
            using (StreamWriter writer = 
                new StreamWriter(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Directory Traversal.txt"))
            {
                foreach (var item in allFiles.OrderByDescending(x => x.Value.Count).
                            ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value))
                {
                    Console.WriteLine(item.Key);
                    writer.WriteLine(item.Key);
                    foreach (var file in item.Value.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value))
                    {
                        Console.WriteLine($"--{file.Key} - {file.Value}kb");
                        writer.WriteLine($"--{file.Key} - {file.Value}kb");
                    }
                }
            }
        }
    }
}
