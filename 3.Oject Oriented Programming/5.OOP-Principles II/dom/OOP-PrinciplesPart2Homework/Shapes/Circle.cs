using System;
using System.Linq;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double width) : base(width, width)
        {
        }

        public override double CalculateSurface()
        {
            return this.Width * 2 * Math.PI;
        }
    }
}