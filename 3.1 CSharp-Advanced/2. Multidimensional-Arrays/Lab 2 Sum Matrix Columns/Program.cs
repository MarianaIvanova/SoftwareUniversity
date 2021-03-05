using System;
using System.Linq;

namespace Lab_2_Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = sizes[0];
            int columns = sizes[1];
            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowsData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowsData[col];
                }
            }

            SumColumnsMatrix(matrix);
        }

        static void SumColumnsMatrix(int[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sumColumns = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sumColumns += matrix[row, col];
                }

                Console.WriteLine(sumColumns);
            }
        }
    }
}
