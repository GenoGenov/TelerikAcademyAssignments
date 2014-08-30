using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;
namespace _01.ParseTree
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("..//..//input.txt"));

            var tree = ParseTree();

            //Display the root 
            Console.WriteLine("Root Node: {0}",tree.Root.Value);

            //Display the leafs
            var leafs = new List<Node<int>>();
            tree.GetLeafs(ref leafs);
            Console.WriteLine("Leafs:");
            Console.WriteLine(string.Join(",",leafs.Select(x=>x.Value)));

            //Display middle nodes
            leafs=new List<Node<int>>();
            tree.GetMiddleNodes(ref leafs);
            Console.WriteLine("Middle Nodes:");
            Console.WriteLine(string.Join(",", leafs.Select(x => x.Value)));

            //Display longest path
            Node<int> node;
            int path = tree.GetLongestPath(out node);
            Console.WriteLine("Longest path is {0} and the end Node is {1}",path,node.Value);

            //Display paths with sum n
            Console.Write("Paths sum:");
            int n = int.Parse(Console.ReadLine());
            var paths = GetPathsWithSum(n, tree.Root);
            Console.WriteLine("The paths that equal {0} and start from {1} are:",n,tree.Root.Value);
            foreach (var p in paths)
            {
                Console.WriteLine(string.Join(",",p.Select(x=>x.Value)));
            }
        }

        static Tree<int> ParseTree()
        {
            var nodes = new Dictionary<int, Node<int>>();
            Console.Write("Number of nodes:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Start typing the node pairs separated by a single space");
            
            for (int i = 0; i < n-1; i++)
            {
                var pair = Console.ReadLine().Split();
                int first = int.Parse(pair[0]);
                int second = int.Parse(pair[1]);
                if (!nodes.ContainsKey(first))
                {
                    Node<int> parent = new Node<int>(first);
                    nodes.Add(first, parent);
                }

                if (!nodes.ContainsKey(second))
                {
                    Node<int> newNode = new Node<int>(second);
                    newNode.HasParent = true;
                    nodes.Add(second,newNode);
                    nodes[first].Children.Add(newNode);
                }

                nodes[first].Children.Add(nodes[second]);
                nodes[second].HasParent=true;

                
            }
            var root = nodes.First(x => x.Value.HasParent == false);
            var tree = new Tree<int>(root.Value);
            return tree;
        }

        private static void GetPaths(ref List<Node<int>> temp, ref List<List<Node<int>>> result, Node<int> startNode, int n)
        {
            if (temp.Count==0)
            {
                temp.Add(startNode);
            }

            foreach (var child in startNode.Children)
            {
                temp.Add(child);

                if (temp.Sum(x=>x.Value)==n)
                {
                    result.Add(new List<Node<int>>(temp));
                }

                GetPaths(ref temp, ref result, child, n);
                temp.Remove(child);
            }
        }

        public static List<List<Node<int>>> GetPathsWithSum(int sum, Node<int> startNode)
        {
            var temp = new List<Node<int>>();
            var result = new List<List<Node<int>>>();
            GetPaths(ref temp, ref result, startNode, sum);
            return result;
        }
    }
}
