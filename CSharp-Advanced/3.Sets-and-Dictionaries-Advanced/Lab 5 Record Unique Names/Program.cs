using System;
using System.Collections.Generic;

namespace Lab_5_Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> allNames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string currentName = Console.ReadLine();
                allNames.Add(currentName);//No need to check if it exist, as it will not add currentName second time
            }

            Console.WriteLine(string.Join(Environment.NewLine,allNames));
        }
    }
}
