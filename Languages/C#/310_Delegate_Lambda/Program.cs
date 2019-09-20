using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _310_Delegate_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lambda表达式用来代替匿名方法
            // 所以Lambda表达式也是定义了一个方法
            // Lambda表达式的参数是不需要声明类型的
            Func<int, int, int> plus = (arg1, arg2) => { return arg1 + arg2; };

            Console.WriteLine(plus(1, 2));

            // 如果委托只有一个参数，可以不用括号，直接写
            // 如果函数体语句只有一句时，可以不加上大括号，也可以不加上return
            Func<int, int> test = a => a + 37;
            Func<int, int> test1 = (a) => { return a + 37; };
            // 以上两个委托功能一样，写法不同
            Console.WriteLine(test(1));
            Console.WriteLine(test1(1));
                       
            Console.ReadKey();
        }
    }
}
