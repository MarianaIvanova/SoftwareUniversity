﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _1LabBinaryTree
{
    public class Node<T>
    {
        public Node(T value, Node<T> leftChild = null, Node<T> rightChild = null)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
        public T Value { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }
    }
}
