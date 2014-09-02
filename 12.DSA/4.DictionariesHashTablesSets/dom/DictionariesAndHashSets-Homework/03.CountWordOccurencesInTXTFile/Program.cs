namespace _03.CountWordOccurencesInTXTFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {

            var reader = new StreamReader("..//..//text.txt", Encoding.UTF8);
            string[] words;
            using (reader)
            {
                words =
                    reader.ReadToEnd()
                          .Split(new[] { ' ', '.', '!', '?', '-', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(x => x.ToLower())
                          .ToArray();
            }
            var wordsDict = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (!wordsDict.ContainsKey(word))
                {
                    wordsDict[word] = 0;
                }

                wordsDict[word]++;
            }

            var sortedWords = wordsDict.OrderBy(x => x.Value);
            foreach (var i in sortedWords)
            {
                Console.WriteLine(i.Key + " -> " + i.Value + " times");
            }
        }
    }
}