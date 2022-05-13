using System;
using System.Collections.Generic;

namespace _3LabTreesBFSandDFS
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        public List<T> DFS(Node<T> node, int level)
        {
            //Console.Write(new string(' ', level));//Тук печатаме level на брой празни елементи!
            //Console.WriteLine(node);

            List<T> list = new List<T>();
            //list.Add(node.Value);//Тук ще добавяме когато влизаме в съответната рекурсия

            foreach (var child in node.Children)//Започваме от root-а и за всяко едно дете му казваме - създай нов лист и го 
                //и го мърджни към нашия текущ лист (затова имаме AddRange - добавяме лист към лист). Защото при рекурсии - влизаме, влизаме, влизаме... до най-дълбокото, т.е. създаваме нов лист, създаваме нов лист и т.н., след това излизаме, излизаме, излизаме...до рута от рекурсиите и ги мърджваме един по един всички създадени листове към първия, който сме създали и накрая ще получим рекурсивно общия лист.
            {
                list.AddRange(DFS(child, level + 3));//3 - защото искаме отстоянията да са но шпации
            }

            list.Add(node.Value);//Тук ще добавяме когато излизаме от съответната рекурсия. А ние в DFS искаме да добавяме на връщане!

            return list;
        }

        public List<Node<T>> BFS(Node<T> root)
        {
            //Add the root to the queue
            //while queue not empty
            //queue dequeue
            //foreach child in current node enqueue
            List<Node<T>> list = new List<Node<T>>();

            Queue<Node<T>> queue = new Queue<Node<T>>();

            queue.Enqueue(root);

            while(queue.Count > 0)//For the first iteration it is the root
            {
                Node<T> node = queue.Dequeue();
                list.Add(node);

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return list;
        }
        //DFS - направен като BFS разписване, но със стак, вместо със кю!
        public List<Node<T>> DFS2(Node<T> root)
        {
            //Add the root to the queue
            //while queue not empty
            //queue dequeue
            //foreach child in current node enqueue
            List<Node<T>> list = new List<Node<T>>();

            Stack<Node<T>> stack = new Stack<Node<T>>();

            stack.Push(root);

            while (stack.Count > 0)//For the first iteration it is the root
            {
                Node<T> node = stack.Pop();
                list.Add(node);

                foreach (var child in node.Children)
                {
                    stack.Push(child);
                }
            }

            //But the list is reversed, so we need to make it right - Mine
            List<Node<T>> reversedList = new List<Node<T>>();
            for (int i = 0; i < list.Count; i++)
            {
                reversedList.Add(list[list.Count - 1 - i]);
            }

            return reversedList;
        }
    }
}
