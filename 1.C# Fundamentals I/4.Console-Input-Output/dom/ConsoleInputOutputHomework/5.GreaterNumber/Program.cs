using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.GreaterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int a;
            int b;

            do
            {
                Console.WriteLine("First numver:");
                input = Console.ReadLine();
            } while (!int.TryParse(input,out a));

            do
            {
                Console.WriteLine("Second number different from the first :");
                input = Console.ReadLine();
            } while (!int.TryParse(input,out b) || a==b);

            bool aGreater = a > b;

            Console.WriteLine("The greater number is {0}",aGreater ? a:b);

        }
    }
}
