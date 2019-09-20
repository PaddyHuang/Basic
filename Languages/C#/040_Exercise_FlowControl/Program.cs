using System;

namespace _Exercise_FlowControl
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 编写程序完成一下要求：
            // 1. 接收一个整数n
            // 2. 如果n为正数，输出1-n之间的所有整数
            // 3. 如果n为负数，用break或return退出程序
            // 4. 如果n为0，转到(1)继续接收下一个n

            while(true){
                Console.Write("Enter an integer:");
                //string str = Console.ReadLine();
                //int n = Convert.ToInt32(str);
                int n = Convert.ToInt32(Console.ReadLine());
                if (n > 0)
                {
                    Console.Write("{0}: ", n);
                    for (int i = 1; i <= n; i++)
                        Console.Write("{0}, ", i);
                    Console.WriteLine("");
                }
                else if (n < 0)
                    return;
                //else if (n == 0)
                    //continue;
            }               
  		}
    }
}
