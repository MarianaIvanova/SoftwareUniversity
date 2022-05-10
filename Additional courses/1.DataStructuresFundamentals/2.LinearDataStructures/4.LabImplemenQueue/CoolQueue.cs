using _2.LabImplementLinkedList;

namespace _4.LabImplemenQueue
{
    public class CoolQueue<T>
    {
        private LinkedList<T> linkedList;//Използваме създадения клас в другия проект LinkedList

        public CoolQueue()
        {
            linkedList = new LinkedList<T>();
        }

        public int Count { get { return linkedList.Count; } }
        //public int Count { get => linkedList.Count; }

        public void Enqueue(T element)
        {
            linkedList.AddLast(element);//Добавяме го отзад!
        }

        public T Peek()
        {
            return linkedList.Head.Value;//Value to return T
        }

        public T Dequeue()
        {
            return linkedList.RemoveHead().Value;
        }
    }
}
