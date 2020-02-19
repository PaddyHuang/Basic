using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_Params
{
    class Program
    {
        static int Sum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        static int Plus(params int[] array)     // int类型的参数数组
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int sum = Sum(new int[] { 1, 3, 89, 1 });
            Console.WriteLine(sum);
            int sum2 = Plus(12, 1, 3);
            Console.WriteLine(sum2);

            Console.ReadKey();
        }
    }
}
