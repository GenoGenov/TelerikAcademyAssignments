using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.BitAtPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int p;
            int v;
            string input;

            do
            {
                Console.Write("Number:");
                input = Console.ReadLine();
            } while (!int.TryParse(input,out v));

            do
            {
                Console.Write("Bit position:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out p));

            int mask = 1<<p;
            int numAndmask = mask & v;
            int bitValue=numAndmask >> p;
            bool isOne = bitValue == 1;
            Console.WriteLine("The bit at position {0} of the number {1}( {4} ) is {2}\n{3}",p,v,bitValue,isOne,Convert.ToString(v,2).PadLeft(8,'0'));
            

        }
    }
}
