using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_12_TriFunctionEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, int> getAsciiSum = p => p.Select(c => (int)c).Sum();//!!!!!!!!!!!!!!!!!
            //string person = SumLeetersASCCIIName(names, n, getAsciiSum);
            //Console.WriteLine(person);

            Func<List<string>, int, Func<string, int>, string> nameFunc = (names, n, func) =>
            names.FirstOrDefault(p => func(p) >= n);

            string result = nameFunc(names, n, getAsciiSum);
            Console.WriteLine(result);
        }

        static string SumLeetersASCCIIName(List<string> names, int n, Func<string, int> func)
        {
            string result = null;

            foreach (var person in names)
            {
                if(func(person) >= n)
                {
                    result = person;
                }
            }

            return result;
        }
    }
}
