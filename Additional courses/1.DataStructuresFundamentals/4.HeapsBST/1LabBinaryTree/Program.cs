using System;

namespace _1LabBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //          1
            //      5       7
            //  2      3 9      11

            Node<int> root = new Node<int>(1,
                    new Node<int>(5,
                        new Node<int>(2),
                        new Node<int>(3)),
                    new Node<int>(7,
                        new Node<int>(9),
                        new Node<int>(11))
                );

            BinaryTree<int> tree = new BinaryTree<int>(root);
            Console.WriteLine(tree.DFSPreOrder(root, 0));
            //1
            //    5
            //       2
            //       3
            //    7
            //       9
            //       11
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(tree.DFSInOrder(root, 0));
            //      2
            //   5
            //      3
            //1
            //      9
            //   7
            //      11
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(tree.DFSPostOrder(root, 0));
             //      2
             //      3
             //   5
             //      9
             //      11
             //   7
             //1
        }
    }
}
