//A dictionary is stored as a sequence of text lines containing words and their explanations. Write a program that enters a word and translates it by using the dictionary. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> theDict = new Dictionary<string, string>();

            theDict.Add(".NET", "platform for applications from Microsoft");
            theDict.Add("CLR" , "managed execution environment for .NET");
            theDict.Add("namespace", "hierarchical organization of classes");
            theDict.Add("Gosho Otpochivka", "Bulgarian retard");
            theDict.Add("BigSha", "Bulgarian hip-hop singer wannabe");
            theDict.Add("Kilata Maika", "Just kilata");
            theDict.Add("The Priest from Hisarya", "dunno");

            Console.WriteLine("Dictionary entries:");
            foreach (var item in theDict)
            {
                Console.WriteLine(item.Key);
            }


            Console.WriteLine("Type a key to get the explanation:");
            string key = Console.ReadLine();
            string input;
            if (theDict.TryGetValue(key, out input))
            {
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine("wrong key! Try again");
            }

        }
    }
}
