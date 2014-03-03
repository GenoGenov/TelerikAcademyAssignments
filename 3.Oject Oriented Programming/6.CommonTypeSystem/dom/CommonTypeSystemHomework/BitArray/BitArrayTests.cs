using System;
using System.Linq;

namespace BitArray
{
    public class BitArrayTests
    {
        private static void Main(string[] args)
        {
            BitArray64 array = new BitArray64();

            array[3] = 1;
            array[9] = 1;

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Bit {0} : {1}", i, array[i]);
            }

            Console.WriteLine(array);
        }
    }
}