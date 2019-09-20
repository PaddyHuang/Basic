using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210_DerivedConstructor
{
    class DerivedClass : BaseClass
    {
        private int y;

        // Constructor      若父类中没有重写构造函数，则调用默认的无参构造函数
        public DerivedClass() : base()  // 调用父类中无参的构造函数
        {
            Console.WriteLine("DerivedClass 构造函数");
        }

        public DerivedClass(int x, int y) : base(x)
        {
            this.y = y;
            base.z = z;
            Console.WriteLine("y赋值完成");
        }
    }
}
