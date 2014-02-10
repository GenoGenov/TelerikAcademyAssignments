using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ThreeIntegerSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int a;
            int b;
            int c;

            do
            {
                Console.Write("a=");
                input = Console.ReadLine();
            } while (!int.TryParse(input,out a));

            do
            {
                Console.Write("b=");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out b));

            do
            {
                Console.Write("c=");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out c));

            Console.WriteLine("{0}+{1}+{2} = {3}",a,b,c,a+b+c);

        }
    }
}
