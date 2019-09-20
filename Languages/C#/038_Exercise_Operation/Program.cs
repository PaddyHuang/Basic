using System;

namespace _Exercise_Operation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 输出1-5的平方值，要求用分别用for、while、do-while语法实现
            Console.WriteLine("For method:");
            forMethod();
            Console.WriteLine("While method:");
            whileMethod();
            Console.WriteLine("Do-while method");
            do_whileMethod();
        }

        public static void forMethod(){
            for (int i = 1; i <= 5; i++){
                Console.WriteLine("{0}^2 = {1}", i, i * i);
            }
        }

        public static void whileMethod(){
            int i = 1;
            while(i <= 5){
                Console.WriteLine("{0}^2 = {1}", i, i * i);
                i++;
            }
        }

        public static void do_whileMethod(){
            int i = 1;
            do
            {
                Console.WriteLine("{0}^2 = {1}", i, i * i);
                i++;
            } while (i <= 5);

        }
    }
}
