using System;

namespace _1LabTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);

            node1.Children.Add(node2);
            node1.Children.Add(node3);

            node2.Children.Add(node4);

            //Това ще изглежда така:
            //          1
            //      2       3
            //  4
        }
    }
}
