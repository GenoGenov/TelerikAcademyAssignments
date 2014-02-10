using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.DivisionByFive
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            uint numOne;
            uint numTwo;
            int p=0;

            do
            {
                Console.Write("First Number:");
                input = Console.ReadLine();
            } while (!uint.TryParse(input,out numOne));

            do
            {
                Console.Write("Second Number:");
                input = Console.ReadLine();
            } while (!uint.TryParse(input, out numTwo));

            for (uint i = numOne; i <= numTwo; i++)
            {
                if(i%5==0)
                {
                    p++;
                }
            }

            Console.WriteLine("p({0},{1}) = {2}.",numOne,numTwo,p);

        }
    }
}
