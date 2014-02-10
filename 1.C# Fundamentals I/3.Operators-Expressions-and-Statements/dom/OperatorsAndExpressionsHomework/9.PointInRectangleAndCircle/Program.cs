using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.PointOutRectangleInCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Point center = new Point(1, 1);
            int x;
            int y;
            int top = 1;
            int left = -1;
            int width = 6;
            int height = 2;
            int radius=3;

            do
            {
                Console.Write("X coordinate:");
                input = Console.ReadLine();


            } while (!int.TryParse(input, out x));

            do
            {
                Console.Write("Y coordinate:");
                input = Console.ReadLine();


            } while (!int.TryParse(input, out y));

            Point point = new Point(x, y);
            bool isInCircle=((point.X - center.X) * (point.X - center.X) + (point.Y - center.Y) * (point.Y - center.Y)) <= radius * radius;
            bool isInRectangle = ((point.X >= left) && (point.X <= left + width)) && ((point.Y <= top) && (point.Y >= top - height));
            Console.WriteLine("The point is{0} in the circle and {1} the rectangle.",isInCircle ? string.Empty:" not",isInRectangle ? "in":"out");
        }
    }
}
