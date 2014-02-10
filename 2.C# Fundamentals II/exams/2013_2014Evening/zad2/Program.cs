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
            string input = Console.ReadLine();
            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder b = new StringBuilder();
            int longest = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > longest)
                {
                    longest = words[i].Length;
                }
            }

            for (int i = 0; i < longest; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j].Length > i)
                    {
                        b.Append(words[j][words[j].Length - i - 1]);
                    }
                }
            }
            string message = b.ToString();
            for (int j = 0; j < b.Length; j++)
            {
                char l = b[j];
                int k = (int)char.ToLower(l) - 'a' + 1;
                int index = j + k;
                
                index = index % b.Length;
                b.Remove(j, 1);
                b.Insert(index, l);

            }
            Console.WriteLine(b.ToString());
        }
    }
}
