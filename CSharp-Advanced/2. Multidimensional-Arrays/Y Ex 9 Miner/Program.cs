using System;

namespace Y_Ex_9_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] allCommands = Console.ReadLine().Split(" ");

            char[,] matrix = new char[n, n];
            FillMatrix(matrix);

            string[] startingRowCol = FindingStartingPosition(matrix).Split(" ");
            int currentRow = int.Parse(startingRowCol[0]);
            int currentCol = int.Parse(startingRowCol[1]);
            int coalCount = 0;
            int allCoals = CountAllCoals(matrix);

            for (int i = 0; i < allCommands.Length; i++)
            {
                string currentCommand = allCommands[i];
                switch(currentCommand)
                {
                    case "up":
                        if(currentRow >= 1)
                        {
                            currentRow--;
                        }
                        break;
                    case "down":
                        if (currentRow < matrix.GetLength(0) - 1)
                        {
                            currentRow++;
                        }
                        break;
                    case "left":
                        if (currentCol >= 1)
                        {
                            currentCol--;
                        }
                        break;
                    case "right":
                        if (currentCol < matrix.GetLength(1) - 1)
                        {
                            currentCol++;
                        }
                        break;
                }

                switch(matrix[currentRow, currentCol])
                {
                    case '*':
                        break;
                    case 'c':
                        {
                            matrix[currentRow, currentCol] = '*';
                            coalCount++;
                            if(coalCount == allCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                Environment.Exit(0);
                            }
                        }
                        break;
                    case 'e':
                        {
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            Environment.Exit(0);
                        }
                        break;
                }
            }

            int remainingCoals = allCoals - coalCount;
            Console.WriteLine($"{remainingCoals} coals left. ({currentRow}, {currentCol})");
        }
        static int CountAllCoals(char[,] matrix)
        {
            int allCoals = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        allCoals++;
                    }
                }
            }

            return allCoals;
        }
        static string FindingStartingPosition(char[,] matrix)
        {
            string startingRowCol = string.Empty;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col] == 's')
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
                string[] currentRow = Console.ReadLine().Split(" ");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = char.Parse(currentRow[col]);
                }
            }
        }
    }
}
