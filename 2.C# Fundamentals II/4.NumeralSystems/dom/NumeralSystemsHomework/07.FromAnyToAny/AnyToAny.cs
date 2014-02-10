using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConverterClass;

namespace _07.FromAnyToAny
{
    class AnyToAny
    {
        static void Main(string[] args)
        {
            int b1,b2;
            string input,input2;
            string num;
            do
            {
                Console.Write("The base of the number to convert:");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out b1) || b1 < 2 || b1 > 16);


                Console.Write("The number to convert(of base {0}):",b1);
                num = Console.ReadLine();

                do
                {
                    Console.Write("The desired base:");
                    input2 = Console.ReadLine();

                } while (!int.TryParse(input2, out b2) || b2 < 2 || b2 > 16);

                if (b1 > 10)
                {
                    int temp = Converters.HigherToDecimal(num, b1);

                    if (b2 > 10)
                    {
                        Console.WriteLine("Your Number: {0}",Converters.DecimalToHigher(temp,b2));
                    }
                    else if (b2 == 10)
                    {
                        Console.WriteLine("Your Number: {0}", temp);
                    }
                    else if (b2 < 10)
                    {
                        Console.WriteLine("Your Number: {0}", Converters.DecimalToLower(temp, b2));
                    }
                }
                else if(b1==10)
                {
                    int number;
                    if (!int.TryParse(input, out number))
                    {
                        throw new InvalidOperationException("INCORRECT NUMBER!");
                    }
                    else
                    {
                        if (b2 > 10)
                        {
                            Console.WriteLine("Your Number: {0}", Converters.DecimalToHigher(number, b2));
                        }
                        else if (b2 == 10)
                        {
                            Console.WriteLine("Your Number: {0}", number);
                        }
                        else if (b1 < 10)
                        {
                            Console.WriteLine("Your Number: {0}", Converters.DecimalToLower(number, b2));
                        }
                    }
                }
                else if (b1 < 10)
                {
                    int temp = Converters.LowerToDecimal(num, b1);

                    if (b2 > 10)
                    {
                        Console.WriteLine("Your Number: {0}", Converters.DecimalToHigher(temp, b2));
                    }
                    else if (b2 == 10)
                    {
                        Console.WriteLine("Your Number: {0}", temp);
                    }
                    else if (b1 < 10)
                    {
                        Console.WriteLine("Your Number: {0}", Converters.DecimalToLower(temp, b2));
                    }
                }
        }
    }
}
