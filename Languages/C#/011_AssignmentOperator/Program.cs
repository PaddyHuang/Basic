using System;

namespace _AssignmentOperator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int num1 = 34;  // 这是最常用、最基本的赋值运算
            num1 += 12;     // num1 = num1 + 12 // 46
            num1 -= 12;     // num1 = num1 - 12 // 34
            num1 *= 2;      // num1 = num1 * 2  // 68
            num1 /= 2;      // num1 = num1 / 2  // 34
            num1 %= 4;      // num1 = num1 % 4  // 2
            Console.WriteLine(num1);

        }
    }
}
