using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CountNumberOccurences
{
    using System.Globalization;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("How many numbers would you like to enter:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Start entering the double numbers in the form 'XX.XX' each on a separate row:");
            var numDict = new Dictionary<double, int>();
            for (int i = 0; i < n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (!numDict.ContainsKey(num))
                {
                    numDict[num] = 0;
                }

                numDict[num]++;
            }

            foreach (var i in numDict)
            {
                Console.WriteLine(i.Key+" -> "+i.Value+" times");
            }

        }
    }
}
