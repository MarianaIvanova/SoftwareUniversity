using System;
using System.Linq;

namespace Lab_4_Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine().Split(", ").Select(decimal.Parse).ToArray();
            decimal[] numbersWithVat = numbers.Select(x => x * 1.2m).ToArray();//!!!!!!!If it's not decimal/double and 1.2m - NOT OK!!

            foreach (var number in numbersWithVat)
            {
                Console.WriteLine($"{number:F2}");
            }

        }
    }
}
