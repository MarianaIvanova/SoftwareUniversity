using System;
using System.Linq;

namespace Y_Ex_3_Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensionSizes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = dimensionSizes[0];
            int cols = dimensionSizes[1];
            int[,] matrix = new int[rows, cols];

            FillMatrix(matrix);
            //PrintMatrix(matrix);
            if(rows >= 3 && cols >= 3)
            {
                int sumMax3x3Matrix = int.MinValue;
                int startRowMax = 0;
                int startColMax = 0;
                for (int row = 0; row < matrix.GetLength(0) - 2; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                    {
                        int sumCurrent3x3Matrix = 0;
                        for (int row3x3 = row; row3x3 < row + 3; row3x3++)
                        {
                            for (int col3x3 = col; col3x3 < col + 3; col3x3++)
                            {
                                sumCurrent3x3Matrix += matrix[row3x3, col3x3];
                            }
                        }

                        if(sumCurrent3x3Matrix > sumMax3x3Matrix)
                        {
                            sumMax3x3Matrix = sumCurrent3x3Matrix;
                            startRowMax = row;
                            startColMax = col;
                        }
                    }
                }

                Console.WriteLine($"Sum = {sumMax3x3Matrix}");
                PrintMatrix3x3(matrix, startRowMax, startColMax);
            }
        }

        static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
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

        private static void PrintMatrix3x3(int[,] matrix, int startRowMax, int startColMax)
        {
            for (int row = startRowMax; row < startRowMax + 3; row++)
            {
                for (int col = startColMax; col < startColMax + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
