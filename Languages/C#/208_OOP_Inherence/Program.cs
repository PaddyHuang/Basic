using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _208_OOP_Inherence
{
    class Program
    {
        static void Main(string[] args)
        {
            Boss boss = new Boss();
            boss.Attack();      // 继承：父类里面所有的数据成员和函数成员都会继承到子类里面

            Enermy enermy;
            enermy = new Boss();        // 父类声明的对象，可以使用子类构造
                                        // 子类声明的对象不能使用父类构造
            Boss boss1 = (Boss)enermy;  // enermy虽然使用父类声明，但是使用子类构造，所有本质上是一个子类类型，我们可以强制转换enermy成子类类型
            boss1.Attack();

            Enermy enermy1 = new Enermy();
            //Boss boss2 = (Boss)enermy1; // 强制转换错误
            // 一个对象的类型，主要看其构造器
            // 这里enermy1使用了父类的构造器，所以只能使用父类的字段与函数

            // virtual
            Boss boss3 = new Boss();
            boss3.Move();

            // 隐藏方法
            Boss boss4 = new Boss();
            boss4.AI();     // 调用子类Boss的AI方法
            Enermy enermy2 = new Boss();
            enermy2.AI();   // 调用父类Enermy的AI方法

            Crow crow = new Crow();
            crow.Fly();
            Bird bird = new Crow();
            bird.Fly();     // 可以使用抽象类声明对象，但是不能使用抽象类的构造器

            Console.ReadKey();
        }
    }
}
