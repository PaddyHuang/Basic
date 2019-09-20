using System;

namespace _Exercise_MaxAndMin
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 编写一个程序，对输入的4个整数，求出其最大最小值，并显示出来
            Console.WriteLine("Enter 4 integers:");
            Console.WriteLine("Enter the first:");
            //string str1 = Console.ReadLine();
            //int num1 = Convert.ToInt32(str1);
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second:");
            //string str2 = Console.ReadLine();
            //int num2 = Convert.ToInt32(str2);
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the third:");
            //string str3 = Console.ReadLine();
            //int num3 = Convert.ToInt32(str3);
            int num3 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the forth:");
            //string str4 = Console.ReadLine();
            //int num4 = Convert.ToInt32(str4);
            int num4 = Convert.ToInt32(Console.ReadLine());

            int max = (num1 > num2) ? num1 : num2;
            max = (max > num3) ? max : num3;
            max = (max > num4) ? max : num4;
            Console.WriteLine("Max: {0}", max);

            int min = (num1 < num2) ? num1 : num2;
            min = (min < num3) ? min : num3;
            min = (min < num4) ? min : num4;
            Console.WriteLine("Min: {0}", min);

        }
    }
}
