using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> nums = new Dictionary<string, int>();

            nums.Add("-!", 0);
            nums.Add("**", 1);
            nums.Add("!!!", 2);
            nums.Add("&&", 3);
            nums.Add("&-", 4);
            nums.Add("!-", 5);
            nums.Add("*!!!", 6);
            nums.Add("&*!", 7);
            nums.Add("!!**!-", 8);

            string input = Console.ReadLine();
            BigInteger result = 0;
            BigInteger multiplier = 1;
            List<BigInteger> results = new List<BigInteger>();

            for (int i = 0; i < input.Length; i++)
            {
                int l = 1;
                string sub = input.Substring(i, l);
                while (i + l < input.Length && !nums.ContainsKey(sub))
                {
                    l++;
                    sub = input.Substring(i, l);
                }
                i += l - 1;
                if (nums.ContainsKey(sub))
                {
                    results.Add(nums[sub]);
                }


            }

            for (int i = results.Count - 1; i >= 0; i--)
            {
                result += results[i] * multiplier;
                multiplier *= 9L;
            }

            Console.WriteLine(result);
        }
    }
}
