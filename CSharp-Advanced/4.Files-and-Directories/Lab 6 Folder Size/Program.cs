using System;
using System.IO;

namespace Lab_6_Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Console.ReadLine();//../../../ is 372708 - with all folders and files
            //or C:\Windows - with all folders and files
            Console.WriteLine(GetDirectorySize(directoryPath));
        }

        static double GetDirectorySize(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);
            double sum = 0;

            string[] directories = Directory.GetDirectories(directoryPath);
            for (int i = 0; i < directories.Length; i++)
            {
                Console.WriteLine($"Directories {directories[i]}");
                sum += GetDirectorySize(directories[i]);//РЕКУРСИЯ - here it goes in all directories in deep
                //Directory.Delete(directories[i]);// ТАКА ЗАЧИСТВАМ ЦЕЛИ ДИРЕКТОРИИ, МНОГО ДА ВНИМАВАМ
            }

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo info = new FileInfo(files[i]);
                Console.WriteLine($"{info.FullName} --> {info.Length} bytes");
                sum += info.Length;
                //File.Delete(files[i]);/ ТАКА ЗАЧИСТВАМ ФАЙЛОВЕ, МНОГО ДА ВНИМАВАМ
            }

            //Console.WriteLine(sum);
            return sum;
        }

    }
}
