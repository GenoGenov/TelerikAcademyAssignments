using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> words = new List<string>();
            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine());
            }
            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];
                int newPos = word.Length % (n + 1);
                words.Insert(newPos, word);
                int index=i;
                if (newPos < i)
                {
                    index++;
                }
                words.RemoveAt(index);
            }

            StringBuilder b = new StringBuilder();

            string longest=string.Empty;
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Length > longest.Length)
                {
                    longest = words[i];
                }
            }

            for (int i = 0; i < longest.Length; i++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if (words[j].Length > i)
                    {
                        b.Append(words[j][i]);
                    }
                }
               
            }
            Console.WriteLine(b.ToString());
        }
    }
}
