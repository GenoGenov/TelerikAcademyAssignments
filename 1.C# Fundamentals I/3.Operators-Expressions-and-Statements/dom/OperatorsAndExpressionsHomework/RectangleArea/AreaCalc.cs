using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RectangleArea
{
    class AreaCalc
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.Write("Width:");
            decimal width = decimal.Parse(Console.ReadLine());
            Console.Write("Height:");
            decimal height = decimal.Parse(Console.ReadLine());
            decimal area = width * height;
            Console.WriteLine("Area: {0}",area);
        }
    }
}
