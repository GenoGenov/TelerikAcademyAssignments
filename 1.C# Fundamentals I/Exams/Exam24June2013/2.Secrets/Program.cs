using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _2.Secrets
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            number=BigInteger.Abs(number);
            BigInteger specialSum = 0;
            string numStr = number.ToString();
            int position = 1;
            for (int i = numStr.Length - 1; i >= 0; i--)
            {
                if (position % 2 == 0)
                {
                    specialSum += BigInteger.Parse(numStr[i].ToString()) * BigInteger.Parse(numStr[i].ToString()) * (position);
                }
                else
                {
                    specialSum += BigInteger.Parse(numStr[i].ToString()) * (position) * (position);
                }
                position++;
            }
            Console.WriteLine(specialSum);
            BigInteger alphaLength = specialSum % 10;
            BigInteger R = specialSum % 26;
            if (alphaLength == 0)
            {
                Console.WriteLine("{0} has no secret alpha-sequence", number);
            }
            else
            {
                string alphaSeq = ((char)(R + 65)).ToString();
                int counter = 1;
                for (int i = 1; i < alphaLength; i++)
                {
                    if (R + 65 + counter > 90)
                    {
                        counter = 0;
                        R = 0;
                    }
                    alphaSeq += ((char)(R + 65 + counter)).ToString();
                    counter++;
                }
                Console.WriteLine(alphaSeq);
            }
        }
    }
}
