using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _202_Exception    // try...catch...finally 
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] myArray = { 1, 2, 3, 4 };
            //int myEle = myArray[4];
            //Console.WriteLine("Test");
            //Console.ReadKey();

            // catch和finally必须有0个或1个
            // try 包含可能出现异常的语句
            // catch 捕捉异常
            // finally 包含始终会执行的代码，不管有没有异常

            try
            {
                int[] myArray = { 1, 2, 3, 4 };
                //int myEle = myArray[3];
                int myEle = myArray[4];
            }
            catch (NullReferenceException)  // 如果捕捉异常类型不对，则捕捉异常失败
            {
                Console.WriteLine("NullReferenceException");
            }
            catch (IndexOutOfRangeException)
            {
                //throw;
                Console.WriteLine("IndexOutOfRangeException");
            }
            catch   // 如果不写catch的参数，则这个catch会捕捉任何出现的异常信息
            {
                Console.WriteLine("Error");
            }
            finally
            {
                Console.WriteLine("Finally");
            }

            Console.ReadKey();

        }
    }
}
