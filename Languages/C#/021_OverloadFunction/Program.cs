using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021_OverloadFunction
{
    class Program
    {
        // 函数名相同，参数不同，叫做函数重载（编译器通过不同参数识别不同函数）
        // 1. Max Value in int
        static int MaxValue(params int[] array)
        {
            Console.WriteLine("Int MaxValue");

            int maxValue = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }
            return maxValue;
        }

        // 2. Max Value in double
        static double MaxValue(params double[] array)
        {
            Console.WriteLine("Double MaxValue");

            double maxValue = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }
            return maxValue;
        }

        static void Main(string[] args)
        {
            int res1 = MaxValue(1, 23, 87);
            Console.WriteLine(res1);
            double res2 = MaxValue(12.2, 3.14, 5.67);            
            Console.WriteLine(res2);

            Console.ReadKey();
        }
    }
}
