using System;
using System.Linq;
using System.Collections.Generic;

namespace _2.Rumors
{
    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parent;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());//number of people
            var e = int.Parse(Console.ReadLine());//number of connections

            graph = new List<int>[n];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var line = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                var parent = line[0] - 1;
                var child = line[1] - 1;

                if(!graph[parent].Contains(child))
                {
                    graph[parent].Add(child);
                }

                if (!graph[child].Contains(parent))
                {
                    graph[child].Add(parent);
                }

            }

            var x = int.Parse(Console.ReadLine());//person to start the rumor

            for (int i = 0; i < graph.Length; i++)
            {
                visited = new bool[graph.Length];
                parent = new int[graph.Length];
                //int[] is full with 0's on initialization, so we fill it with - 1
                Array.Fill(parent, -1);

                var start = x - 1;

                if(start == i)
                {
                    continue;
                }

                var destination = i;

                BFS(start, destination);
            }
        }
        private static void BFS(int startNode, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited[startNode] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    var path = GetPat(destination);
                    Console.WriteLine($"{startNode + 1} -> {destination + 1} ({path.Count - 1})");
                    break;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parent[child] = node;
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

            while (node != -1)
            {
                path.Push(node);
                node = parent[node];
            }

            return path;
        }
    }
}
