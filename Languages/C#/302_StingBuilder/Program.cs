using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _302_StingBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Constructor   当需要对一个字符串进行频繁的删除添加操作时，使用StringBuilder效率更高
            StringBuilder sb = new StringBuilder("www.polin.com");
            StringBuilder sb1 = new StringBuilder(20);
            StringBuilder sb2 = new StringBuilder("www.polin.com", 100);

            // 2. Append
            sb.Append("/xxx.html");
            Console.WriteLine(sb.ToString());
            // 3. Insert
            sb.Insert(0, "http://");
            Console.WriteLine(sb.ToString());
            // 4. Remove
            sb.Remove(0, 7);
            Console.WriteLine(sb.ToString());
            // 5. Replace
            sb.Replace(".", "-");
            Console.WriteLine(sb.ToString());


            Console.ReadKey();
        }
    }
}
