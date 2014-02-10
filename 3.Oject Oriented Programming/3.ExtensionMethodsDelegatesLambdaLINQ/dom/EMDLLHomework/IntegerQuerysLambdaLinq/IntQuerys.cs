using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerQuerysLambdaLinq
{
    class IntQuerys
    {
        static Random rand=new Random();
        static void Main(string[] args)
        {
            int[] arr = new int[50];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0,51);
            }

            Console.WriteLine("Initial array:\n"+string.Join(",",arr));
            Console.WriteLine();

            //using linq
            var linqCheck = from integer in arr
                where integer%3 == 0 && integer%7 == 0
                select integer;
            Console.WriteLine(string.Join(",",linqCheck));
            Console.WriteLine();

            //using lambda
            Action<IEnumerable<int>> print = x =>
            {
                foreach (var s in x)
                {
                    Console.WriteLine(s);
                }
            };
            print(arr.Where(x => x%3 == 0 && x%7 == 0));
        }
    }
}
