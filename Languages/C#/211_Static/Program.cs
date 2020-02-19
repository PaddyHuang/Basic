using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211_Static
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassXyz.z = 100;
            Console.WriteLine(ClassXyz.z);
            ClassXyz.Test();

            Console.ReadKey();
        }
    }
}
