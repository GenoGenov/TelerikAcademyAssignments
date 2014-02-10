//Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.UnicodeLiterals
{
    class Unicode
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String :");
            string text = Console.ReadLine();

            char[] unicodes = text.ToCharArray();
            for (int i = 0; i < unicodes.Length; i++)
            {
                Console.Write("\\u"+((int)unicodes[i]).ToString("X").PadLeft(4,'0'));
            }
            Console.WriteLine();
        }
    }
}
