using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;
using MySql.Data.MySqlClient;

namespace program7_1
{
    public partial class Form1 : Form
    {
        public OrderService orderOP = new OrderService();
        public string KeyWord { get; set; }
        public long KeyWord1 { get; set; }
        public long KeyWord2 { get; set; }
        public long KeyWord3 { get; set; }


        public Form1()
        {
            InitializeComponent();
            orderOP.list.Add(new order("张三", 20181111001, 3, 3, 3,123456789));
            orderOP.list.Add(new order("李四", 20181111002, 4, 4, 4,987654321));
            bindingSource1.DataSource = orderOP.list;

            Input.DataBindings.Add("Text", this, "KeyWord");
            Input2.DataBindings.Add("Text", this, "KeyWord1");
            Input3.DataBindings.Add("Text", this, "KeyWord2");
            Input4.DataBindings.Add("Text", this, "KeyWord3");
        }
        //根据Name进行查询的操作
        private void button1_Click(object sender, EventArgs e)   //这个是查询名字
        {
            bindingSource1.DataSource = orderOP.SearchOrderName(KeyWord);
        }
        //根据ID进行查询的操作
        private void button2_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = orderOP.SearchOrderNum(KeyWord1);
        }
        //显示全部订单的操作
        private void button4_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = orderOP.list;
        }
        //这个按钮是增加一个订单，但是只有当进行查询操作之后，点击显示全部订单的按钮，新建的订单才会显示出来(不知道怎么回事)
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(orderOP);
            form2.MdiParent = this.MdiParent;
            form2.TransfEvent += form2_TransfEvent;
            form2.Show();
            bindingSource1.DataSource = orderOP.SearchOrderName(KeyWord);
        }

        //事件处理方法(增加订单的操作)
        void form2_TransfEvent(order value)
        {
            orderOP.list.Add(value);
        }

        //删除按钮
        private void button6_Click(object sender, EventArgs e)
        {
            orderOP.deleteOrderNum(KeyWord2);
            bindingSource1.DataSource = orderOP.SearchOrderNum(KeyWord2);
        }
        //修改数据
        private void button5_Click(object sender, EventArgs e)
        {
            order modify = orderOP.SearchOrderNum(KeyWord3);
            Form3 form3 = new Form3(orderOP,modify);
            form3.MdiParent = this.MdiParent;
            form3.Show();
            bindingSource1.DataSource = orderOP.SearchOrderName(KeyWord);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"E:\answer\code\homework_csharp\HomeWork_7\program7_1\s.xml");

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(@"E:\answer\code\homework_csharp\HomeWork_7\program7_1\Transform.xslt");

                FileStream fileStream = File.OpenWrite(@"E:\answer\code\homework_csharp\HomeWork_7\program7_1\homework8.html");
                XmlTextWriter writer =
                    new XmlTextWriter(fileStream, System.Text.Encoding.UTF8);
                xt.Transform(nav, null, writer);
            }
            catch (XmlException ee)
            {
                Console.WriteLine("XML Exception:" + ee.ToString());
            }
            catch (XsltException ee)
            {
                Console.WriteLine("XSLT Exception:" + ee.ToString());
            }

        }

        string MyconnectionString = "Server=localhost;Database=order_1;Uid=root;Pwd=password";
        private void button8_Click(object sender, EventArgs e)
        {
            MySqlConnection msq = new MySqlConnection(MyconnectionString);
            msq.Open();
            MySqlCommand cmd=new MySqlCommand("CREATE TABLE `NewTable` (`ClientName`  varchar(255) NULL,`ID`  bigint NULL,`AppleNum`  int NULL,`BallNum`  int NULL,`PenNum`  int NULL,`Price`  decimal(10, 2) NULL,`ClientTelephoneNumber`  bigint NULL);",msq);
            cmd.ExecuteNonQuery();
            msq.Close();
            //try
            //{
            //    cmd = msq.CreateCommand();
            //    foreach (order i in orderOP.list)
            //    {
            //        cmd.CommandText = "INSERT INTO Order(ClientName,ID,AppleNum,BallNum,PenNum,Price,ClientTelephoneNumber)VALUES(@ClientName,@ID,@AppleNum,@BallNum,@PenNum,@Price,@ClientTelephoneNumber)";
            //        cmd.Parameters.AddWithValue("@ClientName", i.ClientName);
            //        cmd.Parameters.AddWithValue("@ID", i.ID);
            //        cmd.Parameters.AddWithValue("@AppleNum", i.AppleNum);
            //        cmd.Parameters.AddWithValue("@BallNum", i.BallNum);
            //        cmd.Parameters.AddWithValue("@PenNum", i.PenNum);
            //        cmd.Parameters.AddWithValue("@Price", i.price);
            //        cmd.Parameters.AddWithValue("@ClientTelephoneNumber", i.ClientTelephoneNumber);

            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //finally
            //{
            //    if (msq.State == ConnectionState.Open)
            //    {
            //        msq.Close();
            //    }
            //}
        }
    }
}
