//Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22.WordsCount
{
    class Words
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String :");
            string text = Console.ReadLine();

            List<string> checkedWords = new List<string>();
            string[] words = text.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> count = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (!checkedWords.Contains(word))
                {
                    count.Add(word, words.Count(x => x == word));
                    checkedWords.Add(word);
                }
            }
            List<KeyValuePair<string, int>> sorted = count.ToList();

            sorted.Sort((x, y) => { return y.Value.CompareTo(x.Value); });
            foreach (var item in sorted)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }
        }
    }
}
