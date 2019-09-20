using System;

namespace _Exercise_Rabbits
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 兔子繁殖问题：设有一对新生兔子，从第三个月开始它们每个月都生一对兔子，新生的兔子从第三个月开始又每个月生一对兔子。
            // 按此规律，并假定兔子没有死亡，20个月后共有多少只兔子？
            Console.Write("Enter the month:");
            int month = Convert.ToInt32(Console.ReadLine());
            int rabbits = Rabbits(month);
            Console.WriteLine(rabbits);
		}

        public static int Rabbits(int month){
            if (month < 3)
                return 1;
            else
                return Rabbits(month - 1) + Rabbits(month - 2);
        }
    }
}
