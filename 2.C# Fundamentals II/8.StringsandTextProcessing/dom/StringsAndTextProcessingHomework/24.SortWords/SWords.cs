//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24.SortWords
{
    class SWords
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String :");
            string text = Console.ReadLine();

            List<string> words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            words.Sort();
            Console.WriteLine();

            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine(words[i]);
            }

        }
    }
}
