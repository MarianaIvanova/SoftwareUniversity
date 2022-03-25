using System;

namespace _3_Lab_CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            for (int i = 0; i < 5; i++)
            {
                list.AddFirst(new Node(i));
            }

            for (int i = 0; i < 5; i++)
            {
                list.AddLast(new Node(i));
            }

            list.PrintList();//Prints on a new line 4 3 2 1 0 0 1 2 3 4

            Console.WriteLine();

            list.RemoveFirst();
            list.RemoveFirst();
            list.RemoveFirst();
            list.PrintList();//Prints on a new line 1 0 0 1 2 3 4

            Console.WriteLine();
            list.RemoveLast();
            list.RemoveLast();
            list.PrintList();//Prints on a new line 1 0 0 1 2

            Console.WriteLine();
            Console.WriteLine(list.ToArray().Length);//5

            Console.WriteLine();
            list.Remove(0);//If the value is the first or the last in the list - it gives mistake the way we have made next and previous
            list.PrintList();//Prints on a new line 1 0 1 2
        }
    }
}
