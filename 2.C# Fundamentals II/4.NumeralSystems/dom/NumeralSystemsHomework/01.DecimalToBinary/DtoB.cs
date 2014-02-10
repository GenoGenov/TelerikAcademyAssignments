using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DecimalToBinary
{
    public class DtoB
    {
        public static string DecimalToBinaryConverter(int number)
        {
            string result = string.Empty;

            do
            {
                result = number % 2 + result;
                number = number / 2;
            } while (number != 0);

            return result;
        }
        static void Main(string[] args)
        {

            int a;
            string input;
            do
            {
                Console.Write("Number to convert to binary :");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out a));

            Console.WriteLine("The number converted to binary:\n{0}", DecimalToBinaryConverter(a).PadLeft(32, '0'));

        }
    }
}
