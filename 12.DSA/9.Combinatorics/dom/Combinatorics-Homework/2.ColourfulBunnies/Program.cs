namespace _2.ColourfulBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var bunniesByColor = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());
            var guesses = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (bunniesByColor.ContainsKey(num))
                {
                    if (bunniesByColor[num] < num)
                    {
                        bunniesByColor[num]++;
                    }
                    else
                    {
                        bunniesByColor[num] = 0;
                        guesses.Add(num);
                    }
                }
                else
                {
                    guesses.Add(num);
                    bunniesByColor[num] = 0;
                }
            }
            Console.WriteLine(guesses.Select(x => ++x).Sum());
        }
    }
}