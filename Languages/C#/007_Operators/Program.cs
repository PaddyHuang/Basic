using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 45, num2 = 50;

            int add = num1 + num2;
            int sub = num1 - num2;
            int mul = num1 * num2;
            //int div = num1 / num2;
            float div = num1 / num2;
            int mod = num1 % num2;
            // 加减乘除两边的操作数都是整数，结果还是整数。
            // 不能整除时，自动略去小数部分。
            int num3 = 3;
            double num4 = 0.5;
            double add2 = num3 + num4;

            Console.WriteLine("add: {0}, sub: {1}, mul: {2}, div: {3}, mod: {4}", add, sub, mul, div, mod);

            // 关于加法运算符更多的使用
            // 1. 连接两个字符串，返回一个字符串
            string str1 = "123abc", str2 = "654def";
            string str = str1 + str2;
            Console.WriteLine(str);

            // 2. 连接数字与字符串，返回的结果是字符串
            string str3 = "456";
            int num = 789;
            str = str3 + num;
            Console.WriteLine(str);

            Console.ReadKey();
        }
    }
}
