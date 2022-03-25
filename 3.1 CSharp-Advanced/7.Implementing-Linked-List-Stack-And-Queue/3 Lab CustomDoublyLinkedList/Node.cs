using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Lab_CustomDoublyLinkedList
{
    public class Node//a recursive data structure
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
}
