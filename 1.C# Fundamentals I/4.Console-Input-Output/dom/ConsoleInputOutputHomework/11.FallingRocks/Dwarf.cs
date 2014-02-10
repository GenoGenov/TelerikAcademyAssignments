using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.FallingRocks
{
    class Dwarf
    {
        public Point player;
        public string looks;
        public ConsoleColor color;

        public Dwarf(Point player)
        {
            this.player.X = player.X;
            this.player.Y = player.Y;
            looks = "(0)";
            color = ConsoleColor.White;
        }

        public void MoveLeft()
        {
            if(player.X-1>=0)
            {
                player.X -= 1;
            }
        }

        public void MoveRight()
        {
            if(player.X+1<=Console.WindowWidth-1)
            {
                player.X += 1;
            }
        }

    }
}
