using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _201_Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Compiler error
            //int temp = 54;
            //tem = 5;

            // 2. Logic error
            //int num1 = 4, num2 = 5;
            //int sum = num1 * num2;

            // Debug Interrupt: F9 to add or delete a breakpoint
            Console.WriteLine("Breakpoints");
            int num1 = 4;
            int num2 = 5;
            int sum = num1 + num2;
            Console.WriteLine(sum);

            Console.ReadKey();
        }
    }
}
