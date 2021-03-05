using System;
using System.Linq;

namespace Lab_1_Sum_Matrix_Elements_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];
            //int sum = 0;

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowsData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = rowsData[column];
                    //sum += rowsData[column];
                }
            }
            //PrintMatrix(matrix); // Print just for check and no need to write it every time - just copy the method!!!
            Console.WriteLine(rows);
            Console.WriteLine(columns);
            //Console.WriteLine(sum);
            Console.WriteLine(SumMatrix(matrix));//Calculation sum in method
        }

        static int SumMatrix(int[,] matrix)
        {
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    sum += matrix[row,column];
                }
            }
            return sum;
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row, column] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
