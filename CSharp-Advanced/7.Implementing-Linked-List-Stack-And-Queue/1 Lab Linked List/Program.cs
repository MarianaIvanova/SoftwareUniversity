using System;

namespace _1_Lab_LinkedListSingly
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            for (int i = 0; i < 10; i++)
            {
                list.AddHead(new Node(i));
            }

            list.PrintList();

            //This is for stack:
            Console.WriteLine($"Poped {list.Pop().Value}");
            Console.WriteLine($"Poped {list.Pop().Value}");
            Console.WriteLine($"Poped {list.Pop().Value}");

            list.PrintList();
        }
    }
}
