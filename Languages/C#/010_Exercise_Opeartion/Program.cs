using System;

namespace _Exercise_Opeartion
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 练习：接受用户从控制台输入的两个数字，并计算和，输出到控制台
            Console.WriteLine("Enter two numbers, I'll add them up.");
            Console.Write("Enter the first: ");
            string str1 = Console.ReadLine();
            Console.Write("Enter the second: ");
            string str2 = Console.ReadLine();
            int num1 = Convert.ToInt32(str1);
            int num2 = Convert.ToInt32(str2);
            int res = num1 + num2;
            Console.WriteLine("The result: {0}", res);
        }
    }
}
