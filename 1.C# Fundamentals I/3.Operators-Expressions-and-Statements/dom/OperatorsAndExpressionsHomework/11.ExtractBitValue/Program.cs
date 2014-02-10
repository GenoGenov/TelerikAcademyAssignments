using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ExtractBitValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int b;
            int i;
            string input;

            do
            {
                Console.Write("Number:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out i));

            do
            {
                Console.Write("Bit position:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out b));

            int mask = 1 << b;
            int numAndmask = mask & i;
            int bitValue = numAndmask >> b;
            bool isOne = bitValue == 1;
            int value;
            if (isOne)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            Console.WriteLine("The bit at position {0} of the number {1}( {3} ) is {2}", b, i, bitValue, iConvert.ToString(i, 2).PadLeft(8, '0'));
        }
    }
}
