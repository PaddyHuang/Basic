using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _312_观察者设计模式_猫和老鼠
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("加菲猫", "黄色");
            Mouse mouse1 = new Mouse("米奇", "黑色", cat);
            //cat.catCome += mouse1.RunAway;
            Mouse mouse2 = new Mouse("唐老鸭", "红色", cat);
            //cat.catCome += mouse2.RunAway;
            Mouse mouse3 = new Mouse("水老鼠", "红色", cat);
            //cat.catCome += mouse3.RunAway;

            // 在Cat中调用观察者的方法，在观察者发生改变时，需要同时修改被观察者的代码（高耦合性）
            //cat.CatComing(mouse1,mouse2);   // 猫的状态发生改变

            cat.CatComing();
            //cat.catCome();  // 事件不能在类的外表触发，只能在类的内部触发

            Console.ReadKey();
        }
    }
}
