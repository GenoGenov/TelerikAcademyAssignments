using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public class Point3DTest
    {
        public static void Main(string[] args)
        {
            Path p = new Path();
            p.Add(new Point3D(1, 2, 3));
            p.Add(new Point3D(2, 2, 2));

            PathStorage.SavePath(p, "path1.txt");

            Path p2 = PathStorage.LoadPath("path1.txt");

            if (p2 != null)
            {
                for (int i = 0; i < p2.Count; i++)
                {
                    Console.WriteLine(p2[i]);
                }

                Console.WriteLine("Distance: ");
                Console.WriteLine(Distance.FindDistance(p2[0], p2[1]));
            }
        }
    }
}