using System;
using System.Linq;

namespace Y_Ex_7_Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());//dimensionSizes
            string[,] matrix = new string[n, n];

            FillMatrix(matrix);

            string[,] matrixAttacking = new string[n, n];

            FillMatrixAttacking(matrix, matrixAttacking);
            KnightsAttacking(matrix, matrixAttacking);

            bool indexCheck = false;
            int knightsRemoved = 0;

            while (!indexCheck)
            {
                int rowMax = 0;
                int colMax = 0;
                int maxValueMatrix = 0;
                for (int row = 0; row < matrixAttacking.GetLength(0); row++)
                {
                    for (int col = 0; col < matrixAttacking.GetLength(1); col++)
                    {
                        if (int.Parse(matrixAttacking[row, col]) > maxValueMatrix)
                        {
                            maxValueMatrix = int.Parse(matrixAttacking[row, col]);
                            rowMax = row;
                            colMax = col;
                        }
                    }
                }

                if (int.Parse(matrixAttacking[rowMax, colMax]) > 0)
                {
                    matrix[rowMax, colMax] = "0";
                    matrixAttacking[rowMax, colMax] = "0";
                    knightsRemoved++;
                }
                else
                {
                    indexCheck = true;
                }

                KnightsAttacking(matrix, matrixAttacking);
            }

            Console.WriteLine(knightsRemoved);
            //PrintMatrix(matrix);
            //PrintMatrix(matrixAttacking);
        }

        static void KnightsAttacking(string[,] matrix, string[,] matrixAttacking)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col] == "K")
                    {
                        int index = 0;
                        if(row - 2 >= 0 && col - 1 >= 0)
                        {
                            if (matrix[row - 2, col - 1] == "K")
                            {
                                index++;
                            }
                        }
                        if(row - 2 >= 0 && col + 1 < matrix.GetLength(1))
                        {
                            if (matrix[row - 2, col + 1] == "K")
                            {
                                index++;
                            }
                        }
                        if (row - 1 >= 0 && col - 2 >= 0)
                        {
                            if (matrix[row - 1, col - 2] == "K")
                            {
                                index++;
                            }
                        }
                        if (row - 1 >= 0 && col + 2 < matrix.GetLength(1))
                        {
                            if (matrix[row - 1, col + 2] == "K")
                            {
                                index++;
                            }
                        }
                        if (row + 1 < matrix.GetLength(0) && col - 2 >= 0 )
                        {
                            if (matrix[row + 1, col - 2] == "K")
                            {
                                index++;
                            }
                        }
                        if (row + 1 < matrix.GetLength(0) && col + 2 < matrix.GetLength(1))
                        {
                            if (matrix[row + 1, col + 2] == "K")
                            {
                                index++;
                            }
                        }
                        if (row + 2 < matrix.GetLength(0) && col - 1 >= 0)
                        {
                            if (matrix[row + 2, col - 1] == "K")
                            {
                                index++;
                            }
                        }
                        if (row + 2 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1))
                        {
                            if (matrix[row + 2, col + 1] == "K")
                            {
                                index++;
                            }
                        }

                        matrixAttacking[row, col] = index.ToString();
                    }
                }
            }
        }
        static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col].ToString();
                }
            }
        }
        static void FillMatrixAttacking(string[,] matrix, string[,] matrixAttacking)
        {
            for (int row = 0; row < matrixAttacking.GetLength(0); row++)
            {
                for (int col = 0; col < matrixAttacking.GetLength(1); col++)
                {
                    matrixAttacking[row, col] = matrix[row, col];
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + ", ");
                }

                Console.WriteLine();
            }
        }
    }
}
