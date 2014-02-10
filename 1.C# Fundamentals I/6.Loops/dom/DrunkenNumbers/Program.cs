using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRounds = int.Parse(Console.ReadLine());
            long M = 0;
            long V = 0;

            for (int i = 0; i < numberOfRounds; i++)
            {
                long drunkenNumber = long.Parse(Console.ReadLine());
                drunkenNumber = Math.Abs(drunkenNumber);
                string numstr = drunkenNumber.ToString();

                if (numstr.Length % 2 != 0)
                {
                    for (int j = 0; j < numstr.Length/2; j++)
                    {
                        V += drunkenNumber % 10;
                        drunkenNumber /= 10;
                    }

                    V += drunkenNumber % 10;
                    M += drunkenNumber % 10;
                    drunkenNumber /= 10;
                    numstr = drunkenNumber.ToString();

                    for (int g = 0; g < numstr.Length; g++)
                    {
                        M += drunkenNumber % 10;
                        drunkenNumber /= 10;
                    }

                }
                else
                {
                    for (int g = 0; g < numstr.Length / 2; g++)
                    {
                        V += drunkenNumber % 10;
                        drunkenNumber /= 10;
                    }

                    numstr = drunkenNumber.ToString();

                    for (int j = 0; j < numstr.Length; j++)
                    {
                        M += drunkenNumber % 10;
                        drunkenNumber /= 10;
                    }
                }

            }

            if (M > V)
            {
                Console.WriteLine("M {0}", M - V);
            }
            else if (V > M)
            {
                Console.WriteLine("V {0}", V - M);
            }
            else if (M == V)
            {
                Console.WriteLine("No {0}", V + M);
            }
        }
    }
}
