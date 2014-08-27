namespace _04.LongestSubsequenceOfEquals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static List<int> FindLongestSubsequenceOfEquals(List<int> list)
        {
            var longest = 1;
            var current = 1;
            var element = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    current++;
                }
                else
                {
                    if (current > longest)
                    {
                        element = list[i - 1];
                        longest = current;
                    }
                    current = 1;
                }
            }

            return new List<int>(Enumerable.Repeat(element, longest));
        }

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
            var subseq = FindLongestSubsequenceOfEquals(values);
            Console.WriteLine(string.Join(",", subseq));
        }
    }
}