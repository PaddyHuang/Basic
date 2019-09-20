using System;

namespace _Delegate
{
    // 定义一个委托和函数差不多，区别在于
    // 1. 定义委托需要加上delegate关键字
    // 2. 委托的定义不需要函数体

    public delegate double MyDelegate(double param1, double param2);

    class MainClass
    {
        public static double Multiply(double param1, double param2){
            return param1 * param2;
        }

        public static double Divide(double param1,double param2){
            return param1 / param2;
        }

        public static void Main(string[] args)
        {
            MyDelegate de;  // 利用我们定义的委托声明了一个新变量
            de = Multiply;  // 当我们给一个委托的变量赋值时，返回值跟参数列表必须一样，否则无法返回
            Console.WriteLine(de(2.0, 4.3));
            de = Divide;
            Console.WriteLine(de(5.3, 2.2));
        }
    }
}
