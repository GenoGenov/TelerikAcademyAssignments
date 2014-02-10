using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DecimalToHexadecimal
{
    public class DtoH
    {
       public enum Hexa {A=10,B,C,D,E,F};

       public static string DecimalToHexadecimalConverter(uint number)
       {
           string result = string.Empty;

            do
            {
                if (number % 16 > 9)
                {
                    result = (Hexa)(number % 16) + result;
                }
                else
                {
                    result = number % 16 + result;
                }
                number = number / 16;
            } while (number!=0);

            return result;
        
       }
        static void Main(string[] args)
        {
            uint a;
            string input;
            do
            {
                Console.Write("Number to convert to hexadecimal :");
                input = Console.ReadLine();

            } while (!uint.TryParse(input, out a));

            Console.WriteLine("The number converted to hexademical:\n{0}", DecimalToHexadecimalConverter(a));
        }
    }
}
