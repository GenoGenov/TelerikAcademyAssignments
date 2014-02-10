using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public class Path
    {
        #region Fields

        private List<Point3D> points;

        #endregion

        #region Properties

        public int Count
        {
            get { return points.Count; }
        }

        #endregion

        #region Constructors

        public Path()
        {
            points = new List<Point3D>();
        }

        #endregion

        #region Indexer

        public Point3D this[int index]
        {
            get
            {
                if (index < 0 || index >= points.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return points[index];
            }
        }

        #endregion

        #region Methods

        public void Add(Point3D p)
        {
            points.Add(p);
        }

        public bool Remove(Point3D p)
        {
            return points.Remove(p);
        }

        #endregion
    }
}