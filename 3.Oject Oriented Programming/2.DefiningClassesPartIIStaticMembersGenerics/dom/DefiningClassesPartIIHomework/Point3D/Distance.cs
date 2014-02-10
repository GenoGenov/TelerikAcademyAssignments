using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public static class Distance
    {
        public static double FindDistance(Point3D p1, Point3D p2)
        {
            int xd = p2.X - p1.X;
            int yd = p2.Y - p1.Y;
            int zd = p2.Z - p1.Z;

            return Math.Sqrt(xd*xd + yd*yd + zd*zd);
        }
    }
}