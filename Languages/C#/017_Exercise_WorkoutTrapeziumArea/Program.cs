using System;

namespace _Exercise_WorkoutTrapezoidArea
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 编写一个程序，输入梯形的上底、下底和高，计算梯形的面积并输出
            Console.WriteLine("Enter the topline, baseline and the high of a trapezoid:");
            Console.WriteLine("Topline:");
            string str1 = Console.ReadLine();
            double topline = Convert.ToDouble(str1);
            Console.WriteLine("Baseline:");
            string str2 = Console.ReadLine();
            double baseline = Convert.ToDouble(str2);
            Console.WriteLine("High");
            string str3 = Console.ReadLine();
            double high = Convert.ToDouble(str3);
            Console.WriteLine("The area of the trapezoid is {0}", (topline + baseline) * high / 2);

        }
    }
}
