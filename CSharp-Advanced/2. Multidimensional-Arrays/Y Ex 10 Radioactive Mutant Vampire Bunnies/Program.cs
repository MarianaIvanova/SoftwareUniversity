using System;
using System.Linq;

namespace Y_Ex_10_Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] indexes = Console.ReadLine().Split(" ");
            int n = int.Parse(indexes[0]);
            int m = int.Parse(indexes[1]);
            char[,] matrix = new char[n, m];

            FillMatrix(matrix);

            string[] startingRowCol = FindingStartingPosition(matrix).Split(" ");
            int currentRow = int.Parse(startingRowCol[0]);
            int currentCol = int.Parse(startingRowCol[1]);
            bool isAlive = true;
            bool escaped = false;

            string allCommands = Console.ReadLine();
            for (int i = 0; i < allCommands.Length; i++)
            {
                char[,] matrixNewTmp = new char[n, m];
                FillTmpMatrix(matrixNewTmp);
                char currentCommand = allCommands[i];
                //matrix[currentRow, currentCol] = '.';
                switch (currentCommand)
                {
                    case 'U':
                        if (currentRow >= 1)
                        {
                            currentRow--;
                        }
                        else
                        {
                            escaped = true;
                        }
                        break;
                    case 'D':
                        if (currentRow < matrix.GetLength(0) - 1)
                        {
                            currentRow++;
                        }
                        else
                        {
                            escaped = true;
                        }
                        break;
                    case 'L':
                        if (currentCol >= 1)
                        {
                            currentCol--;
                        }
                        else
                        {
                            escaped = true;
                        }
                        break;
                    case 'R':
                        if (currentCol < matrix.GetLength(1) - 1)
                        {
                            currentCol++;
                        }
                        else
                        {
                            escaped = true;
                        }
                        break;
                }
                //matrix[currentRow, currentCol] = 'P';

                matrix = BunnySpreading(matrix, matrixNewTmp);

                switch (matrix[currentRow, currentCol])
                {
                    case '.':
                        break;
                    case 'B':
                        {
                            isAlive = false;
                        }
                        break;
                }

                if (escaped)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {currentRow} {currentCol}");
                    Environment.Exit(0);
                }
                if (!isAlive)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {currentRow} {currentCol}");
                    Environment.Exit(0);
                }
            }
        }
        static char[,] BunnySpreading(char[,] matrix, char[,] matrixNewTmp)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col] == 'B')
                    {
                        matrixNewTmp[row, col] = 'B';
                        if (row - 1 >= 0)
                        {
                            matrixNewTmp[row - 1, col] = 'B';
                        }
                        if (col - 1 >= 0)
                        {
                            matrixNewTmp[row, col - 1] = 'B';
                        }
                        if (row + 1 < matrix.GetLength(0))
                        {
                            matrixNewTmp[row + 1, col] = 'B';
                        }
                        if (col + 1 < matrix.GetLength(1))
                        {
                            matrixNewTmp[row, col + 1] = 'B';
                        }
                    }
                }
            }

            return matrixNewTmp;
        }
        static string FindingStartingPosition(char[,] matrix)
        {
            string startingRowCol = string.Empty;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        startingRowCol = row + " " + col;
                        break;
                    }
                }
            }

            return startingRowCol;
        }
        static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        static void FillTmpMatrix(char[,] matrixNewTmp)
        {
            for (int row = 0; row < matrixNewTmp.GetLength(0); row++)
            {
                for (int col = 0; col < matrixNewTmp.GetLength(1); col++)
                {
                    matrixNewTmp[row, col] = '.';
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
