using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсоваяработаТехП
{
    public abstract class IImpactPoint
    {

        public float X; 
        public float Y;

        
        public abstract void ImpactParticle(Particle particle);

        // базовый класс для отрисовки точечки
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.White),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );

        }
    }

    public class GravityPoint : IImpactPoint
    {
        public int Power = 200; // сила притяжения

        // а сюда по сути скопировали с минимальными правками то что было в UpdateState
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            //particle.SpeedX += gX * Power / r2;
            //particle.SpeedY += gY * Power / r2;
        }

        public override void Render(Graphics g)
        {
            // буду рисовать окружность с диаметром равным Power
            g.DrawEllipse(
                   new Pen(Color.Black),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );
        }

    }
}
