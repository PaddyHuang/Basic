using System;

namespace _Exercise_GreatestCommonDivisor_LeastCommonMultiple
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 输入两个正整数m和n，求其最大公约数和最小公倍数
            Console.WriteLine("Hello World!");
            Console.WriteLine("Enter two number:");
            Console.Write("Enter the first: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int greatestCD = GreatestCommonDivisor(m, n);
            int leastCM = LeastCommonMultiple(m, n);

            Console.WriteLine("Greatest Common Divisor: {0}", greatestCD);
            Console.WriteLine("Least Common Multiple: {0}", leastCM);
        }

        static int GreatestCommonDivisor(int m, int n)  // 辗转相除法求最大公约数
        {
            int a = m, b = n, c;
            while(b!=0)             // 余数不为零，继续相除，直到余数为0
            {
                c = a % b;
                a = b;
                b = c;
            }
            return a;               // 最大公约数即a
        }

        static int LeastCommonMultiple(int m, int n)
        {
            int greatestCommonDivosor = GreatestCommonDivisor(m, n);
            int temp = m * n / greatestCommonDivosor;
            return temp;
        }
    }
}
