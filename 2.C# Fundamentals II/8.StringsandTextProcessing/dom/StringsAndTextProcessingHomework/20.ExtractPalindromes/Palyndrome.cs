//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.ExtractPalindromes
{
    class Palyndrome
    {
        static bool IsPalyndrome(string str)
        {
            Stack<char> s = new Stack<char>();
            Queue<char> q = new Queue<char>();

            for (int i = 0; i < str.Length; i++)
            {
                s.Push(str[i]);
                q.Enqueue(str[i]);
            }
            bool flag = true;
            for (int j = 0; j < str.Length; j++)
            {
                if (s.Pop() != q.Dequeue())
                {
                    flag = false;
                }
            }
            if (flag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("String :");
            string text = Console.ReadLine();

            string[] words = text.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine();
            Console.WriteLine("palyndromes:");
            for (int i = 0; i < words.Length; i++)
            {
                if (IsPalyndrome(words[i]))
                {
                    Console.WriteLine(words[i]);
                }
            }

        }
    }
}
