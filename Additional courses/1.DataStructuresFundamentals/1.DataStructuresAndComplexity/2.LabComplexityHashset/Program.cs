using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _2.LabComplexityHashset
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array strudent name
            //Write a function that accept students and returns true or false weather student is in the array
            int count = 100000;//int.Parse(Console.ReadLine());
            int[] array = new int[count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            Stopwatch watch = new Stopwatch();
            watch.Start();
            bool isThere = false;
            for (int i = 0; i < count; i++)
            {
                isThere = LinearFind(array, -5);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);//6577 milliseconds, тук започва да забива при повече от 100 хиляди, а при HashSet добавих още 2 нули (разбира се нулирах count-а в цикъла на array-а) и мина само за 299!

            watch.Reset();
            HashSet<int> set = new HashSet<int>(array);
            watch.Start();
            for (int i = 0; i < count; i++)
            {
                isThere = ConstantTimeFind(set, -5);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);//3 milliseconds. Поне 2 хил. пъти по-малко
        }
        //O(n) - сложност
        static bool LinearFind(int[] array, int element)
        {
            return array.Contains(element);
        }

        //O(1) - най-бързото време, което можем да постигнем
        static bool ConstantTimeFind(HashSet<int> array, int element)
        {
            return array.Contains(element);
        }
    }
}
