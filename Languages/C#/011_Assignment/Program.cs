using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 34;   // 最基本的赋值运算
            num += 12;      // 46
            num -= 12;      // 34
            num *= 12;      // 408
            num /= 12;      // 34
            num %= 12;      // 10

            Console.WriteLine(num);

            Console.ReadKey();
        }
    }
}
