//Write a program for extracting all email addresses from given text. All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.ExtractEmails
{
    class ExtractMails
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String :");
            string text = Console.ReadLine();

            string[] words = text.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine();
            Console.WriteLine("mails:");
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains("@") && words[i].Contains("."))
                {
                    Console.WriteLine(words[i]);
                }
            }


        }
    }
}
