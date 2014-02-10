using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _11.FallingRocks
{
    class Rocks
    {
        public Point location;
        public string type;
        public ConsoleColor color;

        public Rocks(Point location, string type, ConsoleColor color)
        {
            this.color = color;
            this.location = location;
            this.type = type;
        }

        public void UpdateLocation()
        {
            location.Y += 1;

        }

    }
}
