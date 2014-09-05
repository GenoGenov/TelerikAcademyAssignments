using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new PriorityQueue<int>();

            queue.Enqueue(5);
            queue.Enqueue(8);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(11);

            foreach (var i in queue)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("*******Removed value:{0}",queue.Dequeue());
            foreach (var i in queue)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("*******Removed value:{0}", queue.Dequeue());
            foreach (var i in queue)
            {
                Console.WriteLine(i);
            }
        }
    }
}
