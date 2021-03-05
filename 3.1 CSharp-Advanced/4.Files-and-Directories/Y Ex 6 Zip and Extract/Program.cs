using System;
using System.IO.Compression;

namespace Y_Ex_6_Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args) 
        {
            //ВИНАГИ СЪЗДАВАНЕТО НА zip файла трябва да е на една директрия и да се записва в друга директория
            ZipFile.CreateFromDirectory(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}",
                @$"C:\Users\PC\Test\MyZipFile.zip");

            ZipFile.ExtractToDirectory(@"C:\Users\PC\Test\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources.zip",
                        @"C:\Users\PC\Test");

            //string startPath = @".\start";
            //string zipPath = @".\result.zip";
            //string extractPath = @".\extract";

            //ZipFile.CreateFromDirectory(startPath, zipPath);

            //ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
