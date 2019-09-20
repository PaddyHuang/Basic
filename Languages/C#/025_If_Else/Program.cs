using System;

namespace _If_Else
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Score?");
            string str = Console.ReadLine();
            int score = Convert.ToInt32(str);
            if (score >= 90)
                Console.WriteLine("Perfect!");
            else if (score >= 80 && score < 90)
                Console.WriteLine("Good!");
            else if (score >= 60 && score < 80)
                Console.WriteLine("Not bad.");
            else
                Console.WriteLine("Come on!");

        }
    }
}
