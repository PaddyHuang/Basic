using System;

namespace _Exercise_RoundingOff
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 输入一个正数, 对其进行四舍五入到个位的运算。
            // 例如实数12.56四舍五入，结果为13；而12.46四舍五入，结果为12.
            Console.WriteLine("Rounding off test");
            Console.Write("Enter a number:");
            double x = Convert.ToDouble(Console.ReadLine());
            RoundingOff(x);
        }

        public static void RoundingOff(double x)
        {
            //double flag = (x * 10) % 10;
            //int res = 0;
            //if (flag >= 5.0)
            //{
            //    x += 0.5;
            //}
            //res = Convert.ToInt32(x);
            int res = (int)(x + 0.5f);
            Console.WriteLine("Result: {0}", res);
        }
    }
}
