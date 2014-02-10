//Write a program that creates an array containing all letters from the alphabet (A-Z). Read a word from the console and print the index of each of its letters in the array.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.AlphabetLetters
{
    class AlphabetArray
    {
        static void Main(string[] args)
        {
            Console.Write("Word:");
            string input = Console.ReadLine();
            List<char> letters = Enumerable.Range(65, 26).Select(x => (char)x).ToList().Concat(Enumerable.Range(97, 26).Select(x => (char)x).ToList()).ToList();
            Console.WriteLine("Indexes of each letter in the array:");
            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(letters.BinarySearch(input[i]));
            }
        }
    }
}
