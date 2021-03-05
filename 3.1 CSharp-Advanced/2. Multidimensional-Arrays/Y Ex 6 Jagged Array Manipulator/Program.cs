using System;
using System.Linq;

namespace Y_Ex_6_Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            decimal[][] matrix = new decimal[rows][];//We devide by 2 - so it's good to be decimal - not to loose data!

            FillMatrix(matrix);
            AnalysingMatrix(matrix);

            string commandInfo = Console.ReadLine();

            CommandMatrix(matrix, commandInfo);
            PrintMatrix(matrix);
        }

        static void CommandMatrix(decimal[][] matrix, string commandInfo)
        {
            while(commandInfo != "End")
            {
                string[] commandSplit = commandInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if(commandSplit.Length == 4)
                {
                    string commandName = commandSplit[0];
                    int row = int.Parse(commandSplit[1]);
                    int column = int.Parse(commandSplit[2]);
                    int value = int.Parse(commandSplit[3]);

                    switch (commandName)
                    {
                        case "Add":
                            if (row >= 0 && row < matrix.Length && column >= 0 && column < matrix[row].Length)
                            {
                                matrix[row][column] += value;
                            }
                            break;
                        case "Subtract":
                            if (row >= 0 && row < matrix.Length && column >= 0 && column < matrix[row].Length)
                            {
                                matrix[row][column] -= value;
                            }
                            break;
                    }
                }
                commandInfo = Console.ReadLine();
            }
        }
        static void AnalysingMatrix(decimal[][] matrix)
        {
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if(matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = matrix[row][col] * 2;
                        matrix[row + 1][col] = matrix[row + 1][col] * 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = matrix[row][col] / 2;
                    }
                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] = matrix[row + 1][col] / 2;
                    }
                }
            }
        }
        static void FillMatrix(decimal[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine().
                    Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[row] = new decimal[currentRow.Length];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row][col] = currentRow[col];
                }
            }
        }

        private static void PrintMatrix(decimal[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
