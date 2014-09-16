namespace _4.RecoverMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Policy;

    internal class Program
    {
        private static Dictionary<char, Node> graph = new Dictionary<char, Node>();

        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var msgPart = Console.ReadLine();

                    for (int j = 0; j < msgPart.Length; j++)
                    {
                        if (!graph.ContainsKey(msgPart[j]))
                        {
                            graph.Add(msgPart[j], new Node(msgPart[j]));
                        }
                        if (j>0)
                        {
                            var parent = graph[msgPart[j - 1]];
                            var node = graph[msgPart[j]];

                            parent.Children.Add(node);
                            node.Parents.Add(parent);
                        }

                    }

                
            }

            var sorted = new List<char>();
            var nodesWithoutParents = new SortedSet<Node>();
            foreach (var node in graph.Values)
            {
                if (node.Parents.Count==0)
                {
                    nodesWithoutParents.Add(node);
                }
            }
            while (nodesWithoutParents.Count>0)
            {
                var node = nodesWithoutParents.First();
                nodesWithoutParents.Remove(node);
                sorted.Add(node.Value);

                foreach (var child in node.Children.ToList())
                {
                    child.Parents.Remove(node);
                    node.Children.Remove(child);
                    if (child.Parents.Count==0)
                    {
                        nodesWithoutParents.Add(child);
                    }

                }
            }

            Console.WriteLine(string.Join("", sorted));

        }

        private class Node:IComparable<Node>
        {
            public Node(char value)
            {
                this.Value = value;
                this.Children = new HashSet<Node>();
                this.Parents=new HashSet<Node>();
            }

            public char Value { get; set; }

            public HashSet<Node> Children { get; set; }

            public HashSet<Node> Parents { get; set; } 

           

            public int CompareTo(Node other)
            {
                return this.Value.CompareTo(other.Value);
            }
        }
    }
}