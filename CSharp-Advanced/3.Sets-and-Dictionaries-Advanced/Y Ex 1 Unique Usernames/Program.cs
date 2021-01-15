using System;
using System.Collections.Generic;

namespace Y_Ex_1_Unique_Usernames
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
                allNames.Add(currentName);
            }

            Console.WriteLine(string.Join(Environment.NewLine, allNames));
        }
    }
}
