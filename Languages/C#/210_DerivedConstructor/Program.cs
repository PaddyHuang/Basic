using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210_DerivedConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            // 会先调用父类构造函数，再调用派生类的构造函数
            DerivedClass derived1 = new DerivedClass();

            DerivedClass derived2 = new DerivedClass(1, 2);

            BaseClass baseClass = new BaseClass();
            

            Console.ReadKey();
        }
    }
}
