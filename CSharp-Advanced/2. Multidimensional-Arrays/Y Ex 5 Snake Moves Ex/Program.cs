using System;
using System.Linq;

namespace Y_Ex_5_Snake_Moves_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensionSizes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = dimensionSizes[0];
            int cols = dimensionSizes[1];
            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();

            FillMatrix(matrix, snake);
            PrintMatrix(matrix);
        }

        static void FillMatrix(char[,] matrix, string snake)
        {
            int indexCurrentLetter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row == 0 || row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[indexCurrentLetter];
                        indexCurrentLetter++;
                        if(indexCurrentLetter == snake.Length)
                        {
                            indexCurrentLetter = 0;
                        }
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[indexCurrentLetter];
                        indexCurrentLetter++;
                        if (indexCurrentLetter == snake.Length)
                        {
                            indexCurrentLetter = 0;
                        }
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
