using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LinkedListImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();
            list.AddFirst(2);
            list.AddFirst(1);
            var node = list.Find(2);
            list.AddAfter(node,3);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.AddBefore(node,7);

            Console.WriteLine("----------Adding Before 2-----------------");

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
