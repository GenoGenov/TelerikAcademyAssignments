using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Dividable5and7
{
    class Dividable
    {
        static void Main(string[] args)
        {
            Console.Write("Write a whole number to check if it can be divided by 5 and 7 simultaneously:");
            int number = int.Parse(Console.ReadLine());
            if(number%5==0 && number%7==0)
            {
                Console.WriteLine("Yes.");
            }
            else
            {
                Console.WriteLine("No.");
            }
        }
    }
}
