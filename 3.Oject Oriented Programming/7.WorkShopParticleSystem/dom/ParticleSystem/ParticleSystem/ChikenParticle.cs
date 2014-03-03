using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ChikenParticle:ChaoticParticle
    {
        private int stopDuration;

        private int stopTimeRemaining;

        public ChikenParticle(MatrixCoords position, MatrixCoords speed, int stopDuration) : base(position, speed)
        {
            this.stopDuration = Math.Abs(stopDuration);
            this.stopTimeRemaining = 0;
        }

        

        public override IEnumerable<Particle> Update()
        {            
            if(this.stopTimeRemaining!=0)
            {
                stopTimeRemaining--;
                if(this.stopTimeRemaining==0)
                {
                    var newChiken = new List<ChikenParticle>();
                    newChiken.Add(new ChikenParticle(this.Position,new MatrixCoords(-this.Speed.Row,-this.Speed.Col),this.stopDuration));
                    return newChiken;
                }
                return base.Update();
            }
            if(this.GetGenerator.Next(101)>88)
            {
                this.stopTimeRemaining = this.stopDuration;
            }
            return base.Update();

        }
    }
}
