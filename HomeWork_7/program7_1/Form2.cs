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
    public delegate void TransfDelegate(order value);
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        public event TransfDelegate TransfEvent;
        private void button1_Click(object sender, EventArgs e)
        {
            
            string str1 = this.textBox1.Text;
            string str2 = this.textBox2.Text;
            string str3 = this.textBox3.Text;
            string str4 = this.textBox4.Text;
            string str5 = this.textBox5.Text;
            order orderform2 = new order(str1, int.Parse(str2), int.Parse(str3), int.Parse(str4),int.Parse(str5));
            TransfEvent(orderform2);
            this.Close();
        }
    }
}
