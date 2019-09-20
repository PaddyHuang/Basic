using System;

namespace _Exrecise_Random
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1. diecCount\n2. dice\n3. coin\n0. Exit\n");
            Console.WriteLine("Choose a mode");
            string choose = Console.ReadLine();
            while(choose != "0"){
                switch(choose){
                    case "1":
                        diceCount();
                        break;
                    case "2":
                        dice();
                        break;
                    case "3":
                        coin();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Choose a mode");
                choose = Console.ReadLine();
            }
            Console.WriteLine("Bye");
        }

        public static void coin(){
            Random random = new Random();
            Console.WriteLine("Start!");
            string start = Console.ReadLine();
            while (start != "0")
            {
                if (random.NextDouble() > 0.5)
                    Console.WriteLine("+");
                else
                    Console.WriteLine("-");

                Console.WriteLine("Start!");
                start = Console.ReadLine();
            }
            Console.WriteLine("End");
        }

        public static void dice(){
            Random random = new Random();
            Console.WriteLine("Start!");
            string start = Console.ReadLine();
            while (start != "0"){
                Console.WriteLine(random.Next(1, 7));
                Console.WriteLine("Start!");
                start = Console.ReadLine();
            }
            Console.WriteLine("End");
        }

        public static void diceCount(){
            // 编写一个掷骰子100次的程序，并打印出各种点数的出现次数
            Random random = new Random();
            int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0, count6 = 0;
            Console.WriteLine("Start!");
            string start = Console.ReadLine();
            while (start != "0")
            {
                for (int i = 0; i < 100; i++)
                {
                    switch (random.Next(1, 7))
                    {
                        case 1:
                            count1++;
                            break;
                        case 2:
                            count2++;
                            break;
                        case 3:
                            count3++;
                            break;
                        case 4:
                            count4++;
                            break;
                        case 5:
                            count5++;
                            break;
                        case 6:
                            count6++;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("{0}: {1}", 1, count1);
                Console.WriteLine("{0}: {1}", 2, count2);
                Console.WriteLine("{0}: {1}", 3, count3);
                Console.WriteLine("{0}: {1}", 4, count4);
                Console.WriteLine("{0}: {1}", 5, count5);
                Console.WriteLine("{0}: {1}", 6, count6);
                Console.WriteLine("Start!");
                start = Console.ReadLine();
            }
            Console.WriteLine("End");
        }
    }
}
