using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program7_1
{
    public class order
    {
        public string ClientName { set; get; }
        public int ID { set; get; }
        public int AppleNum { set; get; }
        public int BallNum { set; get; }
        public int PenNum { set; get; }
        public int price { set; get; }

        public order(string name, int id, int apple,int ball,int pen)
        {
            ClientName = name;
            ID = id;
            AppleNum = apple;
            BallNum = ball;
            PenNum = pen;
            this.price = apple * 1000 + ball * 2000 + ball * 300;
        }
    }

    public class OrderService
    {
        public List<order> list = new List<order>();
        //添加


        public void PrintOrder(order i)
        {
            if (i != null) Console.WriteLine(i.ClientName + "  订单号：" + i.ID + "  苹果的个数" + i.AppleNum + "  球的个数" + i.BallNum + "  笔的个数" + i.PenNum + " 订单总金额为:" + i.price);
            else Console.WriteLine("这个订单为空");
        }

        public void AddOrder()
        {
            try
            {
                Console.Write("输入客户名字：");
                string ClientName = Convert.ToString(Console.ReadLine());
                Console.Write("输入订单号码：");
                int Number = Convert.ToInt32(Console.ReadLine());
                Console.Write("输入苹果数量：");
                int AppleNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("输入球数量：");
                int BallNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("输入笔数量：");
                int PenNum = Convert.ToInt32(Console.ReadLine());
                order NewOrder = new order(ClientName, Number, AppleNum, BallNum, PenNum);
                list.Add(NewOrder);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        //查询
        //根据客户名字查询
        public order SearchOrderName(string ClientName)
        {
            var O1 = from n in list
                     where n.ClientName == ClientName
                     select n;
            order O2 = null;
            if (O1 != null)
            {
                foreach (order ele in O1) O2 = ele;
            }
            return O2;
        }
        //按照订单号查询
        public order SearchOrderNum(int Number)
        {
            var O1 = from n in list
                     where n.ID == Number
                     select n;
            order O2 = null;
            foreach (order ele in O1) O2 = ele;
            return O2;
        }

        //根据订单号删除
        public void deleteOrderNum(int number)
        {
            try
            {
                order ii = null;
                foreach (order i in list)
                {
                    if (i.ID == number) ii = i;
                }
                list.Remove(ii);
            }
            catch (Exception e)
            {
                Console.WriteLine("Remove失败" + e.Message);
            }

        }

        //修改订单的数据
        //修改客户名称
        public void modifyOrderName(string name1, string name2)
        {
            try
            {
                foreach (order i in list)
                {
                    if (i.ClientName == name1) i.ClientName = name2;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        //修改客户订单号
        public void modifyOrderNum(int num1, int num)
        {
            try
            {
                foreach (order i in list)
                {
                    if (i.ID == num1) i.ID = num;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }

}
