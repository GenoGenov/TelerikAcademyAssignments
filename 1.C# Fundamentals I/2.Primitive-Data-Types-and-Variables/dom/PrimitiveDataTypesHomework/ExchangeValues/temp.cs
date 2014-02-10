using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeValues
{
    class temp
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            Console.WriteLine("a = {0} , b = {1}", a, b);
            int temp;
            temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After exchange:\na = {0} , b = {1}",a,b);
        }
    }
}
