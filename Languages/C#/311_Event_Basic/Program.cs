using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _311_Event_Basic
{
    class Program
    {
        public delegate void MyDelegate();

        //public MyDelegate myDelegate;   // 声明一个委托类型的变量，作为类的成员（字段）

        // event 只能用在字段的声明，不能用在函数中的局部变量声明
        // deleagte 既可以用在字段的声明也可以用在函数中的局部变量声明
         
        public event MyDelegate myDelegate;   // 声明一个委托类型的变量，作为类的成员（字段）

        static void Main(string[] args)
        {
            Program program = new Program();
            program.myDelegate = Test1;
            program.myDelegate();

            Console.ReadKey();
        }

        static void Test1()
        {
            Console.WriteLine("tets1");
        }

    }
}
