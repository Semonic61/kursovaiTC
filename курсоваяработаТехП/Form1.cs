using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static курсоваяработаТехП.Emitter;

namespace курсоваяработаТехП
{
    public partial class Form1 : Form
    {
        private Emitter emitter;
        private GravityPoint point1;
        private int time;

        public Form1()
        {
            InitializeComponent();
            // привязал изображение
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 1,
                SpeedMax = 10,
                ColorFrom = Color.Cyan,
                ColorTo = Color.FromArgb(0, Color.Purple),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };

            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);
        }



        double ToRadians(int degrees)
        {
            return degrees / 180.0 * Math.PI;
        }

        private void time1_Tick(object sender, EventArgs e)
        {
            time++;
            emitter.X = (int)(point1.X + point1.Power / 2 * Math.Sin(ToRadians(time)));
            emitter.Y = (int)(point1.Y + point1.Power / 2 * Math.Cos(ToRadians(time)));

            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Orange);
                emitter.Render(g);
            }

            picDisplay.Invalidate();

        }
        
        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 40 - tbDirection.Value;
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton1.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = trackBar1.Value;
        }

    }
}
