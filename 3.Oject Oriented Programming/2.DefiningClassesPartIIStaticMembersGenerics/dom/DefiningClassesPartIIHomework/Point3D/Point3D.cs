using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public struct Point3D
    {
        private static readonly Point3D o = new Point3D(0, 0, 0);

        #region Constructors

        public Point3D(int x, int y, int z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return string.Format("({0};{1};{2})", this.X, this.Y, this.Z);
        }

        #endregion

        #region Properties

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public static Point3D O
        {
            get { return o; }
        }

        #endregion
    }
}