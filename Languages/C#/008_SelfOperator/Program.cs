using System;

namespace _SelfOperator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int num1 = 45;
            //num1++;
            //++num1;
            //int res = num1++;
            int res = ++num1;
            Console.WriteLine(res + ":" + num1);
        }
    }
}
