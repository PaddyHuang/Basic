using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _216_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            var o1 = new ClassA<int, string>(12, 56);   // 当我们利用泛型来构造时，需要指定泛型的类型
            string s = o1.GetSum();
            Console.WriteLine(s);

            var o2 = new ClassA<string, int>("abc", "def");
            string str = o2.GetSum();
            Console.WriteLine(str);

            // Generic Function
            Console.WriteLine(GetSum("xyz", "asd"));

            Console.ReadKey();
        }

        // Generic Function
        public static string GetSum<T>(T a, T b)
        {
            return a + " " + b;
        }
    }
}
