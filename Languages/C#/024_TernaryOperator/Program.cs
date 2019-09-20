using System;

namespace _TernaryOperator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int myInteger = 10;
            string resStr = (myInteger < 10) ? "Less than 10" : "Grater than or equal to 10";
            Console.WriteLine(resStr);
        }
    }
}
