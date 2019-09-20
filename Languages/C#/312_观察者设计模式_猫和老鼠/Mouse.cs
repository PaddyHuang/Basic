using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _312_观察者设计模式_猫和老鼠
{
    class Mouse         // 观察者
    {
        private string name;
        private string color;

        public Mouse(string name, string color, Cat cat)
        {
            this.name = name;
            this.color = color;
            // 把自身的逃跑方法 注册进 猫里面
            cat.catCome += this.RunAway;    // 订阅消息
        }

        /// <summary>
        /// 老鼠逃跑
        /// </summary>
        public void RunAway()
        {
            Console.WriteLine(color + "的老鼠" + name + "说：老猫来了，赶紧跑...");
        }

    }
}
