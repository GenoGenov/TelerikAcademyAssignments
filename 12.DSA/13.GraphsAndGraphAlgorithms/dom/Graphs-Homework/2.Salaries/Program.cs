namespace _2.Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static Graph<int> graph = new Graph<int>();

        private static Dictionary<Node<int>,long> used = new Dictionary<Node<int>,long>();

        private static List<Node<int>> sorted = new List<Node<int>>();

        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var relations = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    if (relations[j] == 'Y')
                    {
                        graph.AddConnection(i, j, 1);
                    }
                }
            }
            //var node = graph.Nodes.Values.FirstOrDefault(x => !used.Contains(x));
            //while (node != null)
            //{
            //    TP(node);
            //    node = graph.Nodes.Values.FirstOrDefault(x => !used.Contains(x));
            //}

            long total = 0;
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                total += CalcSalary(graph.Nodes[i]);
            }

            Console.WriteLine(total);
        }

        static long CalcSalary(Node<int> node )
        {
            if (used.ContainsKey(node))
            {
                return used[node];
            }

            long result = 0;
            if (node.Connections.Count==0)
            {
                used.Add(node,1);
                return 1;
                
            }
            
            foreach (var connection in node.Connections)
            {
                    result+= CalcSalary(connection.Destination);
                    
            }
            used.Add(node,result);
            return result;
        }

        //private static void TP(Node<int> node)
        //{
        //    if (used.Contains(node))
        //    {
        //        return;
        //    }
        //    used.Add(node);
        //    foreach (var connection in node.Connections)
        //    {
        //        TP(connection.Destination);
        //    }
           
        //    sorted.Add(node);
        //}

        public class Edge<T>
            where T : IComparable<T>
        {
            public Node<T> Destination { get; set; }

            public T Weight { get; set; }
        }

        public class Graph<T>
            where T : IComparable<T>
        {
            public Graph()
            {
                this.Nodes = new Dictionary<T, Node<T>>();
            }

            public Dictionary<T, Node<T>> Nodes { get; set; }

            public void AddConnection(T source, T destination, T weight, bool oneWay = true)
            {
                var n = new Node<T>() { Value = source };
                if (!this.Nodes.ContainsKey(source))
                {
                    this.Nodes.Add(source, new Node<T>() { Value = source });
                }

                if (!this.Nodes.ContainsKey(destination))
                {
                    this.Nodes.Add(destination, new Node<T>() { Value = destination });
                }

                this.Nodes[source].Connections.Add(
                                                   new Edge<T>
                                                       {
                                                           Destination = this.Nodes[destination],
                                                           Weight = weight
                                                       });
                if (!oneWay)
                {
                    this.Nodes[destination].Connections.Add(
                                                            new Edge<T>
                                                                {
                                                                    Destination = this.Nodes[source],
                                                                    Weight = weight
                                                                });
                }
            }
        }

        public class Node<T> : IComparable<Node<T>>
            where T : IComparable<T>
        {
            public Node()
            {
                this.Connections = new List<Edge<T>>();
            }

            public T Value { get; set; }

            public List<Edge<T>> Connections { get; set; }

            public int DijkstraDistance { get; set; }

            public int CompareTo(Node<T> other)
            {
                return this.Value.CompareTo(other.Value);
            }

            public override int GetHashCode()
            {
                return this.Value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                return this.Value.Equals((obj as Node<T>).Value);
            }
        }
    }
}