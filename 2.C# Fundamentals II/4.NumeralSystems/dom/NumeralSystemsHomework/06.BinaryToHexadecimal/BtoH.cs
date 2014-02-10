using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.BinaryToDecimal;
using _03.DecimalToHexadecimal;

namespace _06.BinaryToHexadecimal
{
    class BtoH
    {
        public static string BinaryToHexadecimalConverter(string bi)
        {
            string result = string.Empty;
            int num = BtoD.BinaryToDecimalConverter(bi);
            uint unum = uint.Parse(num.ToString());
            result = DtoH.DecimalToHexadecimalConverter(unum);

            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Binary number to convert:");
            string s = Console.ReadLine();
            Console.WriteLine("The number in hexadecimal is:"+BinaryToHexadecimalConverter(s));
        }
    }
}
