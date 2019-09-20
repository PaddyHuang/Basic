using System;

namespace _Exercise_Fibonacci
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // f(n) = f(n-1)+f(n-2), f(0)=2, f(1)=3, 求f(40)

            Console.WriteLine("f(n) = f(n-1)+f(n-2), f(0)=2, f(1)=3, 求f(40): ");
            long res = FibonacciLike(40);
            Console.WriteLine("Result: {0}", res);
        }

        static long FibonacciLike(int n){
            if (n == 0)
                return 2;
            else if (n == 1)
                return 3;
            else
                return FibonacciLike(n - 1) + FibonacciLike(n - 2);
        }
    }
}
