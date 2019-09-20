using System;

namespace _Exercise_FreeFall
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 一个球从100米高度落下，每次落地后反弹回原高度的一半，再下落。
            // 问它在第十次下落时，共经过多少米？第十次反弹多高？
            Console.WriteLine("Hello World!");
            Console.Write("How high the ball is: ");
            int high = Convert.ToInt32(Console.ReadLine());
            Console.Write("Which time you wanna know: ");
            int n = Convert.ToInt32(Console.ReadLine());

            double distance = TotalDistance(n, high);
            Console.WriteLine("Total distance is {0}", distance);
            double rebound = Rebound(n, high);
            Console.WriteLine("On the {0}th time, the ball rebound {1}m", n, rebound);
        }

        static double TotalDistance(int n, int howHigh)
        {
            double distance = 0;
            if (n == 1)
                distance = howHigh;
            else
            {
                distance = howHigh;
                double temp = howHigh;
                for (int i = 1; i < n; i++, temp /= 2)
                {
                    distance += temp;    // up and down in one time
                }
            }
            return distance;
        }

        static double Rebound(int n, int howHigh)
        {
            double rebound = 0;
            double temp = howHigh;
            for (int i = 0; i < n; i++, temp /= 2)
            {
                rebound = temp;
            }
            return rebound;
        }
    }
}
