using System;
using System.Linq;
using System.Collections.Generic;

namespace _3.CyclesGraphTopologSortDfs
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;

        static void Main(string[] args)
        {
            //var input = Console.ReadLine();

            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            //while(input != "End")
            while (true)
            {
                var input = Console.ReadLine();

                if(input == "End")
                { 
                    break;
                }

                var currentEdge = input.Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var from = currentEdge[0];
                var to = currentEdge[1];

                if(!graph.ContainsKey(from))
                {
                    graph[from] = new List<string>();
                }

                if (!graph.ContainsKey(to))
                {
                    graph[to] = new List<string>();
                }

                graph[from].Add(to);

                //input = Console.ReadLine();
            }

            try
            {
                foreach (var node in graph.Keys)
                {
                    DFS(node);
                }

                //If all the nodes have no exceptions, then:
                Console.WriteLine("Acyclic: Yes");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Acyclic: No");
            }
        }

        private static void DFS(string node)
        {
            if(cycles.Contains(node))
            {
                throw new InvalidOperationException();//Because we have void function here, we use exception. So we have a cycle graph
            }    

            if(visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            cycles.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);//накрая разкачаме ноуда от тук, защото той не е вече част от текущата рекурсия.
        }
    }
}
