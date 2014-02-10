//Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with '*'. Print the result string into the console.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.AppendStars
{
    class Append
    {
        static void Main(string[] args)
        {
            string input;
            
            do
            {
                Console.Write("String: ");
                input = Console.ReadLine();

            } while (input.Length>20);

            StringBuilder b=new StringBuilder(input);

            if (input.Length < 20)
            {
               
                b.Append('*', 20 - input.Length);
            }
            Console.WriteLine(b.ToString());
        }
    }
}
