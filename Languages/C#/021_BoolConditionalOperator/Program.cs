using System;

namespace _BoolConditionalOperator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool var1 = true;
            bool var2 = false;
            // 取反
            bool res1 = !var1;          // false
            // 与
            bool res2 = var1 & var2;    // false
            // 或
            bool res3 = var1 | var2;    // true
            // 异或
            bool res4 = var1 ^ var2;    // true

            Console.WriteLine(res1);
            Console.WriteLine(res2);
            Console.WriteLine(res3);
            Console.WriteLine(res4);
        }
    }
}
