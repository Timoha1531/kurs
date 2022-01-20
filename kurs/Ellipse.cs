using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs
{
     class Ellipse
    {
        public float R;
        public float X, Y;
        public Color color;

        public Ellipse(float R, float X, float Y)
        {
            this.X = X;
            this.Y = Y;
            this.R = R;
            
        }

       
        public virtual void Render(Graphics g)
        {
            g.DrawEllipse(
              new Pen(Color.Red),
              X - R,
              Y - R,
              2*R,
              2*R
          );
        }
       
    }
}
