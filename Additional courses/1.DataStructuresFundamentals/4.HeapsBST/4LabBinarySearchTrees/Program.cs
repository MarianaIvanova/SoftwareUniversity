using System;
using System.Collections.Generic;
using CommonDataStructures;//REF for a Library which we have created!

namespace _4LabBinarySearchTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 20; i+=2)
            {
                list.Add(i);
            }

            BST<int> tree = new BST<int>();

            //MISTAKE 1
            //for (int i = 0; i < list.Count; i++)//This will create a linked list
            //{
            //    tree.Insert(list[i], tree.Root);
            //}

            //Console.WriteLine(DFS.DFSInOrder(tree.Root, 0));
            ////0
            ////   2
            ////      4
            ////         6
            ////            8
            ////               10
            ////                  12
            ////                     14
            ////                        16
            ////                           18

            ////MISTAKE 2
            //for (int i = list.Count / 2; i >= 0; i--)//This will create two linked list
            //{
            //    tree.Insert(list[i], tree.Root);
            //}

            //for (int i = list.Count / 2; i < list.Count; i++)
            //{
            //    tree.Insert(list[i], tree.Root);
            //}

            //Console.WriteLine(DFS.DFSInOrder(tree.Root, 0));
            ////               0
            ////            2
            ////         4
            ////      6
            ////   8
            ////10
            ////   10
            ////      12
            ////         14
            ////            16
            ////               18

            //CORRECT ONE - with recursion

            Insert(tree, 0, list.Count, list);

            Console.WriteLine($"Find: {57} -> {tree.Contains(57,tree.Root)}");//false
            Console.WriteLine($"Find: {0} -> {tree.Contains(0,tree.Root)}");//false

            Console.WriteLine(DFS.DFSInOrder(tree.Root, 0));
            //Find: 57->False
            //Find: 0->True
            //      0
            //   4
            //      6
            //10
            //      12
            //   16
            //      18
            //MISSING 2, 8, 14 

        }

        private static void Insert(BST<int> tree, int start, int end, List<int> list)
        {
            if(start >= end)
            {
                return;
            }

            var middle = (start + end) / 2;

            tree.Insert(list[middle], tree.Root);

            Insert(tree, start, middle - 1, list);
            Insert(tree, middle + 1, end, list);
        }
    }
}
