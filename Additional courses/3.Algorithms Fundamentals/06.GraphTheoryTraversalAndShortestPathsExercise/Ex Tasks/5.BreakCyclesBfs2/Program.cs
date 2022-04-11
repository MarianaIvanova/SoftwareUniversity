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

            var toRemoveEdges = new List<string>();

            //Разкачаме ребрата и в двете посоки
            foreach (var edge in edges)
            {
                //This will return true or false or is the edge was successfully removed
                var removed = graph[edge.First].Remove(edge.Second) && graph[edge.Second].Remove(edge.First);

                //Защото ако премахна ребро, което не е част от графа, няма нужда да проверявам след това дали има път между тези два ноуда.
                //Ще имаме remove = false само тогава, когато първото ребро е вече премахнато, а аз се опитвам да го премахна отново, и независимо, че ревърс реброто е true, имаме remove = false. Тогава няма нужда това ребро да минаваме и да го прегреждаме, защото това е ревърс реброто. Имаме remove = true само тогава, когато и две условия са true, т.е. нямаме премахата едната от двете връзки в двупосочния граф!!!
                if (!removed)
                {
                    continue;
                }

                //Проверяваме дали имаме все още връзка между edge.First и edge.Second чрез друг път. Ако има такава връзка, го премахваме, ако няма - го оставяме, за да не разкачим на части графа.
                if(BFS(edge.First, edge.Second))
                {
                    toRemoveEdges.Add($"{edge.First} - {edge.Second}");
                    //Тук маркираме, че и обратното ребро е махнато.
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
