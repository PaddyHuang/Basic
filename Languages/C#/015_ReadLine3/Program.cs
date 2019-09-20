using System;

namespace _ReadLine3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 编写一个操作台应用程序，要求用户输入4个int值，并显示它们的乘积
            Console.WriteLine("Enter four integers:");
            Console.WriteLine("Enter the first:");
            string str1 = Console.ReadLine();
            int num1 = Convert.ToInt32(str1);
            Console.WriteLine("Enter the second:");
            string str2 = Console.ReadLine();
            int num2 = Convert.ToInt32(str2);
            Console.WriteLine("Enter the third:");
            string str3 = Console.ReadLine();
            int num3 = Convert.ToInt32(str3);
            Console.WriteLine("Enter the forth:");
            string str4 = Console.ReadLine();
            int num4 = Convert.ToInt32(str4);

            Console.WriteLine("Their multiplication is :\n{0} x {1} x {2} x {3} = {4}", num1, num2, num3, num4, num1 * num2 * num3 * num4);

        }
    }
}
