using System;
using System.Collections.Generic;

namespace _2.AreasInMatrixDfs
{
    class Program
    {
        //The solution is made with graphs and DFS for graph, but the solution can be made with recursion and backtracking too!!!
        private static char[,] graph;
        private static bool[,] visited;
        private static IDictionary<char, int> areas;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            graph = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();

            for (int r = 0; r < rows; r++)
            {
                var rowElements = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    graph[r, c] = rowElements[c];
                }
            }

            var areasCount = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if(visited[r, c])
                    {
                        continue;
                    }

                    var nodeValue = graph[r, c];
                    DFS(r, c, nodeValue);

                    areasCount += 1;

                    if (areas.ContainsKey(nodeValue))
                    {
                        areas[nodeValue] += 1;
                    }
                    else
                    {
                        areas[nodeValue] = 1;
                    }
                }
            }

            Console.WriteLine($"Areas: {areasCount}");
            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col, char parentNode)
        {
            //If we are out of the matrix
            if (row < 0 || row >= graph.GetLength(0) || col < 0 || col >= graph.GetLength(1))
            {
                return;
            }

            //If the cell was visited
            if (visited[row, col])
            {
                return;
            }

            //If the cell is with different value
            if (graph[row, col] != parentNode)
            {
                return;
            }

            visited[row, col] = true;

            DFS(row, col - 1, parentNode);
            DFS(row, col + 1, parentNode);
            DFS(row - 1, col, parentNode);
            DFS(row + 1, col, parentNode);
        }
    }
}
