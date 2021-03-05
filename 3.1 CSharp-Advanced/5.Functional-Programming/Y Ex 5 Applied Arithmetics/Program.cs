using System;
using System.Linq;

namespace Y_Ex_5_Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            string input = Console.ReadLine();
            while(input != "end")
            {
                switch(input)
                {
                    case "add":
                        {
                            numbers = numbers.Select(x => x + 1).ToArray();
                        }
                        break;
                    case "multiply":
                        {
                            numbers = numbers.Select(x => x * 2).ToArray();
                        }
                        break;
                    case "subtract":
                        {
                            numbers = numbers.Select(x => x - 1).ToArray();
                        }
                        break;
                    case "print":
                        {
                            Console.WriteLine(string.Join(" ",numbers));
                        }
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
