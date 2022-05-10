using System;
using System.Collections.Generic;

namespace _2.LabImplementLinkedList
{
    //Recursive data structure - нарича се рекурсивна структура от данни, защото реферира себе си!
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }
        public T Value { get; set; }

        public Node<T> Next { get; set; }//Това прави връзката на нода със следващия нод.
    }
}
