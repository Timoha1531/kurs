using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs
{
     class ColorEllipse : Ellipse
    {
       
        public ColorEllipse(float R, float X, float Y,Color color) : base(R, X, Y)
        {
            this.color = color;  
        }
        public override void Render(Graphics g)
        {
            g.DrawEllipse(
              new Pen(color),
              X - R,
              Y - R,
              2 * R,
              2 * R
          );
        }
        public static void RemoweColor(List<Ellipse> ellipses, Emiter emitter, int Value)
        {
            float pifagor = 0;
            foreach (Ellipse ell in ellipses)
            {
                if (ell is ColorEllipse)
                {
                    foreach (Particle particle in emitter.particles)
                    {
                        float newX = ell.X - particle.X;
                        float newY = ell.Y - particle.Y;
                        pifagor = (float)(Math.Sqrt(newX * newX + newY * newY));
                        if (pifagor <= ell.R)
                        {
                            particle.FromColor = ell.color;
                            particle.ToColor = ell.color;
                        }
                    }
                }
            }

        }
    }
}
