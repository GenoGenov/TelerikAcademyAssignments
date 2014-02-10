using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concatenation
{
    class Concat
    {
        static void Main(string[] args)
        {
            string first = "Hello";
            string second = "World";
            object strConcat = first + " " + second;
            string third = (string)strConcat;

            Console.WriteLine("Concatenation of \"{0}\" and \"{1}\" is \"{2}\" ",first,second,third);
        }
    }
}
