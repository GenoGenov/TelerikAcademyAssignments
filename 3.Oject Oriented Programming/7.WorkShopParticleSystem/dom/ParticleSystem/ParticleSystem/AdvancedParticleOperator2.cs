using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class AdvancedParticleOperator2:AdvancedParticleOperator
    {
        private List<ParticleRepeller> repellers = new List<ParticleRepeller>();
        private List<Particle> particles = new List<Particle>();
        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var repeller = p as ParticleRepeller;
            if (repeller == null)
            {
                this.particles.Add(p);
            }
            else
            {
                this.repellers.Add(repeller);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in repellers)
            {
                foreach (var particle in particles)
                {
                    if(repeller.IsInRange(particle))
                    {
                        particle.Accelerate(new MatrixCoords(particle.Speed.Row * repeller.Power * -1,particle.Speed.Col * repeller.Power * -1));
                    }
                }
            }
            this.repellers.Clear();
            this.particles.Clear();
            base.TickEnded();
        }
    }
}
