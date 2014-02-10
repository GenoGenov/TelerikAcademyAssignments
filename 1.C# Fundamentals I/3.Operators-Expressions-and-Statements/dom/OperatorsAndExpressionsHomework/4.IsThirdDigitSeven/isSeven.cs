using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.IsThirdDigitSeven
{
    class isSeven
    {
        static void Main(string[] args)
        {
            Console.Write("Write a whole number with atleast 3 digits:");
            int number = int.Parse(Console.ReadLine());
            bool isThirdDigitSeven;
            int temp = number / 100;
            if(temp%10==7)
            {
                isThirdDigitSeven = true;
            }
            else
            {
                isThirdDigitSeven = false;
            }
            Console.WriteLine(isThirdDigitSeven);
        }
    }
}
