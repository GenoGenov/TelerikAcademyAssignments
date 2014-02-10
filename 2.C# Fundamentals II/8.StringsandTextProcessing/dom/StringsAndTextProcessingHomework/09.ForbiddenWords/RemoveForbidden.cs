//We are given a string containing a list of forbidden words and a text containing some of these words. Write a program that replaces the forbidden words with asterisks. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ForbiddenWords
{
    class RemoveForbidden
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Text :");
            string text = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Forbidden words :");
            string word = Console.ReadLine();
            word = word.Trim();
            string[] words = word.Split(new[]{' ',','}, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder b=new StringBuilder(text);
            for (int i = 0; i < words.Length; i++)
            {
                if (text.Contains(words[i]))
                {
                    b.Replace(words[i], new string('*', words[i].Length));
                }
            }

            Console.WriteLine(b.ToString());
        }
    }
}
