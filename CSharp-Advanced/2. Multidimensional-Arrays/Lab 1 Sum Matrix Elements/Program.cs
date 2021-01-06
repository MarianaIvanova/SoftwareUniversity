using System;
using System.Linq;

namespace Lab_1_Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];
            int sum = 0;

            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                int[] rowsData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rowsData[j];
                    sum += rowsData[j];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(columns);
            Console.WriteLine(sum);
        }
    }
}
