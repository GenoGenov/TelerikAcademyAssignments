namespace Tree
{
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T>
    {
        private Node<T> root;

        public Tree(T value)
        {
            this.root = new Node<T>(value);
        }

        public Tree(Node<T> rootNode)
        {
            this.root = rootNode;
        }

        public Node<T> Root
        {
            get
            {
                return this.root;
            }
        }

        public void GetLeafs(ref List<Node<T>> result, Node<T> startNode = null)
        {
            if (startNode == null)
            {
                startNode = this.root;
            }
            foreach (var child in startNode.Children)
            {
                if (child.Children.Count == 0)
                {
                    result.Add(child);
                }
                else
                {
                    this.GetLeafs(ref result, child);
                }
            }
        }

        public void GetMiddleNodes(ref List<Node<T>> result, Node<T> startNode = null)
        {
            if (startNode == null)
            {
                startNode = this.root;
            }
            foreach (var child in startNode.Children)
            {
                if (child.Children.Count != 0)
                {
                    result.Add(child);
                }
                else
                {
                    this.GetLeafs(ref result, child);
                }
            }
        }

        private void GetFarthestLeafPaths(int n, Dictionary<int, Node<T>> paths, Node<T> startNode = null)
        {
            if (startNode == null)
            {
                startNode = this.root;
            }
            foreach (var child in startNode.Children)
            {
                if (child.Children.Count == 0)
                {
                    paths[n] = child;
                }
                else
                {
                    n++;
                    this.GetFarthestLeafPaths(n, paths, child);
                    n--;
                }
            }
        }

        public int GetLongestPath(out Node<T> endNode)
        {
            var paths = new Dictionary<int, Node<T>>();
            this.GetFarthestLeafPaths(1, paths);
            endNode = paths[paths.Keys.Max()];
            return paths.Keys.Max();
        }

    
    }
}