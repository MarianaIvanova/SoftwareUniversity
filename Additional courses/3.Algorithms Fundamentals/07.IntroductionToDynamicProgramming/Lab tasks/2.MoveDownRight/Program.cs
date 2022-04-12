using System;
using System.Linq;
using System.Collections.Generic;

namespace _2.MoveDownRight
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var rowElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = rowElements[c];
                }
            }

            var dp = new int[rows, cols];//matrixSum
            dp[0, 0] = matrix[0, 0];

            //For the first row
            for (int c = 1; c < cols; c++)
            {
                dp[0, c] = dp[0, c - 1] + matrix[0, c];
            }

            //For the first column
            for (int r = 1; r < rows; r++)
            {
                dp[r, 0] = dp[r - 1, 0] + matrix[r, 0];
            }

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    var upper = dp[r - 1, c];
                    var left = dp[r, c - 1];
                    dp[r, c] = Math.Max(upper, left) + matrix[r, c];
                }
            }

            var path = new Stack<string>();//Защото по-долу извеждаме данните от долу нагоре!

            var row = rows - 1;
            var col = cols - 1;

            while(row > 0 && col > 0)
            {
                path.Push($"[{row}, {col}]");

                var upper = dp[row - 1, col];
                var left = dp[row, col - 1];

                if(upper > left)
                {
                    row -= 1;
                }
                else
                {
                    col -= 1;
                }
            }

            while(row > 0)
            {
                path.Push($"[{row}, {col}]");
                row -= 1;
            }

            while(col > 0)
            {
                path.Push($"[{row}, {col}]");
                col -= 1;
            }

            //foreach (var cell in path)
            //{
            //    Console.WriteLine(path.Pop());
            //}
            path.Push($"[{row}, {col}]");

            Console.WriteLine(string.Join(" ", path));
        }
    }
}
