using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CheckPointInCircle
{
    class CheckPoint
    {
        static void Main(string[] args)
        {
            string xCoord;
            string yCoord;
            Point center = new Point(0,0);
            int radius = 5;
            int pointX;
            int pointY;
            do
            {
                Console.Write("X coordinate:");
                xCoord = Console.ReadLine();
                
            } while (!int.TryParse(xCoord,out pointX));

            do
            {
                Console.Write("Y coordinate:");
                yCoord = Console.ReadLine();

            } while (!int.TryParse(yCoord, out pointY));

            bool ispointInCircle = (pointX - center.X) * (pointX - center.X) + (pointY - center.Y) * (pointY - center.Y) <= radius * radius;
            Console.WriteLine("Is the point in the circle: {0}",ispointInCircle? "Yes":"No" );
            
        }
    }
}
