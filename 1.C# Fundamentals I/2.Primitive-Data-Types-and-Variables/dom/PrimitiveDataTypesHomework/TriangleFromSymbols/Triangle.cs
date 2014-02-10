using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleFromSymbols
{
    class Triangle
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            char c ='\u00A9';
            Console.WriteLine("{0,10}",c);
            Console.WriteLine("{0,9}{1}{2}",c,c,c);
            Console.WriteLine("{0,8}{1}{2}{3}{4}",c,c,c,c,c);
           
        }
    }
}
