using System;

namespace _Exercise_PrimeNumber
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 编程输出1000以内的所有素数
            for (int i = 2; i <= 1000; i++){
                bool flag = true;
                for (int j = 2; j < i; j++){
                    if (i % j == 0){
                        flag = false;
                        break;
                    }
                }
                if(flag)
                    Console.WriteLine(i);
            }
        
        }
    }
}
