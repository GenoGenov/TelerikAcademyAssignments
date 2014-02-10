using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _01.Extensions
{
    internal class SubStrExtTest
    {
        private static void Main(string[] args)
        {
            var b = new StringBuilder("qwjkhf");
            Console.WriteLine(b.SubString(3, 1));

            string[] str = {"pencho", "haralambi"};
            Console.WriteLine(str.Sum());
            Console.WriteLine(str.Min());

            int[] arr = {1, 2, 3};
            Console.WriteLine(arr.Sum());
            Console.WriteLine(arr.Min());
            Console.WriteLine(arr.Product());
            Console.WriteLine(arr.Average());
        }
    }
}