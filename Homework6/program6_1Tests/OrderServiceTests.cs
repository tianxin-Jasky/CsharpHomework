using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests
{
    [TestClass()]

    public class OrderServiceTests
    {
        Order O1 = new Order("张三", 1, 3, 3, 3);
        Order O2 = new Order("李四", 2, 4, 4, 4);
        List<Order> orderlist = new List<Order>();
        [TestMethod()]
        public void SearchOrderNameTest()
        {
            orderlist.Add(O1);
            orderlist.Add(O2);
            OrderService o1 = new OrderService();
            o1.list = orderlist;
            Order o11 = o1.SearchOrderName("张三");
            Assert.AreEqual(O1, o11);
        }

        [TestMethod()]
        public void SearchOrderNumTest()            //查询结果是否相等
        {
            orderlist.Add(O1);
            orderlist.Add(O2);
            OrderService o1 = new OrderService();
            o1.list = orderlist;
            Order o11 = o1.SearchOrderNum(1);
            Assert.AreEqual(O1, o11);     
        }

        [TestMethod()]
        public void deleteOrderNumTest()
        {
            orderlist.Add(O1);
            orderlist.Add(O2);
            OrderService o1 = new OrderService();
            o1.list = orderlist;
            o1.deleteOrderNum(1);
            Order o11 = o1.SearchOrderNum(1);     //删除指定订单号，再查找，若为null则测试正确
            Assert.IsNull(o11);
        }

        [TestMethod()]
        public void modifyOrderNameTest()
        {
            orderlist.Add(O1);
            orderlist.Add(O2);
            OrderService o1 = new OrderService();
            o1.list = orderlist;
            string s = "王二",ss="张三";
            o1.modifyOrderName(ss, s);
            Order o11 = o1.SearchOrderName(ss);   //修改客户名称，在依据原来的名称查找，找不到，则该测试无误
            Assert.IsNull(o11);
        }

        [TestMethod()]
        public void modifyOrderNumTest()
        {
            orderlist.Add(O1);
            orderlist.Add(O2);
            OrderService o1 = new OrderService();
            o1.list = orderlist;
            int s = 1, ss = 3;
            o1.modifyOrderNum(s, ss);
            Order o11 = o1.SearchOrderNum(s);   //修改订单号之后，按照原来的那个订单号找，测试能否找到
            Assert.IsNull(o11);
        }
    }
}