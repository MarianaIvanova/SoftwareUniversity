using System;
using System.Collections.Generic;

namespace _1.LabGraphRepresentAdjacencyList
{
    class Program
    {
        static void Main(string[] args)
        {
            //The graph is an array of list<int> and the indexes are the nodes, while the edges/connections are the lists<int>
            //For the case when we have nodes which are numbers from 0 or from 1 to n
            var graph = new List<int>[]
            {
                new List<int> {3, 6},//Node 0 or index 0
                new List<int> {2, 3, 4, 5, 6},//Node 1 or index 1
                new List<int> {1, 4, 5},//Node 2 or index 2
                new List<int> {0, 1, 5},//Node 3 or index 3
                new List<int> {1, 2, 6},//Node 4 or index 4
                new List<int> {1, 2, 3},//Node 5 or index 5
                new List<int> {0, 1, 4},//Node 6 or index 6
            };

            //If we wanna see the children of 0 (parent) node:
            Console.WriteLine(string.Join(", ", graph[0]));

            //For the case when we have nodes which are strings
            //Operations with strings is slower than this with int
            var graphStrings = new Dictionary<string, List<string>>();
            //But it will be better if we work with int nodes and make a mapping table for the int and the string. Like 0 - Russe, 1 - Sofia, 2 - Vratza and so on.
            var mapping = new Dictionary<int, string>()
            {
                {0, "Russe"},
                {1, "Sofia"},
                {2, "Vratza"}
            };
            //and use:
            //var graphTowns = new List<int>[];
        }
    }
}
