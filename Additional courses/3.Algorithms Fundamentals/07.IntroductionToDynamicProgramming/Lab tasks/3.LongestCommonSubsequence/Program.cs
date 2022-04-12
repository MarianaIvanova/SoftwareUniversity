using System;
using System.Collections.Generic;

namespace _3.LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            //Да не забравим да добавим нулев ред и колона, които са със стойност string.Empty за двата стринга
            var matrix = new int[str1.Length + 1, str2.Length + 1];//По подразбиране всички стойности на матрицата от int e 0

            //This is not needed as all the default values in the int matrix are 0
            //matrix[0, 0] = 0;

            //for (int r = 1; r < str1.Length + 1; r++)
            //{
            //    matrix[r, 0] = 0;
            //}

            //for (int c = 1; c < str2.Length + 1; c++)
            //{
            //    matrix[0, c] = 0;
            //}

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if(str1[row - 1] == str2[col - 1])
                    {
                        matrix[row,col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    }
                }
            }

            //Print the number of the equal substring 
            Console.WriteLine(matrix[str1.Length, str2.Length]);

            //Print the sunstring
            Console.WriteLine(PrintLCS(str1.Length, str2.Length, str1, str2, matrix));
        }

        static string PrintLCS(int row, int col, string str1, string str2, int[,] lcs)
        {
            var lcsLetters = new Stack<char>();

            while (row > 0 && col > 0)
            {
                if (str1[row - 1] == str2[col - 1])
                {
                    lcsLetters.Push(str1[row - 1]);
                    row -= 1;
                    col -= 1;
                }
                else if(lcs[row - 1, col] > lcs[row, col - 1]) 
                { 
                    row -= 1;
                }
                else 
                { 
                    col -= 1; 
                }
            }

            return string.Join("", lcsLetters);
        }
    }
}
