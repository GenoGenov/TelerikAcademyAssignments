using System;
using System.Linq;

namespace Shapes
{
    public class ShapesTests
    {
        private static void Main(string[] args)
        {
            Shape[] shapes =
            {
                new Circle(4),
                new Rectangle(3, 7),
                new Triangle(5, 9),
            };
            
            foreach (var shape in shapes)
            {
                Console.WriteLine("Figure: {0} : Surface: {1}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}