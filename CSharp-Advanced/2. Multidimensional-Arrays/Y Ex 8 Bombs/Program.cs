using System;
using System.Linq;

namespace Y_Ex_8_Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            FillMatrix(matrix);

            string[] allBombs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < allBombs.Length; i++)
            {
                string[] currentBomb = allBombs[i].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int currentBombRow= int.Parse(currentBomb[0]);
                int currentBombCol = int.Parse(currentBomb[1]);

                if(currentBombRow >= 0 && currentBombRow < matrix.GetLength(0) 
                    && currentBombCol >= 0 && currentBombCol < matrix.GetLength(1))
                    //The bomb coordinates will always be in the matrix.
                {
                    int currentBombValue = matrix[currentBombRow, currentBombCol];
                    if(currentBombValue > 0)
                    {
                        if (currentBombRow - 1 >= 0)
                        {
                            matrix[currentBombRow - 1, currentBombCol] =
                                ReducingCurrentCellValue(matrix[currentBombRow - 1, currentBombCol], currentBombValue);
                            if (currentBombCol - 1 >= 0)
                            {
                                matrix[currentBombRow - 1, currentBombCol - 1] =
                                    ReducingCurrentCellValue(matrix[currentBombRow - 1, currentBombCol - 1], currentBombValue);
                            }
                        }
                        if (currentBombCol + 1 < matrix.GetLength(1))
                        {
                            matrix[currentBombRow, currentBombCol + 1] =
                                    ReducingCurrentCellValue(matrix[currentBombRow, currentBombCol + 1], currentBombValue);
                            if (currentBombRow - 1 >= 0)
                            {
                                matrix[currentBombRow - 1, currentBombCol + 1] =
                                    ReducingCurrentCellValue(matrix[currentBombRow - 1, currentBombCol + 1], currentBombValue);
                            }
                        }
                        if (currentBombCol - 1 >= 0)
                        {
                            matrix[currentBombRow, currentBombCol - 1] =
                                ReducingCurrentCellValue(matrix[currentBombRow, currentBombCol - 1], currentBombValue);
                            if (currentBombRow + 1 < matrix.GetLength(0))
                            {
                                matrix[currentBombRow + 1, currentBombCol - 1] =
                                    ReducingCurrentCellValue(matrix[currentBombRow + 1, currentBombCol - 1], currentBombValue);
                            }
                        }
                        if (currentBombRow + 1 < matrix.GetLength(0))
                        {
                            matrix[currentBombRow + 1, currentBombCol] =
                                 ReducingCurrentCellValue(matrix[currentBombRow + 1, currentBombCol], currentBombValue);
                            if (currentBombCol + 1 < matrix.GetLength(1))
                            {
                                matrix[currentBombRow + 1, currentBombCol + 1] =
                                    ReducingCurrentCellValue(matrix[currentBombRow + 1, currentBombCol + 1], currentBombValue);
                            }
                        }

                        matrix[currentBombRow, currentBombCol] = 0;
                    }
                }
            }

            string[] aliveCellsCountAndSum = AliveCellsCountAndSum(matrix).Split(" ");
            int aliveCellsCount = int.Parse(aliveCellsCountAndSum[0]);
            int aliveCellsSum = int.Parse(aliveCellsCountAndSum[1]);
            Console.WriteLine($"Alive cells: {aliveCellsCount}");
            Console.WriteLine($"Sum: {aliveCellsSum}");
            PrintMatrix(matrix);
        }

        static string AliveCellsCountAndSum(int[,] matrix)
        {
            int count = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col] > 0)
                    {
                        count++;
                        sum += matrix[row, col];
                    }
                }
            }

            string countAndSum = count.ToString() +" " + sum.ToString();
            return countAndSum;
        }


        static int ReducingCurrentCellValue(int currentCellValue, int currentBombValue)
        {
            if (currentCellValue > 0)
            {
                currentCellValue -= currentBombValue;
            }

            return currentCellValue;
        }
        static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine().Split(" ");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(currentRow[col]);
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
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
