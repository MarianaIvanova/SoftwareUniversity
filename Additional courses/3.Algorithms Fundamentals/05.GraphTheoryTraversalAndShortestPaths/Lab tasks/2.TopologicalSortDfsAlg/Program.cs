using System;
using System.Linq;
using System.Collections.Generic;

namespace _2.TopologicalSortDfsAlg
{
    class Program
    {
        //НЕ ИЗКАРВА ВИНАГИ ЕДИН И СЪЩИ РЕЗУЛАТ С Source Removal Algorithm. ТОВА МУ Е ЛОГИКАТА! ТАКА РАБОТИ! В Judge e 66/100, защото там е за Source Removal Algorithm, е не за DFS
        //We should use mapping and work with int for the string nodes, but here make an exception for easily understanding!
        private static Dictionary<string, List<string>> graph;
        private static Stack<string> sorted;
        //Това е за всички посетени ноудове:
        private static HashSet<string> visited;
        //Това е само за ноудовете, които обхождаме като стартираме с определен ноуд, тоест за текущия компонент, който в момента обхождаме, затова при приключване на рекурсията ги махаме.
        private static HashSet<string> cycles;

        static void Main(string[] args)
        {
            //Number of lines:
            var n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);
            sorted = new Stack<string>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            var hasCycle = false;
            foreach (var node in graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    //Console.WriteLine("Invalid topological sorting");
                    hasCycle = true;
                    break;
                }
            }

            //sorted.Reverse();//Можем да го направим и stack - по-добър е първоформънса, а не list, който да reverse-ваме

            if(!hasCycle)
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
            }           
        }

        private static void DFS(string node)
        {
            //Check for cycles
            if(cycles.Contains(node))
            {
                throw new InvalidOperationException("Invalid topological sorting");
            }
            //Base
            if(visited.Contains(node))
            {
                return;
            }

            cycles.Add(node);
            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);

            sorted.Push(node);
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => e.Trim())//No empty spaces for the both elements
                    .ToArray();

                var key = parts[0];

                //In cases when we don't have children
                if (parts.Length == 1)
                {
                    //result.Add(key, new List<string>());
                    result[key] = new List<string>();
                }
                else
                {
                    var children = parts[1].Split(", ").ToList();
                    //result.Add(key, children);
                    result[key] = children;
                }
            }

            return result;
        }
    }
}

