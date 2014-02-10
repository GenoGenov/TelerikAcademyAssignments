using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.SequenceMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            int InitMember = 2;
            int[] a = new int[10];
            a[0] = InitMember;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i - 1] % 2 == 0)
                { a[i] = (-a[i - 1]) - 1; }
                else
                { a[i] = Math.Abs(a[i - 1]) + 1; }

            }
            Console.WriteLine("First 10 members of the sequence are :");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + ", ");
            }
        }
    }
}
