using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210_DerivedConstructor
{
    class BaseClass
    {
        private int x;
        protected int z;    // 当没有继承时，其作用和private一样
                            // 当有继承时，表示可以被子类访问的字段和方法
        public BaseClass()
        {
            Console.WriteLine("BaseClass 无参构造函数");
        }

        public BaseClass(int x)
        {
            this.x = x;
        }
    }
}
