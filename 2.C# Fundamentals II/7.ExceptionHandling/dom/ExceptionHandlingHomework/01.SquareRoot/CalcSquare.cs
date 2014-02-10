//Write a program that reads an integer number and calculates and prints its square root. If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SquareRoot
{
    class CalcSquare
    {
        static void Main(string[] args)
        {
            Console.Write("Number:");
            string input = Console.ReadLine();
                 
            try
            {
                uint num = uint.Parse(input);
                Console.WriteLine("The square root is {0}", Math.Sqrt(num));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
