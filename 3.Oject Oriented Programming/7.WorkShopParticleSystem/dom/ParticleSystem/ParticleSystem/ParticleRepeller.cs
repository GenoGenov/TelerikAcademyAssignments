using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ParticleRepeller:Particle
    {
        public int Power { get; private set; }

        public int Range { get; private set; }

        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int power, int range) : base(position, speed)
        {
            this.Power = power;
            this.Range = range;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'R' } };
        }

        public bool IsInRange(Particle p)
        {
            return Math.Sqrt(Math.Pow((this.Position.Row - p.Position.Row), 2) + Math.Pow((this.Position.Col - p.Position.Col), 2)) < this.Range;
        }
    }
}
