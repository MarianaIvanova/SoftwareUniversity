using System;

//Victor Dakov's code:
namespace _6._8QueensPuzzle2
{
    class Program
    {
        // COMPEXITY = N!
        //Много бавен алгоритъм. Brute-Force Algorithm. Много изчисления, бездънни...
        static void Main(string[] args)
        {
            //int queens = int.Parse(Console.ReadLine());//Брой царици х. За 4 царици

            //int[,] matrix = new int[queens, queens];//Тогава дъската ще е х на х и на нея слагаме цариците. При създаването на матрицата всички стойности в нея са 0.
            int[,] matrix = new int[8, 8];
            GetQueens(matrix, 0);//Матрицата и текущият ред
        }

        static void PrintQueens(int[,] queens)
        {
            for (int row = 0; row < queens.GetLength(0); row++)
            {
                for (int col = 0; col < queens.GetLength(1); col++)
                {
                    if (queens[row, col] == 1)
                    {
                        Console.Write("*" + " ");
                    }

                    if (queens[row, col] == 0)
                    {
                        Console.Write("-" + " ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            //- * - -
            //- - - *
            //* - - -
            //- - * -


            //- - * -
            //* - - -
            //- - - *
            //- * - -


            //2 for 4 queens
        }
        private static int GetQueens(int[,] queens, int row)
        {
            //Algorithm
            if (row == queens.GetLength(0))//Когато стигнем до последния ред на матрицата 
            {
                PrintQueens(queens);
                return 1;
            }

            int foundQueens = 0;

            for (int col = 0; col < queens.GetLength(1); col++)//До броя на колоните, макар че е квадратна матрица, но може да го направим и за не квадратна.
            {
                queens[row, col] = 1; //Където имаме царица, слагаме 1
                if (IsSafe(queens, row, col))
                {
                    foundQueens += GetQueens(queens, row + 1);
                }
                queens[row, col] = 0; //Това не е като пътищата, а се ПРЕИЗПОЛЗВАТ цариците!!! Това е много важно за референтните типове. Че когато ги използваме рекурсирвно, винаги трябва да си зачистваме.
            }

            return foundQueens;
        }

        private static bool IsSafe(int[,] queens, int row, int col)
        {
            for (int i = 1; i < queens.GetLength(0); i++)//Важи само за квадратна матрица
            {
                if (row - i >= 0 && queens[row - i, col] == 1)//За да не излизаме от матрицата и ако има царица нагоре по редовете, трябва да излезем
                {
                    return false;
                }

                if (col - i >= 0 && queens[row, col - i] == 1)//За да не излизаме от матрицата и ако има царица наляво по колоните, трябва да излезем
                {
                    return false;
                }

                if (row + i < queens.GetLength(0) && queens[row + i, col] == 1)//За да не излизаме от матрицата и ако има царица надолу по редовете, трябва да излезем
                {
                    return false;
                }

                if (col + i < queens.GetLength(0) && queens[row, col + i] == 1)//За да не излизаме от матрицата и ако има царица надясно по колоните, трябва да излезем
                {
                    return false;
                }

                //Диагоналите също
                if (col + i < queens.GetLength(0) &&
                    row + i < queens.GetLength(0) &&
                    queens[row + i, col + i] == 1)
                {
                    return false;
                }

                if (col - i >= 0 &&
                    row + i < queens.GetLength(0) &&
                    queens[row + i, col - i] == 1)
                {
                    return false;
                }

                if (col + i < queens.GetLength(0) &&
                    row - i >= 0 &&
                    queens[row - i, col + i] == 1)
                {
                    return false;
                }

                if (col - i >= 0 &&
                    row - i >= 0 &&
                    queens[row - i, col - i] == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
