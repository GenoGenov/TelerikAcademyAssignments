using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.nNumbersSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int n;
            int[] numbers;

            do
            {
                Console.Write("Numbers count: ");
                input = Console.ReadLine();
            } while (!int.TryParse(input,out n));

            numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.Write("Number [{0}] :",i);
                    input = Console.ReadLine();
                } while (!int.TryParse(input,out numbers[i]));
            }

            Console.WriteLine("The sum of all numbers is {0}",numbers.Sum());

        }
    }
}
