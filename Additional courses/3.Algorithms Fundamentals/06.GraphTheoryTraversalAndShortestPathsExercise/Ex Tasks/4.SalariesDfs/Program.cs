using System;
using System.Linq;
using System.Collections.Generic;

namespace _4.SalariesDfs
{
    class Program
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> visited;//Node + its salary
             
        static void Main(string[] args)
        {
            //Employees can have one or several direct managers. People who manage nobody are called regular employees and their salaries are 1. People who manage at least one employee are called managers.Each manager takes a salary which is equal to the sum of the salaries of their directly managed employees. 
            //So, to find the salary of one node - employee/manager, we need to find the salary of it's children, it's children's children and so on. So we need to use DFS
            //Read the number of employees
            var n = int.Parse(Console.ReadLine());

            //Data comes in matrix, so we gona use array for the graph after reading the data
            graph = new List<int>[n];
            visited = new Dictionary<int, int>();

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();

                var nodeChildren = Console.ReadLine();

                for (int child = 0; child < nodeChildren.Length; child++)
                {
                    if(nodeChildren[child] == 'Y')
                    {
                        graph[node].Add(child);
                    }
                }
            }

            var salaryAllEmployees = 0;

            for (int node = 0; node < graph.Length; node++)
            {
                salaryAllEmployees += DFS(node);             
            }

            Console.WriteLine(salaryAllEmployees);
        }

        private static int DFS(int node)
        {
            //Base is when we reach visited node
            if (visited.ContainsKey(node))
            {
                return visited[node];//This we make it, so we won't calculate every time the already visited nodes
            }

            var salary = 0;
            //if the node doesn't have children
            if (graph[node].Count == 0)
            {
                salary = 1;//As the salary of the employees, which are not managers is 1.
            }
            else
            {
                foreach (var child in graph[node])
                {
                    salary += DFS(child);
                }
            }

            visited[node] = salary;

            return salary;
        }
    }
}
