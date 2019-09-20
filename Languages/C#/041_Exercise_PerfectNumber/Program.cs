using System;

namespace _Exercise_PerfectNumber
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 求1000以内所有的完数。所谓完数是指一个数恰好等于它的所有因子之和。例如6是完数，6=1+2+3
            Console.WriteLine("Perfect Number Under 1000:");
            for (int i = 1; i <= 1000; i++){
                string str = "1";
                int sum = 1;
                for (int j = 2; j < i; j++)
                    if (i % j == 0){
                        sum += j;
                        str += " + " + j;
                    }
                if (sum == i)
                    Console.WriteLine(i + " = " + str);
            }
        }
    }
}
