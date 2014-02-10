using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FloatCompare
{
    class FloatCompareWithPrecision
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            bool imput1;
            bool imput2;
            double number1;
            double number2;
            imput1 = double.TryParse(Console.ReadLine(), out number1);
            imput2 = double.TryParse(Console.ReadLine(), out number2);
            if (imput1 && imput2)
            {
                bool equal = (decimal)number1 == (decimal)number2;
                Console.WriteLine("({0};{1})->{2}", number1, number2, equal);
            }
            else
            {
                Console.WriteLine("Incorrect input!");
                
            }

        }
    }
}
