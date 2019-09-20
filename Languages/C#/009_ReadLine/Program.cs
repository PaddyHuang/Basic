using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_ReadLine
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine(str);

            str = Console.ReadLine();
            int num = Convert.ToInt32(str);
            Console.WriteLine(num);

            str = Console.ReadLine();
            double num1 = Convert.ToDouble(str);
            Console.WriteLine(num1);

            Console.ReadKey();
        }
    }
}
