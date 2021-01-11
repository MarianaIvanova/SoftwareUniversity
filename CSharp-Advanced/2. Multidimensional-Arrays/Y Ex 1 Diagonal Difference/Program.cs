using System;
using System.Linq;

namespace Y_Ex_1_Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());//dimensionSizes
            int[,] matrix = new int[n, n];

            FillMatrix(matrix);
            //PrintMatrix(matrix);

            int sum1 = SumPrimaryDiagonalmatrix(matrix);
            int sum2 = SumSecondaryDiagonalmatrix(matrix);
            int absoluteDifference = Math.Abs(sum1 - sum2);
            Console.WriteLine(absoluteDifference);
        }

        static int SumPrimaryDiagonalmatrix(int[,] matrix)
        {
            int sum = 0;

            for (int rowCol = 0; rowCol < matrix.GetLength(0); rowCol++)
            {
                sum += matrix[rowCol, rowCol];
            }

            return sum;
        }

        static int SumSecondaryDiagonalmatrix(int[,] matrix)
        {
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, matrix.GetLength(0) - row - 1];
            }

            return sum;
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
