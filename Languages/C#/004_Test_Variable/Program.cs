using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_Test_Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Polin";
            int hp = 100;
            int level = 50;
            float exp = 353.5f;
            Console.WriteLine(string.Format("name: {0}, hp: {1}, lv: {2}, exp: {3}", name, hp, level, exp));

            Console.ReadKey();
        }
    }
}
