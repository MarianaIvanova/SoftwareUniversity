using System;
using System.Linq;

namespace Lab_2_Sum_Matrix_Columns_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = sizes[0];
            int columns = sizes[1];

            int[,] matrix = FillingElementsMatrix(rows, columns);

            SumColumnsMatrix(matrix);
        }

        static int[,] FillingElementsMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowsData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowsData[col];
                }
            }
            return matrix;
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
