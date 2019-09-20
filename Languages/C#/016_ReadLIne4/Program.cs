using System;

namespace _ReadLine4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 从键盘输入一个三位正整数，按数字的相反顺序输出
            Console.WriteLine("Enter a three-bit integer:");
            string str = Console.ReadLine();
            int num = Convert.ToInt32(str);
            int hundred = num / 100;        // xyz /100 = x
            int decade = num % 100 /10;     // xyz % 100 = yz; yz / 10 = y
            int unit = num % 10;            // xyz % 10 = z
            Console.WriteLine("The opposite order of the number is: {2}{1}{0}", hundred, decade, unit);


        }
    }
}
