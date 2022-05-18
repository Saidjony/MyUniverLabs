using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лр17шарп
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static Graphics g; 

        Ellipses myellipses = new Ellipses();
        private void button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            int b =   int.Parse(textBox2.Text);
            g = pictureBox1.CreateGraphics();
            int width = pictureBox1.Width, height = pictureBox1.Height;
            g.DrawLine(new Pen(Color.Black), width / 2, height,width/2, 0);
            g.DrawLine(new Pen(Color.Black), 0, height / 2, width, height / 2);
            myellipses.drawEllipse(new Pen(Color.Red),a, b, width, height);
            double fokal = Math.Sqrt(Math.Pow(a, 2) - Math.Pow(b, 2));
            float x1=(width/2- (float)fokal/2), x2=(width/2+ (float)fokal/2);
            g.DrawLine(new Pen(Color.Green), x1, height / 2,x2, height / 2);
            double p =(height/2- 2*(Math.Pow(b/2, 2)) / a);
            myellipses.drawfokal(x1, x2, height, (float)p);
            
            label1.Text = "фокальная параметр P =  " + myellipses.fokalparam(a, b).ToString();
        }
        public readonly struct Ellipses
        {
            public void drawEllipse(Pen pen, int a, int b, int width, int height) {
                g.DrawEllipse(pen, width / 2 - a / 2, height / 2 - b / 2, a, b);
                g.DrawRectangle(pen, width / 2 - 5, height / 2 - 5, 10, 10);
            }
            public float fokalparam(int a, int b) { return (float)(Math.Pow(b, 2) / a); }
            public void drawfokal(float x1, float x2, float height, float p)
            {
                g.DrawLine(new Pen(Color.HotPink), x1, height / 2, x1, (float)p);
                g.DrawLine(new Pen(Color.HotPink), x2, height / 2, x1, (float)p);
            }
            
            public readonly int num_a, num_b;

            public Ellipses(int a, int b)
            {
                num_a = a;
                num_b = b;
                
            }

            public static int[] operator -(Ellipses a,Ellipses b)
            {
                int suma = Math.Abs(a.num_a - b.num_a);
                int sumb = Math.Abs(a.num_b - b.num_b);
                int[] res = new int[] {suma,sumb};
                return res;
            }
            public static string operator !=(Ellipses fir, Ellipses sec)
            {
                if (fir.fokalparam(fir.num_a, fir.num_b) != sec.fokalparam(sec.num_a, sec.num_b))
                {
                    return "!=";
                }
                return "==";
            }


            public static string operator ==(Ellipses fir, Ellipses sec)
            {
                if (fir.fokalparam(fir.num_a, fir.num_b) == sec.fokalparam(sec.num_a, sec.num_b))
                {
                    return "==";
                }
                else if (fir.fokalparam(fir.num_a, fir.num_b) < sec.fokalparam(sec.num_a, sec.num_b))
                {
                    return "<";
                }
                else return ">";     
            }
            public static Ellipses operator ++(Ellipses ell)
            {
                return new Ellipses(Math.Max(ell.num_a, ell.num_b),Math.Min(ell.num_a,ell.num_b));
            }

        }
        private void ClearColor(PaintEventArgs e)
        { 
            e.Graphics.Clear(pictureBox1.BackColor);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ClearColor(new PaintEventArgs(g,new Rectangle(pictureBox1.Location.X,pictureBox1.Location.Y,pictureBox1.Width,pictureBox1.Height)));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text), b = int.Parse(textBox2.Text),w=int.Parse(textBox3.Text),h=int.Parse(textBox4.Text);
            Ellipses ellipses_ab = new Ellipses(a, b),ellipses_wh=new Ellipses(w,h);
            var plus = ellipses_ab-ellipses_wh;
            MessageBox.Show("plus a"+plus[0]+" - " + plus[1]);
            Ellipses myellipses = new Ellipses();
            myellipses.drawEllipse(new Pen(Color.Black),plus[0], plus[1], pictureBox1.Width, pictureBox1.Height);
            myellipses.drawEllipse(new Pen(Color.Aqua), w, h, pictureBox1.Width, pictureBox1.Height);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text), b = int.Parse(textBox2.Text),w=int.Parse(textBox3.Text),h=int.Parse(textBox4.Text);
            var compare1 = new Ellipses(a, b);
            var compare2 = new Ellipses(w, h);
            var comp = compare1 == compare2;
            label9.Text = "ellipse 1" +comp+ "ellipse 2";  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text), b = int.Parse(textBox2.Text),w=int.Parse(textBox3.Text),h=int.Parse(textBox4.Text);

            var increment = new Ellipses(w,h);
            increment++;
            increment.drawEllipse(new Pen(Color.DarkBlue), increment.num_a, increment.num_b, pictureBox1.Width,pictureBox1.Height);
        }
    }
}