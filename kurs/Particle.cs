﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace kurs
{
    class Particle
    {
        
        public int Radius; 
        public float X; 
        public float Y; 
        public float SpeedX; 
        public float SpeedY;
        public float Life;
        public Color FromColor = Color.Red;
        public Color ToColor = Color.Black;
        public Color ColorFrom = Color.Red; // 
        public Color ColorTo = Color.FromArgb(0, Color.Orange); 
        public static Random rand = new Random();

        
        public Particle()
        {
            var direction = (0);
            var speed = 1 + rand.Next(50);

            
            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);
            
            Radius = 2 + rand.Next(10);
            Life = 20 + rand.Next(100); 
        }
        public virtual void Draw(Graphics g)
        {


            
            float k = Math.Min(1f, Life / 100);
            
            int alpha = (int)(k * 255);

           
            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);

            
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
        
        public class ParticleColorful : Particle
        {
            
           

            
            public static Color MixColor(Color color1, Color color2, float k)
            {
                return Color.FromArgb(
                    (int)(color2.A * k + color1.A * (1 - k)),
                    (int)(color2.R * k + color1.R * (1 - k)),
                    (int)(color2.G * k + color1.G * (1 - k)),
                    (int)(color2.B * k + color1.B * (1 - k))
                );
            }

          
            public override void Draw(Graphics g)
            {
                float k = Math.Min(1f, Life / 100);

                
                var color = MixColor(ToColor, FromColor, k);
                var b = new SolidBrush(color);

                g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

                b.Dispose();
            }
            public virtual void ResetParticle(Particle particle) { }
        }
        }
}
