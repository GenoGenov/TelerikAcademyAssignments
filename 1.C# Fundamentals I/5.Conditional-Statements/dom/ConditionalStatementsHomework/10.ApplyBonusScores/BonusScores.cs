//Write a program that applies bonus scores to given scores in the range [1..9]. The program reads a digit as an input. If the digit is between 1 and 3, the program multiplies it by 10; if it is between 4 and 6, multiplies it by 100; if it is between 7 and 9, multiplies it by 1000. If it is zero or if the value is not a digit, the program must report an error.Use a switch statement and at the end print the calculated new value in the console.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.ApplyBonusScores
{
    class BonusScores
    {
        static void Main(string[] args)
        {
            string input;
            int score;

            do
            {
                Console.Write("Score:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out score));

            switch (score)
            {
                default: Console.WriteLine("Input error!"); break;
                case 1:
                case 2:
                case 3: score *= 10; Console.WriteLine("New Value: {0}", score); break;
                case 4:
                case 5:
                case 6: score *= 100; Console.WriteLine("New value: {0}", score); break;
                case 7:
                case 8:
                case 9: score *= 1000; Console.WriteLine("New value: {0}", score); break;
            }
        }
    }
}
