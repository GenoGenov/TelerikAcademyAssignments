using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.DecimalToHexadecimal;

namespace _04.HexadecimalToDecimal
{
    class HtoD
    {
        
        public static int HexademicalToDecimalConverter(string hex)
        {
            int result=0;
            hex = string.Join("", hex.Reverse());
            int c;
            for (int i = 0; i <hex.Length; i++)
            {
                if (Enum.GetNames(typeof(DtoH.Hexa)).Contains(hex[i].ToString()))
                {
                    result += (int)Enum.Parse(typeof(DtoH.Hexa), hex[i].ToString())*(int)Math.Pow(16,i);
                }
                else if(!int.TryParse(hex[i].ToString(),out c))
                {
                    throw new InvalidOperationException("THE STRING IS NOT A VALID HEX NUMBER!");
                }
                else if (int.Parse(hex[i].ToString()) > -1 && int.Parse(hex[i].ToString()) < 10)
                {
                    result += int.Parse(hex[i].ToString()) * (int)Math.Pow(16, i);
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            string input;

                Console.Write("Hexadecimal number to convert to decimal :");
                input = Console.ReadLine();


            Console.WriteLine("The number converted to decimal:\n{0}", HexademicalToDecimalConverter(input));
        }
    }
}
