//Write a program that, depending on the user's choice inputs int, double or string variable. If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. The program must show the value of that variable as a console output. Use switch statement.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8.User_sChoice
{
    class ChooseType
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.WriteLine("Choose a type of variable:");
            string input = Console.ReadLine();
            switch (input)
            {
                default: Console.WriteLine("Input Error!");break;
                case "double":  Console.Write("Enter variable:");
                                double dVar = double.Parse(Console.ReadLine());
                                Console.WriteLine("double: {0}",++dVar);break;

                case "string":  Console.Write("Enter string:"); 
                                string str = Console.ReadLine();
                                Console.WriteLine("string: {0}", str + '*'); break;

                case "int":     Console.Write("Enter variable:");
                                int iVar = int.Parse(Console.ReadLine());
                                Console.WriteLine("int: {0}",++iVar);break;
            }
        }
    }
}
