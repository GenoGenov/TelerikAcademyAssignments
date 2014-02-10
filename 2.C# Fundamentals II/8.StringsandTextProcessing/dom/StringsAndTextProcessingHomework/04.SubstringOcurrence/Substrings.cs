//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SubstringOcurrence
{
    class Substrings
    {
        static void Main(string[] args)
        {
            Console.Write("String:");
            string input = Console.ReadLine();
            int i = 0;
            int count = 0;
            while (i<input.Length)
            {
                if (input.IndexOf("in", i, StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    count++;
                    i = input.IndexOf("in", i, StringComparison.InvariantCultureIgnoreCase)+1;
                }
                else
                {
                    i++;
                }
                
                
            }

            Console.WriteLine("Result: {0}", count);
        }
    }
}
