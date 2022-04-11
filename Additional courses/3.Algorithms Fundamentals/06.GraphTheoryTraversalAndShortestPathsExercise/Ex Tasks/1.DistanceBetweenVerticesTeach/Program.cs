using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.DistanceBetweenVerticesTeach
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;//Use dictionary - as we have no node from 1 to 1

        static void Main(string[] args)
        {
            //Number of nodes 
            var n = int.Parse(Console.ReadLine());
            //Number of pairs to find the shortest path
            var p = int.Parse(Console.ReadLine());

            //Initialise the graph
            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var node = int.Parse(line[0]);

                if (line.Length == 1)
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var children = line[1].Split(" ").Select(int.Parse).ToList();
                    graph[node] = children;
                }
            }

            for (int i = 0; i < p; i++)
            {
                var line = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                //From where to where we need to find the shortest path
                var start = line[0];
                var destination = line[1];

                var steps = BFS(start, destination);
                Console.WriteLine($"{{{start}, {destination}}} -> {steps}");
            }
        }

        private static int BFS(int startNode, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);

            var visited = new HashSet<int> {startNode};
            //var visited = new HashSet<int>();
            //visited.Add(startNode);

            var parent = new Dictionary<int, int> { { startNode, -1 } };
            //var parent = new Dictionary<int, int>();
            //parent.Add(startNode, -1);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    var steps = GetSteps(destination, parent);

                    return steps;
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                    parent.Add(child, node);
                }
            }

            return -1;
        }

        private static int GetSteps(int destination, Dictionary<int, int> parent)
        {
            var steps = 0;

            var node = destination;

            while (node != -1)
            {
                node = parent[node];
                steps += 1;          
            }

            return steps - 1;
        }
    }
}
