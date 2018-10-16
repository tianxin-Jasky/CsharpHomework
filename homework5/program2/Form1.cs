using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }

        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;

            string ss1 = this.textBox1.Text;
            string ss2 = this.textBox2.Text;
            string ss3 = this.textBox3.Text;
            string ss4 = this.textBox4.Text;
            string ss5 = this.textBox5.Text;

            double s1 = double.Parse(ss1);
            double s2 = double.Parse(ss2);
            double th1 = double.Parse(ss3) * Math.PI / 180; ;
            double th2 = double.Parse(ss4) * Math.PI / 180;
            double k= double.Parse(ss5);

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng *k *Math.Cos(th);
            double y2 = y0 + leng *k* Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, s1 * leng, th + th1);
            drawCayleyTree(n - 1, x2, y2, s2 * leng, th - th2);
        }

        void drawLine(double x0,double y0,double x1,double y1)
        {
            graphics.DrawLine(
                Pens.Red,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
