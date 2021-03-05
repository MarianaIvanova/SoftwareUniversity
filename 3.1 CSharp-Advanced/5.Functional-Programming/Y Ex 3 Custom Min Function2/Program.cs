using System;
using System.Linq;

namespace Y_Ex_3_Custom_Min_Function_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> myIntParse = x => int.Parse(x);

            int[] numbers = Console.ReadLine()
                .Split(" ")
                //.Select(int.Parse)//Този ред е съкратената версия на долния ред!
                //.Select(x => int.Parse(x))
                .Select(myIntParse)//Това е нашата функция на парсването!
                .ToArray();

            Func<int[], int> minNumber = nums =>
            {
                //int minNum = nums.Min();

                int minNum = int.MaxValue;
                foreach (var num in nums)
                {
                    if(num < minNum)
                    {
                        minNum = num;
                    }
                }
                return minNum;
            };
            Console.WriteLine(minNumber(numbers));
        }
    }
}

