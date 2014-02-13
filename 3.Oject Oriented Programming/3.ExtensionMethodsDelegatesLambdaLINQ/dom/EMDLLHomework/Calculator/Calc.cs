using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Calc
    {
        private const decimal precision = 0.001m;

        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            StringBuilder b = new StringBuilder();
            b.Append("1 + 1/2 + 1/4 + 1/8 + 1/16... = ");
            decimal sum = GenerateSeries(i => 1/(decimal) Math.Pow(2, (double) i), precision, b);
            b.AppendFormat(" = {0}", sum);
            Console.WriteLine(b.ToString());

            Console.WriteLine();

            b = new StringBuilder("1 + 1/2! + 1/3! + 1/4! + 1/5!... = ");
            sum = GenerateSeries(i => 1.0m/GetFactorial((long) i), precision, b);
            b.AppendFormat(" = {0}", sum);
            Console.WriteLine(b.ToString());

            Console.WriteLine();

            b = new StringBuilder("1 + 1/2 - 1/4 + 1/8 - 1/16... = ");
            sum = GenerateSeries(i => i == 0 ? 1 : -1/(decimal) Math.Pow(-2, (double) i), precision, b);
            b.AppendFormat(" = {0}", sum);
            Console.WriteLine(b.ToString());
        }

        private static long GetFactorial(long num)
        {
            if (num <= 2)
            {
                return num;
            }
            long result = 2;
            for (int i = 3; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }

        private static decimal GenerateSeries(Func<decimal, decimal> function, decimal p, StringBuilder b)
        {
            int i = 1;
            decimal sum = 0;
            decimal temp = GenerateElement(function, p, i);
            while (temp != 0)
            {
                b.AppendFormat("{0}", temp > 0 ? "+" + temp : temp.ToString());
                sum += temp;
                i++;
                temp = GenerateElement(function, p, i);
            }
            return sum;
        }

        private static decimal GenerateElement(Func<decimal, decimal> function, decimal p, int i)
        {
            decimal element = 0;
            if (Math.Abs(function(i)) > p)
            {
                element = function(i);
            }
            return element;
        }
    }
}