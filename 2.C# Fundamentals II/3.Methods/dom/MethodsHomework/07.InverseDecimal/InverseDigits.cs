//Write a method that reverses the digits of given decimal number. 

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07.InverseDecimal
{
    class InverseDigits
    {
        static void Inverse(ref decimal d)
        {
            char[] digits = d.ToString().ToCharArray();
            string result = string.Join("", digits.Reverse());
            d = decimal.Parse(result);
            
        }
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string input;
            decimal a;
            do
            {
                Console.Write("Decimal number:");
                input = Console.ReadLine();
            } while (!decimal.TryParse(input, out a));

            Inverse(ref a);
            Console.WriteLine("The decimal number with reversed digits: {0}",a);
        }
    }
}
