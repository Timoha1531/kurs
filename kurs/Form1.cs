using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurs
{
    public partial class Form1 : Form
    {
        Ellipse ellipse; float ellipseAngle = 0f;
        Emiter emitter = new Emiter(); 
        List<Ellipse> ellipses = new List<Ellipse>();
        
        float Engalspeed1 =1;
      
        public Form1()
        {
            InitializeComponent();
            
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            ellipse = new Ellipse(40, picDisplay.Width / 2, picDisplay.Height / 2);

            emitter.colorEllipses.Add(new ColorEllipse(60, picDisplay.Width - picDisplay.Width / 4, picDisplay.Height / 2, Color.Pink));
            emitter.colorEllipses.Add(new ColorEllipse(60, picDisplay.Width / 2, picDisplay.Height / 6, Color.Green));
            emitter.colorEllipses.Add(new ColorEllipse(60, picDisplay.Width / 2, picDisplay.Height - picDisplay.Height / 6, Color.Purple));
            emitter.colorEllipses.Add(new ColorEllipse(60, picDisplay.Width / 4, picDisplay.Height / 2, Color.Blue));



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SearchMove();
           
            emitter.UpdateState(); 
            
            using (var g = Graphics.FromImage(picDisplay.Image))
            {

                g.Clear(Color.White);
                emitter.Render(g);
                ellipse.Render(g);

            }

            picDisplay.Invalidate();

        }
        
        public void SearchMove()
        {
           
            if (ellipseAngle < 360)
            {
                emitter.X = (float)(ellipse.R * Math.Cos(ellipseAngle*Math.PI/180)+ ellipse.X);
                emitter.Y = (float)(ellipse.R * Math.Sin(ellipseAngle * Math.PI / 180)+ ellipse.Y);
                ellipseAngle+=Engalspeed1;
                
                emitter.Direction = -ellipseAngle+90;
            }
            else
            {
                emitter.X = (float)(ellipse.R * Math.Cos(ellipseAngle * Math.PI / 180) + ellipse.X);
                emitter.Y = (float)(ellipse.R * Math.Sin(ellipseAngle * Math.PI / 180) + ellipse.Y);
                ellipseAngle=0;
               emitter.Direction = -ellipseAngle+90;
            }
        }
      
      
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            
        
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ellipse.R = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Engalspeed1 = trackBar2.Value;
         
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = trackBar3.Value;
        }

        public void trackBar4_Scroll(object sender, EventArgs e)
        {
            foreach(Ellipse ellipse in emitter.colorEllipses)
            {
                if(ellipse is ColorEllipse)
                {
                    ellipse.R = trackBar4.Value;
                }
            }
        }
       

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

