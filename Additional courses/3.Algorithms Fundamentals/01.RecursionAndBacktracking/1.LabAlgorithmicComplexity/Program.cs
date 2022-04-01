using System;
using System.Linq;

namespace _1.LabAlgorithmicComplexity
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Loop complexity is n for 1 loop. For m nested loops is n^m
            int n = int.Parse(Console.ReadLine());
            long result = GetOperationsCount(n);//Result is comlexity T(n) = 3(n ^ 2) + 3n + 3, but we say it is n ^ 2

            //2. Linq operations for an array:
            var nums = new[] { 1, 2, 3, 4, 5 };
            if(nums.All(x => x % 2 == 0))//Here the complexity is also n, cause we itarate through all the numbers int the array to check what we need.
            { }
            //So, the complexity is n ^ 3 in this case:
            for (int i = 0; i < n; i++)// n
            {
                for (int j = 0; j < n; j++)// n
                {
                    if (nums.All(x => x % 2 == 0))// n
                    { }
                }
            }
            //Here the complexity is n:
            for (int i = 0; i < n; i++)//n
            {
                for (int j = 0; j < n/2; j++)// n/2 --this we don't count, cause this is 1/2 of n
                {}
            }

            //3. Constant complexity:
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int num = int.Parse(Console.ReadLine());
            int c = Sum(a, b);
            var result2 = IsEven(num);
        }
        //1.
        public static long GetOperationsCount(int n)
        {
            long counter = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    counter++;
                }
            }
            //This is the original from the lecture:
            //for (int i = 0; i < n; i++)
            //    for (int j = 0; j < n; j++)
            //        counter++;

            return counter;
        }
        //3.1 Constant complexity:
        public static int Sum(int a, int b)
        {
            return a + b;
        }
        //3.2 Constant complexity:
        public static bool IsEven(int num)
        {
            if(num % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
