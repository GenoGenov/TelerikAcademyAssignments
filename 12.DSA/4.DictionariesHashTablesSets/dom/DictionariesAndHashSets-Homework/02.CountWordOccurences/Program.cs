using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CountWordOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many words would you like to enter:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Start entering the words each on a separate row:");
            var wordsDict = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                if (!wordsDict.ContainsKey(word))
                {
                    wordsDict[word] = 0;
                }

                wordsDict[word]++;
            }

            Console.WriteLine("The words that present odd number of times are:");

            foreach (var i in wordsDict)
            {
                if (i.Value%2!=0)
                {
                    Console.WriteLine(i.Key + " -> " + i.Value + " times");
                }
                
            }
        }
    }
}
