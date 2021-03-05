using System;
using System.Linq;

namespace Lab_5_Square_With_Maximum_Sum_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSizes[0];
            int columns = matrixSizes[1];
            int[,] basicMatrix = BasicMatrixData(rows, columns);

            int maxValueSubMatrix = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < basicMatrix.GetLength(0) - 1; row++)
            {
                int subMatrixSum = 0;

                for (int col = 0; col < basicMatrix.GetLength(1) - 1; col++)
                {
                    subMatrixSum = basicMatrix[row, col] + basicMatrix[row, col + 1]
                        + basicMatrix[row + 1, col] + basicMatrix[row + 1, col + 1];

                    if (subMatrixSum > maxValueSubMatrix)
                    {
                        maxValueSubMatrix = subMatrixSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine(basicMatrix[maxRow, maxCol] + " " + basicMatrix[maxRow, maxCol + 1]);
            Console.WriteLine(basicMatrix[maxRow + 1, maxCol] + " " + basicMatrix[maxRow + 1, maxCol + 1]);
            Console.WriteLine(maxValueSubMatrix);
        }

        static int[,] BasicMatrixData(int rows, int columns)
        {
            int[,] basicMatrix = new int[rows, columns];

            for (int row = 0; row < basicMatrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < basicMatrix.GetLength(1); col++)
                {
                    basicMatrix[row, col] = rowData[col];
                }
            }

            return basicMatrix;
        }
    }
}
