using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3LabTreesBFSandDFS //Взет от интернет!
{
    public class TreeGenerator
    {
        private readonly int maxChilds;
        private readonly Random rnd = new Random();

        public TreeGenerator(int maxChilds)
        {
            this.maxChilds = maxChilds;
        }

        public Node<T> CreateTree<T>(int maxDepth, Func<T> valueGenerator)
        {
            var node = new Node<T>(); //и конструктор
            //var node = (Node<T>)Activator.CreateInstance(typeof(T));//Reflection
            node.Value = valueGenerator();
            if (maxDepth > 0)
            {
                var childsCount = rnd.Next(maxChilds);
                for (var i = 0; i < childsCount; ++i)
                    node.Children.Add(CreateTree(maxDepth - 1, valueGenerator));
            }
            return node;
        }

        public static void Demo()
        {
            var rnd = new Random();
            var generator = new TreeGenerator(3 /* max childs count*/);
            var tree = generator.CreateTree(4 /*max depth*/, () => rnd.Next() /*node value*/);
        }
    }
}
