using System;

namespace _Exercise_百钱买百鸡
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 某人有100元钱，要买100只鸡。公鸡5元一只，母鸡3元一只，小鸡一元三只。
            // 问可以买到公鸡、母鸡、小鸡各几只？总共要买100只鸡。
            // 把所有可能性打印出来
            Console.WriteLine("百钱买百鸡!");
            //int x = 0, y = 0;   // Rooster x; Hen y; Chick z
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 100 / 3; y++)
                {
                    for (int z = 0; z < 99; z += 3)
                    {
                        if ((5 * x + 3 * y + z / 3) == 100 && z % 3 == 0 && x + y + z == 100)
                            Console.WriteLine("Rooster: {0}, Hen: {1}, Chick: {2}", x, y, z);
                    }
                }
            }
        }
    }
}
