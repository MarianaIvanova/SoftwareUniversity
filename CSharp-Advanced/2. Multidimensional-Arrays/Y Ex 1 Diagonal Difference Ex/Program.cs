using System;
using System.Linq;

namespace Y_Ex_1_Diagonal_Difference_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());//dimensionSizes
            int[,] matrix = new int[n, n];

            FillMatrix(matrix);
            //PrintMatrix(matrix);

            int sumPrimary = 0;//All numbers with row == col
            int sumSecondary = 0;//All numbers with col = matrix.GetLength(1) - row - 1//col = n - row - 1

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(row == col)
                    {
                        sumPrimary += matrix[row, col];
                    }
                    if(col == n - row - 1)
                    {
                        sumSecondary += matrix[row, col];
                    }
                }
            }
            int absoluteDifference = Math.Abs(sumPrimary - sumSecondary);
            Console.WriteLine(absoluteDifference);
        }


        static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)//matrix.GetLength(1) == currentRow.Length
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
