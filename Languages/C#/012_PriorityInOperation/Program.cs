using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_PriorityInOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 12 + 90;          // 102
            int num1 = 12 + 90 * 2;     // 192
            int num2 = (12 + 90) * 2;   // 204
            Console.WriteLine(num);
            Console.WriteLine(num1);
            Console.WriteLine(num2);
             
            Console.ReadKey();
        }
    }
}
