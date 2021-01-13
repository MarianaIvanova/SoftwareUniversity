using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_8_Custom_ComparatorEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            //Array.Sort(numbers, (x, y) => x.CompareTo(y));
            Array.Sort(numbers, (x, y) =>
            {
                int sorter = 0;

                if(x % 2 == 0 && y % 2 != 0)
                {
                    sorter = -1;//Ще ги остави така, както са си
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    sorter = 1;// Ще размени първо да е четното, след това нечетното
                }

                else//сравняваме четни или нечетни числа
                {
                    sorter = x - y;//ще ги подреди възходящо и е равно та x.CompareTo(y)
                }
                return sorter;
            });

            //Може и само така:
            //Array.Sort(numbers, (x, y) =>
            //(x % 2 == 0 && y % 2 != 0) ? - 1:
            //(x % 2 != 0 && y % 2 == 0) ? 1 :
            //x.CompareTo(y));

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
