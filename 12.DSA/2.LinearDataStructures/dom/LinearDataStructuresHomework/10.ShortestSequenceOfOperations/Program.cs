namespace _10.ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("N=");
            int n = int.Parse(Console.ReadLine());
            Console.Write("M=");
            int m = int.Parse(Console.ReadLine());

            var members = new Queue<int>();
            var visited = new HashSet<int>();

            int operationsCount = 0;
            long current = n;
            members.Enqueue(n);

            while (!members.Contains(m))
            {
                var tempQueue = new Queue<int>();
                for (int i = members.Count-1; i >= 0; i--)
                { 
                    var item = members.Dequeue();
                    if (!visited.Contains(item) && item<m)
                    {
                        tempQueue.Enqueue(item + 1);
                        tempQueue.Enqueue(item + 2);
                        tempQueue.Enqueue(item * 2);
                        visited.Add(item);
                    }
                    
                }
                operationsCount++;
                members = tempQueue;
            }
            Console.WriteLine(operationsCount);
        }
    }
}