using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace program7_1
{
    public partial class Form3 : Form
    {
        public order order3 { get; set; }
        public OrderService order3Service { get; set; }
        public Form3(OrderService value1,order value)
        {
            InitializeComponent();
            order3Service = value1;
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
            if (!checkright(textBox2))
            {
                return;
            }
            else
            {
                string str2 = this.textBox2.Text;
                order3.ID = long.Parse(str2);
            }
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (!checkPhone(textBox6))
            {
                return;
            }
            else
            {
                string str6 = this.textBox6.Text;
                order3.ClientTelephoneNumber = long.Parse(str6);
            }
        }

        public bool checkright(TextBox Mtextbox)//订单号的警告操作
        {
            string str = Mtextbox.Text;
            string pattern = "[0-9]{11}";
            if (!Regex.IsMatch(str, pattern))
            {
                MessageBox.Show("ID输入格式错误,请检查ID的格式");
                return false;
            }
            try
            {
                if (order3Service.SearchOrderNum(long.Parse(str)) != null)
                {
                    MessageBox.Show("该订单号重复请重新输入订单号");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("输入的类型错误", e.Message);
                return false;
            }
            return true;
        }

        public bool checkPhone(TextBox Ptextbox)//电话号码的检查
        {
            string str = Ptextbox.Text;
            string pattern = "[0-9]{9}";
            if (!Regex.IsMatch(str, pattern))
            {
                MessageBox.Show("电话输入错误");
            }
            try
            {
                long phone = long.Parse(str);
            }
            catch (Exception e)
            {
                MessageBox.Show("输入的类型错误", e.Message);
                return false;
            }
            return true;
        }
    }
}
