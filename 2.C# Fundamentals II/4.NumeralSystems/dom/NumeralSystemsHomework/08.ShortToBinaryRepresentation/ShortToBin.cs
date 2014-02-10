using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ShortToBinaryRepresentation
{
    class ShortToBin
    {
        static void Main(string[] args)
        {
            short s;
            string input;

            do
            {
                Console.Write("Short Value:");
                input = Console.ReadLine();
            } while (!short.TryParse(input,out s));

            Console.WriteLine("The binary representation: {0}",Convert.ToString(s,2).PadLeft(16,'0'));
        }
    }
}
