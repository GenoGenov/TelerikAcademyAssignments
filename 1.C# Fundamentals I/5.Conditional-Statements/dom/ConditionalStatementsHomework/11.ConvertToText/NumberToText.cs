//* Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ConvertToText
{
    class NumberToText
    {
        static void Main(string[] args)
        {
            string input;
            uint var;

            do
            {
                Console.Write("Number:");
                input = Console.ReadLine();
            } while (!uint.TryParse(input, out var) || var > 999);

            uint a, b, c;
            a = var % 10;
            uint temp = var / 10;
            b = temp % 10;
            temp = temp / 10;
            c = temp;
            //YES, IM AWARE IT CAN BE DONE 1000 TIMES SHORTER, THE POINT WAS TO DO IT WITH "SWITCH"...MANY SWITCHES !
            if (var == 0)
            {
                Console.WriteLine("Zero");
                Console.WriteLine();
            }
            else if (var > 0 && var < 10)
            {
                switch (a)
                {
                    default: break;
                    case 1: Console.Write("One"); break;
                    case 2: Console.Write("Two"); break;
                    case 3: Console.Write("Three"); break;
                    case 4: Console.Write("Four"); break;
                    case 5: Console.Write("Five"); break;
                    case 6: Console.Write("Six"); break;
                    case 7: Console.Write("Seven"); break;
                    case 8: Console.Write("Eight"); break;
                    case 9: Console.Write("Nine"); break;
                }
                Console.WriteLine();
            }
            else if (var == 10)
            {
                Console.WriteLine("Ten");
                Console.WriteLine();
            }
            else if (var > 10 && var < 20)
            {
                switch (var)
                {
                    default: break;
                    case 11: Console.Write("Eleven"); break;
                    case 12: Console.Write("Twelve"); break;
                    case 13: Console.Write("Thirteen"); break;
                    case 14: Console.Write("Forteen"); break;
                    case 15: Console.Write("Fifteen"); break;
                    case 16: Console.Write("Sixteen"); break;
                    case 17: Console.Write("Seventeen"); break;
                    case 18: Console.Write("Eighteen"); break;
                    case 19: Console.Write("Nineteen"); break;
                }
                Console.WriteLine();
            }

            else if (var > 19 && var < 100)
            {
                switch (b)
                {
                    default: break;
                    case 1: Console.Write("Ten"); break;
                    case 2: Console.Write("Twenty "); break;
                    case 3: Console.Write("Thirty "); break;
                    case 4: Console.Write("Forty "); break;
                    case 5: Console.Write("Fifty "); break;
                    case 6: Console.Write("Sixty"); break;
                    case 7: Console.Write("Seventy "); break;
                    case 8: Console.Write("Eighty "); break;
                    case 9: Console.Write("Ninety "); break;
                }

                switch (a)
                {
                    default: break;
                    case 1: Console.Write("One"); break;
                    case 2: Console.Write("Two"); break;
                    case 3: Console.Write("Three"); break;
                    case 4: Console.Write("Four"); break;
                    case 5: Console.Write("Five"); break;
                    case 6: Console.Write("Six"); break;
                    case 7: Console.Write("Seven"); break;
                    case 8: Console.Write("Eight"); break;
                    case 9: Console.Write("Nine"); break;
                }
                Console.WriteLine();
            }
            else if (var > 99 && b == 0)
            {
                switch (c)
                {
                    default: break;
                    case 1: Console.Write("One hundred "); break;
                    case 2: Console.Write("Two hundred "); break;
                    case 3: Console.Write("Three jundred "); break;
                    case 4: Console.Write("Four hundred "); break;
                    case 5: Console.Write("Five hundred "); break;
                    case 6: Console.Write("Six hundred "); break;
                    case 7: Console.Write("Seven hundred "); break;
                    case 8: Console.Write("Eight hundred "); break;
                    case 9: Console.Write("Nine hundred "); break;
                }
                if (a != 0) { Console.Write("And "); }

                switch (a)
                {
                    default: break;
                    case 1: Console.Write("One"); break;
                    case 2: Console.Write("Two"); break;
                    case 3: Console.Write("Three"); break;
                    case 4: Console.Write("Four"); break;
                    case 5: Console.Write("Five"); break;
                    case 6: Console.Write("Six"); break;
                    case 7: Console.Write("Seven"); break;
                    case 8: Console.Write("Eight"); break;
                    case 9: Console.Write("Nine"); break;
                }
                Console.WriteLine();
            }
            else if (var > 99 && b == 1)
            {
                switch (c)
                {
                    default: break;
                    case 1: Console.Write("One hundred "); break;
                    case 2: Console.Write("Two hundred "); break;
                    case 3: Console.Write("Three jundred "); break;
                    case 4: Console.Write("Four hundred "); break;
                    case 5: Console.Write("Five hundred "); break;
                    case 6: Console.Write("Six hundred "); break;
                    case 7: Console.Write("Seven hundred "); break;
                    case 8: Console.Write("Eight hundred "); break;
                    case 9: Console.Write("Nine hundred "); break;
                }
                Console.Write("and ");
                switch (a)
                {
                    default: break;
                    case 0: Console.Write("Ten"); break;
                    case 1: Console.Write("Eleven"); break;
                    case 2: Console.Write("Twelve"); break;
                    case 3: Console.Write("Thirteen"); break;
                    case 4: Console.Write("Forteen"); break;
                    case 5: Console.Write("Fifteen"); break;
                    case 6: Console.Write("Sixteen"); break;
                    case 7: Console.Write("Seventeen"); break;
                    case 8: Console.Write("Eighteen"); break;
                    case 9: Console.Write("Nineteen"); break;
                }
                Console.WriteLine();
            }
            else if (var > 119 && a != 0)
            {
                switch (c)
                {
                    default: break;
                    case 1: Console.Write("One hundred"); break;
                    case 2: Console.Write("Two hundred"); break;
                    case 3: Console.Write("Three jundred"); break;
                    case 4: Console.Write("Four hundred"); break;
                    case 5: Console.Write("Five hundred"); break;
                    case 6: Console.Write("Six hundred"); break;
                    case 7: Console.Write("Seven hundred"); break;
                    case 8: Console.Write("Eight hundred"); break;
                    case 9: Console.Write("Nine hundred"); break;
                }

                switch (b)
                {
                    default: break;
                    case 1: Console.Write("Ten"); break;
                    case 2: Console.Write(" Twenty "); break;
                    case 3: Console.Write(" Thirty "); break;
                    case 4: Console.Write(" Forty "); break;
                    case 5: Console.Write(" Fifty "); break;
                    case 6: Console.Write(" Sixty"); break;
                    case 7: Console.Write(" Seventy "); break;
                    case 8: Console.Write(" Eighty "); break;
                    case 9: Console.Write(" Ninety "); break;
                }

                switch (a)
                {
                    default: break;
                    case 1: Console.Write("One"); break;
                    case 2: Console.Write("Two"); break;
                    case 3: Console.Write("Three"); break;
                    case 4: Console.Write("Four"); break;
                    case 5: Console.Write("Five"); break;
                    case 6: Console.Write("Six"); break;
                    case 7: Console.Write("Seven"); break;
                    case 8: Console.Write("Eight"); break;
                    case 9: Console.Write("Nine"); break;
                }
                Console.WriteLine();
            }
            else if (var > 119 && a == 0)
            {
                switch (c)
                {
                    default: break;
                    case 1: Console.Write("One hundred"); break;
                    case 2: Console.Write("Two hundred"); break;
                    case 3: Console.Write("Three jundred"); break;
                    case 4: Console.Write("Four hundred"); break;
                    case 5: Console.Write("Five hundred"); break;
                    case 6: Console.Write("Six hundred"); break;
                    case 7: Console.Write("Seven hundred"); break;
                    case 8: Console.Write("Eight hundred"); break;
                    case 9: Console.Write("Nine hundred"); break;
                }
                Console.Write(" And ");
                switch (b)
                {
                    default: break;
                    case 1: Console.Write("Ten"); break;
                    case 2: Console.Write("Twenty "); break;
                    case 3: Console.Write("Thirty "); break;
                    case 4: Console.Write("Forty "); break;
                    case 5: Console.Write("Fifty "); break;
                    case 6: Console.Write("Sixty"); break;
                    case 7: Console.Write("Seventy "); break;
                    case 8: Console.Write("Eighty "); break;
                    case 9: Console.Write("Ninety "); break;
                       
                }
                Console.WriteLine();
            }
        }
    }
}
