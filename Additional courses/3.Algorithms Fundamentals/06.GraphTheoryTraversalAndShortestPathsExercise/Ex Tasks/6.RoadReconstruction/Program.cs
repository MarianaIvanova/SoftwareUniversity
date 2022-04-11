 using System;
using System.Linq;
using System.Collections.Generic;

namespace _6.RoadReconstructionDfs
{
    public class Edge//Street
    {
        public int First{ get; set; }//FirstBuilding
        public int Second { get; set; }//SecondBuilding

        public override string ToString()
        {
            return $"{First} {Second}";
        }
    }
    class Program
    {
        //Seeing the task, we are looking for the streets which are not in loop
        //Връзките в графа би трябвало да са двупосочни, но във входящите данни не са, затова трябва да си ги добавим!
        private static List<int>[] graph;
        private static List<Edge> edges;
        private static bool[] visited;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());//edges

            graph = new List<int>[n];
            edges = new List<Edge>();

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var edgeParts = Console.ReadLine().Split(" - ").Select(int.Parse).ToArray();

                var firstNode = edgeParts[0];
                var secondNode = edgeParts[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);

                edges.Add(new Edge { First = firstNode, Second = secondNode });//Add only the edge, but not the reverse edge
            }

            Console.WriteLine("Important streets:");
            //Проверяваме за всяко едно ребро, ако го махнем дали ще можем да обходим целия граф, ако не можем - това е важна улица и не може да се маха!!!
            foreach (var edge in edges)
            {
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                //при всяко премахване на ребро, трябва да го занулим
                visited = new bool[graph.Length];//!!!!!!!!!!!!!!!!!!!!!!!!!

                //We can use BFS or DFS
                DFS(0);//We can use also DFS(edge.Second) or DFS(edge.First); Because if the graph is connected, it doesn't matter from which node we start, we can go to all other nodes!!
               
                //Need to check is there is a not which is not visited
                if(visited.Contains(false))
                {
                    //we have not visited nodes, so the node we have deleted is important
                    var newEdge = new Edge
                    {
                        First = Math.Min(edge.First, edge.Second),
                        Second = Math.Max(edge.First, edge.Second)
                    };

                    Console.WriteLine(newEdge);
                }

                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }
        }

        private static void DFS(int node)
        {
            //Base
            if(visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }
}
