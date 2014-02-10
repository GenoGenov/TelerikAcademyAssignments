using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.PrintNumbersInInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int n;

            do
            {
                Console.Write("Interval upper limit ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n));

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }

        }
    }
}
