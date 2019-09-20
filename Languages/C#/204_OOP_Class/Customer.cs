using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _204_OOP_Class
{
    class Customer
    {
        // 数据成员，里边包含4个字段
        public string name;
        public string address;
        public int age;
        public string buyTime;

        // 函数成员，包含一个方法
        public void Show()
        {
            Console.WriteLine("Name: {0}, Address: {1}, Age: {2}, BuyTime: {3}", name, address, age, buyTime);
        }
    }
}
