using System;

namespace _Exercise_Factorial
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 求1!+2!+3!+...+20!
            Console.WriteLine("求1!+2!+3!+...+20!");
            long res = 0;
            for (int i = 1; i <= 20; i++)
                res += Factorial(i);
            Console.WriteLine("Result: {0}", res);
		}

        static long Factorial(int n)
        {
            long res = 1;
            for (int i = 1; i <= n; i++)
            {
                res *= i;
            }
            return res;
        }

        static long Sum(params long[] array)
        {
            long sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }
}
