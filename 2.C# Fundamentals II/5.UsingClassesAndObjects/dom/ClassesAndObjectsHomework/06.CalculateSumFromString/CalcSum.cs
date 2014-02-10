//You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from given string and calculates their sum. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CalculateSumFromString
{
    class CalcSum
    {

        public static uint CalcSumFromString(string str)
        {
            string[] nums = str.Split(' ');
            uint sum = 0;
            try
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    sum += uint.Parse(nums[i]);
                }
            }
            catch (FormatException)
            {

                Console.WriteLine("The input string was incorrect!\n\n");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The input string must have only positive numbers!\n");
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.Write("String:");
            string str=Console.ReadLine();
            Console.WriteLine("The sum is {0}",CalcSumFromString(str));
            
        }
    }
}
