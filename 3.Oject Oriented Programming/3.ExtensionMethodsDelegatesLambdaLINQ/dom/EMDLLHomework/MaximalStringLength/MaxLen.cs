using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MaximalStringLength
{
    internal class MaxLen
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Write some strings separated by space and hit enter");
            string[] arr = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var strMax = from str in arr
                where str.Length == arr.Max(x => x.Length)
                select str;


            Console.WriteLine(string.Join("", strMax));
        }
    }
}