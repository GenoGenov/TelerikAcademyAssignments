namespace _08.FindMajorant
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
            var elementsCount = values.Count;

            var valuesDictionary = new Dictionary<int, int>();
            foreach (var value in values)
            {
                if (valuesDictionary.ContainsKey(value))
                {
                    valuesDictionary[value]++;
                }
                else
                {
                    valuesDictionary[value] = 1;
                }
            }
            Console.WriteLine(
                              "Majorant {0}",
                              valuesDictionary.Values.Any(x => x >= elementsCount / 2 + 1)
                                  ? "EXISTS: "
                                    + valuesDictionary.FirstOrDefault(x => x.Value >= elementsCount / 2 + 1).Key
                                  : "DOES NOT EXIST");
        }
    }
}