using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100;
            System.Collections.ArrayList A = new System.Collections.ArrayList();    //使用了ArrayList类
            for (int i = 2; i <= n; i++)
            {
                A.Add(i);                                                          //给A中添加1-100的元素
            }
            for (int j = 2; j < n; j++)                                           //从j倍数开始删除
            {
                for (int ncount=0 ; ncount < A.Count; ncount++)
                {
                    int i = (int)A[ncount];
                    if (i % j == 0 && i != j)                          //判断i是否是j的倍数，是，且i不等于j删除
                    {
                        A.RemoveAt(ncount);
                        ncount--;                               //移除后A中的元素后面部分前移，故需要减小一位
                    }
                }
            }
            foreach (int s in A){                               //遍历数组并输出
                Console.WriteLine(s);
            }
        }
    }
}
