using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _308_Delegate_Multicast   // 多播委托
{
    class Program
    {
        static void Main(string[] args)
        {
            Action a = Test1;
            //a = Test2;
            a += Test2;     // 表示添加一个委托的引用

            //a -= Test1;     // 当一个委托没有指向任何方法时，调用会出现空指针异常NullReferenceException
            //a -= Test2;
            // 故一般调用委托时，先判空
            //a();
            if (a != null)
            {
                a();
            }

            // 单独调用委托中的方法
            Delegate[] delegates = a.GetInvocationList();
            foreach (var de in delegates)
            {
                de.DynamicInvoke();
            }

            Console.ReadKey();
        }

        static void Test1()
        {
            Console.WriteLine("Test1");
            //throw new Exception();      // 如果委托中的一个方法出现异常，那么该方法之后的方法都不再执行
        }

        static void Test2()
        {
            Console.WriteLine("Test2");
        }
    }
}
