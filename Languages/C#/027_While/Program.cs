using System;

namespace _While
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //while(true){    // 死循环
            //    Console.WriteLine("Winner");
            //}

            byte index = 1;
            while (index <= 9) { 
                Console.WriteLine(index);
                index++;
            }


        }
    }
}
