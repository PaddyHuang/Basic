using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _205_OOP_Vehicle
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle car1 = new Vehicle();
            car1.speed = 100;
            car1.Run();
            car1.Stop();
            Console.WriteLine(car1.speed);

            Console.ReadKey();
        }
    }
}
