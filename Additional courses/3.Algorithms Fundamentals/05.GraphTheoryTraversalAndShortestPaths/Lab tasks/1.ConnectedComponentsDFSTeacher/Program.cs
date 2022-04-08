using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.ConnectedComponentsDFSTeacher
{
    class Program
    {
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
                if(string.IsNullOrEmpty(line))
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
                if(visited[node])
                {
                    continue;
                }

                var component = new List<int>();
                DFS(node, component);

                Console.WriteLine($"Connected component: {string.Join(" ", component)}");

                //Mine - more complex, the uper one we don't call the DFS for already visited components!
                //if(component.Count > 0)
                //{
                //    Console.WriteLine($"Connected component: {string.Join(" ", component)}");
                //}
            }
        }

        private static void DFS(int node, List<int> component)
        {
            //Base
            if(visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, component);
            }

            component.Add(node);
        }
    }
}
//The first part of this lab aims to implement the DFS algorithm (Depth-First-Search) to traverse a graph and find its connected components (nodes connected either directly, or through other nodes). The graph nodes are numbered from 0 to n-1. The graph comes from the console in the following format:
//•	First line: number of lines n
//•	Next n lines: list of child nodes for the nodes 0 … n-1 (separated by a space)
//Print the connected components in the same format as in the examples below.

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
//Connected component: 6 4 5 1 3 0
//Connected component: 8 2
//Connected component: 7

