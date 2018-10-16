using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Order O1 = new Order("张三", 1, 3, 3, 3);
            Order O2 = new Order("李四", 2, 4, 4, 4);
            List<Order> orderlist = new List<Order>();
            orderlist.Add(O1);
            orderlist.Add(O2);
            Console.WriteLine("输入进行的操作:1显示所有订单 2添加订单 3删除订单 4查询 5修改订单 6查询金额大于10000的订单 7@  ");
            string sss = Console.ReadLine();
            while (sss != "@")
            {
                int operationNum = int.Parse(sss);
                switch (operationNum)
                {
                    case 1:       //利用foreach将所有的订单输出
                        OrderService order11 = new OrderService();
                        foreach (Order i in orderlist)
                        {
                            order11.PrintOrder(i);
                        }
                        break;
                    case 2:         //添加订单
                        OrderService order1 = new OrderService();
                        order1.AddOrder();
                        orderlist.Add(order1.list[0]);
                        break;
                    case 3:
                        OrderService order2 = new OrderService();
                        order2.list = orderlist;
                        try
                        {
                            Console.WriteLine("输入删除订单号：");
                            int Searchnum3 = Convert.ToInt32(Console.ReadLine());
                            Order o32 = order2.SearchOrderNum(Searchnum3);
                            order2.deleteOrderNum(o32.Number);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("失败了" + e.Message);
                        }
                        break;
                    case 4:
                        OrderService order4 = new OrderService();
                        order4.list = orderlist;
                        Console.WriteLine("1客户名称 2订单号");
                        int qq = int.Parse(Console.ReadLine());
                        switch (qq)
                        {
                            case 1:
                                Console.WriteLine("输入：");
                                string SearchName = Console.ReadLine();
                                Order o41 = order4.SearchOrderName(SearchName);
                                order4.PrintOrder(o41);
                                break;
                            case 2:
                                Console.WriteLine("输入：");
                                int Searchnum = Convert.ToInt32(Console.ReadLine());
                                Order o2 = order4.SearchOrderNum(Searchnum);
                                order4.PrintOrder(o2);
                                break;
                        }
                        break;
                    case 5:
                        OrderService order3 = new OrderService();
                        order3.list = orderlist;
                        Console.WriteLine("1修改客户名称 2修改订单号");
                        int qqq = int.Parse(Console.ReadLine());
                        switch (qqq)
                        {
                            case 1:
                                Console.WriteLine("输入原来的名字：");
                                string SearchName1 = Convert.ToString(Console.ReadLine());
                                Console.WriteLine("输入现在的名字：");
                                string SearchName2 = Convert.ToString(Console.ReadLine());
                                Order o1 = order3.SearchOrderName(SearchName1);
                                o1.ClientName = SearchName2;
                                break;
                            case 2:
                                Console.WriteLine("输入以前的订单号：");
                                int Searchnum = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("输入现在的订单号：");
                                int Searchnum2 = Convert.ToInt32(Console.ReadLine());
                                Order o2 = order3.SearchOrderNum(Searchnum);
                                o2.Number = Searchnum2;
                                break;
                        }
                        break;
                    case 6:
                        
                        OrderService order6 = new OrderService();
                        foreach (Order i in orderlist)
                        {
                            if (i.price > 10000)
                            {
                                order6.PrintOrder(i);
                            }
                        }
                        break;
                }
                Console.WriteLine("输入进行的操作:1显示所有订单 2添加订单 3删除订单 4查询 5修改订单 6查询金额大于10000的订单 7@ ");
                sss = Console.ReadLine();
            }
            Environment.Exit(0);
        }
    }
}

class Order
{
    public string ClientName;
    public int Number, AppleNum, BallNum, PenNum,price;
    public Order(string clientName, int number, int applenum, int ballnum, int pennum)
    {
        ClientName = clientName;
        Number = number;
        AppleNum = applenum;
        BallNum = ballnum;
        PenNum = pennum;
        price = applenum * 1000 + ballnum * 2000 + pennum * 300;
    }
    
}

class OrderService
{
    public List<Order> list = new List<Order>();
    //添加

    public void PrintOrder(Order i)
    {
        Console.WriteLine(i.ClientName + "  订单号：" + i.Number + "  苹果的个数" + i.AppleNum + "  球的个数" + i.BallNum + "  笔的个数" + i.PenNum + " 订单总金额为:" + i.price);
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
            Order NewOrder = new Order(ClientName, Number, AppleNum, BallNum, PenNum);
            list.Add(NewOrder);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    //查询
    //根据客户名字查询
    public Order SearchOrderName(string ClientName)
    {
        var O1 = from n in list
                 where n.ClientName == ClientName
                 select n;
        Order O2 = null;
        foreach (Order ele in O1) O2 = ele;
        return O2;
    }
    //按照订单号查询
    public Order SearchOrderNum(int Number)
    {
        var O1 = from n in list
                 where n.Number == Number
                 select n;
        Order O2 = null;
        foreach (Order ele in O1) O2 = ele;
        return O2;
    }

    //根据订单号删除
    public void deleteOrderNum(int number)
    {
        try
        {
            Order ii = null;
            foreach (Order i in list)
            {
                if (i.Number == number) ii = i;
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
    public void modifyOrderName(string name)
    {
        try
        {
            Console.Write("输入想要修改的客户名字：");
            string name1 = Convert.ToString(Console.ReadLine());
            foreach (Order i in list)
            {
                if (i.ClientName == name) i.ClientName = name1;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    //修改客户订单号
    public void modifyOrderNum(string name)
    {
        try
        {
            Console.Write("输入订单号：");
            int num = Convert.ToInt32(Console.ReadLine());
            foreach (Order i in list)
            {
                if (i.ClientName == name) i.Number = num;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


    }
}
