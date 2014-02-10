using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ModifyBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int p;
            int v;
            int n;
            string input;

            do
            {
                Console.Write("Number:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n));

            do
            {
                Console.Write("Bit position:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out p));

            do
            {
                Console.Write("Value of the bit(0 or 1):");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out v) || !(v==0 || v==1));
            int newNum;
            if(v==0)
            {
                int mask = ~(1 << p);
                newNum = mask & n;
            }
            else
            {
                int mask = 1 << p;
                newNum = mask | n;

            }
            
            
            Console.WriteLine("The bit at position {0} of the number {1}( {2} ) has been changed to {3}( {4} )", p, n, Convert.ToString(n, 2).PadLeft(8, '0'),v,Convert.ToString(newNum,2).PadLeft(8,'0'));
        }
    }
}
