using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _022_Delegate
{
    // 定义一个委托和函数差不多，区别在于
    // 1. 定义委托需要添加delegate关键字
    // 2. 委托的定义不需要函数体
    public delegate double MyDelegate(double param1, double param2);

    class Program
    {
        static double Multiply(double param1, double param2)
        {
            return param1 * param2;
        }

        static double Devide(double param1, double param2)
        {
            return param1 / param2;
        }

        static void Main(string[] args)
        {
            MyDelegate de;  // 利用委托声明一个新变量
            de = Multiply;  // 当我们给一个委托变量赋值时，返回值必须和参数列表一致，否则无法赋值
            Console.WriteLine(de(2.0, 5));
            de = Devide;
            Console.WriteLine(de(50.0, 2));

            Console.ReadKey();
        }
    }
}
