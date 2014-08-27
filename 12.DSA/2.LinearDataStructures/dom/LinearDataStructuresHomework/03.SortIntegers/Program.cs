using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SortIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = new List<int>();
            Console.WriteLine("Ok, start entering numbers each followed by new line now");
            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                values.Add(int.Parse(input));
                input = Console.ReadLine();
            }
            values.Sort();
            Console.WriteLine("Values sorted:\n"+string.Join(",",values));
        }
    }
}
