using System;

namespace _MultiplicationTable
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("99乘法表");
            for (int i = 1; i < 10; i++){
                Console.Write("{0}: ", i);
                for (int j = 1; j <= i; j++){
                    Console.Write("{0} x {1} = {2} ", j, i, i * j);
                }
                Console.WriteLine("");
            }
        }
    }
}
