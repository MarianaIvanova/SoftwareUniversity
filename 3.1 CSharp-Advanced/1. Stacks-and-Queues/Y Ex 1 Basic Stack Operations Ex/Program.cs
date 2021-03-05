using System;
using System.Collections.Generic;
using System.Linq;


namespace Y_Ex_1_Basic_Stack_Operations_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            //int n = basicInfo[0];
            int s = input[1];

            Stack<int> stack = new Stack<int>(numbers);

            for (int i = 1; i <= s; i++)//Приемаме, че s <= stack.count
            {
                stack.Pop();
            }

            int x = input[2];

            if(stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if(stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
