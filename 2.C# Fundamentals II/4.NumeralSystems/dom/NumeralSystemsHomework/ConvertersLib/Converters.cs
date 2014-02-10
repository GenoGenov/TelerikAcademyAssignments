using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="b">the number's base</param>
        /// <returns></returns>
        public static int LowerToDecimal(string number, int b)
        {
            int result = 0;
            number = string.Join("", number.Reverse());
            int c;
            for (int i = 0; i < number.Length; i++)
            {
                if (!int.TryParse(number[i].ToString(), out c) || c>=b)
                {
                    throw new InvalidOperationException("INPUT STRING WAS NOT A CORRECT NUMBER OF THE CORRESPONDING BASE!");
                }
            }
            for (int i = 0; i < number.Length; i++)
            {
                result += int.Parse(number[i].ToString())*(int)Math.Pow(b, i);
            }

            return result;
        }
        /// <summary>
        /// Converts from decimal to numeral systems with base lower than 10.
        /// </summary>
        /// <param name="number">the number in decimal</param>
        /// <param name="b">the desired base</param>
        /// <returns></returns>
        public static string DecimalToLower(int number, int b)
        {
            string result = string.Empty;

            do
            {
                result = number % b + result;
                number = number / b;
            } while (number != 0);

            return result;
        }
        /// <summary>
        /// Converts from numeral systems with higher base to decimal.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="b">the number's base</param>
        /// <returns></returns>
        public static int HigherToDecimal(string number, int b)
        {
            int result = 0;
            number = string.Join("", number.Reverse());
            int c;
            for (int i = 0; i < number.Length; i++)
            {
                if (Enum.GetNames(typeof(Hexa)).Contains(number[i].ToString()))
                {
                    if ((int)Enum.Parse(typeof(Hexa), number[i].ToString()) >= b)
                    {
                        throw new InvalidOperationException("INPUT STRING WAS NOT A CORRECT NUMBER OF THE CORRESPONDING BASE!");
                    }
                    result += (int)Enum.Parse(typeof(Hexa), number[i].ToString()) * (int)Math.Pow(16, i);
                }
                else if (!int.TryParse(number[i].ToString(), out c))
                {
                    throw new InvalidOperationException("INPUT STRING WAS NOT A CORRECT NUMBER OF THE CORRESPONDING BASE!");
                }
                else if (int.Parse(number[i].ToString()) > -1 && int.Parse(number[i].ToString()) < 10)
                {
                    result += int.Parse(number[i].ToString()) * (int)Math.Pow(16, i);
                }
            }
            return result;
        }
    }
}