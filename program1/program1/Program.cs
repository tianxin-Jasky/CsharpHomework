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
            double n = 0.0,m=0.0,k=0.0;
            Console.WriteLine("Please input an digital:");
            s = Console.ReadLine();
            n = double.Parse(s);
            Console.WriteLine("Please input the second digital:");
            s = Console.ReadLine();
            m = double.Parse(s);
            k = m * n;
            Console.WriteLine("The result of the calculation is "+k);
        }
    }
}
