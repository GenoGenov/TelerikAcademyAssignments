//Write methods that calculate the surface of a triangle

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SurfaceOfATriangle
{
    class Test
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Surface by given three sides :{0}",Triangle.SurfaceOfATriangle(8, 9, 11m));


            //angle in radians 2.14675498 rad = 123 degrees
            Console.WriteLine("Surface by given two sides and an angle:{0}",Triangle.SurfaceOfATriangle(150, 231, 2.14675498f)); 


            Console.WriteLine("Surface by given a side and an altitude:{0}",Triangle.SurfaceOfATriangle(4,8));
        }
    }
}
