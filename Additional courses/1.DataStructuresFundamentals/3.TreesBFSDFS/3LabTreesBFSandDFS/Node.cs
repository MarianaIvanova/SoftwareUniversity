namespace _3LabTreesBFSandDFS
{
    using System.Collections.Generic;
    using System.Linq;

    public class Node<T>
    {
        public Node()
        {
            Children = new List<Node<T>>();
        }
        public Node(T value, params Node<T>[] children)//с params можем безкрайно да изброяваме нодове като деца
        {
            Value = value;
            Children = children.ToList();// using System.Linq;
        }
        public T Value { get; set; }
        public List<Node<T>> Children { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
