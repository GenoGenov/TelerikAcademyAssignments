//Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]). Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _08.AddTwoNumbersAsArrays
{
    class AddAsArrays
    {
        static BigInteger Sum(BigInteger a, BigInteger b)
        {
            List<char> symbols1 = a.ToString().ToList();
            List<char> symbols2 = b.ToString().ToList();
            string result = string.Empty;
            int remainder = 0;
            int count1 = symbols1.Count;
            int count2 = symbols2.Count;
            if (count1 != count2)
            {
                if (count1 > count2)
                {
                    for (int i = 0; i < count1-count2; i++)
                    {
                        symbols2.Insert(0, '0');
                    }
                }
                if (count1 < count2)
                {
                    for (int i = 0; i < count2 - count1; i++)
                    {
                        symbols1.Insert(0, '0');
                    }
                }
            }
            for (int i = symbols1.Count-1; i >= 0; i--)
            {
                
                int digit1 = 0;
                int digit2 = 0;

                digit1 = int.Parse(symbols1[i].ToString());
                digit2 = int.Parse(symbols2[i].ToString());

                int digit = digit1 + digit2 + remainder;
                if (digit > 9)
                {
                    remainder = digit / 10;
                    digit = digit % 10;
                }
                else
                {
                    remainder = 0;
                }
                int final = digit;
                result = final + result;
            }
            if (remainder > 0)
            {
                result = remainder + result;
            }
            return BigInteger.Parse(result);
        }
        static void Main(string[] args)
        {
            string num;
            BigInteger big1;
            BigInteger big2;
            do
            {
                Console.Write("First Number:");
                num = Console.ReadLine();
            } while (!BigInteger.TryParse(num, out big1) || big1.Sign<0);

            do
            {
                Console.Write("Second Number:");
                num = Console.ReadLine();
            } while (!BigInteger.TryParse(num, out big2) || big2.Sign < 0);

            Console.WriteLine("the sum is {0}",Sum(big1,big2));
        }
    }
}
