//Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.TrimString
{
    class TrimEquals
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String :");
            string text = Console.ReadLine();
            StringBuilder b = new StringBuilder(text);
            for (int i = text.Length-2; i >= 0; i--)
            {
                char prev = text[i + 1];
                char current = text[i];
                if (prev == current)
                {
                    b.Remove(i + 1, 1);
                }
            }

            Console.WriteLine("Trimmed Text:");
            Console.WriteLine(b.ToString());
        }
    }
}
