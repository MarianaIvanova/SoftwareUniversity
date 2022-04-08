using System;
using System.Linq;
using System.Collections.Generic;

namespace _2.TopologicalSortSourceRemovalAlg
{
    class Program
    {
        //We should use mapping and work with int for the string nodes, but here make an exception for easily understanding!
        private static Dictionary<string, List<string>> graph;
        //We eshould know how many dependencies/parents each node has.
        private static Dictionary<string, int> dependencies;
        static void Main(string[] args)
        {
            //Number of lines:
            var n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);

            dependencies = ExtractDependencies(graph);

            var sorted = new List<string>();

            //Now we should find the nodes with 0 dependencies:
            while(dependencies.Count > 0)
            {
                //Взимаме първото депенденси - само ноуда му - key, на което стойността му е 0:
                var nodeToRemove = dependencies.FirstOrDefault(n => n.Value == 0).Key;

                //Ако нямам ноуд с 0 депенденсита, значи че имаме цикъл в този граф и винаги ще зациклям:
                if(nodeToRemove == null)
                {
                    break;
                }

                dependencies.Remove(nodeToRemove);
                sorted.Add(nodeToRemove);

                //Минаваме през всички деца на този ноуд, за да махнем по 1 от депенденситата им
                foreach (var chilld in graph[nodeToRemove])
                {
                    dependencies[chilld] -= 1;
                }
            }

            //Ако сме премахнали всички връзки, OK
            if(dependencies.Count == 0)
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
            }
            else
            {
                Console.WriteLine("Invalid topological sorting");
            }
        }

        private static Dictionary<string, int> ExtractDependencies(Dictionary<string, List<string>> graph)
        {
            var result = new Dictionary<string, int>();

            foreach (var kvp in graph)//keyValuePair
            {
                var node = kvp.Key;
                var children = kvp.Value;

                //Ако не го съдържа го дабавяме с нула връзки към него:
                if(!result.ContainsKey(node))
                {
                    result[node] = 0;
                }

                foreach (var child in children)
                {
                    if (!result.ContainsKey(child))
                    {
                        //Ако не го съдържа го дабавяме с 1 връзка от родителя към детето:
                        result[child] = 1;
                    }
                    else
                    {
                        result[child] += 1;
                    }    
                }
            }

            return result;
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
                if(parts.Length == 1)
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
