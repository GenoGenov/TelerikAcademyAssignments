using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ADTStackImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine("Capacity: "+stack.Capacity);
            stack.Push(4);
            stack.Push(5);
            Console.WriteLine("Capacity: "+stack.Capacity);
            Console.WriteLine("-----------------------------");
            foreach (var i in stack)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-----------------------------");
            stack.TrimExess();
            Console.WriteLine("Capacity: "+stack.Capacity);
        }
    }
}
