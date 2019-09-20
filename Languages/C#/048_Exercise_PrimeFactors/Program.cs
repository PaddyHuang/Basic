using System;

namespace _Exercise_PrimeFactors
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 将一个正整数分解质因数。例如：输入90，输出90=2*3*3*5，测试数据有多组
            Console.WriteLine("Prime Factors");
            Console.Write("Enter a number to factorize: ");
            int n = Convert.ToInt32(Console.ReadLine());
            PrimeFactorize(n);

        }

        public static void PrimeFactorize(int n)
        {
            string str = "1";
            for (int i = 2; i <= n; i++)
            {
                bool isPrime = true;
                if (n%i==0)
                {
                    for (int j = 2; j < i; j++) // is Prime?
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if(isPrime==true)
                        str += " * " + i;
                }
            }
            Console.WriteLine(n + " = " + str);
        }
    }
}
