using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> messages = new Dictionary<string, int>();
            messages.Add("Rawr", 0);
            messages.Add("Rrrr", 1);
            messages.Add("Hsst", 2);
            messages.Add("Ssst", 3);
            messages.Add("Grrr", 4);
            messages.Add("Rarr", 5);
            messages.Add("Mrrr", 6);
            messages.Add("Psst", 7);
            messages.Add("Uaah", 8);
            messages.Add("Uaha", 9);
            messages.Add("Zzzz", 10);
            messages.Add("Bauu", 11);
            messages.Add("Djav", 12);
            messages.Add("Myau", 13);
            messages.Add("Gruh", 14);

            decimal result = 0;
            decimal count = 1;
            for (int i = input.Length - 1; i >= 3; i--)
            {
                string word = input.Substring(i - 3, 4);
                if (messages.ContainsKey(word))
                {
                    result += count * messages[word];
                    count *= 15m;
                }

            }
            Console.WriteLine(result);
        }
    }
}
