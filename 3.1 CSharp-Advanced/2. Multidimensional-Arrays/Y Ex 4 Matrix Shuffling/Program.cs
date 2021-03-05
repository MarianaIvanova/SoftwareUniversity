using System;
using System.Linq;

namespace Y_Ex_4_Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensionSizes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = dimensionSizes[0];
            int cols = dimensionSizes[1];
            string[,] matrix = new string[rows, cols];

            FillMatrix(matrix);
            //PrintMatrix(matrix);
            CommandsSwapElementsOfMatrix(matrix);
        }

        static void CommandsSwapElementsOfMatrix(string[,] matrix)
        {
            string input = Console.ReadLine();

            while(input != "END")
            {
                string[] commandInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if(commandInfo.Length == 5)
                {
                    string command = commandInfo[0];
                    int row1 = int.Parse(commandInfo[1]);
                    int col1 = int.Parse(commandInfo[2]);
                    int row2 = int.Parse(commandInfo[3]);
                    int col2 = int.Parse(commandInfo[4]);

                    if(command == "swap" && 
                        row1 >= 0 && row1 < matrix.GetLength(0) &&
                        row2 >= 0 && row2 < matrix.GetLength(0) &&
                        col1 >= 0 && col1 < matrix.GetLength(1) &&
                        col2 >= 0 && col2 < matrix.GetLength(1) )
                    {
                        string tmp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = tmp;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }
        static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)//matrix.GetLength(1) == currentRow.Length
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
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
