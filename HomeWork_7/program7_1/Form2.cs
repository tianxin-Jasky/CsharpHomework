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
    public delegate void TransfDelegate(order value);
    public partial class Form2 : Form
    {
        public OrderService order2 { get; set; }
        public Form2(OrderService OP)
        {
            order2 = OP;
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
            string str6= this.textBox6.Text;
            if (!checkright(textBox2))
            {
                return;
            }
            else
            {
                if (!checkPhone(textBox6))
                {
                    return;
                }
                else
                {
                    order orderform2 = new order(str1, long.Parse(str2), int.Parse(str3), int.Parse(str4), int.Parse(str5), long.Parse(str6));
                    TransfEvent(orderform2);
                    this.Close();
                }
            }
        }

        public bool checkright(TextBox Mtextbox)//订单号的警告操作
        {
            string str = Mtextbox.Text;
            string pattern = "[0-9]{11}";
            if (!Regex.IsMatch(str,pattern))
            {
                MessageBox.Show("ID输入格式错误,请检查ID的格式");
                return false;
            }
            try
            {
                if (order2.SearchOrderNum(long.Parse(str)) != null)
                {
                    MessageBox.Show("该订单号重复请重新输入订单号");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("输入的类型错误",e.Message);
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
