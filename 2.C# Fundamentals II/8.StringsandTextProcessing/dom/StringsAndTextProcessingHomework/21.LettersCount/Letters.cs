//Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.LettersCount
{
    class Letters
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String :");
            string text = Console.ReadLine();

            List<char> checkedLetters = new List<char>();
            Dictionary<char, int> count = new Dictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                if (letter != ' ' && !checkedLetters.Contains(letter))
                {
                    count.Add(letter, text.Count(x => x == letter));
                    checkedLetters.Add(letter);
                }
            }
            List<KeyValuePair<char, int>> sorted = count.ToList();

            sorted.Sort((x, y) => { return y.Value.CompareTo(x.Value); });
            foreach (var item in sorted)
            {
                Console.WriteLine("{0} - {1}",item.Key,item.Value);
            }
        }
    }
}
