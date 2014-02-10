//Write a method that adds two polynomials. Represent them as arrays of their coefficients.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.AddTwoPolynomials
{
    class AddPolys 
    {
        public static int[] AddPolynomials(int[] p1, int[] p2)
        {
            int length = Math.Max(p1.Length, p2.Length);
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
            {
                int a=0;
                int b=0;
                if (i < p1.Length)
                {
                    a = p1[i];
                }
                if (i < p2.Length)
                {
                    b = p2[i];
                }
                result[i] = a + b;
            }

            return result;
        }

        static void Print(int[] p)
        {
            for (int i = p.Length - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    Console.Write("{0}X^{1} + ",p[i],i);
                }
                else
                {
                    Console.Write("{0}",p[i]);
                }
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int n,m;
            string input;
            do
            {
                Console.Write("First array Length:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out n) || n < 1);


            do
            {
                Console.Write("Second array Length:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out m) || m < 1);

            int[] poly1 = new int[n];
            int[] poly2 = new int[m];
            for (int i = 0; i < n; i++)
            {
                int g;
                do
                {
                    Console.Write("First array : Element at [{0}]:", i);
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out g));
                poly1[i] = g;
            }

            for (int i = 0; i < m; i++)
            {
                int g;
                do
                {
                    Console.Write("Second array : Element at [{0}]:", i);
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out g));
                poly2[i] = g;
            }

            int[] poly3 = AddPolynomials(poly1, poly2);
            Print(poly3);
        }
    }
}
