namespace _06.RemoveWithOddNumberOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var values = new List<int>();
            Console.WriteLine("Ok, start entering numbers each followed by new line now");
            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                values.Add(int.Parse(input));
                input = Console.ReadLine();
            }

            var toRemove = new HashSet<int>(values.FindAll(x => values.Count(y => y == x) % 2 != 0));
            foreach (var i in toRemove)
            {
                values.RemoveAll(x => x == i);
            }

            Console.WriteLine("Removed the elements taht occur odd number of times:\n" + string.Join(",", values));
        }
    }
}