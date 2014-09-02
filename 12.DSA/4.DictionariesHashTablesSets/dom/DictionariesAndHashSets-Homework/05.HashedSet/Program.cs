using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HashedSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashedSet<int>();
            set.Add(1);
            set.Add(1);
            set.Add(1);
            set.Add(1);
            Console.WriteLine(set.Count);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(10);

            var otherSet = new HashedSet<int>();
            otherSet.Add(1);
            otherSet.Add(2);
            otherSet.Add(190);

            Console.WriteLine(string.Join(",",set.Union(otherSet)));
            Console.WriteLine(string.Join(",", set.Intersect(otherSet)));
        }
    }
}
