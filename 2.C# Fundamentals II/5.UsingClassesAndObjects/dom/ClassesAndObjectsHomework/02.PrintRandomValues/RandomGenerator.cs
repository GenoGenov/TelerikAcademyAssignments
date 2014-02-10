using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PrintRandomValues
{
    class RandomGenerator
    {
        static Random rand;

        public static int[] Generate(int start, int end)
        {
            rand = new Random();
            int[] r = new int[end - start];
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = rand.Next(start, end + 1);
            }
            return r;
        }
    }
}
