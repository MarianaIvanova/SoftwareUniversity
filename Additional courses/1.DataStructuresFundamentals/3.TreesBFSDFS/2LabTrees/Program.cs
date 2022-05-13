using System;

namespace _2LabTrees
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
            Console.WriteLine(root.Value);
        }
    }
}
