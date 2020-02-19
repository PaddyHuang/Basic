using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _309_Delegate_AnonymousMethod     // 匿名方法
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> plus = Test1;

            // 修改成匿名方法
            Func<int, int, int> plusAnonymous = delegate (int arg1, int arg2) { return arg1 + arg2; };
            // 一般匿名方法用来做成回调函数
            // 匿名方法本质上还是一个方法，只是没有名字
            // 任何使用委托的地方都可以使用匿名方法赋值

            Console.ReadKey();
        }

        static int Test1(int arg1, int arg2)
        {
            return arg1 + arg2;
        }
    }
}
