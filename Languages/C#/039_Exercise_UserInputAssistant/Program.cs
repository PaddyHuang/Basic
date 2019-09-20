using System;

namespace _Exercise_UserInputAssistant
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 要求用户输入5个大写字母，如果用户输入的信息不符合要求，提示帮助信息并要求重新输入
            Console.WriteLine("Enter 5 upper letters:");
            string str1, str2, str3, str4, str5;
            for (int i = 1; i <= 5; i++){
                switch(i){
                    case 1:
                        Console.Write("No.1: ");
                        str1 = Console.ReadLine();
                        char char1 = Convert.ToChar(str1);
                        if (str1 == null || char1 < 'A' || char1 > 'Z')
                            Console.WriteLine("Enter error");
                        break;
                    case 2:
                        Console.Write("No.2: ");
                        str2 = Console.ReadLine();
                        char char2 = Convert.ToChar(str2);
                        if (str2 == null || char2 < 'A' || char2 > 'Z')
                            Console.WriteLine("Enter error");
                        break;
                    case 3:
                        Console.Write("No.3: ");
                        str3 = Console.ReadLine();
                        char char3 = Convert.ToChar(str3);
                        if (str3 == null || char3 < 'A' || char3 > 'Z')
                            Console.WriteLine("Enter error");
                        break;
                    case 4:
                        Console.Write("No.4: ");
                        str4 = Console.ReadLine();
                        char char4 = Convert.ToChar(str4);
                        if (str4 == null || char4 < 'A' || char4 > 'Z')
                            Console.WriteLine("Enter error");
                        break;
                    case 5:
                        Console.Write("No.5: ");
                        str5 = Console.ReadLine();
                        char char5 = Convert.ToChar(str5);
                        if (str5 == null || char5 < 'A' || char5 > 'Z')
                            Console.WriteLine("Enter error");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
