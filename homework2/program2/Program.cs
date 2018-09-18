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
            int[] A = {35,8,47,95,89,30,98,64,12,10};
            int max = A[0],min=A[0],s=0;
            double average=2.0;
            for (int i = 0; i < 9; i++)
            {
                if (max <=A[i+1])
                {
                    max = A[i+1];
                } 
                if (min >= A[i + 1])
                {
                    min = A[i+1];
                }
                s = A[i] + s;
            }
            average = s / 10.0;
            Console.WriteLine("The max:"+max+'\n'+ "The min:" + min+'\n'+"The sum:"+s+'\n'+"The average:"+ average);
        }
    }
}
