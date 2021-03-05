using System;
using System.Linq;

namespace Lab_3_Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = MatrixData(n);

            Console.WriteLine(SumPrimaryDiagonalSquarematrix(matrix));
        }

        static int[,] MatrixData(int n)
        {
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            return matrix;
        }

        static int SumPrimaryDiagonalSquarematrix(int[,] matrix)
        {
            int sum = 0;

            for (int rowCol = 0; rowCol < matrix.GetLength(0); rowCol++)
            {
                sum += matrix[rowCol, rowCol];
            }

            return sum;
        }
    }
}
