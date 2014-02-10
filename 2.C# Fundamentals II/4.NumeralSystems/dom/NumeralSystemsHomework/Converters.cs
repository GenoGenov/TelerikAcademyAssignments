using System;
namespace ConverterClass
{


    public class Converters
    {
        public enum Hexa { A = 10, B, C, D, E, F };
        /// <summary>
        /// Converts from decimal to numeral systems with base higher than 10.
        /// </summary>
        /// <param name="number">The number in decimal</param>
        /// <param name="b">Base of the numeral system to convert to</param>
        /// <returns></returns>
        public static string DecimalToHigher(int number, int b)
        {
            string result = string.Empty;

            do
            {
                if (number % b > 9)
                {
                    result = (Hexa)(number % b) + result;
                }
                else
                {
                    result = number % b + result;
                }
                number = number / b;
            } while (number != 0);

            return result;
        }
        /// <summary>
        /// Converts to decimal from numeral systems with base lower than 10.
        /// </summary>
        /// <param name="number">The number in decimal</param>
        /// <param name="b">Base of the numeral system to convert to</param>
        /// <returns></returns>
        public static int LowerToDecimal(string number, int b)
        {
            int result = 0;
            n = string.Join("", n.Reverse());

            for (int i = 0; i < number.Length; i++)
            {
                result += result += (int)Math.Pow(b, i);
            }

            return result;
        }
    }
}