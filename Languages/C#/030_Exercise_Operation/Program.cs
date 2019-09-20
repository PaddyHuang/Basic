using System;

namespace _Exercise_Operation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 让用户输入两个整数，然后再输入0-3之间的一个数，0代表加，1代表减，2代表乘
            Console.WriteLine("1. Addition\n2. Subtraction\n3. Multiplication\n4. Division\n0. Exit");
            Console.WriteLine("Choose an operator");
            int num1 = 0, num2 = 0, res = 0;
            //string str1 = "", str2 = "";
            string choose = Console.ReadLine();
            while (choose != "0")
            {
                Console.WriteLine("Enter two integers:");
                Console.WriteLine("Enter the first:");
                //str1 = Console.ReadLine();
                //num1 = Convert.ToInt32(str1);
                num1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the second:");
                //str2 = Console.ReadLine();
                //num2 = Convert.ToInt32(str2);
                num2 = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case "1":
                        //Console.WriteLine("Enter two integers:");
                        //Console.WriteLine("Enter the first:");
                        ////str1 = Console.ReadLine();
                        ////num1 = Convert.ToInt32(str1);
                        //num1 = Convert.ToInt32(Console.ReadLine());

                        //Console.WriteLine("Enter the second:");
                        ////str2 = Console.ReadLine();
                        ////num2 = Convert.ToInt32(str2);
                        //num2 = Convert.ToInt32(Console.ReadLine());

                        //Console.WriteLine("{0} - {1} = {2}", num1, num2, num1 - num2);
                        res = num1 + num2;
                        break;
                    case "2":
                        //Console.WriteLine("Enter two integers:");
                        //Console.WriteLine("Enter the first:");
                        ////str1 = Console.ReadLine();
                        ////num1 = Convert.ToInt32(str1);
                        //num1 = Convert.ToInt32(Console.ReadLine());

                        //Console.WriteLine("Enter the second:");
                        ////str2 = Console.ReadLine();
                        ////num2 = Convert.ToInt32(str2); 
                        //num2 = Convert.ToInt32(Console.ReadLine());

                        //Console.WriteLine("{0} x {1} = {2}", num1, num2, num1 * num2);
                        res = num1 - num2;
                        break;
                    case "3":
                        res = num1 * num2;
                        break;
                    case "4":
                        res = num1 / num2;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Result = {0}", res);
                Console.WriteLine("");
                Console.WriteLine("Choose an operator");
                choose = Console.ReadLine();
            }
        }
    }
}
