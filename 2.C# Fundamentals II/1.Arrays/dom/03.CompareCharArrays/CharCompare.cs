//Write a program that compares two char arrays lexicographically (letter by letter).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompareCharArrays
{
    class CharCompare
    {
        static void Main(string[] args)
        {
            List<char> firstArr = new List<char>();
            List<char> secondArr = new List<char>();

            char symbol = '1';
            int l1 = 0;
            int l2 = 0;
            while (symbol != ' ')
            {
                Console.Write("Element {0} of the first array(write space(\" \") to finish):", l1);
                if (symbol != ' ')
                {
                    if(char.TryParse(Console.ReadLine(),out symbol))
                    {
                        firstArr.Add(symbol);
                        l1++;
                    }
                    else
                    {
                        Console.WriteLine("Bad Input! the value will be set to 0");
                        firstArr.Add('0');
                        l1++;
                    }
                }
            }
            symbol = '1';

            Console.WriteLine();

            while (symbol != ' ')
            {
                Console.Write("Element {0} of the second array(write space(\" \") to finish):", l2);
                if (symbol != ' ')
                {
                    if (char.TryParse(Console.ReadLine(), out symbol))
                    {
                        secondArr.Add(symbol);
                        l2++;
                    }
                    else
                    {
                        Console.WriteLine("Bad Input! the value will be set to 0");
                        secondArr.Add('0');
                        l2++;
                    }
                }
            }

            firstArr.TrimExcess();
            secondArr.TrimExcess();
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < Math.Min(l1, l2); i++)
            {
                if ((int)firstArr.ElementAt(i) == (int)secondArr.ElementAt(i))
                {
                    Console.WriteLine("Elements [{0}] - Equal", i);
                }
                else
                {
                    Console.WriteLine((int)firstArr.ElementAt(i) > (int)secondArr.ElementAt(i) ? "Elements [{0}] - First Is bigger" : "Elements [{0}] - Second is bigger", i);
                }
            }
        }
    }
}
