using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

//声明参数类型
public class TimeEventArgs : EventArgs {
    public int hours, minutes;
} 

//声明委托类型
public delegate void  Alarm_clockHandle(object sender,TimeEventArgs e);      
namespace program1          
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour, minute;
            Console.Write("设置闹钟的小时:");
            hour = Convert.ToInt32(Console.ReadLine());
            Console.Write("设置闹钟的分钟:");
            minute = Convert.ToInt32(Console.ReadLine());
            //注册事件，var万能钥匙
            var settime = new Alarm_clock(hour,minute);
            //调用showtime函数
            settime.Alarm_clockEvent+=showtime;
            settime.Clock_Compare(hour,minute);
        }
        //事件的处理方法
        static void showtime(object sender,TimeEventArgs e) {
            Console.WriteLine("这个时候闹钟就应该发出奇怪的声音了");
        }
    }
}
  
class Alarm_clock
{
    public int Myhours, Myminutes;
    public event  Alarm_clockHandle Alarm_clockEvent;
    public Alarm_clock(int hours,int minutes)
    {
        Myhours = hours;
        Myminutes = minutes;
    }
    public  void Clock_Compare(int a,int b)
    {
        for (; ; )
        {
            System.DateTime currentTime = new System.DateTime();    //类的实例化
            currentTime = System.DateTime.Now;
            if (currentTime.Hour == a && currentTime.Minute == b)
            {
                TimeEventArgs args = new TimeEventArgs();
                args.hours = Myhours;
                args.minutes = Myminutes;
                Alarm_clockEvent(this, args);
                break;
            }
            System.Threading.Thread.Sleep(1000);
        }
    }
}
