namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;//Използваме го, за да сме сигурни, че не се повтарят стойностите в дървото, иначе можеше да бъде лист.

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int[] currentPair = input[i].Split(' ').Select(int.Parse).ToArray();
                int current1 = currentPair[0];
                int current2 = currentPair[1];

                var node1 = CreateNodeByKey(current1);
                var node2 = CreateNodeByKey(current2);

                AddEdge(current1, current2);
            }

            return GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            Tree<int> node = null;

            if (!nodesBykeys.ContainsKey(key))
            {
                node = new Tree<int>(key);
                nodesBykeys.Add(key, node);
            }

            return node;
        }

        public void AddEdge(int parent, int child)
        {
            nodesBykeys[parent].AddChild(nodesBykeys[child]);
            nodesBykeys[child].AddParent(nodesBykeys[parent]);
        }

        private Tree<int> GetRoot()
        {
            Tree<int> root = null;

            foreach (var item in nodesBykeys)
            {
                if(item.Value.Parent == null)
                {
                    root = item.Value;
                }
            }

            return root;
            //return nodesBykeys.FirstOrDefault().Value;//Спорно е дали първият елемент е точно корена!
        }
    }
}
