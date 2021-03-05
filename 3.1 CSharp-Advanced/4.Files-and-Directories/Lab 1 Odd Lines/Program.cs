using System;
using System.IO;

namespace Lab_1_Odd_Lines//NO Judge access to check it!!!
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../InputOddLines.txt"))
            //We can use this code as a base for the program Program.cs, instead of InputOddLines.txt
            {
                string currentLine = reader.ReadLine();
                int count = 0;
                while(currentLine != null)
                {
                    if(count % 2 == 1)
                    {
                        Console.WriteLine(currentLine);
                    }
                    currentLine = reader.ReadLine();
                    count++;
                }
                //Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
}
