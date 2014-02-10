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
            messages.Add("CHU", 0);
            messages.Add("TEL", 1);
            messages.Add("OFT", 2);
            messages.Add("IVA", 3);
            messages.Add("EMY", 4);
            messages.Add("VNB", 5);
            messages.Add("POQ", 6);
            messages.Add("ERI", 7);
            messages.Add("CAD", 8);
            messages.Add("K-A", 9);
            messages.Add("IIA", 10);
            messages.Add("YLO", 11);
            messages.Add("PLA", 12);

            decimal result = 0;
            decimal count = 1;
            for (int i = input.Length - 1; i >= 2; i--)
            {
                string word = input.Substring(i - 2, 3);
                if (messages.ContainsKey(word))
                {
                    result += count * messages[word];
                    count *= 13m;
                }

            }
            Console.WriteLine(result);
        }
    }
}
