using System;

namespace _Switch
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            byte state = 3;
            switch(state){
                case 0:
                    Console.WriteLine("Welcome Page");
                    break;
                case 1:
                    Console.WriteLine("Fighting");
                    break;
                case 2:
                    Console.WriteLine("Pause");
                    break;
                case 3:
                case 4:
                    Console.WriteLine("Win");
                    break;
                case 5:
                    Console.WriteLine("Failed");
                    break;
                default:
                    Console.WriteLine("Overflow");
                    break;

            }
        
        }
    }
}
