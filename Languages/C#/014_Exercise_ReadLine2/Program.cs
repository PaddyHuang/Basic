using System;

namespace _Exercise_ReadLine2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 接受用户输入的两个整数，存储到两个变量中，变换两个变量存储的值
            Console.WriteLine("Enter two integers:");
            Console.WriteLine("Enter the first:");
            string str1 = Console.ReadLine();
            int num1 = Convert.ToInt32(str1);
            Console.WriteLine("Enter the second:");
            string str2 = Console.ReadLine();
            int num2 = Convert.ToInt32(str2);
            Console.WriteLine("The first is {0}, and the second is {1}", num1, num2);

            int temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine("We exchange their value.\nRight now the first is {0}, and the second is {1}", num1, num2);
        }
    }
}
