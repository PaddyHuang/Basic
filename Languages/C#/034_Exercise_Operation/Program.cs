using System;

namespace _Exercise_Operation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 编程输出1-100中能被3整除但不能被5整除的数，并统计又多少个这样的数
            int count = 0;
            for (int i = 1; i <= 100; i++){
                if (i % 3 == 0 && i % 5 != 0)
                    count++;
            }
            Console.WriteLine(count);
        }
    }
}
