using System;
using System.Linq;

namespace Lab_3_Count_Uppercase_WordsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Abc"[0] == "Abc".ToUpper()[0]);//True, because A == A
            //Console.WriteLine("abc"[0] == "abc".ToUpper()[0]);//False, because a != A
            Func<string, bool> upperChecker = x => x[0] == x.ToUpper()[0];//This is the first letter [0]
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(upperChecker)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
