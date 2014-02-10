//Write a program that finds the most frequent number in an array.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.MostFrequentNumberInArray
{
    class MostFrequentNum
    {
        static void Main(string[] args)
        {
            List<int> firstArr = new List<int>();
            int num = 1;
            int l1 = 0;
            
            Console.Write("Element {0} of the array(write some bad input to finish):", l1);
            l1++;
            while (int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Element {0} of the array(write some bad input to finish):", l1);
                firstArr.Add(num);
                l1++;
            }

            firstArr.TrimExcess();
            Console.WriteLine();
            Console.WriteLine();

            int element=firstArr[0];
            int occurenceCount=firstArr.FindAll(x=> x==element).Count;

            for (int i = 1; i < firstArr.Count; i++)
            {
                int temp = firstArr[i];
                int count=firstArr.FindAll(x => x == temp).Count;
                if (count > occurenceCount)
                {
                    occurenceCount = count;
                    element = firstArr[i];
                }
            }

            Console.WriteLine("{0}({1} times)",element,occurenceCount);
        }
    }
}
