using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _306_Delegate_Func
{
    class Program
    {
        static void Main(string[] args)
        {
            // Func中的泛型指定的是 指向方法的返回值类型
            Func<int> a = Test1;
            Console.WriteLine(a.Invoke());
            // Func后可以跟很多类型，最后一个类型是返回值类型，C#中，一个方法只能有一个返回值
            // 前面的类型是参数类型，参数类型必须和所指向的方法的参数类型按顺序对应
            Func<string, int> a1 = Test2;
            Console.WriteLine(a1.Invoke("Hello"));


            Console.ReadKey();
        }

        static int Test1()
        {
            return 1;
        }

        static int Test2(string str)
        {
            Console.WriteLine(str);
            return 100;
        }

    }
}
