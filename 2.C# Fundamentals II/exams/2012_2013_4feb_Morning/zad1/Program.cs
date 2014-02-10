using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());

            List<ulong> digits = new List<ulong>();
            List<string> allDigits = new List<string>();
            digits.Add(n % 256);
            n = n / 256;
            while (n!=0)
            {
                digits.Add(n % 256);
                n = n / 256;
            }


            for (int i = 65; i <= 90; i++)
            {
                allDigits.Add(((char)i).ToString());
            }

            for (int i = 97; i <= 122; i++)
            {
                for (int j = 65; j <= 90; j++)
                {
                    allDigits.Add(((char)i).ToString() + ((char)j).ToString());
                }
            }

            for (int i = digits.Count - 1; i >= 0; i--)
            {
                Console.Write(allDigits[(int)digits[i]]);
            }
        }
    }
}
