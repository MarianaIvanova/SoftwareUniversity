namespace Tree
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            _children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);//this._children.Add(child);
                child.AddParent(this);//child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        //Task 2
        public string GetAsString()//DFS - стандартен с рекурсия
        {
            //Mine
            //StringBuilder sb = new StringBuilder();

            //var list = DFS(this, 0);
            ////var list = DFSstack(this, 0);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    sb.AppendLine(list[i].ToString());
            //}

            //return sb.ToString().TrimEnd();

            return this.GetAsString(0).TrimEnd();
        }

        //Task 3 - I have done it the same way, but without help method
        public List<T> GetLeafKeys()
        {
            List<Tree<T>> listNodes = GetLeafNodes();
            List<T> list = new List<T>();

            for (int i = 0; i < listNodes.Count; i++)
            {
                var currentNode = listNodes[i];
                list.Add(currentNode.Key);
            }

            return list;
        }
        ////Task 5 - Mine
        //public Tree<T> GetDeepestLeftomostNode()
        //{
        //    Dictionary<Tree<T>, int> dict = new Dictionary<Tree<T>, int>();
        //    Queue<Tree<T>> queue = new Queue<Tree<T>>();

        //    queue.Enqueue(this);

        //    while(queue.Count > 0)
        //    {
        //        Tree<T> subtree = queue.Dequeue();
        //        if(subtree.Children.Count == 0)//Only leafs i.e. without children, this is the end leaf
        //        {
        //            var tmpSubtree = subtree;

        //            dict.Add(tmpSubtree, 1);
        //            int count = 1;
        //            var tmpSubtree2 = tmpSubtree;

        //            while (tmpSubtree2.Parent != null)
        //            {
        //                count++;
        //                tmpSubtree2 = tmpSubtree2.Parent;
        //            }
        //            dict[tmpSubtree] = count;
        //        }

        //        foreach (var child in subtree.Children)
        //        {
        //            queue.Enqueue(child);
        //        }
        //    }

        //    int maxValue = 0;

        //    foreach (var item in dict)
        //    {
        //        if(item.Value > maxValue)
        //        {
        //            maxValue = item.Value;
        //        }
        //    }

        //    var result = dict.FirstOrDefault(c => c.Value == maxValue);

        //    return result.Key;
        //}
        //Task 5
        public Tree<T> GetDeepestLeftomostNode()
        {
            Dictionary<Tree<T>, int> dict = new Dictionary<Tree<T>, int>();
            List<Tree<T>> listNodes = GetLeafNodes();

            foreach (var node in listNodes)
            {
                var count = 1;
                var nodeTmp = node;
                dict.Add(nodeTmp, 1);

                while (nodeTmp.Parent != null)
                {
                    count++;
                    nodeTmp = nodeTmp.Parent;
                }
                dict[node] = count;
            }

            int maxValue = 0;

            foreach (var item in dict)
            {
                if (item.Value > maxValue)
                {
                    maxValue = item.Value;
                }
            }

            var result = dict.FirstOrDefault(c => c.Value == maxValue);

            return result.Key;
        }
 
        //Task 4 - Mine
        public List<T> GetMiddleKeys()
        {
            List<T> list = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();
                if (subtree.Children.Count > 0 && subtree.Parent != null)//Only middle nodes
                {
                    list.Add(subtree.Key);
                }

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return list;
        }
        //Task 6
        public List<T> GetLongestPath()
        {
            Dictionary<Tree<T>, int> dict = new Dictionary<Tree<T>, int>();
            List<Tree<T>> listNodes = GetLeafNodes();

            foreach (var node in listNodes)
            {
                var count = 1;
                var nodeTmp = node;
                dict.Add(nodeTmp, 1);

                while (nodeTmp.Parent != null)
                {
                    count++;
                    nodeTmp = nodeTmp.Parent;
                }
                dict[node] = count;
            }

            int maxValue = 0;

            foreach (var item in dict)
            {
                if (item.Value > maxValue)
                {
                    maxValue = item.Value;
                }
            }

            var result = dict.FirstOrDefault(c => c.Value == maxValue);

            List<T> list = new List<T>();

            Tree<T> node2 = result.Key;
            for (int i = 0; i < maxValue; i++)
            {
                list.Add(node2.Key);
                node2 = node2.Parent;
            }

            //List<T> reversedList = new List<T>();
            //for (int i = maxValue - 1; i >=0; i--)
            //{
            //    reversedList.Add(list[i]);
            //}

            list.Reverse();
            return list;
        }
        //task 7 - v1
        public List<List<T>> PathsWithGivenSum(int sum)
        {
            List<Tree<T>> listNodes = GetLeafNodes();
            List<List<T>> listPaths = new List<List<T>>();

            foreach (var node in listNodes)
            {
                List<T> currentPathValues = new List<T>();
                var sumPath = 0;
                var nodeTmp = node;

                while (nodeTmp != null)
                {
                    currentPathValues.Add(nodeTmp.Key);
                    sumPath += int.Parse(nodeTmp.Key.ToString());//Convert.ToInt32(nodeTmp.Key); - той има много повече възможности от стандартното парсване, което не може да парсва стандартно дженерици, а само когато са парснати към стринг!
                    nodeTmp = nodeTmp.Parent;
                }
                
                if(sumPath == sum)
                {
                    currentPathValues.Reverse();
                    listPaths.Add(currentPathValues);
                }
            }
            return listPaths;
        }
        ////task 7 - teacher's solution excercise v2+v3
        //public List<List<T>> PathsWithGivenSum2(int sum)
        //{
        //    int currentSum = 0;
        //    List<List<T>> listPaths = new List<List<T>>();
        //    //PathsWithSumDFS1(this, ref currentSum, sum, listPaths, new List<T>());
        //    PathsWithSumDFS2(this, currentSum, sum, listPaths, new List<T>());

        //    return listPaths;
        //}
        ////Task 7 - help method teacher's solution excercise v2
        //private void PathsWithSumDFS1(Tree<T> node, ref int currentSum, //ref int currentSum == Int32 currentSum
        //    int targetSum, List<List<T>> allPaths, List<T> currentPathValues)
        //{
        //    currentSum += Convert.ToInt32(node.Key);
        //    currentPathValues.Add(node.Key);

        //    foreach (var child in node.Children)
        //    {
        //        PathsWithSumDFS1(child, ref currentSum, targetSum, allPaths, currentPathValues);//тъй като тук по референция добавяме текущата сума, по-надолу ще извадим за последия нод при излизане от рекурсията, като преди това проверим дали отговаряме на условието за сума.
        //    }
        //    //Това се случва вече, когато излизаме от рекурсията. При листото сума се проверява и ако е равна се добавя към allPaths. След това сумата на листото се изважда. И ако има ново листо, влизаме в него - добавяме го и проверяваме сумата, след това го изваждаме и т.н.
        //    if (currentSum == targetSum)
        //    {
        //        allPaths.Add(new List<T>(currentPathValues));//Тук ако не подадем new List<T>, а само currentPathValues, защото после махамаме последния елемент и ще счупим резултата. Затова подаваме копие на листа, до който съм стигнал (new List<T>(currentPathValues)).
        //    }

        //    currentSum -= Convert.ToInt32(node.Key);
        //    currentPathValues.RemoveAt(currentPathValues.Count - 1);
        //}

        ////Task 7 - help method Mine - using teacher's solution excercise v2, but changing without ref - v3!!!!!
        //private void PathsWithSumDFS2(Tree<T> node, int currentSum, //NO NEED OF REF
        //    int targetSum, List<List<T>> allPaths, List<T> currentPathValues)
        //{
        //    currentPathValues.Add(node.Key);
        //    currentSum += Convert.ToInt32(node.Key);
        //    foreach (var child in node.Children)
        //    {
        //        PathsWithSumDFS2(child, currentSum, targetSum, allPaths, currentPathValues);
        //    }
        //    if (currentSum == targetSum)
        //    {
        //        allPaths.Add(new List<T>(currentPathValues));
        //    }

        //    currentPathValues.RemoveAt(currentPathValues.Count - 1);//След излизане от рекурсията, currentSum се връща на предходната, но currentPathValues си остава същото, не се изтрива последното, защото това е лист - референтен е!
        //}
        //task 8
        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<T>> listNodes = GetSubtreeNodes();
            List<Tree<T>> listSubtreesWithSum = new List<Tree<T>>();

            foreach (var node in listNodes)
            {
                var sumSubtree = SumSubtree(node);

                if (sumSubtree == sum)
                {
                    listSubtreesWithSum.Add(node);
                }
            }
            return listSubtreesWithSum;
        }
         //Task 2 - Mine - like the teachings from lab
        private List<string> DFS(Tree<T> subtree, int level)
        {
            List<string> list = new List<string>();

            string vs = new string(' ', level);
            list.Add($"{vs}{subtree.Key}");

            foreach (var child in subtree.Children)
            {
                list.AddRange(DFS(child, level + 2));
            }

            return list;
        }

        //Task 2 - teacher from the exercises
        private string GetAsString(int identification = 0)//Override на метода
        {
            var result = new string(' ', identification) + this.Key + "\r\n";//при първия път влиза в root

            foreach (var child in this.Children)
            {
                result += child.GetAsString(identification + 2);//тук при децата
            }

            return result;
        }
        //Task 3 - help method
        private List<Tree<T>> GetLeafNodes()
        {
            List<Tree<T>> list = new List<Tree<T>>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();
                if (subtree.Children.Count == 0)//Only leafs i.e. without children
                {
                    list.Add(subtree);
                }

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return list;
        }

        //Task 8 - help method
        private List<Tree<T>> GetSubtreeNodes()//All nodes in a tree are subtree
        {
            List<Tree<T>> list = new List<Tree<T>>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> subtree = queue.Dequeue();
                list.Add(subtree);

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return list;
        }
        //task 8 - help method
        private int SumSubtree(Tree<T> node)
        {
            int sum = int.Parse(node.Key.ToString());

            foreach (var child in node.Children)
            {
                sum += SumSubtree(child);
            }

            return sum;
        }
    }
}
