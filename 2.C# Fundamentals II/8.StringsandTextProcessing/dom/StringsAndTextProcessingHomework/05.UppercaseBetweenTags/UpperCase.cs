using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested

namespace _05.UppercaseBetweenTags
{
    class UpperCase
    {
        static void Main(string[] args)
        {
            Console.Write("String:");
            string input = Console.ReadLine();

            StringBuilder b = new StringBuilder(input);
            int index = 0;
            while (index <= input.Length)
            {
                int checkOpen = input.IndexOf('<',index);
                int checkClose = input.IndexOf('<', checkOpen + 1);
                if (checkOpen != -1)
                {
                    string sub = input.Substring(checkOpen + 8, checkClose - checkOpen - 8);
                    b.Remove(checkOpen, 8+sub.Length+9);
                    b.Insert(checkOpen, sub.ToUpper());
                    input = b.ToString();
                }
                index++;
            }

            Console.WriteLine(input);
        }
    }
}
