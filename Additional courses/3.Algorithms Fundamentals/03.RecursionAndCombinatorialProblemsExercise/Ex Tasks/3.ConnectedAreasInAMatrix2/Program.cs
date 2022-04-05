using System;
using System.Linq;
using System.Collections.Generic;

namespace _3.ConnectedAreasInAMatrix2
{
    public class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }
    class Program
    {
        private const char VisitedSymbol = 'v';
        private static char[,] matrix;
        //private static int size = 0; //We can use it in the methods
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var colElements = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = colElements[c];
                }
            }

            var areas = new List<Area>();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    var area = new Area {Row = r, Col = c };

                    ExploreArea(r, c, area);

                    if (area.Size != 0)
                    {
                        areas.Add(area);
                    }
                }
            }

            var sortedAreas = areas
                //.Where(a => a.Size > 0)
                .OrderByDescending(x => x.Size)
                .ThenBy(x => x.Row)
                .ThenBy(x => x.Col)
                .ToList();

            Console.WriteLine($"Total areas found: {sortedAreas.Count}");

            //int count = 1;

            //foreach (var area in sortedAreas)
            //{
            //    Console.WriteLine($"Area #{count} at ({area.Row}, {area.Col}), size: {area.Size}");
            //    count++;
            //}

            for (int i = 0; i < sortedAreas.Count; i++)
            {
                var area = sortedAreas[i];
                Console.WriteLine($"Area #{i + 1} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static void ExploreArea(int row, int col, Area area)
        {
            if(IsOutside(row, col) || IsWall(row, col) || IsVisited(row, col))//IsWall(row, col) should be alway after IsOutside(row, col) to be inside the matrix and IsVisited after them
            {
                return;
            }

            //Count size
            area.Size += 1;
            //Mark the cell as visited:
            matrix[row, col] = VisitedSymbol;

            ExploreArea(row - 1, col, area);
            ExploreArea(row + 1, col, area);
            ExploreArea(row, col - 1, area);
            ExploreArea(row, col + 1, area);
        }

        private static bool IsOutside(int row, int col)
        {
             if(row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        private static bool IsWall(int row, int col)
        {
            if (matrix[row, col] == '*')
            {
                return true;
            }

            return false;
        }
        private static bool IsVisited(int row, int col)
        {
            if (matrix[row, col] == VisitedSymbol)
            {
                return true;
            }

            return false;
        }
    }
}

//3.Connected Areas in a Matrix
//Let’s define a connected area in a matrix as an area of cells in which there is a path between every two cells. 
//Write a program to find all connected areas in a matrix. 
//Input
//•	On the first line, you will get the number of rows.
//•	On the second line, you will get the number of columns.
//•	The rest of the input will be the actual matrix.
//Output
//•	Print on the console the total number of areas found.
//•	On a separate line for each area print its starting coordinates and size. 
//•	Order the areas by size (in descending order) so that the largest area is printed first.
//o	If several areas have the same size, order them by their position, first by the row, then by the column of the top-left corner.
//o	If there are two connected areas of the same size, the one which is above and/or to the left of the other will be printed first.

////Examples
////Example Layout	
//4
//9
//---*---*-
//---*---*-
//---*---*-
//----*-*--	
////Output
//Total areas found: 3
//Area #1 at (0, 0), size: 13
//Area #2 at (0, 4), size: 10
//Area #3 at (0, 8), size: 5

////Example Layout	
//5
//10
//*--*---*--
//*--*---*--
//*--*****--
//*--*---*--
//*--*---*--	
////Output
//Total areas found: 4
//Area #1 at (0, 1), size: 10
//Area #2 at (0, 8), size: 10
//Area #3 at (0, 4), size: 6
//Area #4 at (3, 4), size: 6
//Hints
//•	Create a method to find the first traversable cell which hasn’t been visited. This would be the top-left corner of a connected area. If there is no such cell, this means all areas have been found.
//•	You can create a class to hold info about a connected area (its position and size). Additionally, you can implement Comparable and store all areas found in a TreeSet.

