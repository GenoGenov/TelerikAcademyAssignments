//Write a program that extracts from a given text all sentences containing given word.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ExtractSentences
{
    class Sentences
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String :");
            string text = Console.ReadLine();
            Console.WriteLine("word to search :");
            string word = Console.ReadLine();

            string[] sentences = text.Split(new[]{'.'},StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < sentences.Length; i++)
            {
                sentences[i]=sentences[i].Trim();
                string[] words = sentences[i].Split(' ');
                if (words.Contains(word))
                {
                    Console.WriteLine(sentences[i]);
                }
            }
        }
    }
}
