using System;

namespace _Exercise_FactorialRecursion
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 用递归求5！
            Console.WriteLine("Factorial in Recursion");
            Console.Write("Enter factorial of what: ");
            int n = Convert.ToInt32(Console.ReadLine());
            long res = Factorial(n);
            Console.WriteLine("Result: {0}", res);
		}

        static long Factorial(int n)
        {
            if (n == 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }
    }
}
