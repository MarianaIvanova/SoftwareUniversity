using System;
using System.Linq;

namespace Lab_6_Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowNumbers = int.Parse(Console.ReadLine());
            int[][] matrix = JaggedMatrixData(rowNumbers);
            OperationsWithmatrix(matrix);
            PrintingJaggedMatrix(matrix);
            //PrintingJaggedMatrix2(matrix);
        }

        static void OperationsWithmatrix(int[][] matrix)
        {
            string input = Console.ReadLine();          

            while (input != "END")
            {
                string[] commandInfo = input.Split(" ").ToArray();
                string command = commandInfo[0];
                int row = int.Parse(commandInfo[1]);
                int col = int.Parse(commandInfo[2]);
                int value = int.Parse(commandInfo[3]);

                switch(command)
                {
                    case "Add":
                        if(row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
                        {
                            matrix[row][col] += value;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        break;
                    case "Subtract":
                        if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
                        {
                            matrix[row][col] -= value;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        break;
                }
                input = Console.ReadLine();
            }
        }

        static int[][] JaggedMatrixData(int rowNumbers)
        {
            int[][] matrix = new int[rowNumbers][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] rowData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                matrix[row] = new int[rowData.Length];

                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row][col] = rowData[col];
                }
            }

            return matrix;
        }

        static void PrintingJaggedMatrix(int[][] matrix)
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

        static void PrintingJaggedMatrix2(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
