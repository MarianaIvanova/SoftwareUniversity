using System;

namespace _2.LabSubsetSumWithRepetition
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

            Console.WriteLine(sums[target]);//true
        }
    }
}
