namespace _14.ImplementLinkedQueue
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var myQueue = new LinkedQueue<int>();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            foreach (var val in myQueue)
            {
                Console.WriteLine(val);
            }
            Console.WriteLine("------------------------");
            var num = myQueue.Dequeue();
            Console.WriteLine("Dequeued value: " + num);
            Console.WriteLine("------------------------");

            foreach (var val in myQueue)
            {
                Console.WriteLine(val);
            }

            var arr = myQueue.ToArray();
            Console.WriteLine("To Array:\n" + string.Join(",", arr));

            myQueue.Clear();

            Console.WriteLine("-------------Cleared-------------");
            myQueue.Enqueue(5);
            myQueue.Enqueue(6);
            myQueue.Enqueue(7);
            myQueue.Enqueue(8);
            foreach (var val in myQueue)
            {
                Console.WriteLine(val);
            }
        }
    }
}