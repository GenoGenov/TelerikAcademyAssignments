using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.IsPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            string input;
            do
            {
                Console.Write("Whole Number <=100:");
                input = Console.ReadLine();
            } while (!int.TryParse(input,out n) || n>100 || n<=1);

            bool isPrime=true;
            for (int i = 2; i < n; i++)
            {
                if(n%i==0)
                {
                    isPrime = false; break;
                }
            }
            Console.WriteLine("Is it prime: {0}",isPrime);
        }
    }
}
