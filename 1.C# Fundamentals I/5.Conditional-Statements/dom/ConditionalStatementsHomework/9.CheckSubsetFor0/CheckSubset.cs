//We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.CheckSubsetFor0
{
    class CheckSubset
    {
        static void Main(string[] args)
        {
            string input;
            int[] vars = new int[5];
            int flag = 0;

            for (int i = 0; i < vars.Length; i++)
            {
                do
                {
                    Console.Write("First variable=");
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out vars[i]));
            }

            for (int a = 0; a < vars.Length; a++)
            {
                for (int b = 1; b < vars.Length; b++)
                {
                    if (vars[a] + vars[b] == 0)
                    {
                        Console.WriteLine("Yes - {0}+{1}=0", vars[a], vars[b]); flag++; goto exitfield;
                    }
                    for (int c = 2; c < vars.Length; c++)
                    {
                        if (vars[a] + vars[b] + vars[c] == 0)
                        {
                            Console.WriteLine("Yes - {0}+{1}+{2}=0", vars[a], vars[b], vars[c]); flag++; goto exitfield;
                        }
                        for (int d = 3; d < vars.Length; d++)
                        {
                            if (vars[a] + vars[b] + vars[c] + vars[d] == 0)
                            {
                                Console.WriteLine("Yes - {0}+{1}+{2}+{3}=0", vars[a], vars[b], vars[c], vars[d]); flag++; goto exitfield;
                            }
                            for (int e = 4; e < vars.Length; e++)
                            {
                                if (vars[a] + vars[b] + vars[c] + vars[d] + vars[e] == 0)
                                {
                                    Console.WriteLine("Yes - {0}+{1}+{2}+{3}+{4}=0", vars[a], vars[b], vars[c], vars[d], vars[e]); flag++; goto exitfield;
                                }
                            }
                        }
                    }
                }
            }
             if (flag == 0)
            {
                Console.WriteLine("No.");
            }
         exitfield: ;
           
        }
    }
}
