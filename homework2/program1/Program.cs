using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int n;
            Console.WriteLine("Please input an digital:");    //输入一个数;
            s = Console.ReadLine();
            n = int.Parse(s);
            for (int i = 1; i <= n; i++)
            {
                for (int j = 2; j <= i; j++)                 //从2开始;
                {
                    if (i % j == 0)                         //除余如果等于0，则判断如果为本身输出该数，反之break;
                    {
                        if (j == i)
                        {
                            Console.WriteLine(j);
                            break;
                        }
                        break;
                    }
                }
            }
        }
    }
}
