using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _205_OOP_Vehicle
{
    class Vehicle
    {
        public float speed;
        public float maxSpeed;
        public float weight;

        public void Run()
        {
            Console.WriteLine("Car is running on {0}km/h", speed);
        }

        public void Stop()
        {
            speed = 0;
            Console.WriteLine("Stop");
        }
    }
}
