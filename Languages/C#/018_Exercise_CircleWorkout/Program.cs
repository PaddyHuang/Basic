using System;

namespace _Exercise_CircleWorkout
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 计算半径为n的圆的周长和面积
            Console.WriteLine("Workout the perimeter and the area of a circle:");
            Console.WriteLine("Enter its radius:");
            string str = Console.ReadLine();
            double radius = Convert.ToDouble(str);
            double perimeter = 2 * radius * Math.PI;
            Console.WriteLine("Perimeter: 2 x {0} x {1} = {2}", Math.PI, radius, perimeter);
            double area = (Math.PI * Math.Sqrt(radius));
            Console.WriteLine("Area: {0} x {1}^2 = {2}", Math.PI, radius, area);
        }
    }
}
