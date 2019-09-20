using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _305_Delegate_Action
{
    class Program
    {
        static void Main(string[] args)
        {  
            // Action 是System内置（预定义）的一个委托类型
            // 它可以指向一个没有返回值，没有参数的方法
            Action a = PrintString;

            // Action 也可以带多个参数
            // 定义一个委托类型，可以指向一个没有返回值，有一个int参数的方法
            Action<int> a1 = PrintInt;
            // 定义一个委托类型，可以指向一个没有返回值，有一个string参数的方法
            // 编译器自动匹配适合参数的方法
            Action<string> a2 = PrintString;
            // 
            Action<int, int> a3 = PrintInt;
            a3(1, 3);

            Console.ReadKey();
        }

        static void PrintString()
        {
            Console.WriteLine("Hello");
        }

        static void PrintString(string str)
        {
            Console.WriteLine(str);
        }

        static void PrintInt(int i)
        {
            Console.WriteLine(i);
        }

        static void PrintInt(int i, int j)
        {
            Console.WriteLine(i + " " + j);
        }
    }
}
