using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _203_Exception_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;

            while (true)
            {
                try
                {
                    Console.WriteLine("请输入第一个整数");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    // 在try块中，如果有一行代码发生了异常，那么try块中剩余的代码都不执行了
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("您输入的不是一个整数，请重新输入");
                    //throw;
                }
                //break;  // 把代码放在这，不管是否出现异常，都会执行
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("请输入第二个整数");
                    num2 = Convert.ToInt32(Console.ReadLine());
                    // 在try块中，如果有一行代码发生了异常，那么try块中剩余的代码都不执行了
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("您输入的不是一个整数，请重新输入");
                    //throw;
                }
                //break;  // 把代码放在这，不管是否出现异常，都会执行
            }

            int sum = num1 + num2;
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
