using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.OddOrEven
{
    class IntCheck
    {
        static void Main(string[] args)
        {
            Console.Write("Write a whole number:");
            int variable = int.Parse(Console.ReadLine());
            if(variable%2==0)
            {
                Console.WriteLine("Number is even.");
            }
            else
            {
                Console.WriteLine("Number is odd.");
            }
        }
    }
}
