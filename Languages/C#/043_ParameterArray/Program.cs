using System;

namespace _ParameterArray   // 参数数组，定义一个参数个数不确定的函数
{
    class MainClass
    {
        // 我们遇到一个问题：定义一个函数，用来取得数字的和，但是数字的个数不确定
        // 方案1. 定义一个函数，参数传递过来一个数组(数组参数)
        static int Sum(int[] array){    // 如果一个函数调用了参数，那么在调用次函数时一定要传递对应类型的参数，否则无法调用（编译器不通过
            int sum = 0;
            foreach(int item in array){
                sum += item;
            }
            return sum;
        }

        // 方案2. 定义一个参数不确定的函数，这个时候我们就要用参数数组
        static int Plus(params int[] array){    // 这里定义了一个int类型的参数数组
            int sum = 0;
            foreach (int item in array)
            {
                sum += item;
            }
            return sum;
        }

        // 参数数组(1)和数组参数(2)的区别在于函数的调用。
        // 调用参数数组的时候，我们可以传递任意多个参数，编译器会帮我们自动拼成一个数组
        // 调用数组参的话，这个数组需要我们手动创建

        public static void Main(string[] args)
        {
            int sum1 = Sum(new int[] { 2, 3, 412, 43, 545, 6 });
            Console.WriteLine(sum1);

            int sum2 = Plus(21, 321, 4, 323);   // 参数数组就是帮我们减少了一个创建数组的过程
            Console.WriteLine(sum2);
        }
    }
}
