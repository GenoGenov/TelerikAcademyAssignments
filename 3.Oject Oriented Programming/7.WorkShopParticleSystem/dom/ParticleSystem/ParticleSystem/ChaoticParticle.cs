using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ChaoticParticle:Particle
    {
        private static readonly Random rnd = new Random();

        public ChaoticParticle(MatrixCoords position, MatrixCoords speed) : base(position, speed)
        {
        }
        protected Random GetGenerator
        {
            get
            {
                return rnd;
            }
        }

        protected override void Move()
        {
            if(rnd.Next(101)>66)
            {
                this.Accelerate(new MatrixCoords(-this.Speed.Row, -this.Speed.Col));
                this.Accelerate(new MatrixCoords(rnd.Next(-2, 2), rnd.Next(-2, 2)));
            }

            base.Move();
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'c' } };
        }
    }
}
