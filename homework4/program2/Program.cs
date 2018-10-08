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
            int s = 0;
            Order O1 = new Order("张三", 1, 3, 3, 3);
            Order O2 = new Order("李四", 2, 4, 4, 4);
            List<Order> orderlist = new List<Order>();
            orderlist.Add(O1);
            orderlist.Add(O2);
            Console.WriteLine("输入进行的操作:1显示所有订单 2添加订单 3删除订单 4查询 5修改订单 6! ");
            string sss = Console.ReadLine();
            while (sss !="!")
            {
                int operationNum = int.Parse(sss);
                switch (operationNum)
                {
                    case 1:
                        foreach (Order i in orderlist)
                        {
                            Console.WriteLine(orderlist[s].ClientName + "  订单号：" + orderlist[s].Number + "  苹果的个数" + orderlist[s].AppleNum + "  球的个数" + orderlist[s].BallNum + "  笔的个数" + orderlist[s].PenNum);
                            s++;
                        }
                        break;
                    case 2:
                        OrderService order1 = new OrderService();
                        order1.AddOrder();
                        orderlist.Add(order1.list[0]);
                        break;
                    case 3:
                        OrderService order2 = new OrderService();
                        order2.list = orderlist;
                        break;
                    case 4:
                        OrderService order4 = new OrderService();
                        Console.WriteLine("1客户名称 2订单号");
                        int qq = int.Parse(Console.ReadLine());
                        switch (qq)
                        {
                            case 1:
                                Console.WriteLine("输入：");
                                string SearchName = Convert.ToString(Console.ReadLine());
                                Order o1=order4.SearchOrderName(SearchName);
                                Console.WriteLine(o1.ClientName + "  订单号：" + o1.Number + "  苹果的个数" + o1.AppleNum + "  球的个数" + o1.BallNum + "  笔的个数" + o1.PenNum);
                                break;
                            case 2:
                                Console.WriteLine("输入：");
                                int Searchnum = Convert.ToInt32(Console.ReadLine());
                                Order o2 = order4.SearchOrderNum(Searchnum);
                                Console.WriteLine(o2.ClientName + "  订单号：" + o2.Number + "  苹果的个数" + o2.AppleNum + "  球的个数" + o2.BallNum + "  笔的个数" + o2.PenNum);
                                break;
                        }
                        break;
                    case 5:
                        OrderService order3 = new OrderService();
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
                }
                Console.WriteLine("输入进行的操作:1显示所有订单 2添加订单 3删除订单 4查询 5修改订单 6! ");
                sss = Console.ReadLine();
            }
          
            

            
        }
       
    }
}

class Order
{
    public string  ClientName;
    public int Number,AppleNum, BallNum, PenNum;
    public Order(string clientName, int number,int applenum,int ballnum,int pennum)
    {
        ClientName = clientName;
        Number = number;
        AppleNum = applenum;
        BallNum = ballnum;
        PenNum = pennum;
    }
}

//class OrderDetails 
//{
//    Order O1 = new Order("张三","001",3,3,3);
//    Order O2= new Order("李四", "002",4,4,4);
//    List<Order> orderlist = new List<Order>();
//    public OrderDetails()
//    {
//        orderlist.Add(O1);
//        orderlist.Add(O2);
        
//    }
//}

class OrderService
{
    public List<Order> list=new List<Order>();
    //添加
    public  void AddOrder()
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
        Order O1=null;
        int s = 0;
        foreach(Order i in list)
        {
            if (list[s].ClientName == ClientName) O1=list[s];
        }
        return O1;
    }
    //按照订单号查询
    public Order SearchOrderNum(int Number)
    {
        Order O1 = null;
        int s = 0;
        foreach (Order i in list)
        {
            if (list[s].Number == Number) O1 = list[s];
        }
        return O1;
    }
    
    //根据订单号删除
    public void deleteOrderNum(int number)
    {
        try
        {
            int s = 0;
            foreach (Order i in list)
            {
                if (list[s].Number == number) list.Remove(list[s]);
            }
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
        int s = 0;
        try
        {
            Console.Write("输入想要修改的客户名字：");
            string name1 = Convert.ToString(Console.ReadLine());
            foreach (Order i in list)
            {
                if (list[s].ClientName == name) list[s].ClientName = name1;
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
        int s = 0;

        try
        {
            Console.Write("输入订单号：");
            int num = Convert.ToInt32(Console.ReadLine());
            foreach (Order i in list)
            {
                if (list[s].ClientName == name) list[s].Number = num;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
        
    }

}

