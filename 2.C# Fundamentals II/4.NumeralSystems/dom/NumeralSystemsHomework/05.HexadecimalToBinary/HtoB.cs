using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DecimalToBinary;
using _04;
using _03.DecimalToHexadecimal;

namespace _05.HexadecimalToBinary
{
    public class HtoB
    {
        public static string HexadecimalToBinaryConverter(string hex)
        {
            string result = string.Empty;
            int c;
            for (int i = 0; i < hex.Length; i++)
            {
                if (Enum.GetNames(typeof(DtoH.Hexa)).Contains(hex[i].ToString()))
                {
                    result += string.Format(DtoB.DecimalToBinaryConverter((int)Enum.Parse(typeof(DtoH.Hexa), hex[i].ToString())).PadLeft(4,'0'));
                }
                else if (!int.TryParse(hex[i].ToString(), out c))
                {
                    throw new InvalidOperationException("THE STRING IS NOT A VALID HEX NUMBER!");
                }
                else if (int.Parse(hex[i].ToString()) > -1 && int.Parse(hex[i].ToString()) < 10)
                {
                    result += string.Format(DtoB.DecimalToBinaryConverter(int.Parse(hex[i].ToString())).PadLeft(4,'0'));
                }               
            }
            return result;
        }
        static void Main(string[] args)
        {
            string input;

            Console.Write("Hexadecimal number to convert to binary :");
            input = Console.ReadLine();


            Console.WriteLine("The number converted to binary:\n{0}", HexadecimalToBinaryConverter(input).PadLeft(32,'0'));
        }
    }
}
