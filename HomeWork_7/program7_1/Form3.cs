using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program7_1
{
    public partial class Form3 : Form
    {
        public order order3 { get; set; }
        public Form3(order value)
        {
            InitializeComponent();
            order3 = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str4 = this.textBox4.Text;
            order3.BallNum = int.Parse(str4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str1 = this.textBox1.Text;
            order3.ClientName = str1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str2 = this.textBox2.Text;
            order3.ID = int.Parse(str2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str3 = this.textBox3.Text;
            order3.AppleNum = int.Parse(str3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string str5 = this.textBox5.Text;
            order3.PenNum = int.Parse(str5);
        }
    }
}
