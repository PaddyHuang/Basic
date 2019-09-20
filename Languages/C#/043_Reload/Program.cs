using System;

namespace _Olverload
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 函数名相同，参数不同，叫做函数重载(编译器通过不同参数去识别调用不同函数)
            int res1 = MaxValue(21, 2, 34, 32, 1, 6778, 3233, 6777);
            double res2 = MaxValue(3.2, 434.49, 32.53, 434.91);
            Console.WriteLine(res1);
            Console.WriteLine("{0}",res2);
        }

        static int MaxValue(params int[] array){
            Console.WriteLine("int MaxValue");
            int max = array[0];
            foreach(int item in array)
                max = (max > item) ? max : item;
            
            return max;
        }

        static double MaxValue(params double[] array){
            Console.WriteLine("double MaxValue");
            double max = array[0];
            foreach (double item in array)
                max = (max > item) ? max : item;

            return max;
        }
    }
}
