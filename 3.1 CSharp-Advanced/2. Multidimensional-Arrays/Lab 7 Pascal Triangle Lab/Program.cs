using System;
using System.Linq;
using System.Numerics;

namespace Lab_7_Pascal_Triangle_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] matrixJaggedPascal = new long[n][];
            int cols = 1;

            for (int row = 0; row < matrixJaggedPascal.Length; row++)
            {
                matrixJaggedPascal[row] = new long[cols];
                matrixJaggedPascal[row][0] = 1;
                matrixJaggedPascal[row][matrixJaggedPascal[row].Length - 1] = 1;

                if(row > 1)
                {
                    for (int col = 1; col < matrixJaggedPascal[row].Length - 1; col++)
                    {
                        matrixJaggedPascal[row][col] = matrixJaggedPascal[row - 1][col - 1]
                            + matrixJaggedPascal[row - 1][col];
                    }
                }

                cols++;
            }

            foreach (var row in matrixJaggedPascal)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
