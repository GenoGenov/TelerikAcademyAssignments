//Write a program that finds the sequence of maximal sum in given array. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.SequenceOfMaxSum
{
    class MaxSum
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

            //The optimal solution algorithm when using only single loop is:
            //M[1] = A[1]  
            //M[2] = Max (A[2], A[1] + A[2]) = Max (A[2], A[2] + M[1])  
            //M[3] = Max (A[3], A[2] + A[3], A[1] + A[2] + A[3]) =   Max (A[3], A[3] + Max (A[2], A[1] + A[2])) =   Max (A[3], A[3] + M[2]) 

            //Or just M[j] = Max (A[j], A[j] + M[j-1])

            int[] M = new int[firstArr.Count];
            int[] b = new int[firstArr.Count];

            // Initialize the first value in (m) and (b)
            M[0] = firstArr[0];
            b[0] = 0;

            // Initialize maxSum as the first element in (m)
            // we will keep updating maxSum until we get the
            // largest element in (m) which is indeed our
            // MCSS value. (k) saves the (j) position of 
            // the max value (MCSS)
            int maxSum = M[0];
            int k = 0;

            // For each subsequence ending at position (j)
            for (int j = 1; j < firstArr.Count; j++)
            {
                // m[j-1] + a[j] > a[j] is equivalent to m[j-1] > 0
                if (M[j - 1] > 0)
                {
                    // Extending the current window at (j-1)
                    M[j] = M[j - 1] + firstArr[j];
                    b[j] = b[j - 1];
                }
                else
                {
                    // Starting a new window at (j)
                    M[j] = firstArr[j];
                    b[j] = j;
                }

                // Update max and save (j)
                if (M[j] > maxSum)
                {
                    maxSum = M[j];
                    k = j;
                }
            }

            int start = b[k];
            int end = k;
            firstArr.RemoveRange(end + 1, firstArr.Count - end-1);
            Console.WriteLine("The sequence of max sum = {0} -> {1}",maxSum,string.Join(", ",firstArr.Skip(start)));
        }

    }
}
