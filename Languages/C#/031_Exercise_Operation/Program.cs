using System;

namespace _Exercise_Operation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 求出1-1000之间所有能被7整除的数，并计算和输出每5个的和
            int count = 0, sum = 0;
            for (int i = 1; i <= 1000; i++){
                if(i%7==0){
                    Console.WriteLine(i);
                    count++;
                    sum += i;
                }
                if(count == 5){
                    Console.WriteLine("The sum of every 5 item: {0}", sum);
                    sum = 0;
                    count = 0;
                }
            }
        }
    }
}
