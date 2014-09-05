using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FindWordsInText
{
    using System.IO;

    class Program
    {
        static Random rand=new Random();

        static string[] words=new string[10000];
        static void GenerateRandomWords()
        {
            for (int i = 0; i < 10000; i++)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < 5; j++)
                {
                    sb.Append((char)rand.Next(65, 95));
                }
                words[i] = sb.ToString();
                sb.Clear();
            }
           
            
        }

        static string GetRandomWord()
        {
            var sb = new StringBuilder();
            for (int j = 0; j < 5; j++)
            {
                sb.Append((char)rand.Next(65, 95));
            }
            return sb.ToString();
        }

        static void GenerateText(string path)
        {
            var writer = new StreamWriter(path,false);
            using (writer)
            {
                for (int i = 0; i < 10000000; i++)
                {
                    writer.Write(GetRandomWord()+" ");
                }
                writer.Flush();
            }
        }

        static void Main(string[] args)
        {
            GenerateRandomWords();
            GenerateText("..//..//text.txt");

            Dictionary<string,int> wordsCount=new Dictionary<string, int>();

            var trie=new Trie<string>();
            var reader = new StreamReader("..//..//text.txt");
            
            string result = reader.ReadToEnd();
            reader.Close();

            var wordsWritten = result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < 10000; i++)
            {
                trie.Put( words[i], i.ToString());
            }

            foreach (var word in wordsWritten)
            {
                foreach (var c in word)
                {
                    if (!trie.Matcher.NextMatch(c))
                    {
                        break;
                    }
                }
                if (trie.Matcher.IsExactMatch())
                {
                    var w = trie.Matcher.GetPrefix();
                    if (!wordsCount.ContainsKey(w))
                    {
                        wordsCount[w] = 0;
                    }
                    wordsCount[w]++;
                }
                trie.Matcher.ResetMatch();
               
            }

            Console.WriteLine("There are {0} matched words in the dictionary wordsCount",wordsCount.Count);
        }
    }
}
