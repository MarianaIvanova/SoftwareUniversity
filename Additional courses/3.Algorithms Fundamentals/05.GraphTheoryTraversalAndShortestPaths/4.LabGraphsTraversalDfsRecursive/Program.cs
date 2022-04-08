using System;
using System.Collections.Generic;

namespace _4.LabGraphsTraversalDfsRecursive
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;//Which nodes were already visited
        static void Main(string[] args)
        {
            //When we don't have nodes from 0 or 1 to N, we will use dictionar insread of an array
            graph = new Dictionary<int, List<int>>
            {
                {1, new List<int>{19, 21, 14}},
                {19, new List<int>{7, 12, 31, 21}},
                {7, new List<int>{1}},
                {31, new List<int>{21}},
                {21, new List<int>{14}},
                {14, new List<int>{23, 6}},
                {23, new List<int>{21}},
                {12, new List<int>()},
                {6, new List<int>()}
            };

            visited = new HashSet<int>();

            //Сега пускаме DFS за всеки елемент от графа. Прави се, защото може графът да не е свързан и за тези, които вече са посетени няма проблем, че ги посещаваме отново, но за несвързаната част, тук ще я направим. Затова не пускаме само DFS, а foreach с DFS.
            foreach (var node in graph.Keys)
            {
                DFS(node);
            }
        }

        private static void DFS(int node)//Recursive
        {
            //Base when we reach visited node
            if(visited.Contains(node))
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

            Console.WriteLine(node);
            //7
            //12
            //23
            //6
            //14
            //21
            //31
            //19
            //1
        }
    }
}
