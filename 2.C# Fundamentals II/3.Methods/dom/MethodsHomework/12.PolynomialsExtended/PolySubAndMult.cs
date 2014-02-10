//Extend the program to support also subtraction and multiplication of polynomials.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.PolynomialsExtended
{
    class PolySubAndMult
    {
        static int[] AddPolynomials(int[] p1, int[] p2)
        {
            int length = Math.Max(p1.Length, p2.Length);
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
            {
                int a = 0;
                int b = 0;
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

        static int[] SubtractPolynomials(int[] p1, int[] p2)
        {
            int length = Math.Max(p1.Length, p2.Length);
            int[] result = new int[length];
            for (int i = 0; i < length; i++)
            {
                int a = 0;
                int b = 0;
                if (i < p1.Length)
                {
                    a = p1[i];
                }
                if (i < p2.Length)
                {
                    b = -p2[i];
                }
                result[i] = a + b;
            }

            return result;
        }

        static int[] MultiplyPolynomials(int[] p1, int[] p2)
        {
            int length = p1.Length + p2.Length;
            int[] result = new int[length];
           // for (int k = 0; k < length; k++)
           // {
                for (int i = p1.Length - 1; i >= 0; i--)
                {
                    for (int j = p2.Length - 1; j >=0; j--)
                    {
                        result[i + j] += p1[i] * p2[j];
                    }
                }
                
            //}

            return result;
        }
        static void Print(int[] p)
        {
            for (int i = p.Length - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    Console.Write("{0}X^{1} + ", p[i], i);
                }
                else
                {
                    Console.Write("{0}", p[i]);
                }
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int n, m;
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

            Console.WriteLine("First Poly:");
            Print(poly1);

            Console.WriteLine("Second Poly:");
            Print(poly2);

            int[] poly3 = AddPolynomials(poly1, poly2);
            Console.WriteLine("The addition of the two polynomials is:");
            Print(poly3);

            poly3 = SubtractPolynomials(poly1, poly2);
            Console.WriteLine("The subtraction is:");
            Print(poly3);

            poly3 = MultiplyPolynomials(poly1, poly2);
            Console.WriteLine("The multiplication is:");
            Print(poly3);
        }
    }
}
