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
        public void ImpactParticle(Particle particle)
        {
            float newX = X - particle.X;
            float newY = Y - particle.Y;
            float pifagor = (float)(Math.Sqrt(newX * newX + newY * newY));

            if (pifagor <= R)
            {
                particle.FromColor = color;
                particle.ToColor = color;
            }
        }


    }
}
