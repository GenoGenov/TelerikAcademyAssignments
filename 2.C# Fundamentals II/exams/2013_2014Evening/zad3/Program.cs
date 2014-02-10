
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int X = int.Parse(nums[0].ToString());
            int Y = int.Parse(nums[1].ToString());
            int Z = int.Parse(nums[2].ToString());

            string directions1 = Console.ReadLine();
            string directions2 = Console.ReadLine();
            string directions = string.Join(directions1, directions2);

            int redX = X / 2;
            int redY = Y / 2;
            int blueX = X / 2;
            int blueY = Y / 2;
            int test;
            for (int i = 0; i < directions.Length; i++)
            {
                char current = directions[i];
                if (int.TryParse(current.ToString(), out test))
                {
                    i++;

                }
            }
        }
    }
}
