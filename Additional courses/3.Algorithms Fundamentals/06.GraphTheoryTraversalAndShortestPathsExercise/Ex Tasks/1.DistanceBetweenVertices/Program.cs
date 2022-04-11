using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.DistanceBetweenVertices
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;//Use dictionary - as we have no node from 1 to 1
        private static HashSet<int> visited;
        private static Dictionary<int, int> parent;

        static void Main(string[] args)
        {
            //Number of nodes 
            var n = int.Parse(Console.ReadLine());
            //Number of pairs to find the shortest path
            var p = int.Parse(Console.ReadLine());

            //Initialise the graph
            graph = new Dictionary<int, List<int>>();
            visited = new HashSet<int>();
            parent = new Dictionary<int, int>();
            var parentKeep = new Dictionary<int, int>();

            //Initialise all the lists in the graph
            for (int node = 0; node < graph.Count; node++)
            {
                graph[node] = new List<int>();
            }

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

                //Dictionary is empty on initialization, so we fill it with - 1
                parentKeep[node] = -1;
                parent[node] = -1;
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

                BFS(start, destination);

                visited = new HashSet<int>();
                parent = parentKeep;
            }
        }

        private static void BFS(int startNode, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    var path = GetPat(destination);
                    Console.WriteLine($"{{{startNode}, {destination}}} -> {path.Count - 1}");
                    break;
                }
                //NOT OK THIS PART!!!!!!!!!!!!!!!!!
                if(graph[node].Count == 0)
                {
                    Console.WriteLine($"{{{startNode}, {destination}}} -> -1");
                    break;
                }

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        parent[child] = node;//this the parent of the child
                        visited.Add(child);
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
