using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable<int, string>();
            table.Add(5,"Pencho");
            table.Add(1,"Mariika");
            table.Add(199,"Kircho");

            Console.WriteLine(table.Find(1));
            Console.WriteLine(string.Join(",",table.Keys));
            foreach (var val in table)
            {
                Console.WriteLine(val.Value);
            }
            table.Remove(199);
            foreach (var val in table)
            {
                Console.WriteLine(val.Value);
            }

            Console.WriteLine(table.Count);
            Console.WriteLine(table.Capacity);

            table.Add(10, "Pencho");
            table.Add(11, "Mariika");
            table.Add(12, "Kircho");
            table.Add(13, "Pencho");
            table.Add(14, "Mariika");
            table.Add(15, "Kircho");
            table.Add(16, "Pencho");
            table.Add(17, "Mariika");
            table.Add(18, "Kircho");
            table.Add(19, "Pencho");
            table.Add(20, "Mariika");
            table.Add(21, "Kircho");
            table.Add(22, "Pencho");
            table.Add(23, "Mariika");
            table.Add(24, "Kircho");
            table.Add(25, "Pencho");
            table.Add(26, "Mariika");
            table.Add(27, "Kircho");
            table.Add(28, "Pencho");
            table.Add(29, "Mariika");
            table.Add(30, "Kircho");

            Console.WriteLine(table.Find(19));
            Console.WriteLine(table.Capacity);
        }
    }
}
