using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split(new[]{','},StringSplitOptions.RemoveEmptyEntries);
            string[] input2 = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int F = int.Parse(Console.ReadLine());
            string[] input3 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> points = new List<int>();
            List<int> sizes = new List<int>();
            List<int> actual = new List<int>();

            int[] output = new int[3];

            for (int i = 0; i < input1.Length; i++)
            {
                points.Add(int.Parse(input1[i]));
                actual.Add(int.Parse(input1[i]));
            }

            for (int i = 0; i < input2.Length; i++)
            {
                sizes.Add(int.Parse(input2[i]));
            }

            for (int i = points.Count-1; i >=0; i--)
            {
                if (points[i] > 21)
                {
                    points.RemoveAt(i);
                }
            }
            int me = 0;
            int turn = 0;
            while(sizes.Count>0)
            {
                if (turn == 0)
                {
                    me += sizes.Max();
                    sizes.Remove(sizes.Max());
                    turn++;
                }
                else
                {
                    sizes.Remove(sizes.Max());
                    turn++;
                }
                if (turn == F+1)
                {
                    turn=0;
                }
            }
            int count = points.Count(x => x == points.Max());
            if (count == 1)
                output[0] = (actual.IndexOf(points.Max()));
            else
                output[0] = -1;
            output[1] = me;

            int[] owned = new int[3];
            int[] needed = new int[3];

            for (int i = 0; i < 3; i++)
            {
                owned[i] = int.Parse(input3[i]);
                needed[i] = int.Parse(input3[i + 3]);
            }
            int operations = 0;
            while (owned[0]<needed[0] && (owned[1]!=0 || owned[2]!=0))
            {
                if (owned[1] >= 11)
                {
                    owned[0] ++;
                    owned[1] -= 11;
                    operations++;
                }
                else if (owned[2] >= 11)
                {
                    owned[1]++;
                    owned[2] -= 11;
                    operations++;
                }
                else
                {
                    break;
                }
            }
            while (owned[1] < needed[1] && (owned[2] != 0 || owned[0]!=0))
            {
                if (owned[0] > needed[0])
                {
                    owned[0]--;
                    owned[1] += 9;
                    operations++;
                }
                else if (owned[2] >= 11)
                {
                    owned[1]++;
                    owned[2] -= 11;
                    operations++;
                }
                else
                {
                    break;
                }
            }
            while (owned[2] < needed[2] && (owned[1] != 0 || owned[0] != 0))
            {
                if (owned[1] > needed[1])
                {
                    owned[1]--;
                    owned[2] += 9;
                    operations++;
                }
                else if (owned[0] > needed[0])
                {
                    owned[0]--;
                    owned[1] += 9;
                    operations++;
                }
                else
                {
                    break;
                }
            }

            if (owned[0] >= needed[0] && owned[1] >= needed[1] && owned[2] >= needed[2])
            {
                output[2]=operations;
            }
            else
            {
                output[2] = -1;
            }

            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine(output[i]);
            }
        }
    }
}
