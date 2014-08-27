namespace _09.First50MembersOfSequence
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var members = new Queue<long>();
            Console.Write("N=");
            int n = int.Parse(Console.ReadLine());

            members.Enqueue(n);
            int index = 1;
            while (index <= 50)
            {
                long current = members.Dequeue();

                Console.WriteLine("{0} = {1}", index, current);

                members.Enqueue(current + 1);
                members.Enqueue(2 * current + 1);
                members.Enqueue(current + 2);
                index++;
            }
        }
    }
}