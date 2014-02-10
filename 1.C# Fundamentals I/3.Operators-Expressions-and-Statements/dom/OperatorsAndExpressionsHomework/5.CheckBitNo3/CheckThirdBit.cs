using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.CheckBitNo3
{
    class CheckThirdBit
    {
        static void Main(string[] args)
        {
            Console.Write("Write a whole number:");
            int number = int.Parse(Console.ReadLine());
            int p = 3;
            int mask = 1 << p;
            int numAndmask = number & mask;
            int bit = numAndmask >> p;
            Console.WriteLine("The bit at position {0} of the number {1} is {2}",p,number,bit);
        }
    }
}
