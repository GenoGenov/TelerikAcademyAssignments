using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.SwapBitsWithStep
{
    class Program
    {
        static void Main(string[] args)
        {
            int i,j;
            int[] bits;
            bits = new int[32];
            uint n;
            string input;
            int q;
            int p;

            do
            {
                Console.Write("Number:");
                input = Console.ReadLine();
            } while (!uint.TryParse(input, out n));
            uint temp = n;

            do
            {
                Console.Write("p:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out p));

            do
            {
                Console.Write("q:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out q));

            for (i = 0; i < 32; i++)
            {
                uint mask = (uint)1 << i;
                int numAndmask = (int)(mask & n);
                bits[i] = numAndmask >> i;

            }
            uint newNum;
            for (i = p-1,j=q-1; j < 32; i++,j++)
            {

                if (bits[i] == 0)
                {
                    int mask = ~(1 << j);
                    newNum = (uint)mask & n;
                    n = newNum;
                }
                else
                {
                    int mask = 1 << j;
                    newNum = (uint)mask | n;
                    n = newNum;

                }
                if (bits[j] == 0)
                {
                    int mask = ~(1 << i);
                    newNum = (uint)mask & n;
                    n = newNum;
                }
                else
                {
                    int mask = 1 << i;
                    newNum = (uint)mask | n;
                    n = newNum;

                }
            }

            Console.WriteLine("Old number : {0}\nNew number : {1}", Convert.ToString(temp, 2).PadLeft(32, '0'), Convert.ToString(n, 2).PadLeft(32, '0'));
        }
    }
}
