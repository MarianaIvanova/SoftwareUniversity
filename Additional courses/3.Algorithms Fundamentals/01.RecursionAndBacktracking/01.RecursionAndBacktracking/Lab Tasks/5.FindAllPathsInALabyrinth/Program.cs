using System;
using System.Collections.Generic;

namespace _5.FindAllPathsInALabyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var lab = new char[rows, cols];

            //read the matrix:
            for (int r = 0; r < rows; r++)
            {
                var rowElements = Console.ReadLine();

                for (int c = 0; c < rowElements.Length; c++)
                {
                    lab[r, c] = rowElements[c];
                }
            }

            var directions = new List<string>();
            string direction = string.Empty;

            FindAllPaths(lab, 0, 0, directions, direction);
        }

        private static void FindAllPaths(char[,] lab, int row, int col, List<string> directions, string direction)
        {
            //directions - посоките, в които сме вървяли
            //direction - посоката на текущото извикване

            //base for validation the matrix
             if (row < 0 || row >= lab.GetLength(0) || col < 0 || col >= lab.GetLength(1))
            {
                return;
            }

            //base for validation a wall or visited cell
            if(lab[row,col] == '*' || lab[row, col] == 'v')
            {
                return;
            }

            //Add the direction in the path before going to the end, if it is end, if we write it after the check for end, we will lose the movement for the end in the list directions!
            directions.Add(direction);

            //base for end, print the path and return one step back
            if (lab[row,col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty,directions));
                directions.RemoveAt(directions.Count - 1); //Премахваме последния ход, който сме направили!
                return;
            }

            //Mark the visited cell, which we shouldn't go back again:
            lab[row, col] = 'v';

            FindAllPaths(lab, row - 1, col, directions, "U");//Is UP
            FindAllPaths(lab, row + 1, col, directions, "D");//Is DOWN
            FindAllPaths(lab, row, col - 1, directions, "L");//Is LEFT
            FindAllPaths(lab, row, col + 1, directions, "R");//Is RIGHT

            //Unmark the last cell, which we can use for a new path
            lab[row, col] = '-';
            //Remove the last direction in the path
            directions.RemoveAt(directions.Count - 1);
        }
    }
}
