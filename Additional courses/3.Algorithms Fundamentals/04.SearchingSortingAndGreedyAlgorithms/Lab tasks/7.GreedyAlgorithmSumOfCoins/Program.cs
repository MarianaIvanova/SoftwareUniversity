using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.GreedyAlgorithmSumOfCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            //Прочитаме монетите и ги подреждаме по низходящ ред. Поставяме ги в опашка, за да можем първо да извеждаме най-голямата по стойност монета:
            var coins = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderByDescending(x => x));

            var usedCoins = new Dictionary<int, int>();
            var totalCoinsCount = 0;

            var target = int.Parse(Console.ReadLine());

            while(target > 0 && coins.Count > 0)// coins.Count > 0 е когато не ни стигат монетите
            {
                var currentCoin = coins.Dequeue();
                var count = target / currentCoin;//Колко пъти може да използваме тази монета

                //Ако обаче монетата не е използвана е по-добре да не я добавяме с count = 0 в речника:
                if(count == 0)
                {
                    continue;
                }

                //Добавяме монетата в речника
                //usedCoins.Add(currentCoin, count);
                usedCoins[currentCoin] = count;
                totalCoinsCount += count;
                //Виждаме остатъка:
                //target = target % currentCoin;
                target %= currentCoin;
            }

            if(target == 0)
            {
                Console.WriteLine($"Number of coins to take: {totalCoinsCount}");
                foreach (var coin in usedCoins)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            else
            {
                Console.WriteLine($"Error");
            }
        }
    }
}
