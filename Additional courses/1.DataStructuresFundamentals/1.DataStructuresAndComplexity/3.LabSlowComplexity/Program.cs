using System;
using System.Diagnostics;

namespace _3.LabSlowComplexity
{
    class Program
    {
        static int count = 0;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Algorithm(n);

            watch.Stop();
            Console.WriteLine($"Count: {count}");
            Console.WriteLine($"Time: {watch.ElapsedMilliseconds}");

            watch.Reset();
            Console.WriteLine();
            watch.Start();

            Algorithm2(n);

            watch.Stop();
            Console.WriteLine($"Count: {count}");
            Console.WriteLine($"Time: {watch.ElapsedMilliseconds}");
        }
        //Рекурсивен алгоритъм в сложност O(2^n)
        static void Algorithm(int n)
        {
            if(n == 0)
            {
                return;
            }

            count++;

            Algorithm(n - 1);
            Algorithm(n - 1);
        }
        //10
        //Count: 1023
        //Time: 0
        //20
        //Count: 1048575
        //Time: 22
        //Над 30 вече е много дълго, като при мен и при 30 заби!
        static void Algorithm2(int n)// O(n!)
        {
            if (n == 0)
            {
                return;
            }

            count++;
            for (int i = 0; i < n; i++)
            {
                Algorithm(n - 1);
            }
        }
        //10
        //Count: 6134
        //Time: 0
        //20
        //Count: 11534316
        //Time: 323
    }
}
