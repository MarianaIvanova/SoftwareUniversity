using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace _3LabTreesBFSandDFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> root = new Node<int>(7,
                new Node<int>(19,
                    new Node<int>(1),
                    new Node<int>(12),
                    new Node<int>(31)),
                new Node<int>(21),
                new Node<int>(14,
                    new Node<int>(23),
                    new Node<int>(6))
                );

            
            Tree<int> tree = new Tree<int>();
            tree.Root = root;//we don't use it here!

            //This is BFS
            List<Node<int>> treeAsList = tree.BFS(root);

            Console.WriteLine(string.Join(", ", treeAsList)); //7, 19, 21, 14, 1, 12, 31, 23, 6

            //This is DFS
            Console.WriteLine(string.Join(", ", tree.DFS(root, 0)));//1, 12, 31, 19, 21, 23, 6, 14, 7
            Console.WriteLine(string.Join(", ", tree.DFS2(root)));//1, 12, 31, 19, 21, 23, 6, 14, 7
            //Clasical way for printing trees - when we use the print in the DFS method which is in the comments
            //tree.DFS(root, 0);
            //7
            //   19
            //      1
            //      12
            //      31
            //   21
            //   14
            //      23
            //      6

            //This is random generator for trees
            TreeGenerator generator = new TreeGenerator(5);//5 - max children
            var rnd = new Random();
            var generatedTree = generator.CreateTree<int>(15, () => rnd.Next(0,100));

            Stopwatch watch = new Stopwatch();//using System.Diagnostics;

            Console.WriteLine("BFS time in our case with this tree:");
            watch.Start();
            for (int i = 0; i < 100; i++)//Обхождаме повече пъти, защото имаме 0 miliseconds
            {
                tree.BFS(root);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Reset();

            Console.WriteLine("DFS time in our case with this tree:");
            watch.Start();
            for (int i = 0; i < 100; i++)
            {
                tree.DFS(root, 0);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Reset();

            Console.WriteLine("DFS with recursion generated tree:");
            watch.Start();
            for (int i = 0; i < 100; i++)
            {
                tree.DFS(generatedTree, 0);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Reset();

            Console.WriteLine("BFS generated tree:");
            watch.Start();
            for (int i = 0; i < 100; i++)
            {
                tree.BFS(generatedTree);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Reset();

            Console.WriteLine("DFS2 with stack generated tree:");
            watch.Start();
            for (int i = 0; i < 100; i++)
            {
                tree.DFS2(generatedTree);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Reset();

            //BFS time in our case with this tree:
            //0
            //DFS time in our case with this tree:
            //0
            //DFS with recursion generated tree:
            //3270
            //BFS generated tree:
            //1852
            //DFS2 with stack generated tree:
            //2263
        }
    }
}
