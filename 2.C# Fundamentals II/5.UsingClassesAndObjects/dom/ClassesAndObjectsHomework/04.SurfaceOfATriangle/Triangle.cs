using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SurfaceOfATriangle
{
    class Triangle
    {

        private static decimal GetPerimeter(decimal a, decimal b, decimal c)
        {
            return a + b + c;
        }
        public static decimal SurfaceOfATriangle(decimal a,decimal altA)
        {
            return a * altA / 2.0m;
        }

        public static decimal SurfaceOfATriangle(decimal a, decimal b, decimal c)
        {
            decimal p=GetPerimeter(a,b,c)/2.0m;
            decimal s = (p * (p - a) * (p - b) * (p - c));
            return (decimal)Math.Sqrt((double)s);
        }

        public static decimal SurfaceOfATriangle(decimal a, decimal b, double angle)
        {
            return a * b * (decimal)Math.Sin(angle)*0.5m;
        }
    }
}
