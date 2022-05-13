namespace _1LabTrees
{
    using System.Collections.Generic;

    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
            Children = new List<Node<T>>();
        }
        public T Value { get; set; }
        public List<Node<T>> Children { get; set; }
    }
}
