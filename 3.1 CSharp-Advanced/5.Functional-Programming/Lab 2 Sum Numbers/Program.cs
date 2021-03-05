using System;
using System.Linq;

namespace Lab_2_Sum_Numbers_with_Func
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] allNumbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseStringToInt).ToArray();//We have made a parse method
            //1-ви начин с Func
            PrintingCountAndSum(allNumbers, CountNumbers, SumNumbers); 
            //2-ри начин с Lambda
            //PrintingCountAndSum(allNumbers, x =>
            //{
            //    return x.Count();
            //}, x =>
            //{
            //    return x.Sum();
            //}); 
        }
        static void PrintingCountAndSum(int[] allNumbers, Func<int[], int> count, Func<int[], int> sum)
        {
            Console.WriteLine(count(allNumbers));
            Console.WriteLine(sum(allNumbers));
        }
        static int CountNumbers(int[] allNumbers)
        {
            return allNumbers.Count();
        }
        static int SumNumbers(int[] allNumbers)
        {
            return allNumbers.Sum();
        }
        static int ParseStringToInt(string numberInString)
        {
            int number = int.Parse(numberInString);
            return number;
        }
    }
}
