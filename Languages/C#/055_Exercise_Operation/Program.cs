using System;

namespace _Exercise_Operation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 有关系式1*1+2*2+3*3+...+k*k<2000
            // 求满足此式的最大的k
            Console.WriteLine("有关系式1*1+2*2+3*3+...+k*k<2000\n求满足此式的最大的k");
            int index = 0;
            int sum = 0;
            //for (int i = 1, sum = 0; sum < 200; i++)
            //{
            //    sum += Square(i);
            //}
            while(sum < 2000)
            {
                index++;
                sum += Square(index);
            }
            Console.WriteLine("Result: {0}", index - 1);
            Console.WriteLine("Sum until {0}: {1}", index, sum);
        }

        static int Square(int n)
        {
            return n * n;
        }

        static int Sum(params int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }
}
