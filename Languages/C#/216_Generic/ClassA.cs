using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _216_Generic
{
    class ClassA<T,A>     // T代表一个数据类型，当使用ClassA进行构造时，需要指定T的类型
    {
        private T a;
        private T b;
        private A c;

        // Constructor
        public ClassA(T a, T b)
        {
            this.a = a;
            this.b = b;
        }

        public string GetSum()
        {
            return a + " " + b;
        }
    }
}
