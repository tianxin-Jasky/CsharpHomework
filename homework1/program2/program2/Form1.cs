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
        TextBox txt = new TextBox();
        Button btm = new Button();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = this.textBox1.Text;
            double n1 = Double.Parse(s1);
            string s2 = this.textBox2.Text;
            double n2 = Double.Parse(s2);
            this.textBox3.Text = (n1 * n2).ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
