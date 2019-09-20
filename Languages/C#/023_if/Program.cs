using System;

namespace _if
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //bool var = false;
            //if (var)
            //    Console.WriteLine("-------");
            //Console.WriteLine("After if");

            string str = Console.ReadLine();
            int score = Convert.ToInt32(str);
            if (score > 50)
                Console.WriteLine("Score > 50");
            //if (score < 50)
            //Console.WriteLine("Score < 50");
            else
                Console.WriteLine("Score < 50");
		}
    }
}
