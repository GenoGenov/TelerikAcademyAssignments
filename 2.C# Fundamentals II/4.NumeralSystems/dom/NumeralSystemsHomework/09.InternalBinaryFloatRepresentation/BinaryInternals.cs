using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _05.HexadecimalToBinary;

namespace _09.InternalBinaryFloatRepresentation
{
    
    class BinaryInternals
    {
        public static string FloatToBinaryConverter(float value)
        {
            int bitCount = sizeof(float) * 8;
            char[] result = new char[bitCount];


            int intValue = System.BitConverter.ToInt32(BitConverter.GetBytes(value), 0);

            for (int bit = 0; bit < bitCount; ++bit)
            {
                int maskedValue = intValue & (1 << bit); 
                if (maskedValue > 0)
                    maskedValue = 1;

                result[bitCount - bit - 1] = maskedValue.ToString()[0];
            }

            return new string(result);
        }
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            float number;
            string input;

            do
            {
                Console.Write("Float Number:");
                input = Console.ReadLine();
            } while (!float.TryParse(input,out number));

            string bin = FloatToBinaryConverter(number);
            string mantissa = bin.Substring(8, 23);
            string exponent = bin.Substring(1, 8);
            string sign = bin.Substring(0, 1);

            Console.WriteLine("Mantissa: {0}\nExponent: {1}\nSign: {2}",mantissa,exponent,sign);
        }
    }
}
