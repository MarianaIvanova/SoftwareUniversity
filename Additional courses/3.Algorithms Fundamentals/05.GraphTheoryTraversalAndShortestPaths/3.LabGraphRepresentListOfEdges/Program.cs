using System;
using System.Linq;
using System.Collections.Generic;

namespace _3.LabGraphRepresentListOfEdges
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new List<Edge>()
              {
              new Edge() { Parent = 0, Child = 3 },
              new Edge() { Parent = 0, Child = 6 },
              new Edge() { Parent = 0, Child = 1 },
              new Edge() { Parent = 1, Child = 2 },
              new Edge() { Parent = 1, Child = 4 },
              };

            // Add an edge { 3 -> 6 }
            graph.Add(new Edge() { Parent = 3, Child = 6 });

            // List the children of node #1
            var childNodes = graph.Where(e => e.Parent == 1);

        }
        class Edge
        {
            public int Parent { get; set; }//For directed graph it can be here:From, for undirected: First
            public int Child { get; set; }//For directed graph it can be here:To, for undirected: Second
        }
    }
}
