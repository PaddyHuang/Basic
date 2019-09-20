using System;

namespace _Exercise_Operation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 编写一个程序，分别输出1-100之间的平方、平方根
            for (int i = 1; i <= 100; i++){
                Console.WriteLine("{0}:{1}:{2}", i, i * i, Math.Sqrt(i));
            }
        }
    }
}
