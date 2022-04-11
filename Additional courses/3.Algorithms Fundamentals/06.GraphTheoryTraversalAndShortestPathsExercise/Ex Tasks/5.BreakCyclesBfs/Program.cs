using System;
using System.Linq;
using System.Collections.Generic;
//Hint
//•	Enumerate edges { source, destination } in alphabetical order.For each edge { source, destination}
//        check whether it closes a cycle.If yes - remove it. 
//  To check whether an edge { source, destination}
//        closes a cycle, temporarily remove the edge { source, destination }
//        and then try to find a path from source to destination using DFS or BFS.

namespace _5.BreakCyclesBfs
{
    public class Edge
    {
        public string First { get; set; }
        public string Second { get; set; }

        public override string ToString()
        {
            return $"{First} - {Second}";
        }
    }
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                var nodeAndChildren = line.Split(" -> ").ToArray();

                var node = nodeAndChildren[0];

                var children = nodeAndChildren[1].Split().ToList();

                graph[node] = children;

                foreach (var child in children)
                {
                    edges.Add(new Edge { First = node, Second = child });
                }

                edges = edges
                    .OrderBy(e => e.First)
                    .ThenBy(e => e.Second)
                    .ToList();
            }

            var reversedEdges = new HashSet<string>();
            var toRemoveEdges = new List<string>();

            //Разкачаме ребрата и в двете посоки
            foreach (var edge in edges)
            {
                //as we have overrided ToString() 
                //Така няма да проверяваме втората двойка - reverse - и няма да я печатаме!
                if (reversedEdges.Contains(edge.ToString()))
                {
                    continue;
                }

                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);   


                //Проверяваме дали имаме все още връзка между edge.First и edge.Second чрез друг път. Ако има такава връзка, го премахваме, ако няма - го оставяме, за да не разкачим на части графа.
                if(BFS(edge.First, edge.Second))
                {
                    toRemoveEdges.Add($"{edge.First} - {edge.Second}");
                    //Тук маркираме, че и обратното ребро е махнато.
                    reversedEdges.Add($"{edge.Second} - {edge.First}");
                }
                else
                {
                    //добавяме го отново
                    graph[edge.First].Add(edge.Second);
                    graph[edge.Second].Add(edge.First);
                }
            }

            Console.WriteLine($"Edges to remove: {toRemoveEdges.Count}");
            Console.WriteLine(string.Join(Environment.NewLine,toRemoveEdges));
        }

        private static bool BFS(string start, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);

            var visited = new HashSet<string>{ start };
            //visited.Add(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if(node == destination)
                {
                    return true;//still have a connection between start and destination
                }

                foreach (var child in graph[node])
                {
                    if(visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return false;
        }
    }
}
