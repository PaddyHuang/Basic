using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _204_OOP_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 如果要使用一个类的话，就需要先引用它所在的命名空间，因为Customer位于当前命名空间下，故可以直接使用
            Customer customer1;         // 声明一个customer
            //customer1.name = "Polin";   // 我们声明的类要初始化
            customer1 = new Customer(); // 初始化
            customer1.name = "Polin";
            Console.WriteLine(customer1.name);
            customer1.Show();

            Console.ReadKey();
        }
    }
}
