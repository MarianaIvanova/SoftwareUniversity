namespace Tree
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        private bool IsRootDeleted;

        //Task 1
        public Tree(T value)
        {
            Value = value;
            Parent = null;
            _children = new List<Tree<T>>();
        }

        //public Tree(T value, params Tree<T>[] children)
        //    : this(value)
        //{
        //    _children = children.ToList();
        //}

        //Implamantation from lab
        //Task 1
        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        //Task 2
        public ICollection<T> OrderBfs()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<T> list = new List<T>();
            queue.Enqueue(this);//!!!

            while(queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();
                list.Add(subtree.Value);

                foreach (var child in subtree._children)
                {
                    queue.Enqueue(child);
                }
            }

            if (this.IsRootDeleted == true)
            {
                return new List<T>();
            }

            return list;
        }

        //Task 3
        ////Solution 1 - implamantation from lab
        //public ICollection<T> OrderDfs()
        //{
        //    List<T> list = new List<T>();

        //    Dfs(this, list);

        //if(this.IsRootDeleted == true)
        //{
        //  return new List<T>();
        //}

        //    return list;
        //}

        //private void Dfs(Tree<T> subtree, List<T> list)
        //{
        //    foreach (var child in subtree._children)
        //    {
        //        Dfs(child, list);
        //    }

        //    list.Add(subtree.Value);
        //}

        //Task 3
        //Solution 2 - using recursion
        //public ICollection<T> OrderDfs()
        //{
        //    return Dfs(this);
        //}

        //private List<T> Dfs(Tree<T> subtree)
        //{
        //    List<T> list = new List<T>();

        //    foreach (var child in subtree.Children)
        //    {
        //        list.AddRange(Dfs(child));
        //    }

        //    list.Add(subtree.Value);

        //if(this.IsRootDeleted == true)
        //{
        //  return new List<T>();
        //}

        //    return list;
        //}

        //Task 3
        //Solution 3 - using stack - Mine
        public ICollection<T> OrderDfs()
        {
            Stack<Tree<T>> stack = new Stack<Tree<T>>();
            List<T> list = new List<T>();
            stack.Push(this);//!!!

            while (stack.Count > 0)
            {
                Tree<T> subtree = stack.Pop();
                list.Add(subtree.Value);

                foreach (var child in subtree._children)
                {
                    stack.Push(child);
                }
            }

            List<T> reversedList = new List<T>();

            for (int i = 0; i < list.Count; i++)
            {
                reversedList.Add(list[list.Count - 1 - i]);
            }

            if (this.IsRootDeleted == true)
            {
                return new List<T>();
            }

            return reversedList;
        }
        //Task 4
        public void AddChild(T parentKey, Tree<T> child)
        {
            var searchedNode = SearchTreeBFS(this, parentKey);

            IsEmptyNode(searchedNode);

            searchedNode._children.Add(child);
            
        }
        //Task 5
        public void RemoveNode(T nodeKey)
        {
            var searchedNode = SearchTreeBFS(this, nodeKey);

            IsEmptyNode(searchedNode);

            //Чистим децата на намерения нод, ако има
            foreach (var child in searchedNode._children)
            {
                child.Parent = null;//Чистим връзката с родителя т.е. serchedNode 
            }

            searchedNode._children.Clear();//Чистим самите деца

            var searchedParent = searchedNode.Parent;
            //Чистим в родителя връзката към намерения нод, ако има родител
            if (searchedParent == null)//Ако е root,
            {
                searchedNode.IsRootDeleted = true;
            }
            else//ако не е обаче, трябва да изчистим този нод от родителя му
            {
                searchedNode.Parent._children.Remove(searchedNode);
            }

            //Чистим самия нод
            searchedNode.Parent = null;
            searchedNode.Value = default;
        }
        //Task 6
        public void Swap(T firstKey, T secondKey)
        {
            var node1 = SearchTreeBFS(this, firstKey);
            var node2 = SearchTreeBFS(this, secondKey);

            if(node1 == null || node2 == null)
            {
                throw new ArgumentNullException();
            }

            var parentNode1 = node1.Parent;
            var parentNode2 = node2.Parent;

            if(parentNode1 != null)
            {
                if(parentNode2 != null)
                {
                    int index1 = parentNode1._children.IndexOf(node1);
                    int index2 = parentNode2._children.IndexOf(node2);

                    parentNode1._children[index1] = node2;
                    parentNode2._children[index2] = node1;
                }
                else 
                {
                    node2.Value = node1.Value;
                    node2._children.Clear();
                    node2._children.AddRange(node1._children);
                }
            }
            else
            {
                if (parentNode2 != null)
                {
                    node1.Value = node2.Value;
                    node1._children.Clear();
                    node1._children.AddRange(node2._children);
                }
            }

        }

        //Task 4 and 5. For add child and remove node
        private Tree<T> SearchTreeBFS(Tree<T> root, T searchedKey)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Value.Equals(searchedKey))
                {
                    return node;
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
        //Task 4 and 5. For add child and remove node
        private void IsEmptyNode(Tree<T> searchedNode)
        {
            if (searchedNode == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
