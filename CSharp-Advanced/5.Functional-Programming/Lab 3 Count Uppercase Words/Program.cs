using System;
using System.Linq;

namespace Lab_3_Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x[0] == x.ToUpper()[0])//This is the first letter [0]
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
