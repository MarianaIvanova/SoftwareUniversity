using System;
using System.Linq;

namespace _3.BubbleSort
{
    class Program
    {
        //Compexity for time is less then O(n^2), because of adding the sortedCount
        //The searching is to go on the first element and swap it with the second if the first element is bigger. Then to check for the second and third one and so on. We add sortedCount to exlude the last element already ordered as the biggest one!
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            BubbleSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
           var sortedCount = 0; //Колко пъти сме намерили число, което сме закарали най-вдясно. Това го правим, за да не проверяваме отново и отново подредените в дясно най-големи числа! За да имаме performance improvement!

           var isSorted = false;

           while(!isSorted)
            {
                isSorted = true;//Правим го все едно е сортиран, а ако направим Swap, значи не е и ще продължи while цикъла

                for (int j = 1; j < numbers.Length - sortedCount; j++)
                {
                    var i = j - 1;
                    if (numbers[i] > numbers[j])
                    {
                        Swap(i, j, numbers);
                        isSorted = false;//Тъй като на текущата итерация съм направил Swap, значи - не съм приключил цикъла 
                    }
                }

                sortedCount += 1;
            }
        }
        private static void Swap(int first, int second, int[] numbers)
        {
            var tmp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = tmp;
        }
    }
}
