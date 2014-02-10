using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BinaryToDecimal
{
    public class BtoD
    {
        public static int BinaryToDecimalConverter(string n)
        {
            int result = 0;
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] != '0' && n[i] != '1')
                {
                    throw new InvalidOperationException("The input string is invalid!");
                }
            }
            n = string.Join("",n.Reverse());
            if (n.Length > 32)
            {
                n = n.Substring(0, 32);
            }
            for (int i = 0; i < n.Length; i++)
            {
                
                if (n[i] == '1')
                {
                    if(i==31)
                    {
                        result=-result;
                    }
                    result += (int)Math.Pow(2, i);
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Input binary string to convert to decimal :");

            string input = Console.ReadLine();

            int a = BinaryToDecimalConverter(input);

            Console.WriteLine("The number converted to decimal: {0}",a);
        }
    }
}
