using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.ConnectedComponentsBFSTeacher
{
    class Program
    {
        //Only for educational purpose, not in judge!                                                                        
        //Using array of lists or AdjacencyList
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            //Number of lines:
            var n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited = new bool[n];

            for (int node = 0; node < n; node++)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var children = line.Split().Select(int.Parse).ToList();
                    graph[node] = children;
                }
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                var component = new List<int>();
                BFS(node, component);

                Console.WriteLine($"Connected component: {string.Join(" ", component)}");
            }
        }

        private static void BFS(int startNode, List<int> component)
        {
            //Have done UP
            //if (visited[node])
            //{
            //    continue;
            //}

            var queue = new Queue<int>();

            queue.Enqueue(startNode);
            visited[startNode] = true;

            while(queue.Count > 0)
            {
                var node = queue.Dequeue();

                component.Add(node);

                foreach (var child in graph[node])
                {
                    if(!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }
    }
}
//For
//9
//3 6
//3 4 5 6
//8
//0 1 5
//1 6
//1 3
//0 1 4

//2
//Result
//Connected component: 0 3 6 1 5 4
//Connected component: 2 8
//Connected component: 7


//The first part of this lab aims to implement the DFS algorithm (Depth-First-Search) to traverse a graph and find its connected components (nodes connected either directly, or through other nodes). The graph nodes are numbered from 0 to n-1. The graph comes from the console in the following format:
//•	First line: number of lines n
//•	Next n lines: list of child nodes for the nodes 0 … n-1 (separated by a space)
//Print the connected components in the same format as in the examples below.

