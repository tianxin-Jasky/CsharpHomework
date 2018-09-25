using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Chart
{
    private string name;

    public Chart(string s)
    {
        N = s;
    }
    public string N {                   //类型
        get
        {
            return name;
        } 
        set
        {
            name = value;
        }
    }
    public virtual void Draw()                  //绘制，虚方法
    {
        Console.WriteLine("draw shape Icon");
    }
    public abstract double Area             //面积。
    {
        get;                    //？
    }
    public override string ToString()               //覆盖object的虚方法
    {
        return N + "Area=" + string.Format(" {0:F2}", Area);
    }
}

//正方形
public class Square : Chart
{
    private int Side;      //边长 ？
    public Square(int side,string name) : base(name)
    {
        this.Side = side;
    }
    public override double Area                 //实现面积
    {
        get                 //？
        {
            return this.Side * this.Side;
        }
    }
    public override void Draw()                      //绘制方法
    {
        Console.WriteLine("draw 4 side:"+this.Side);
    }
}

public class Circle : Chart
{
    private int myRadius;       //半径
    public Circle (int radius,string name):base (name)
    {
        myRadius = radius;
    }
    public override double Area
    {
        get
        {
            return myRadius * myRadius * System.Math.PI;
        }
    }
    public override void Draw()
    {
        Console.WriteLine("draw circle:"+myRadius);
    }
}

public class Rectangle : Chart
{
    private int myWidth;
    private int myHeight;
    public Rectangle(int width,int height, string name) : base(name)
    {
        myWidth = width;
        myHeight = height;
    }
    public override double Area
    {
        get
        {
            return myWidth * myHeight;
        }
    }
    public override void Draw()
    {
        Console.WriteLine("draw Rectangle:");
    }
}

public class Triangle : Chart
{
    private int myOneSide;
    private int myTwoSide;
    private int myThreeSide;
    private double p;
    public Triangle(int one, int two,int tree, string name) : base(name)
    {
        myOneSide = one;
        myTwoSide = two;
        myThreeSide = tree;
        p = (myOneSide + myTwoSide + myThreeSide)/2;
    }
    public override double Area
    {
        get
        {
            return Math.Sqrt(p*(p-myOneSide)*(p-myTwoSide)*(p-myThreeSide));
        }
    }
    public override void Draw()
    {
        Console.WriteLine("draw triangle:");
    }
}


namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Chart[] charts = {
                new Square(3,"Square"),
                new Circle(4,"Circle"),
                new Rectangle(7,8,"rectangle"),
                new Triangle(5,12,13,"triangle")
            };
            foreach(Chart i in charts)
            {
                Console.WriteLine(i);
            }
        }
    }
}
