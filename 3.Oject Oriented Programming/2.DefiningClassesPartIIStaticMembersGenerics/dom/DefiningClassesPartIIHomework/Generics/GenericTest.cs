using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class GenericTest
    {
        public static void Main(string[] args)
        {
            var l = new GenericList<int>();

            l.Add(3);
            l.Add(4);
            l.Add(235252532);

            Console.WriteLine(l);

            l.Insert(1, 2);
            Console.WriteLine(l);

            Console.WriteLine(l.Find(4));

            l.RemoveAt(1);
            Console.WriteLine(l);

            l.Add(1);
            l.Add(7);
            l.Add(1);
            l.Add(9);
            l.Add(3);
            l.Add(2);
            l.Add(6);
            l.Add(8);
            Console.WriteLine(l);

            Console.WriteLine(l.Min());
            Console.WriteLine(l.Max());
            l.Clear();
            Console.WriteLine(l);
        }
    }
}