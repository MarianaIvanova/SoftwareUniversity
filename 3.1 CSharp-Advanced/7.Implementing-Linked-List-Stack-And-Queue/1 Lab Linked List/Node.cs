using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Lab_LinkedListSingly
{
    public class Node
    {
        //Singly Linked List - Едносвързан списък
        public Node(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }
        public Node Next { get; set; }
    }
}
