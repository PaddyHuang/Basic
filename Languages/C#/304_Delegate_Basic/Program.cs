using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _304_Delegate_Basic
{
    class Program
    {
        // 定义一个委托
        private delegate string GetAString();
        
        static void Main(string[] args)
        {
            int x = 40;
            int y = 20;
            string s = x.ToString();
            Console.WriteLine(s);

            // 实例委托
            GetAString getAString = new GetAString(x.ToString);
            // 通过委托调用一个方法，和直接调用这个方法是一样的 
            string str = getAString();  // 通过委托实例调用x中的tostring方法
            Console.WriteLine(s);

            // 调用方法
            // 1. 赋值给委托
            GetAString a = x.ToString;
            Console.WriteLine(a());
            // 2. Invoke    通过Invoke方法调用a所引用的方法
            Console.WriteLine(a.Invoke());

            // 使用委托类型作为方法的参数
            PrintString method = Method1;
            PrintStr(method);
            method = Method2;
            PrintStr(method);


            Console.ReadKey();
        }

        // 委托类型可以作为参数
        private delegate void PrintString();
        static void PrintStr(PrintString print)
        {
            print();
        }

        static void Method1()
        {
            Console.WriteLine("Method1");
        }
        static void Method2()
        {
            Console.WriteLine("Method2");
        }
    }
}
