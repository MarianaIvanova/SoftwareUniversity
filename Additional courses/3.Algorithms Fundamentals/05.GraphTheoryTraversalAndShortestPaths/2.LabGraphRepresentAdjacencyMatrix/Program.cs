using System;

namespace _2.LabGraphRepresentAdjacencyMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] graph = new int[][] 
            {
               // 0  1  2  3  4  5  6
               new[] { 0, 0, 0, 1, 0, 0, 1 }, // node 0
               new[] { 0, 0, 1, 1, 1, 1, 1 }, // node 1
               new[] { 0, 1, 0, 0, 1, 1, 0 }, // node 2
               new[] { 1, 1, 0, 0, 0, 1, 0 }, // node 3
               new[] { 0, 1, 1, 0, 0, 0, 1 }, // node 4
               new[] { 0, 1, 1, 1, 0, 0, 0 }, // node 5
               new[] { 1, 1, 0, 0, 1, 0, 0 } // node 6
            };
            // Add an edge { 3 -> 6 }
            graph[3][6] = 1;
            // List the children of node #1
            int[] childNodes = graph[1];
        }
    }
}
