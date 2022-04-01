using System;
using System.Collections.Generic;

namespace _6._8QueensPuzzle
{
    class Program
    {
        // COMPEXITY = N!
        //We use the following having in mind that the position of the queen is at row and col, then:
        //AttackedRows (row),
        //AttackedCols (col),
        //AttackedLeftDiagonals (row - col),
        //AttackedRightDiagonals (row + col).
        //If some of the number of a queen is equal to a number of the other queen,
        //they attack eack other!
        //For each queen we add we will add in the sets below its row, col
        //and both diagonals numbers:
        private static HashSet<int> AttackedRows = new HashSet<int>();
        private static HashSet<int> AttackedCols = new HashSet<int>();
        private static HashSet<int> AttackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> AttackedRightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            //All cells in the board are false in the beginning as a default
            var board = new bool[8, 8];

            PutQueen(board, 0);
        }

        private static void PutQueen(bool[,] board, int row)
        {
            //Base
            if(row >= board.GetLength(0))
            {
                //Print when you reach the end of the board:
                PrintBoard(board);
                return;
            }

            //За всяка една колона на този ред, ще се опитаме да поставим кралица:
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if(CanPlaceQueen(row,col))//If I can place a queen in this cell,
                {
                    //Add the attacked cells for this queen:
                    AttackedRows.Add(row);
                    AttackedCols.Add(col);
                    AttackedLeftDiagonals.Add(row - col);
                    AttackedRightDiagonals.Add(row + col);
                    //Placing the queen changes the cell from false to true:
                    board[row, col] = true;

                    // then will try to generate a solution for the next rows
                    PutQueen(board, row + 1);

                    //FROM here we have BACKTRACKING:
                    //Return the queen changes the cell from true to false:
                    board[row, col] = false;
                    //Remove the attacked cells for this queen:
                    AttackedRows.Remove(row);
                    AttackedCols.Remove(col);
                    AttackedLeftDiagonals.Remove(row - col);
                    AttackedRightDiagonals.Remove(row + col);
                }
            }
        }
        private static bool CanPlaceQueen(int row, int col)
        {
            return !AttackedRows.Contains(row) 
                    && !AttackedCols.Contains(col)
                    && !AttackedLeftDiagonals.Contains(row - col)
                    && !AttackedRightDiagonals.Contains(row + col);
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if(board[row,col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
