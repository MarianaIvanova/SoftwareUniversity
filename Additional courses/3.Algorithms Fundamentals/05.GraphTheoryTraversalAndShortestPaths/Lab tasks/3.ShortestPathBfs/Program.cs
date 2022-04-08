using System;
using System.Linq;
using System.Collections.Generic;

namespace _3.ShortestPathBfs
{
    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parent;

        static void Main(string[] args)
        {
            //Number of nodes 
            var n = int.Parse(Console.ReadLine());
            //Number of edges
            var e = int.Parse(Console.ReadLine());

            //Initialise the graph
            graph = new List<int>[n + 1];//?????
            visited = new bool[graph.Length];
            parent = new int[graph.Length];

            //int[] is full with 0's on initialization, so we fill it with - 1
            Array.Fill(parent, -1);

            //Initialise all the lists in the graph
            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var edge = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edge[0];
                var secondNode = edge[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }

            //From where to where we need to find the shortest path
            var start = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            Console.WriteLine();

            BFS(start, destination);
        }

        private static void BFS(int startNode, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited[startNode] = true;

            while(queue.Count > 0)
            {
                var node = queue.Dequeue(); 

                if (node == destination)
                {
                    var path = GetPat(destination);
                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(" ", path));
                    break;
                }

                foreach (var child in graph[node])
                {
                    if(!visited[child])
                    {
                        parent[child] = node;//this the parent of the child
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }

        private static Stack<int> GetPat(int destination)
        {
            var path = new Stack<int>();

            var node = destination;

            while(node != -1)
            {
                path.Push(node);
                node = parent[node];
            }

            return path;
        }
    }
}

//You will be given a graph from the console your task is to find the shortest path and print it back on the console. The first line will be the number of Nodes - N the second one the number of Edges - E, then on each E line the edge in form {destination} – { source}. On the last two lines, you will read the start node and the end node.
//Print on the first line the length of the shortest path and the second the path itself, see the examples below.
//Input
//8
//10
//1 2
//1 4
//2 3
//4 5
//5 8
//5 6
//5 7
//5 8
//6 7
//7 8
//1
//7

//Output
//Shortest path length is: 3
//1 4 5 7

