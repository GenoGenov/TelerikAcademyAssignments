//Write a program to check if in a given expression the brackets are put correctly.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BracketsCheck
{
    class Brackets
    {
        static void Main(string[] args)
        {
            Console.Write("String:");
            string input = Console.ReadLine();
            int openCount = 0;
            int closeCount = 0;

            openCount = input.Count(x => x == '(');
            closeCount=input.Count(x=> x==')');

            if (openCount == closeCount)
            {
                Console.WriteLine("Backets are correctly placed!");

            }
            else
            {
                Console.WriteLine("Brackets are incorrect!");
            }
        }
    }
}
