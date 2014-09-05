using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ProductsPriceInRange
{
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main(string[] args)
        {
            var products = new OrderedMultiDictionary<int, string>(false);
            Console.WriteLine("Adding products...");
            for (int i = 0; i < 500000; i++)
            {
                products.Add(i,"product"+i);
            }
            Console.WriteLine("Done!");
            Console.WriteLine();
            Console.WriteLine("Performing queries...");
            for (int i = 0; i < 10000; i++)
            {
                var prodictsInRange = products.Where(x => x.Key >= i && x.Key <= i * 50);
            }
            Console.WriteLine("Done!");
        }
    }
}
