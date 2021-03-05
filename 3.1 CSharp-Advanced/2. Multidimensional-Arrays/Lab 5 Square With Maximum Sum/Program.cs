using System;
using System.Linq;

namespace Lab_5_Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSizes[0];
            int columns = matrixSizes[1];
            int[,] basicMatrix = BasicMatrixData(rows, columns);
            SubMatrix2x2MaxSum(basicMatrix);
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

        static void SubMatrix2x2MaxSum(int[,] basicMatrix)
        {
            int maxValueSubMatrix = int.MinValue;
            int[,] subMatrixMax = new int[2, 2];

            for (int row = 0; row < basicMatrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < basicMatrix.GetLength(1) - 1; col++)
                {
                    int[,] subMatrix = new int[2, 2];
                    int subMatrixSum = 0;

                    subMatrix[0, 0] = basicMatrix[row, col];
                    subMatrix[0, 1] = basicMatrix[row, col + 1];
                    subMatrix[1, 0] = basicMatrix[row + 1, col];
                    subMatrix[1, 1] = basicMatrix[row + 1, col + 1];
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            subMatrixSum += subMatrix[i, j];
                        }
                    }

                    if (subMatrixSum > maxValueSubMatrix)   
                    {
                        subMatrixMax = subMatrix;
                        maxValueSubMatrix = subMatrixSum;

                    }
                }
            }

            PrintSubMatrix2x2MaxSum(subMatrixMax);
            Console.WriteLine(maxValueSubMatrix);
        }

        static void PrintSubMatrix2x2MaxSum(int[,] subMatrixMax)
        {
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(subMatrixMax[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
