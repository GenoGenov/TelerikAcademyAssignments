namespace _01.CalcSumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;
    internal class Program
    {
        private static void Main(string[] args)
        {
            var values = new List<uint>();
            Console.WriteLine("Ok, start entering numbers each followed by new line now");
            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                values.Add(uint.Parse(input));
                input = Console.ReadLine();
            }

            Console.WriteLine("Sum: {0}\nAverage: {1}", values.Sum(x => x), values.Average(x => x));
        }
    }
}