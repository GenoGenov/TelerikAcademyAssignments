//Write a program that calculates for given N how many trailing zeros present at the end of the number N!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _13.TrailingZeros
{
    class TrailingZeros
    {
       
        static void Main(string[] args)
        {
            uint n;
            string input;
            int count = 0;
            BigInteger nFact = 1;

            do
            {
                Console.Write("N = ");
                input = Console.ReadLine();
            } while (!uint.TryParse(input, out n));

            for (int i = 2; i < n; i++)
			{
                nFact = nFact * i;
			}


            Console.WriteLine("N! = {0}",nFact);

            string number = nFact.ToString();

            while (number[number.Length - 1] == '0')
            {
                count++;
                number = number.Remove(number.Length - 1);
            }

            Console.WriteLine("The number has {0} trailing zeros.",count); //Works with 50 000 , just give it ~ 10-15 seconds :D
        }
    }
}
