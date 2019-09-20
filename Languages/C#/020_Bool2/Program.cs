using System;

namespace _Bool2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int num1 = 23;
            int num2 = 44;
            bool res1 = num1 == num2;   // false
            bool res2 = num1 != num2;   // true
            bool res3 = num1 < num2;    // true
            bool res4 = num1 > num2;    // false
            bool res5 = num1 <= num2;   // true
            bool res6 = num1 >= num2;   // flase
            Console.WriteLine(res1);
            Console.WriteLine(res2);
            Console.WriteLine(res3);
            Console.WriteLine(res4);
            Console.WriteLine(res5);
            Console.WriteLine(res6);
        }
    }
}
