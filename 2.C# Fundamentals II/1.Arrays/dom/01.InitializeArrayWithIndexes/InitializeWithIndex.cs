//Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.InitializeArrayWithIndexes
{
    class InitializeWithIndex
    {
        static void Main(string[] args)
        {
            int[] SampleArray = new int[20];

            for (int i = 0; i < SampleArray.Length; i++)
            {
                SampleArray[i] = i * 5;
            }

            Console.WriteLine("The values of the elements initialized with [i]*5 :");
            Console.WriteLine(string.Join("\n",SampleArray));
        }
    }
}
