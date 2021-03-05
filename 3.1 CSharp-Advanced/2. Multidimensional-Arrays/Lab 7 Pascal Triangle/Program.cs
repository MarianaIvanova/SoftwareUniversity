using System;
using System.Linq;
using System.Numerics;

namespace Lab_7_Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger[][] matrixJaggedPascal = new BigInteger[n][];

            for (int row = 0; row < matrixJaggedPascal.Length; row++)
            {
                matrixJaggedPascal[row] = new BigInteger[row + 1];
                matrixJaggedPascal[row][0] = 1;

                for (int col = 1; col < matrixJaggedPascal[row].Length; col++)
                {
                    if (col < matrixJaggedPascal[row].Length - 1)
                    {
                        matrixJaggedPascal[row][col] = matrixJaggedPascal[row - 1][col - 1] 
                            + matrixJaggedPascal[row - 1][col];
                    }
                    else
                    {
                        matrixJaggedPascal[row][col] = matrixJaggedPascal[row - 1][col - 1] + 0;
                    }
                }
            }

            foreach (var row in matrixJaggedPascal)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
