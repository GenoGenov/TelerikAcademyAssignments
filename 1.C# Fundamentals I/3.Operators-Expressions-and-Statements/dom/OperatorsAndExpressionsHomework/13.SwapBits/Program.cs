using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.SwapBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int p;
            int[] bits;
            bits = new int[32];
            uint n;
            string input;

            do
            {
                Console.Write("Number:");
                input = Console.ReadLine();
            } while (!uint.TryParse(input, out n));
            uint temp=n;

            for (p= 0; p < 32; p++)
            {
                uint mask = (uint)1 << p;
                int numAndmask = (int)(mask & n);
                bits[p] = numAndmask >> p;
                
            }
            uint newNum;
            for (p = 24; p < 27; p++)
            {

            if(bits[p-21]==0)
            {
                int mask = ~(1 << p);
                newNum = (uint)mask & n;
                n = newNum;
            }
            else
            {
                int mask = 1 << p;
                newNum = (uint)mask | n;
                n = newNum;

            }
            if (bits[p] == 0)
            {
                int mask = ~(1 << (p-21));
                newNum = (uint)mask & n;
                n = newNum;
            }
            else
            {
                int mask = 1 << (p-21);
                newNum = (uint)mask | n;
                n = newNum;

            }
            }

            Console.WriteLine("Old number : {0}\nNew number : {1}",Convert.ToString(temp,2).PadLeft(32,'0'),Convert.ToString(n,2).PadLeft(32,'0'));

        }
    }
}
