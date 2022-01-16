﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs
{
    class Emiter
    {
        public List<Particle> particles = new List<Particle>();
        public float X;
        public float Y;
        public float GravitationX = 0;
        public float GravitationY = 0; // пусть гравитация будет силой один пиксель за такт, нам хватит
        public int ParticlesCount = 500;
        public float Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 100; // разброс частиц относительно Direction
        public int SpeedMin = 10; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы
        public int ParticlesPerTick = 5; // добавил новое поле

        public Color ColorFrom = Color.Red; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Blue); // конечный цвет частиц

        public virtual void ResetParticle(Particle particle) {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction
                + (double)Particle.rand.Next(Spreading)
                - Spreading / 2;

            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }
        public virtual Particle CreateParticle()
        {
            var particle = new Particle.ParticleColorful();
            //particle.FromColor = ColorFrom;
            //particle.ToColor = ColorTo;

            return particle;
        }

        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick;
            foreach (var particle in particles)
            {
                
                if (particle.Life <= 0)
                {
                    particle.Life = 20 + Particle.rand.Next(100); 
                    particle.X = X;
                    particle.Y = Y;
                    // делаю рандомное направление, скорость и размер
                    var direction = (double)Particle.rand.Next(360);
                    var speed = 1 + Particle.rand.Next(10);

                    particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                    particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);
                    particle.Radius = 2 + Particle.rand.Next(10);
                    if (particlesToCreate > 0)
                    {
                        /* у нас как сброс частицы равносилен созданию частицы */
                        particlesToCreate -= 1; // поэтому уменьшаем счётчик созданных частиц на 1
                        ResetParticle(particle);
                    }
                }
                else
                {
                    // гравитация воздействует на вектор скорости, поэтому пересчитываем его
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;


                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
            // добавил генерацию частиц
            // генерирую не более 10 штук за тик
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }

        public void Render(Graphics g)
        {
            
            
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
        }
    }
}
