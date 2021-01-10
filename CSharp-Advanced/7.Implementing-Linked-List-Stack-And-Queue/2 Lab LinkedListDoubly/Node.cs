using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Lab_LinkedListDoubly
{
    public class Node
    {
        //Doubly Linked List
        public Node(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
}
