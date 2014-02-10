//Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation. Format the output aligned right in 15 symbols.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11.PrintInDifferentForms
{
    class Formatting
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Number :");
            string num = Console.ReadLine();

            decimal deciForm;
            decimal.TryParse(num, out deciForm);

            int hexaForm;

            int.TryParse(num, out hexaForm);
            string hexa = hexaForm.ToString("X");

            string deci = deciForm.ToString("F");

            string exponential = deciForm.ToString("E");

            Console.WriteLine("{0}".PadLeft(15),deci);
            Console.WriteLine("{0}".PadLeft(15),hexaForm);
            Console.WriteLine("{0}".PadLeft(15),exponential);
        }
    }
}
