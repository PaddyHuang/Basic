using System;

namespace _MathOperator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //int num1 = 45;
            //int num2 = 13;
            //int res1 = num1 + num2;
            //int res2 = num1 - num2;
            //int res3 = num1 * num2;
            //double res4 = num1 / num2;
            //int res5 = num1 % num2;
            //// 加减乘除两边的操作数都是整型，结果还是整。不能被整除的话，就自动略去小数部分
            //int num3 = 45;
            //double num4 = 3.1;
            //double res6 = num3 + num4;
            //Console.WriteLine("Add: {0}\nSub: {1}\nMul: {2}\nDiv: {3}\nMod: {4}", res1, res2, res3, res4, res5);

            // 关于加法运算符的更多使用
            // 1. 字符串相加，用来连接两个字符串
            //string str1 = "1234ad";
            //string str2 = "asaf";
            //string str = str1 + str2;
            //Console.WriteLine(str);
            // 2. 当一个数字和一个字符串相加，首先把数字转换成字符串，然后相加，最后结果是字符串
            string str1 = "123";
            int num = 456;
            string res = str1 + num;
            Console.WriteLine(res);

        }
    }
}
