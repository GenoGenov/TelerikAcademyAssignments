namespace _07.FindOccurenceCount
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
                var valueParsed = int.Parse(input);
                if (valueParsed >= 0 && valueParsed <= 1000)
                {
                    values.Add(int.Parse(input));
                }
                else
                {
                    Console.WriteLine("That number does not belong in the interval [0;1000] !");
                }
                input = Console.ReadLine();
            }

            var grouped = values.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()).OrderBy(x => x.Value);
            foreach (var item in grouped)
            {
                Console.WriteLine("{0} Times -> {1}", item.Value, item.Key);
            }
        }
    }
}