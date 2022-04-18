using System;
using System.Linq;

namespace _6.ConnectingCablesDP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Using Longest Common Subsequence DP

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //var positions = new int[numbers.Length];
            //var orderedNumbers = numbers.OrderBy(x => x).ToArray();

            var positions = Enumerable.Range(1, numbers.Length).ToArray();

            var dp = new int[numbers.Length + 1, positions.Length + 1];//In this case numbers.Length = positions.Length 

            //For the col = 0 and for row = 0, we have 0, so we work with 
            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if(numbers[row - 1] == positions[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col - 1] + 1; //Ако са равни, вземаме диагонала + 1
                    }
                    else
                    {
                        dp[row, col] = Math.Max(dp[row - 1, col], dp[row, col - 1]);//Ако не са равни, вземаме по-голямата сума от ляво или горе
                    }
                }
            }

            Console.WriteLine($"Maximum pairs connected: {dp[numbers.Length, positions.Length]}");
        }
    }
}
//We are in a rectangular room. On opposite sides of the room, there are sets of n cables (n < 1000). The cables are indexed from 1 to n. 
//On each side of the room, there is a permutation of the cables, e.g. on one side we always have ordered {1, 2, 3, 4, 5} and on the other side, we have some permutation {5, 1, 3, 4, 2}. We are trying to connect each cable from one side with the corresponding cable on the other side – connect 1 with 1, 2 with 2, etc. The cables are straight and should not overlap!
//The task is to find the maximum number of pairs we can connect given the restrictions above.
