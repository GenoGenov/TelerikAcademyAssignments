using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.NullValues
{
    class Null
    {
        static void Main(string[] args)
        {
            int? a = null;
            double? b = null;
            a += 5; b += 7;
            Console.WriteLine("a: {0} , b: {1}",a,b);
        }
    }
}
