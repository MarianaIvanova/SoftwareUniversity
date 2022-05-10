namespace Problem02.DoublyLinkedList
{
    public class Node<T>
    {
        public Node(T item)//, Node<T> next = null, Node<T> previous = null
        {
            this.Item = item;
        }
        public T Item { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }
    }
}