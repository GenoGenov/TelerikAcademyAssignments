namespace _1.FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    internal class Program
    {
        private static HashSet<Node<int>> hospitals = new HashSet<Node<int>>();

        private static void Main(string[] args)
        {
            var points =
                Console.ReadLine()
                       .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToArray();

            int m = points[1];

            var graph = new Graph<int>();
            var hospitalsPoints =
                Console.ReadLine()
                       .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToArray();
            for (int i = 0; i < hospitalsPoints.Length; i++)
            {
                var node = new Node<int> { Value = hospitalsPoints[i] };
                hospitals.Add(node);

                graph.Nodes.Add(hospitalsPoints[i], node);
            }

            for (int i = 0; i < m; i++)
            {
                var street = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                graph.AddConnection(street[0], street[1], street[2]);
            }
            int minDistance = int.MaxValue;
            foreach (var hospital in hospitals)
            {
                var sumOfDistances = FindMinSumOfDistances(hospital, graph);
                if (sumOfDistances < minDistance)
                {
                    minDistance = sumOfDistances;
                }
            }
            Console.WriteLine(minDistance);
        }

        private static int FindMinSumOfDistances(Node<int> hospital, Graph<int> graph)
        {
            var queue = new OrderedSet<Node<int>>();

            foreach (var node in graph.Nodes.Values)
            {
                node.DijkstraDistance = int.MaxValue;
            }
            hospital.DijkstraDistance = 0;
            queue.Add(hospital);
            while (queue.Count > 0)
            {
                var node = queue.RemoveFirst();

                foreach (var n in node.Connections)
                {
                    var distance = node.DijkstraDistance + n.Weight;
                    if (distance < n.Destination.DijkstraDistance)
                    {
                        n.Destination.DijkstraDistance = distance;
                        queue.Add(n.Destination);
                    }
                }
            }
            return graph.Nodes.Where(x => !hospitals.Contains(x.Value)).Sum(x => x.Value.DijkstraDistance);
        }

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

            public void AddConnection(T source, T destination, T weight)
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
                this.Nodes[destination].Connections.Add(
                                                        new Edge<T>
                                                            {
                                                                Destination = this.Nodes[source],
                                                                Weight = weight
                                                            });
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