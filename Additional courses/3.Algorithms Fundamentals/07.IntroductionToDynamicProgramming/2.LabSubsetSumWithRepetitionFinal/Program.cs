using System;
using System.Collections.Generic;

namespace _2.LabSubsetSumWithRepetitionFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 3, 5, 2 };
            var target = 17;

            var sums = new bool[target + 1];//Защото имаме 0 позиция
            sums[0] = true;

            for (int sum = 0; sum < sums.Length; sum++)
            {
                //Когато нямаме постигната сума, то нейната клетка ще е false
                if (!sums[sum])
                {
                    continue;
                }

                //С всяко число искаме да генерираме нова сума:
                foreach (var num in nums)
                {
                    var newSum = sum + num;

                    if (newSum > target)
                    {
                        continue;
                    }

                    sums[newSum] = true;
                }
            }

            var subset = new List<int>();

            while(target > 0)
            {
                //Опитваме да извадим последователно всички числа, като ако резултатът също е true, то това число е използвано
                foreach (var num in nums)
                {
                    var prevSum = target - num;
                    if(prevSum >= 0 && sums[prevSum])
                    {
                        subset.Add(num);
                        target = prevSum;

                        //И ако таргетът е станал 0
                        if(target == 0)
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", subset));//3 5 2 3 2 2
        }
    }
}

