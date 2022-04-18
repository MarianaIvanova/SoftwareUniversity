using System;
using System.Text;
using System.Linq;

namespace _5.WordDifferences
{
    class Program
    {
        //USING DYMAMIC PROGRAMING
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var dp = new int[str1.Length + 1,str2.Length + 1];//Dyamic Programing, + 1 for the empty string

            Console.WriteLine($"Deletions and Insertions: {Str1ToStr2(str1, str2, dp)}");
        }

        private static int Str1ToStr2(string str1, string str2, int[,] dp)
        {
            //Попълваме ръчно първата колона
            for (int row = 1; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = row;
            }

            //Попълваме ръчно първия ред
            for (int col = 1; col < dp.GetLength(1); col++)
            {
                dp[0, col] = col;
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if(str1[row - 1] == str2[col - 1])//-1 защото добавихме по в началото правен стринг в матрицата
                    {
                        dp[row, col] = dp[row - 1, col - 1];
                    }
                    else
                    {
                        dp[row, col] = Math.Min(dp[row - 1, col], dp[row, col - 1]) + 1;
                    }
                }
            }

            return dp[str1.Length, str2.Length];
        }
    }
}
//Write a program that finds all the differences between two strings. You have to determine the smallest set of deletions and insertions to make the first string equal to the second. Finally, you have to print the count of the minimum insertions and deletions.
//Input
//•	You will receive the two strings on separate lines
//Output
//•	Print the minimum amount of deletions and insertions as described below 
//Example
//Input	
//YMCA
//HMBB	
//Output
//Deletions and Insertions: 6
//Comment
//One solution will be to remove "Y" and add "H" to the first: HMCA
//"M" matches in both strings
//Remove "C" and "A" from the first: HM
//Add two "B"'s and now both strings match  

