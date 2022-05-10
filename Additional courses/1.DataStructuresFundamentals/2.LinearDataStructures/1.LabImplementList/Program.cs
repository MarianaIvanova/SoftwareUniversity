using System;

namespace _1.LabImplementList
{
    class Program
    {
        static void Main(string[] args)
        {
            CoolList<int> list = new CoolList<int>();
            //CoolList<int> list = new CoolList<int>(300);//Ако първоначален размер е 300, чак след това ще оразмерим на 600 и т.н.

            for (int i = 0; i < 100; i++)
            {
                list.Add(i * 5);
                Console.WriteLine($"Internal array count: {list.InternalArrayCount}");
                Console.WriteLine($"List count: {list.Count}");
                Console.WriteLine();
            }
            //Internal array count: 4
            //List count: 1

            //Internal array count: 4
            //List count: 2

            //Internal array count: 4
            //List count: 3

            //Internal array count: 4
            //List count: 4

            //Internal array count: 8
            //List count: 5

            //Internal array count: 8
            //List count: 6

            //Internal array count: 8
            //List count: 7

            //Internal array count: 8
            //List count: 8

            //Internal array count: 16
            //List count: 9

            //Internal array count: 16
            //List count: 10
        }
    }
}
