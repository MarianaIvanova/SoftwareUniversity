using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.ConnectedComponentsDFS
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;
        private static List<int> connectedComponents;
        static void Main(string[] args)
        {
            //Number of lines:
            var n = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();
            visited = new HashSet<int>();
            connectedComponents = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var children = Console.ReadLine();

                if (children == string.Empty)
                {
                    graph.Add(i, new List<int>());
                }
                else
                {
                    var childrenSplit = children.Split().Select(int.Parse).ToList();
                    graph.Add(i, childrenSplit);
                }
            }

            var allConnectedComponents = new Dictionary<int, List<int>>();
            var ind = 0;

            foreach (var node in graph.Keys)
            {
                DFS(node);
                if(connectedComponents.Count > 0)
                {
                    allConnectedComponents.Add(ind++, connectedComponents);
                    connectedComponents = new List<int>();
                }                         
            }

            foreach (var connectComponents in allConnectedComponents)
            {
                Console.WriteLine($"Connected component: {string.Join(" ", connectComponents.Value)}");
            }
        }

        private static void DFS(int node)//Recursive
        {
            //Base is when we reach visited node
            if (visited.Contains(node))
            {
                return;
            }

            //Mark the node to be visited
            visited.Add(node);

            //Go to all node's children
            foreach (var child in graph[node])
            {
                DFS(child);
            }

            connectedComponents.Add(node);
        }
    }
}
